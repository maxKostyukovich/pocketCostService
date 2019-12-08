using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketExpensesService.Models
{
    public class Expenses
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Money { get; set; }
        public DateTime DateOfCreate { get; set; }
    }
}
