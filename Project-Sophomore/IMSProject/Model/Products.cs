using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Products
    {
        private int id;
        private string path;
        private DateTime dateTime;
        private string week;
        private int userId;
        private int typeId;

        public int Id { get => id; set => id = value; }
        public string Path { get => path; set => path = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public string Week { get => week; set => week = value; }
        public int UserId { get => userId; set => userId = value; }
        public int TypeId { get => typeId; set => typeId = value; }
    }
}
