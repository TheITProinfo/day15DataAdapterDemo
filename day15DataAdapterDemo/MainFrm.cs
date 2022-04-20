using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace day15DataAdapterDemo
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            // load userinfo all data to DataGridview 
            string connStr = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

            using (SqlConnection conn =new SqlConnection(connStr))
            {
                string strSql = "select UserID, UserName, UserPassword, UserAge, UserEmail, UserMobile, DelFlag, CreateDate, LastErrorDateTime, ErrorTimes from [dbo].[UserInfo]";
                using (SqlDataAdapter adapter = new SqlDataAdapter(strSql, conn))
                {
                    DataTable dt1 = new DataTable();
                    adapter.Fill(dt1);
                    //this.dgvUserInfoList.DataSource = dt;
                    List<UserInfo> userList = new List<UserInfo>();
                    foreach (DataRow dataRow in dt1.Rows)
                    {
                        userList.Add(new UserInfo()
                        {
                            UserID = int.Parse(dataRow["UserID"].ToString()),
                            UserName = dataRow["UserName"].ToString(),
                            UserPassword = dataRow["UserPassword"].ToString()

                        });


                    } // end foreach

                    this.dgvUserInfoList.DataSource = userList;


                }

            }

        }
    }
}
