using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Web_API_Crud_Operation_Simple.Models
{
    public class BAL
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RU5490M;Initial Catalog=Web_API_Task;Integrated Security=True");

        public DataSet UserList()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Web_API_Task", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "UserList");
            SqlDataAdapter adpt = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adpt.SelectCommand = cmd;
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public void Save(User obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Web_API_Task", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Save");
            cmd.Parameters.AddWithValue("@Id", obj.Id);
            cmd.Parameters.AddWithValue("@Name",obj.Name );
            cmd.Parameters.AddWithValue("@Address",obj.Address );
            cmd.Parameters.AddWithValue("@mobile",obj.Mobile );
            cmd.Parameters.AddWithValue("@CityId",obj.CityId );
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet EditUser(User obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Web_API_Task", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "EditUser");
            cmd.Parameters.AddWithValue("@Id", obj.Id);
            SqlDataAdapter adpt = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adpt.SelectCommand = cmd;
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public void Delete(User obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Web_API_Task", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Delete");
            cmd.Parameters.AddWithValue("@Id", obj.Id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet Country()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Web_API_Task", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "country");
            SqlDataAdapter adpt = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adpt.SelectCommand = cmd;
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public DataSet State(User obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Web_API_Task", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "State");
            cmd.Parameters.AddWithValue("@CountryId", obj.CountryId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adpt.SelectCommand = cmd;
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public DataSet City(User obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Web_API_Task", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "City");
            cmd.Parameters.AddWithValue("@StateId", obj.StateId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adpt.SelectCommand = cmd;
            adpt.Fill(ds);
            return ds;
            con.Close();
        }

    }
}