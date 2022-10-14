using SLCD.classes.database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLCD.designer.design
{
    public partial class circutinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Design_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                string
                cName = txt_CtName.Value,
                cFormul = txt_CtFormul.Value,
                cInputs = slc_Inputs.SelectedIndex.ToString(),
                cPic = fle_CtPic.Value;

                if (dbProccess.saveData(dbConnection.conn, "TB_Circuts", "CT_Name, CT_InputCount, CT_Formul, CT_Picture, CT_Enable, CT_CategoryID", $"'{cName}', {Convert.ToInt32(cInputs)}, '{cFormul}', '{cPic}', {0}, {2}"))
                {
                    SQLiteDataReader circut = dbProccess.readData(dbConnection.conn, "TB_Circuts", "ORDER BY CT_ID DESC LIMIT 1");
                    circut.Read();
                    Response.Redirect($"../design/circutformul.aspx?ctid={circut["CT_ID"]}");
                }
                else
                {
                    mbox_Error.Visible = true;
                    return;
                }
            }
        }

        public bool checkFields()
        {
            if (txt_CtName.Value == "" || txt_CtFormul.Value == "" || fle_CtPic.Value == "")
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
    }
}