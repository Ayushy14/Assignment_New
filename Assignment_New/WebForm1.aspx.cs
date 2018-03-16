using System;
using System.Data.SqlClient;
using System.Data;


namespace Assignment_New
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            ExecuteInsert(PlayerName.Text, PlayerTeam.Text, ICCRanking.Text, BestScore.Text);
            Response.Write("Record was successfully added!");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ExecuteDelete(PlayerName.Text, PlayerTeam.Text, ICCRanking.Text, BestScore.Text);
        }

        public void ExecuteDelete(string PlayerName, string PlayerTeam, string ICCRanking, string BestScore)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql1 = "DELETE FROM PlayerInfo WHERE PlayerName=@PlayerName";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql1, conn);
                //SqlDataAdapter adapter = new SqlDataAdapter();
                //adapter.DeleteCommand = new SqlCommand(sql1, conn);
                //adapter.DeleteCommand.ExecuteNonQuery();
                cmd.Parameters.AddWithValue("@PlayerName", PlayerName);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                Response.Write("The record has been deleted successfully");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Delete Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }
            public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["MyConsString"].ConnectionString;
        }
        public void ExecuteInsert(string PlayerName, string PlayerTeam, string ICCRanking, string BestScore)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql = "INSERT INTO PlayerInfo(PlayerName,PlayerTeam,ICCRanking,BestScore) VALUES " + 
                "(@PlayerName,@PlayerTeam,@ICCRanking,@BestScore)";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter[] param = new SqlParameter[4];

                param[0] = new SqlParameter("@PlayerName",SqlDbType.VarChar,50);
                param[1] = new SqlParameter("@PlayerTeam",SqlDbType.VarChar,50);
                param[2] = new SqlParameter("@ICCRanking",SqlDbType.VarChar,50);
                param[3] = new SqlParameter("@BestScore",SqlDbType.VarChar,50);


                param[0].Value = PlayerName;
                param[1].Value = PlayerTeam;
                param[2].Value = ICCRanking;
                param[3].Value = BestScore;

                for (int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}