using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Dapper.Project.MVC.Models;
using Web.Dapper.Project.MVC.Context;
using Dapper;

namespace Web.Dapper.Project.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly DapperContext _context;

        public HomeController(DapperContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeReportViewModel();

            using (var conn = _context.CreateSqlConnection())
            {
                // 1. Son 3 İşlem
                model.Last3Transactions = await conn.QueryAsync<Transaction>(
                    "SELECT TOP 3 * FROM Transactions ORDER BY TransactionDate DESC");

                // 2. Adında veya Soyadında 'A' harfi bulunan ilk 5 Müşteri
                model.CustomersWithLetterA = await conn.QueryAsync<Customer>(
                    "SELECT TOP 5 * FROM Customers WHERE FirstName LIKE '%a%' OR LastName LIKE '%a%'");

                // 3. En Yüksek Bakiyeli 5 Hesap
                model.TopAccounts = await conn.QueryAsync<Account>(
                    "SELECT TOP 5 * FROM Accounts ORDER BY Balance DESC");

                // 4. Son Eklenen 3 Şube
                model.Last3Branches = await conn.QueryAsync<Branch>(
                    "SELECT TOP 3 * FROM Branches ORDER BY Id DESC");
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
