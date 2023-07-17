using ApiMediatR.Handlers.Request;
using MediatR;
using Questao5_Data.Domain.Entities;
using Questao5_Data.Infrastructure.Database.CommandStore.Requests;

namespace ApiMediatR.Handlers
{
    public class EditarMovimentacaoHandler : IRequestHandler<EditarMovimentacaoRequest, Guid>
    {
        private readonly IMovimentacaoCommand _movimentacaoCommand;

        public EditarMovimentacaoHandler(IMovimentacaoCommand movimentacaoCommand)
        {
            _movimentacaoCommand = movimentacaoCommand;
        }

        public async Task<Guid> Handle(EditarMovimentacaoRequest request, CancellationToken cancellationToken = default)
        {
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
                    success = true;

                    return Idretorno;
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

            if (!success)
            {
                // Lidar com o caso de falha após várias tentativas
                // ...

                return new Guid();
            }
        }
    }
}
