using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Counts_Admin
    {
        private int id;
        private DateTime date;
        private string time;
        private string week;
        private int counts;

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Time { get => time; set => time = value; }
        public string Week { get => week; set => week = value; }
        public int Counts { get => counts; set => counts = value; }
    }
}
