using System;
using Dio.Bank.Enums;

namespace Dio.Bank.Models
{
    public class Account
    {
        public Account(string name, decimal credit, decimal balance, AccountType type)
        {
            Name = name;
            Credit = credit;
            Balance = balance;
            Type = type;
        }

        private string Name { get; set; }
        private decimal Credit { get; set; }
        private decimal Balance { get; set; }
        private AccountType Type { get; set; }

        public bool WithdrawMoney(decimal amount)
        {
            if(this.Balance - amount <(this.Credit * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Balance -= amount;
            Console.WriteLine($"Saldo atual da conta de {this.Name} é de R$ {this.Balance}");
            return true;
        }

        public void Deposit(decimal depositedAmount)
        {
            this.Balance += depositedAmount;
            Console.WriteLine($"Saldo atual da conta de {this.Name} é de {this.Balance}");
        }

        public void Transfer(decimal transferAmount, Account targetAccount)
        {
            if(this.WithdrawMoney(transferAmount))
            {
                targetAccount.Deposit(transferAmount);
            }
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += $"Nome : {this.Name} \r\n";
            retorno += $"Saldo: {this.Balance} \r\n";
            retorno += $"Crédito: {this.Credit} \r\n";
            retorno += $"Tipo da Conta: {this.Type} \r\n";

            return retorno;
        }
    }
}