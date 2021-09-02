using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Products_Type
    {
        private int typeId;
        private string typeName;

        public int TypeId { get => typeId; set => typeId = value; }
        public string TypeName { get => typeName; set => typeName = value; }
    }
}
