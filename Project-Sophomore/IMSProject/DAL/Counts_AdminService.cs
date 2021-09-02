using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
  public  class Counts_AdminService
    {
        public static DataSet GetDataInfoDate(int year)
        {
            string sql = $"select Date DateTimes ,SUM(Counts) as VisitedCounts from Counts_Admin where DATEPART(YYYY,Date)='{year}'  group by Date ";
           return dbhelper.SelectData(sql);
        }
    }
}
