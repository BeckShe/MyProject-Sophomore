using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
  public  class Products_TypeService
    {
        public static List<Products_Type> GetTypes()
        {
            string sql = "select * from Products_Type";
            SqlDataReader sdr = dbhelper.GetDataReader(sql);
            List<Products_Type> products_Types = new List<Products_Type>();
            while (sdr.Read())
            {
                Products_Type products_Type = new Products_Type();
                products_Type.TypeId = sdr.GetInt32(0);
                products_Type.TypeName = sdr.GetString(1);
                products_Types.Add(products_Type);
            }
            sdr.Close();
            return products_Types;
        }

        public static bool UpdateTypes(Products_Type type) {
            string sql = $"update Products_Type set TypeName='{type.TypeName}' where TypeID='{type.TypeId}'";
            return dbhelper.ExecuteNonQuery(sql);
        }

        public static bool AddTypes(Products_Type type)
        {
            string sql = $"insert into Products_Type values('{type.TypeName}')";
            return dbhelper.ExecuteNonQuery(sql);
        }
    }
}
