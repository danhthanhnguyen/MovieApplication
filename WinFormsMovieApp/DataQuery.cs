using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace WinFormsMovieApp
{
    class DataQuery
    {
        public string connect;
        public SqlConnection connection;
        public DataTable data;
        public DataQuery()
        {
            connect = @"Data Source=NGUYENDANHTHANH\SQLEXPRESS;Initial Catalog=MovieApp;Integrated Security=True";
            connection = null;
            data = new DataTable();
        }
        public void ConnectSql()
        {
            connection = new SqlConnection(connect);
            connection.Open();
        }
        public void disconnect()
        {
            connection.Close();
        }
        public void printData(string sqlQuery)
        {
            string query = sqlQuery;
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(data);
        }
        public void addData(string table, string value1, string value2)
        {
            string add = $"INSERT INTO {table} VALUES('{value1}', '{value2}')";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = add;
            cmd.ExecuteNonQuery();
        }
        public void addData(string table, string value1, string value2, string value3, string value4)
        {
            string add = $"INSERT INTO {table} VALUES('{value1}', '{value2}', '{value3}', '{value4}')";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = add;
            cmd.ExecuteNonQuery();
        }
    }
}
