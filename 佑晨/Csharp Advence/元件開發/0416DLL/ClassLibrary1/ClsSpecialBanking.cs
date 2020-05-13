using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class ClsSpecialBanking: ClsBanking
    {

        public override decimal Deposit(decimal money)
        {
            return this.m_Balance += money -100;
        }

        public override string ToString()
        {
            return "Special Banking: "  +this.Balance.ToString();
        }

    }
}
