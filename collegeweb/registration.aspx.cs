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
            con.Close();
        }
    }
    protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Vikas\Documents\database\ass_student2.mdb");
        con.Open();
        cmd = new OleDbCommand("select * from class where courseid="+ddlcourse.SelectedValue+"", con);
        da = new OleDbDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "class");
        ddlclass.DataSource = ds.Tables[0];
        ddlclass.DataTextField = "classname";
        ddlclass.DataValueField = "classid";

        ddlclass.DataBind();
        con.Close();
    }
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void btnsub_Click(object sender, EventArgs e)
    {
        
        con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Vikas\Documents\database\ass_student2.mdb");
        con.Open();
        if (rbtnmale.Checked == true)
        {
            cmd = new OleDbCommand("insert into student(studentname,gender,mobno,studemail,pwd,course,class,classid) values('" + txtname.Text + "','male'," + txtmob.Text + ",'" + txtemail.Text + "','" + txtpass.Text + "','" + ddlcourse.SelectedItem.ToString() + "','" + ddlclass.SelectedItem.ToString() + "'," + ddlclass.SelectedValue + ")", con);

            da = new OleDbDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("homepage.aspx?umn=" + txtmob.Text);
        }
        else
        {

            cmd = new OleDbCommand("insert into student(studentname,gender,mobno,studemail,pwd,course,class,classid) values('" + txtname.Text + "','female'," + txtmob.Text + ",'" + txtemail.Text + "','" + txtpass.Text + "','" + ddlcourse.SelectedItem.ToString() + "','" + ddlclass.SelectedItem.ToString() + "'," + ddlclass.SelectedValue + ")", con);

            da = new OleDbDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("homepage.aspx?umn=" + txtmob.Text);
        }
    }
  
}