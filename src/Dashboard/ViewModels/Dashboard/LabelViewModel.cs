using Octokit;
using System.Collections.Generic;

namespace Dashboard.ViewModels.Dashboard
{
    public class LabelViewModel
    {
        public string Label { get; set; }
        public IEnumerable<Issue> LatestIssues { get; set; }
        public int OpenIssueCount { get; set; }
    }
}
