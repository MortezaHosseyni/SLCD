using SLCD.classes.database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLCD.designer.userarea
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string
                uName = txt_Username.Value.Trim(),
                uPass = passHasher(txt_Password.Value),
                uSesionID = this.Session.SessionID;


            if (checkFields())
            {
                if (uSesionID == this.Session.SessionID)
                {
                    if (dbConnection.dbTest())
                    {
                        SQLiteDataReader users = dbProccess.readData(dbConnection.conn, "TB_User", $"US_Username = '{uName}' AND US_Password = '{uPass}'");
                        if (users.StepCount > 0)
                        {
                            mbox_Success.Visible = true;

                            Response.Redirect($"../userarea/userpanel.aspx?user={uName}");
                        }
                        else
                        {
                            mbox_Error.Visible = true;
                            return;
                        }
                    }
                }
            }
        }

        public bool checkFields()
        {
            Timer t = new Timer();
            if (txt_Username.Value == "" || txt_Password.Value == "")
            {
                t.Enabled = true;
                mbox_Empty.Visible = true;
                return false;
            }
            else
            {
                mbox_Empty.Visible = false;
                return true;
            }
        }

        public static string passHasher(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}