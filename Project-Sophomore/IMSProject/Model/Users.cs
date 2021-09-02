using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Users
    {
     private  int id;
     private   string name;
     private   string pwd;
     private DateTime date;
     private string time;
     private string week;
        private int sexs;
        private string sexsStr;
        private int sexsCounts;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Time { get => time; set => time = value; }
        public string Week { get => week; set => week = value; }
        public int Sexs { get => sexs; set => sexs = value; }
        public string SexsStr { get => sexsStr; set => sexsStr = value; }
        public int SexsCounts { get => sexsCounts; set => sexsCounts = value; }
    }
}
