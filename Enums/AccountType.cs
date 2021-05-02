using System.ComponentModel;

namespace Dio.Bank.Enums
{
    public enum AccountType
    {
        [Description("Pessoa Física")]
        RegularAccount = 1,

        [Description("Pessoa Jurídica")]
        CorporationAccount = 2
    }
}