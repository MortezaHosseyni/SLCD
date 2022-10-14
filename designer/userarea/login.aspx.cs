using SLCD.classes.database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLCD.designer.userarea
{
    public partial class login : System.Web.UI.Page
    {
        public string newSessionId;
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionIDManager manager = new SessionIDManager();
            newSessionId = manager.CreateSessionID(HttpContext.Current);
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", newSessionId));
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string
                uName = txt_Username.Value.Trim(),
                uPass = passHasher(txt_Password.Value),
                uSesionID = newSessionId;

            DateTime toDay = DateTime.Now;


            if (checkFields())
            {
                if (dbConnection.dbTest())
                {
                    SQLiteDataReader users = dbProccess.readData(dbConnection.conn, "TB_User", $"US_Username = '{uName}' AND US_Password = '{uPass}'");
                    if (users.StepCount > 0)
                    {
                        users.Read();
                        if (dbProccess.saveData(dbConnection.conn, "TB_LoginLog", "LL_Username, LL_SessionID, LL_LoginDate, LL_UserID", $"'{users["US_Username"]}', '{uSesionID}', '{toDay}', {users["US_ID"]}"))
                        {
                            string url = "../userarea/userpanel.aspx";
                            Response.Write("<script> window.open( '" + url + "','_self' ); </script>");
                            Response.End();
                        }
                    }
                    else
                    {
                        mbox_Error.Visible = true;
                        return;
                    }
                }
            }
        }

        public bool checkFields()
        {
            if (txt_Username.Value == "" || txt_Password.Value == "")
            {
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