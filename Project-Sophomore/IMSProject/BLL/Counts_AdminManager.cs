using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;

namespace BLL
{
  public  class Counts_AdminManager
    {
        public static DataSet GetDataInfoYearFromDAL(int year)
        {
          return  Counts_AdminService.GetDataInfoDate(year);
        }
    }
}
