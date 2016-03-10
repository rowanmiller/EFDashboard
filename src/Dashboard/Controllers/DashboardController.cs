using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Octokit;
using Dashboard.ViewModels.Dashboard;
using System.Collections.Generic;

namespace Dashboard.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Label(string label)
        {
            var client = new GitHubClient(new ProductHeaderValue("EFDashboard"));

            var filter = new RepositoryIssueRequest
            {
                Labels = { label },
                Filter = IssueFilter.All
            };

            var issues = (await client.Issue.GetAllForRepository("aspnet", "EntityFramework", filter))
                .OrderByDescending(i => i.CreatedAt)
                .ToArray();

            return View(new LabelViewModel
            {
                Label = label,
                LatestIssues = issues.Take(20),
                OpenIssueCount = issues.Count()
            });
        }

        public static IEnumerable<Label> GetLabels()
        {
            var client = new GitHubClient(new ProductHeaderValue("EFDashboard"));
            return client.Issue.Labels.GetAllForRepository("aspnet", "EntityFramework").Result;
        }
    }
}
