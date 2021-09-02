using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
  public  class Products_TypeManager
    {
        public static List<Products_Type> GetTypes() => Products_TypeService.GetTypes();

        public static bool UpdateTypeFromDAL(Products_Type type) => Products_TypeService.UpdateTypes(type);

        public static bool AddTypeFromDAL(Products_Type type) => Products_TypeService.AddTypes(type);
    }

  
}
