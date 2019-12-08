
using PocketExpensesService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketExpensesService.Context
{
    public class ExpensesContext : DbContext
    {
        public ExpensesContext() : base()
        {

        }
        public DbSet<Expenses> Expenses { get; set; }
    }
}
