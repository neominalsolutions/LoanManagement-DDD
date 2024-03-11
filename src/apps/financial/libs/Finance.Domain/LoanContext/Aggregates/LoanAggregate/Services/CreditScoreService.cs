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
    private readonly ILoanCustomerRepository loanCustomerRepository;

    public CreditScoreService(ILoanRepository loanRepository, ILoanCustomerRepository loanCustomerRepository)
    {
      this.loanRepository = loanRepository;
      this.loanCustomerRepository = loanCustomerRepository;
    }

    public bool IsApproved(LoanApplication loanApplication)
    {
     
      var loanCustomer = loanCustomerRepository.FindById(loanApplication.LoanCustomerId);

      decimal debtToIncomeRatio = loanApplication.LoanAmount.Value / loanCustomer.AnnualIncome.Value;

      var customerLoans = loanRepository.Find(x => x.LoanCustomerId == loanApplication.LoanCustomerId && x.Closed == false).ToList();

      Money totalDebt = Money.Zero(loanApplication.LoanAmount.Currency);

      customerLoans.ForEach(loan =>
      {
        totalDebt.Value += loan.RemainingAmount.Value;
      });

      decimal debtWeight = 0.30m; // borç ağırlığı
      decimal incomeWeight = 0.40m; // yıllık gelir ağırlığı
      decimal loanApplicationsWeight = 0.30m; // Daha önceden kredi kullanım ağırlığı


      var maxPayableAmount = loanApplication.AnnualIncome.Value * incomeWeight - totalDebt.Value * debtWeight - customerLoans.Count() * loanApplicationsWeight;

      return loanApplication.LoanAmount.Value < maxPayableAmount;

    }

  }
}
