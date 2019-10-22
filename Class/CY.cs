using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace R_bookWY.Class
{
    public class CY
    {
        public DataTable ZxSql(string sql)
        {
            DataTable dt = new DataTable();
            string error = "";
            //用于保存子菜单
            try
            {
                DataSet ds = new DataSet();
                //如果是查询语句
                string sqlConnection = "Data Source=" + System.AppDomain.CurrentDomain.BaseDirectory + "//DB/book.db" + ";";
                SQLiteConnection sqlc = new SQLiteConnection(sqlConnection);
                SQLiteDataAdapter sdp = new SQLiteDataAdapter();
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(sql, sqlc);
                    sdp.SelectCommand = cmd;
                    sdp.Fill(ds);
                    sdp.Dispose();
                    dt = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    error += ex.Message.ToString();
                }
                sqlc.Close();

            }
            catch (Exception ex)
            {
                error += ex.Message.ToString();
            }
            if (error != "")
            {
                dt.Clear();
                dt.Columns.Add("执行情况");
                dt.Columns.Add("错误信息");
                DataRow dr = dt.NewRow();
                dr["执行情况"] = "失败";
                dr["错误信息"] = error;
                dt.Rows.Add(dr);
            }
            return dt; 
        }
    }
    public class MeunInfo
    {
        public string id;
        //菜单标题
        public string meunTitle;
        //菜单地址
        public string meunUrl;
        //菜单状态
        public string meunStatus;
        //菜单标识
        public string meunParent;
        //菜单排序
        public string meunSort;
        //子菜单集合
        public List<MeunInfo> childrenList;
    }
}