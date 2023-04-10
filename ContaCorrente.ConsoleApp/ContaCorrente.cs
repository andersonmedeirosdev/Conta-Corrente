using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    internal class ContaCorrente
    {
        private double saldo;
        private int numero;
        private int limite;
        private bool EhEspecial;
        private Movimentacao[] movimentacoes;
        private int numMovimentacoes;
        public ContaCorrente(double sld, int num, int lmt, bool especial)
        {
            saldo = sld;
            numero = num;
            limite = lmt;
            EhEspecial = especial;
            movimentacoes = new Movimentacao[10];
            numMovimentacoes = 0;
        }

        public void Depositar(double valor)
        {
            saldo += valor;
            movimentacoes[numMovimentacoes] = new Movimentacao(valor, false);
            numMovimentacoes++;
        }

        public bool Sacar(double valor)
        {
            if (saldo - valor >= limite)
            {
                saldo -= valor;
                movimentacoes[numMovimentacoes] = new Movimentacao(valor, true);
                numMovimentacoes++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (saldo - valor >= limite)
            {
                saldo -= valor;
                movimentacoes[numMovimentacoes] = new Movimentacao(valor, true);
                numMovimentacoes++;
                contaDestino.Depositar(valor);
                return true;
            }
            else
            {
                return false;
            }
        }

        public double GetSaldo()
        {
            return saldo;
        }

        public Movimentacao[] GetMovimentacoes() { 
            return movimentacoes.Take(numMovimentacoes).ToArray();
        }

        internal class Movimentacao
        {
            public double Valor;
            public bool EhDebito;

            public  Movimentacao(double valor, bool ehDebito)
            {
                Valor = valor;
                EhDebito = ehDebito;
            }
        }
    }
}
