using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class dbhelper
    {
       
            //数据库连接字符串
            public static string ConnString = "Data Source=.;Initial Catalog=IMS;Integrated Security=True;";
            //数据库连接对象
            private static SqlConnection Conn = null;
            //初始化数据库连接
            private static void InitConnection()
            {
                //如果连接对象不存在，则创建连接
                if (Conn == null)
                    Conn = new SqlConnection(ConnString);
                //如果连接对象关闭，则打开连接
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                //如果连接中断，则重启连接
                if (Conn.State == ConnectionState.Broken)
                {
                    Conn.Close();
                    Conn.Open();
                }
            }

            //查询，获取DataReader
            public static SqlDataReader GetDataReader(string sqlStr)
            {
                InitConnection();
                SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            //查询，获取DataTable
            public static DataTable GetDataTable(string sqlStr)
            {

                InitConnection();
                DataTable table = new DataTable();
                SqlDataAdapter dap = new SqlDataAdapter(sqlStr, Conn);
                dap.Fill(table);
                Conn.Close();
                return table;
            }
        public static DataSet SelectData(string sql) {
            InitConnection();
            using (SqlDataAdapter sda = new SqlDataAdapter(sql, Conn))
            {
                DataSet ds = new DataSet();
                sda.Fill(ds);
                Conn.Close();
                return ds;
            }
        }

            //增删改
            public static bool ExecuteNonQuery(string sqlStr)
            {
                InitConnection();
                SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                int result = cmd.ExecuteNonQuery();
            Conn.Close();
            return result > 0;
            }
            //执行集合函数
            public static object ExecuteScalar(string sqlStr)
            {
                InitConnection();
                SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                object result = cmd.ExecuteScalar();
                Conn.Close();
                return result;
            }



    }
}