using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web;
using System.Collections.Specialized;
using PocketExpensesService.Utils;
using PocketExpensesService.Models;
using PocketExpensesService.Context;

namespace PocketExpensesService.Controllers
{
    public class ExpensesController : ApiController
    {
        private ExpensesContext db = new ExpensesContext();

        // GET: api/Expenses
        public IQueryable<Expenses> GetExpenses()
        {
            var allRows = db.Expenses.ToList();
            List<Expenses> filteredResult = allRows.ToList();
            NameValueCollection queryString = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            foreach (String s in queryString.AllKeys)
            {
                if (Constants.QueryKeys.Contains(s))
                {
                    filteredResult = Filter.FilterByField(filteredResult, s, queryString[s]);
                }
            }
            return filteredResult.AsQueryable();
        }

        // GET: api/Expenses/{id}
        [ResponseType(typeof(Expenses))]
        public IHttpActionResult GetExpenses(int id)
        {

            Expenses expenses = db.Expenses.Find(id);
            if (expenses == null)
            {
                return NotFound();
            }

            return Ok(expenses);
        }

        // PUT: api/Expenses/{id}
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExpenses(int id, Expenses expenses)
        {
            Expenses expense = db.Expenses.Find(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expenses.Id)
            {
                return BadRequest();
            }

            db.Entry(expenses).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpensesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest();
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Expenses
        [ResponseType(typeof(Expenses))]
        public IHttpActionResult PostExpenses(Expenses expenses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Expenses.Add(expenses);
            db.SaveChanges();

            return CreatedAtRoute("API", new { id = expenses.Id }, expenses);
        }

        // DELETE: api/Expenses/5
        [ResponseType(typeof(Expenses))]
        public IHttpActionResult DeleteExpenses(int id)
        {
            Expenses expenses = db.Expenses.Find(id);
            if (expenses == null)
            {
                return NotFound();
            }

            db.Expenses.Remove(expenses);
            db.SaveChanges();

            return Ok(expenses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExpensesExists(int id)
        {
            return db.Expenses.Count(e => e.Id == id) > 0;
        }
    }
}
