using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class UsersService
    {
        public static List<Users> GetUsers(Users user)
        {
            string sql = $"select * from Users where Name='{user.Name}' and Pwd='{user.Pwd}'";
            SqlDataReader sdr = dbhelper.GetDataReader(sql);
            List<Users> users = new List<Users>();
            while (sdr.Read())
            {
                Users us = new Users();
                us.Id = sdr.GetInt32(0);
                us.Name = sdr.GetString(1);
                us.Pwd = sdr.GetString(2);
                users.Add(us);
            }
            sdr.Close();
            return users;
        }



        public static int GetUsersId(Users user)
        {
            string sql = $"select ID from Users where Name='{user.Name}' and Pwd='{user.Pwd}'";
            SqlDataReader sdr = dbhelper.GetDataReader(sql);
                Users us = new Users();
            sdr.Read();
            us.Id = sdr.GetInt32(0);
            sdr.Close();
            return us.Id;
        }


        public static string GetUsersName(int productsId) {
            string sql = "select Name from Users where ID=(select UserID from Products where ID='" + productsId + "')";
            SqlDataReader sdr = dbhelper.GetDataReader(sql);
            sdr.Read();
            Users users = new Users();
           string name= users.Name = sdr.GetString(0);
            sdr.Close();
            return name;
        }


        public static bool AddStu(Users stu)
        {
            string sql = $"insert into Users values('{stu.Name}','{stu.Pwd}','{stu.Date}','{stu.Time}','{stu.Week}','{stu.Sexs}')";
            return dbhelper.ExecuteNonQuery(sql);

        }

        public static DataTable  GetDataRegisterCount(int year)
        {
            string sql = $"select Date Dates,COUNT(*) as PersonCounts from Users where  DATEPART(YYYY,Date)='{year}'  group by Date";
            return dbhelper.GetDataTable(sql);
        }



       public static DataTable GetSexsPercent()
        {
            //string sql = "select s.Name, COUNT(s.Name) as sexcount from Users u,User_Sex s where u.Sexs=s.Id group by s.Name";
            //string sql = "select count(*) as Countss,Sexs as Sexss from Users group by Sexs ";
            string sql = "select s.SexName as Sexss ,count(u.Date) as Countss from Users u,User_Sex s where u.Sexs=s.Id group by Sexs,SexName";
          return  dbhelper.GetDataTable(sql);
        }

        public static DataTable GetDataButForAdmin()
        {
            string sql = "select u.ID,Name,Date,Time,Week,s.SexName SexsStr from Users u, User_Sex s where 1=1  and u.Sexs=s.Id  and not Name='admin'";
          return   dbhelper.GetDataTable(sql);
        }


      
    }
}
