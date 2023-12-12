using System;
using System.Data;
using System.Data.SqlClient;

namespace flower_stock_monitoring.model
{
    public class Function
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable Dt;
        private SqlDataAdapter Sda;
        private string ConString;

        public Function()
        {
            ConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\flower shop\FlowerStockMonitoringDB.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(ConString);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        public DataTable GetData(string Query)
        {
            Dt = new DataTable();
            Sda = new SqlDataAdapter(Query, Con);
            Sda.Fill(Dt);
            return Dt;
        }

        public int SetData(string Query)
        {
            int cnt = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }

            Cmd.CommandText = Query;
            cnt = Cmd.ExecuteNonQuery();
            Con.Close();

            return cnt;
        }
    }
}
