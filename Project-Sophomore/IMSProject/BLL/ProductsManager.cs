using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
   public   class ProductsManager
    {
        public static List<Products> GetProductsFromDAL(int userid) => ProductsService.GetProducts(userid);

        public static List<Products> GetProductsFromDAL() => ProductsService.GetProducts();

        public static string GetProductsImagePath(int id) => ProductsService.GetProductsImagePath(id);

        public static bool DeleteProductFromDAL(int id) => ProductsService.DeleteProducts(id);

        public static bool AddProductFromDAL(Products products) => ProductsService.AddProducts(products);

        public static bool UpdatesProductsFromDAL(Products products) => ProductsService.UpdatesProducts(products);
    }

}
