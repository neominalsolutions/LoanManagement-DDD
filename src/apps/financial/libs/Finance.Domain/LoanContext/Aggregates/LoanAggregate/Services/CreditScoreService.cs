using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Entities;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Repositories;
using Finance.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.LoanContext.Aggregates.LoanAggregate.Services
{
    /// <summary>
    /// Müşterinin Kredis Score hesaplayan Domain Service
    /// </summary>
    public class CreditScoreService
    {
        private readonly ILoanRepository loanRepository;

        public CreditScoreService(ILoanRepository loanRepository)
        {
            this.loanRepository = loanRepository;
        }

        public bool IsApproved(LoanApplication loanApplication)
        {
            // burada kredi not hesaplama yapılacak eğer 700 altında kalırsa kredi onay verilmeyecek

            decimal debtToIncomeRatio = loanApplication.LoanAmount.Value / loanApplication.AnnualIncome.Value;

            var customerLoans = loanRepository.Find(x => x.LoanCustomerId == loanApplication.LoadCustomerId && x.Closed == false).ToList();

            Money totalDebt = Money.Zero(loanApplication.LoanAmount.Currency);

            customerLoans.ForEach(loan =>
            {
                totalDebt.Value += loan.RemainingAmount.Value;
            });

            decimal debtWeight = 0.30m; // borç ağırlığı
            decimal incomeWeight = 0.40m; // yıllık gelir ağırlığı
            decimal loanApplicationsWeight = 0.30m; // Daha önceden kredi kullanım ağırlığı


            var maxPayableAmount = loanApplication.AnnualIncome.Value * incomeWeight - totalDebt.Value * debtWeight - customerLoans.Count() * loanApplicationsWeight;

            return loanApplication.LoanAmount.Value > maxPayableAmount;

        }

    }
}
