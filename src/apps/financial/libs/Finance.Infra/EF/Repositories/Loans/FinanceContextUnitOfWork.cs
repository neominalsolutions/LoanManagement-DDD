using Finance.Infra.EF.Contexts;
using Infra.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.EF.Repositories.Loans
{
    public class FinanceContextUnitOfWork : IUnitOfWork
    {

        FinanceContext financeContext;

        public FinanceContextUnitOfWork(FinanceContext financeContext)
        {
            this.financeContext = financeContext;
        }


        public void Save()
        {
            try
            {
              int r =  financeContext.SaveChanges();
                // auto commit olur
            }
            catch (Exception ex)
            {
                // auto rollbak
                throw;
            }
        }
    }

}
