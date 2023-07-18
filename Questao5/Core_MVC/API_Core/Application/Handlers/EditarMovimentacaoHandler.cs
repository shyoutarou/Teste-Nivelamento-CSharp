using ApiMediatR.Handlers.Request;
using MediatR;
using Questao5_Data.Domain.Entities;
using Questao5_Data.Infrastructure.Database.CommandStore.Requests;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApiMediatR.Handlers
{
    public class EditarMovimentacaoHandler : IRequestHandler<EditarMovimentacaoRequest, Guid>
    {
        private readonly IMovimentacaoCommand _movimentacaoCommand;
        private readonly IIdempotenciaQuery _idempotenciaQuery;
        private readonly IIdempotenciaCommand _idempotenciaCommand;

        public EditarMovimentacaoHandler(IMovimentacaoCommand movimentacaoCommand,
            IIdempotenciaQuery idempotenciaQuery,
            IIdempotenciaCommand idempotenciaCommand)
        {
            _movimentacaoCommand = movimentacaoCommand;
            _idempotenciaQuery = idempotenciaQuery;
            _idempotenciaCommand = idempotenciaCommand;
        }

        public async Task<Guid> Handle(EditarMovimentacaoRequest request, CancellationToken cancellationToken = default)
        {

            // Verificar se a chave de idempotência já existe na tabela
            var idempotencia = await _idempotenciaQuery.GetIdempotenciaByKeyAsync(request.movimentacao.IdMovimento);

            if (idempotencia != null)
            {
                // A resposta já foi registrada, retornar o ID do movimento previamente gerado
                return new Guid(idempotencia.ChaveIdempotencia);
            }


            //// Realizar as validações de negócio
            //var validationResult = ValidateMovimentacaoRequest(request);
            //if (!validationResult.IsValid)
            //{
            //    // As validações falharam, retornar uma resposta de erro
            //    var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            //    throw new ApplicationException("Erro de validação: " + string.Join(", ", errors));
            //}


            bool success = false;
            int retryCount = 0;
            const int maxRetries = 3;
            var Idretorno = new Guid();

            while (!success && retryCount < maxRetries)
            {
                try
                {
                    //var novamovimento = new Movimentacao();
                    //request.movimentacao

                    Idretorno = await _movimentacaoCommand.AddMovimentacaoAsync(request.movimentacao);

                    // Registrar a resposta na tabela "idempotencia" em caso de sucesso
                    var novaIdempotencia = new Idempotencia
                    {
                        ChaveIdempotencia = request.movimentacao.IdMovimento,
                        Requisicao = JsonConvert.SerializeObject(request), // Converter a requisição para formato JSON
                        Resultado = "Sucesso"
                    };

                    await _idempotenciaCommand.AddIdempotenciaAsync(novaIdempotencia);

                    success = true;
                }
                catch (Exception ex)
                {
                    // Tratamento de erros ou falhas

                    // Incrementa o contador de tentativas
                    retryCount++;

                    // Aguarda um tempo antes de tentar novamente
                    await Task.Delay(TimeSpan.FromSeconds(1));


                }
            }

            return Idretorno;
        }


        //private ValidationResult ValidateMovimentacaoRequest(EditarMovimentacaoRequest request)
        //{
        //    var validationResult = new ValidationResult(new List<ValidationFailure>());

        //    // Realizar as validações de negócio
        //    if (!ContaCorrenteCadastrada(request.IdContaCorrente))
        //    {
        //        validationResult.Errors.Add(new ValidationFailure("IdContaCorrente", "Conta corrente não encontrada.", "INVALID_ACCOUNT"));
        //    }

        //    if (!ContaCorrenteAtiva(request.IdContaCorrente))
        //    {
        //        validationResult.Errors.Add(new ValidationFailure("IdContaCorrente", "Conta corrente inativa.", "INACTIVE_ACCOUNT"));
        //    }

        //    if (request.Valor <= 0)
        //    {
        //        validationResult.Errors.Add(new ValidationFailure("Valor", "Valor inválido. Deve ser maior que zero.", "INVALID_VALUE"));
        //    }

        //    if (request.TipoMovimento != "C" && request.TipoMovimento != "D")
        //    {
        //        validationResult.Errors.Add(new ValidationFailure("TipoMovimento", "Tipo de movimento inválido. Deve ser 'C' ou 'D'.", "INVALID_TYPE"));
        //    }

        //    return validationResult;
        //}

        //private bool ContaCorrenteCadastrada(string idContaCorrente)
        //{
        //    // Verificar se a conta corrente está cadastrada no banco de dados
        //    // Implementar a lógica de verificação e retornar true ou false
        //}

        //private bool ContaCorrenteAtiva(string idContaCorrente)
        //{
        //    // Verificar se a conta corrente está ativa no banco de dados
        //    // Implementar a lógica de verificação e retornar true ou false
        //}
    }
}
