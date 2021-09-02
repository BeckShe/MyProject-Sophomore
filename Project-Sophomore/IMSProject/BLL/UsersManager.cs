using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class UsersManager
    {
        public static List<Users> GetUsersFromDAL(Users users)
        {
            return UsersService.GetUsers(users);
        }


        public static int GetUsersIdFromDAL(Users users)
        {
            return UsersService.GetUsersId(users);
        }

        public static string GetUsersNameFromDAL(int id) {
          return  UsersService.GetUsersName(id);
        }


        public static bool AddStu(Users stu)
        {
            if (stu == null)
                return false;

            return UsersService.AddStu(stu);
        }

        public static DataTable GetDataRegisterCountFromDAL(int year)
        {
         return   UsersService.GetDataRegisterCount(year);
        }


        //public static Users GetUsersSexsFromDAL()
        //{
        //    DataTable dt = UsersService.GetSexsPercent();
        //    Users users = new Users(); 
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        string sexstr = item[0].ToString();
        //        int counts = (int)item[1];
        //        users.SexsStr = sexstr;
        //        users.SexsCounts = counts;
        //    }
        //    return users;
        //}



        public static DataTable GetUsersSexsFromDAL()
        {
           return UsersService.GetSexsPercent();
       
        }

        public static DataTable GetDataButForAdminFromDAL()
        {
            DataTable dt=UsersService.GetDataButForAdmin();         
            return dt;
        }

    }
}
