using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using assignment1.Models;

namespace assignment1.ViewModels
{
    public class IncidentViewModel : PageModel
    {
        public enum FilterOption
        {
            All,
            Open,
            Closed,
            Unassigned
        }

        public FilterOption Filter { get; set; }
    }
}
