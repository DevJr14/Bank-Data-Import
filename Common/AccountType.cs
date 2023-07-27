using System.ComponentModel;

namespace Common
{
    public enum AccountType
    {
        [Description(@"Current/Cheque")]
        CurrentOrCheque = 1,
        [Description(@"Savings")]
        Savings = 2,
    }
}
