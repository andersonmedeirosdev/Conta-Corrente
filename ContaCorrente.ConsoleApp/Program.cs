using System.Runtime.CompilerServices;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta1 = new ContaCorrente(1000, 12, 0, true);
            ContaCorrente conta2 = new ContaCorrente(500, 15, 0, false);
            conta1.Depositar(200);

            bool saqueRealizado = conta1.Sacar(100);

            if(saqueRealizado)
            {
                Console.WriteLine("Saque realizado com sucesso!!");
            }
            else
            {
                Console.WriteLine("Você não tem saldo suficiente!!");
            }

            bool transferenciaRealizada = conta1.Transferir(230, conta2);

            if(transferenciaRealizada)
            {
                Console.WriteLine("Transferência realizada com sucesso!!");
            }
            else
            {
                Console.WriteLine("Você não tem saldo suficiente!!");
            }

            Console.WriteLine($"Saldo Conta 1: {conta1.GetSaldo():C}");
            Console.WriteLine($"Saldo Conta 2: {conta2.GetSaldo():C}");


            ContaCorrente.Movimentacao[] movimentacoes1 = conta1.GetMovimentacoes();
            ContaCorrente.Movimentacao[] movimentacoes2 = conta2.GetMovimentacoes();

            Console.WriteLine("Movimentações Conta 1:");
            foreach (var movimentacao in movimentacoes1)
            {
                string tipo = movimentacao.EhDebito ? "Débito" : "Crédito";
                Console.WriteLine($"{tipo}: {movimentacao.Valor:C}");
            }

            Console.WriteLine("Movimentações Conta 2:");
            foreach (var movimentacao in movimentacoes2)
            {
                string tipo = movimentacao.EhDebito ? "Débito" : "Crédito";
                Console.WriteLine($"{tipo}: {movimentacao.Valor:C}");
            }
            Console.ReadLine();
        }
    }
}