using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Default2 : System.Web.UI.Page
{
    OleDbConnection con;
    OleDbCommand cmd;
    OleDbDataAdapter da;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnlog_Click(object sender, EventArgs e)
    {

        con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Vikas\Documents\database\ass_student2.mdb");
        con.Open();

        cmd = new OleDbCommand("select count(*) from student where mobno=" + txtus.Text + " and pwd='" + txtpwd.Text + "'", con);
        da = new OleDbDataAdapter(cmd);

     
        int cnt;

        cnt=Convert.ToInt32(cmd.ExecuteScalar());


        con.Close();
        if (cnt == 1)
        {
            Response.Redirect("homepage.aspx?umn=" + txtus.Text);

        }
        else
        {
            Response.Write("sorry");
        }
    }
}