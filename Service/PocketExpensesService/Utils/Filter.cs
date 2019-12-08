using PocketExpensesService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketExpensesService.Utils
{
   public class Filter
    {
        public static List<Expenses> FilterByField(List<Expenses> AllRows, string fieldName, string value)
        {
            switch (fieldName)
            {
                case Constants.Title:
                    {
                        var res = from item in AllRows
                                  where item.Title.Contains(value)
                                  select item;
                        return res.ToList();
                    }
                case Constants.Money:
                    {
                        try
                        {
                            char isCondition = value[0];
                            if (isCondition == '<')
                            {
                                double moneyValue = Convert.ToDouble(value.Replace("<", ""));
                                var res = from item in AllRows
                                          where item.Money < moneyValue
                                          select item;
                                return res.ToList();
                            }
                            else if (isCondition == '>')
                            {
                                double moneyValue = Convert.ToDouble(value.Replace(">", ""));
                                var res = from item in AllRows
                                          where item.Money > moneyValue
                                          select item;
                                return res.ToList();
                            }
                            else
                            {
                                double moneyValue = Convert.ToDouble(value);
                                var res = from item in AllRows
                                          where item.Money == moneyValue
                                          select item;
                                return res.ToList();
                            }
                        }
                        catch (Exception e)
                        {
                            return AllRows;
                        }
                    }
                case Constants.DateOfCreate:
                    {
                        try
                        {
                            char isCondition = value[0];
                            if (isCondition == '<')
                            {
                                DateTime dateValue = Convert.ToDateTime(value.Replace("<", ""));
                                var res = from item in AllRows
                                          where item.DateOfCreate.Date < dateValue.Date
                                          select item;
                                return res.ToList();
                            }
                            else if (isCondition == '>')
                            {
                                DateTime dateValue = Convert.ToDateTime(value.Replace(">", ""));
                                var res = from item in AllRows
                                          where item.DateOfCreate.Date > dateValue.Date
                                          select item;
                                return res.ToList();
                            }
                            else
                            {
                                DateTime dateValue = Convert.ToDateTime(value);
                                var res = from item in AllRows
                                          where item.DateOfCreate.Date == dateValue.Date
                                          select item;
                                return res.ToList();
                            }

                        }
                        catch (Exception e)
                        {
                            return AllRows;
                        }
                        break;
                    }
                default:
                    {
                        return new List<Expenses>();
                    }
            }
        }
    }
}
