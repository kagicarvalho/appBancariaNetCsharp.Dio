using System;
using System.Collections.Generic;
using Dio.Bank.Enums;
using Dio.Bank.Models;

namespace Dio.Bank
{
    class Program
    {
        static List<Account> accountsList = new List<Account>();

        private static string Menu()
        {
            Console.WriteLine("Dio - Criando app simples de transferência bancárias");            
            Console.WriteLine("Informe a opção desejada");
            
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            
            Console.WriteLine();

            string userChoice = Console.ReadLine().ToLower();
            Console.WriteLine();
            return userChoice;
        }

        static void Main(string[] args)
        {
            string userChoice = Menu();

            while(userChoice != "x")
            {
                switch(userChoice)
                {
                    case "1":
                        Console.Clear();
                        AccountsList();
                        break;
                    case "2":
                        Console.Clear();
                        InsertAccount();
                        break;
                    case "3":
                        Console.Clear();
                        TransferMoney();
                        break;
                    case "4":
                        Console.Clear();
                        WithdrawMoney();
                        break;
                    case "5":
                        Console.Clear();
                        Deposit();
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        Console.WriteLine("Escolha uma opção do menu");
                        break;
                }
                userChoice = Menu();
            }

        }
        
        private static void AccountsList()
        {
            Console.Clear();
            Console.WriteLine("Opção 1 - Lista de contas");

            Console.WriteLine();
            
            var checklist = CheckList();

            if(!checklist)
            {
				Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }


			for (int count = 0; count < accountsList.Count; count++)
			{
				var account = accountsList[count];
				Console.Write($"# - {count} --");
				Console.WriteLine(account);
			}
        }

        private static void InsertAccount()
        {
            Console.Clear();
            Console.WriteLine("Opção 2 - Nova conta");

            Console.WriteLine();

			Console.WriteLine("Digite o Nome do Cliente: ");
			string nameEntry = Console.ReadLine();
            
			Console.WriteLine("Digite o saldo inicial: ");
			decimal balanceEntry = decimal.Parse(Console.ReadLine());

			Console.WriteLine("Digite o crédito: ");
			decimal creditEntry = decimal.Parse(Console.ReadLine());

			Console.WriteLine("Tipo da conta: ");            
			Console.WriteLine("Digite: 1 para Conta Fisica");
			Console.WriteLine("Digite: 2 para Conta Juridica");
			int accountType = int.Parse(Console.ReadLine());

			var newAccount = new Account(name: nameEntry, credit: creditEntry, balance: balanceEntry, type: (AccountType)accountType);

			accountsList.Add(newAccount);
        }

        private static void TransferMoney()
        {
            Console.Clear();
            Console.WriteLine("Opção 3 - Transferir ");

            Console.WriteLine();

            var checklist = CheckList();

            if(!checklist)
            {
				Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            
            Console.WriteLine("Informe o número da conta de origem: ");
			int indexMyAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o número da conta de destino: ");
			int indexTargetAccount = int.Parse(Console.ReadLine());

			Console.WriteLine("Valor da transferência: ");
			decimal transferAmount = decimal.Parse(Console.ReadLine());

            accountsList[indexMyAccount].Transfer(transferAmount, accountsList[indexTargetAccount]);
        }

        private static void WithdrawMoney()
        {
            Console.Clear();
            Console.WriteLine("Opção 4 - Sacar ");

            Console.WriteLine();

            var checklist = CheckList();

            if(!checklist)
            {
				Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

                        
			Console.WriteLine("Informe o número da conta: ");
			int indexAccount = int.Parse(Console.ReadLine());

			Console.WriteLine("Informe o valor a ser sacado: ");
			decimal withdrawalValue = decimal.Parse(Console.ReadLine());

            accountsList[indexAccount].WithdrawMoney(withdrawalValue);
        }

        private static void Deposit()
        {            
            Console.Clear();
            Console.WriteLine("Opção 5 - Deposito ");

            Console.WriteLine();

            var checklist = CheckList();

            if(!checklist)
            {
				Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

			Console.WriteLine("Informe o número da conta: ");
			int indexAccount = int.Parse(Console.ReadLine());

			Console.WriteLine("Valor: R$ ");
			decimal depositAmount = decimal.Parse(Console.ReadLine());

            accountsList[indexAccount].Deposit(depositAmount);
        }        
        private static bool CheckList()
        {
            if(accountsList.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}
