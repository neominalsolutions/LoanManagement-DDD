using Finance.Domain.AccountContext.Aggregates.AccountAggregate.Enumarations;
using Finance.Domain.AccountContext.Aggregates.OwnerAggregate.Entities;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Entities;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Enumerations;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Repositories;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Services;
using Finance.Domain.Shared.ValueObjects;
using Finance.Infra.EF.Contexts;
using Infra.Core.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FinancesController : ControllerBase
  {
 
    private readonly CreditScoreService creditScoreService;
    private readonly IUnitOfWork unitOfWork;
    private readonly ILoanApplicationRepository loanApplicationRepository;
    private readonly ILoanCustomerRepository loanCustomerRepository;
    private readonly ILoanRepository loanRepository;

    public FinancesController(IUnitOfWork unitOfWork, CreditScoreService creditScoreService, ILoanApplicationRepository loanApplicationRepository, ILoanCustomerRepository loanCustomerRepository, ILoanRepository loanRepository)
    {

      this.creditScoreService = creditScoreService;
      this.unitOfWork = unitOfWork;
      this.loanApplicationRepository = loanApplicationRepository;
      this.loanCustomerRepository = loanCustomerRepository;
      this.loanRepository = loanRepository;
    }

    [HttpPost]
    public IActionResult LoanRequest()
    {

      // loanApplication Request

      var loanCustomer = loanCustomerRepository.FindById("E1811140-EA61-4712-9DD7-630C0B16BE28");

      var loanApplication = new LoanApplication(customerId: loanCustomer.Id, loanAmount:new Money(100000,"TL"),annualIncome: loanCustomer.AnnualIncome,loanType:LoanApplicationType.PersonalLoan,term:12 );
      // Kredi için Onay var mı ?
      loanApplication.CheckApproval(creditScoreService);
      loanApplicationRepository.Create(loanApplication);
      this.unitOfWork.Save();

    
      // Approved Yapılan Loan Banka tarafından onay işlemi
      var loan = this.loanRepository.FindById(loanApplication.Id);
      loan.UseLoan();
      this.unitOfWork.Save();


      return Ok();

    }
  }
}
