using Questao1_Library;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Questao1
{

    public class Program
    {
        static List<ContaBancaria_BS> _Contas = new List<ContaBancaria_BS>();

        static async Task Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("========== Menu ==========");
                    Console.WriteLine("1. Cadastrar Conta");
                    Console.WriteLine("2. Realizar Depósito");
                    Console.WriteLine("3. Realizar Saque");
                    Console.WriteLine("4. Exibir Dados da Conta");
                    Console.WriteLine("5. Sair");
                    Console.WriteLine("==========================");

                    Console.Write("Digite a opção desejada: ");
                    int opcao = int.Parse(Console.ReadLine());

                    Console.WriteLine();

                    switch (opcao)
                    {
                        case 1:
                            CadastrarConta();
                            break;
                        case 2:
                            await RealizarDeposito();
                            break;
                        case 3:
                            await RealizarSaque();
                            break;
                        case 4:
                            ExibirDadosConta();
                            break;
                        case 5:
                            Console.WriteLine("Saindo do programa...");
                            return;
                        default:
                            Console.WriteLine("Opção inválida! Tente novamente.");
                            break;
                    }

                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        static void CadastrarConta()
        {
            try
            {
                Console.Write("Entre o número da conta: ");
                int numero = int.Parse(Console.ReadLine());

                Console.Write("Entre o titular da conta: ");
                string titular = Console.ReadLine();

                Console.Write("Haverá depósito inicial (s/n)? ");
                char resp = char.Parse(Console.ReadLine());

                double depositoInicial = 0;

                if (resp == 's' || resp == 'S')
                {
                    Console.Write("Entre o valor de depósito inicial: ");
                    depositoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                }

                ContaBancaria_BS novaConta = new ContaBancaria_BS(numero, titular, depositoInicial);
                _Contas.Add(novaConta);

                Console.WriteLine("Conta cadastrada com sucesso!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Valor inválido digitado. Certifique-se de inserir um número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao cadastrar a conta: {ex.Message}");
            }
        }

        static async Task RealizarDeposito()
        {
            try
            {
                Console.Write("Digite o número da conta: ");
                int numero = int.Parse(Console.ReadLine());

                ContaBancaria_BS conta = BuscarConta(numero);

                if (conta == null)
                {
                    Console.WriteLine("Conta não encontrada!");
                    return;
                }

                Console.Write("Digite o valor do depósito: ");
                double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                await conta.DepositoAsync(valor);

                Console.WriteLine("Depósito realizado com sucesso!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Valor inválido digitado. Certifique-se de inserir um número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao realizar o depósito: {ex.Message}");
            }
        }

        static async Task RealizarSaque()
        {
            try
            {
                Console.Write("Digite o número da conta: ");
                int numero = int.Parse(Console.ReadLine());

                ContaBancaria_BS conta = BuscarConta(numero);

                if (conta == null)
                {
                    Console.WriteLine("Conta não encontrada!");
                    return;
                }

                Console.Write("Digite o valor do saque: ");
                double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                await conta.SaqueAsync(valor);

                Console.WriteLine("Saque realizado com sucesso!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Valor inválido digitado. Certifique-se de inserir um número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao realizar o saque: {ex.Message}");
            }
        }

        static void ExibirDadosConta()
        {
            try
            {
                Console.Write("Digite o número da conta: ");
                int numero = int.Parse(Console.ReadLine());

                ContaBancaria_BS conta = BuscarConta(numero);

                if (conta == null)
                {
                    Console.WriteLine("Conta não encontrada!");
                    return;
                }

                Console.WriteLine("Dados da conta:");
                Console.WriteLine(conta);
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Valor inválido digitado. Certifique-se de inserir um número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao exibir os dados da conta: {ex.Message}");
            }
        }

        static ContaBancaria_BS BuscarConta(int numero)
        {
            foreach (ContaBancaria_BS conta in _Contas)
            {
                if (conta.GetNumero() == numero)
                {
                    return conta;
                }
            }

            return null;
        }
    }
}
