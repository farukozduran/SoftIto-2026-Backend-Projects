using System.Collections.Generic;

namespace Web.Dapper.Project.MVC.Models
{
    public class HomeReportViewModel
    {
        public IEnumerable<Transaction> Last3Transactions { get; set; } = new List<Transaction>();
        public IEnumerable<Customer> CustomersWithLetterA { get; set; } = new List<Customer>();
        public IEnumerable<Account> TopAccounts { get; set; } = new List<Account>();
        public IEnumerable<Branch> Last3Branches { get; set; } = new List<Branch>();
    }
}
