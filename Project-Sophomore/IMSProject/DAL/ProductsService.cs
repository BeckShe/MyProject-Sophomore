using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
   public class ProductsService
    {
        public static List<Products> GetProducts(int userid) {
            string sql = $"select * from Products where UserID='{userid}'";
            SqlDataReader sdr = dbhelper.GetDataReader(sql);
            List<Products> products = new List<Products>();
            while (sdr.Read())
            {
                Products product = new Products();
                product.Id = sdr.GetInt32(0);
                product.Path = sdr.GetString(1);
                product.DateTime = sdr.GetDateTime(2);
                product.Week = sdr.GetString(3);
                product.UserId = sdr.GetInt32(4);
                products.Add(product);
            }
            sdr.Close();
            return products;
        }


        public static List<Products> GetProducts()
        {
            string sql = "select * from Products";
            SqlDataReader sdr = dbhelper.GetDataReader(sql);
            List<Products> products = new List<Products>();
            while (sdr.Read())
            {
                Products product = new Products();
                product.Id = sdr.GetInt32(0);
                product.Path = sdr.GetString(1);
                product.DateTime = sdr.GetDateTime(2);
                product.Week = sdr.GetString(3);
                product.UserId = sdr.GetInt32(4);
                products.Add(product);
            }
            sdr.Close();
            return products;
        }


        public static string GetProductsImagePath(int id)
        {
            string sql = $"select IPath from Products where ID='{id}'";
            SqlDataReader sdr = dbhelper.GetDataReader(sql);
            Products product = new Products();
            sdr.Read();
          product.Path = sdr.GetString(0);
            sdr.Close();
            return product.Path;
        }




        public static bool DeleteProducts(int id)
        {
            string sql = $"delete from Products where ID={id} ";
           return dbhelper.ExecuteNonQuery(sql);
        }


       public static bool AddProducts(Products products)
        {
            string sql =$"insert into Products values('{products.Path}','{products.DateTime}','{products.Week}','{products.UserId}','{products.TypeId}')";
            return dbhelper.ExecuteNonQuery(sql);
        }

        public static bool UpdatesProducts(Products products)
        {
            string sql = $"update Products set IPath='{products.Path}' , IDate='{products.DateTime}',IWeek='{products.Week}' where ID='{products.Id}'";
          return  dbhelper.ExecuteNonQuery(sql);
        }
    }
}
