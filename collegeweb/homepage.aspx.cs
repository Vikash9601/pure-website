using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page
{
    OleDbConnection con;
    OleDbCommand cmd;
    OleDbDataAdapter da;
    protected void Page_Load(object sender, EventArgs e)
    {
        string umn = Request.QueryString["umn"];
        lbwel.Text = "welcome" + " " + umn;


        if (!Page.IsPostBack)
        {

            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Vikas\Documents\database\ass_student2.mdb");
            con.Open();
            cmd = new OleDbCommand("select * from course", con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "course");
            ddlcourse.DataSource = ds.Tables[0];
            ddlcourse.DataTextField = "coursename";
            ddlcourse.DataValueField = "courseid";

            ddlcourse.DataBind();
            ddlcourse.Items[0].Selected = true;
            con.Close();
           
        }
        else
        {

        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Vikas\Documents\database\ass_student2.mdb");
        con.Open();
        cmd = new OleDbCommand("select * from class where courseid=" + ddlcourse.SelectedValue + "", con);
        da = new OleDbDataAdapter(cmd);
        DataSet ds2 = new DataSet();
        da.Fill(ds2, "class");
        ddlclass.DataSource = ds2.Tables[0];
        ddlclass.DataTextField = "classname";
        ddlclass.DataValueField = "classid";

        ddlclass.DataBind();
        con.Close();
    }
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Vikas\Documents\database\ass_student2.mdb");
        con.Open();
        cmd = new OleDbCommand("select * from subject where classid=" + ddlclass.SelectedValue + "", con);
        da = new OleDbDataAdapter(cmd);
        DataSet ds1 = new DataSet();
        da.Fill(ds1, "subject");
        gvshow.DataSource = ds1.Tables[0];
        gvshow.DataBind();
        con.Close();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Vikas\Documents\database\ass_student2.mdb");
        con.Open();
        cmd = new OleDbCommand("select * from subject where subjectname like '" + txtsearch.Text + "%'", con);
       
        da = new OleDbDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "subject");
        gvshow.DataSource = ds.Tables[0];
        gvshow.DataBind();
        con.Close();
    }
    protected void gvshow_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}