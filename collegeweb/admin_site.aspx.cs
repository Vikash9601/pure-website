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
        Label1.Text = "welcome" + " " + umn;

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
        else
        {

        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
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
        fnbindgrid();
    }
    void fnbindgrid()
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
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Vikas\Documents\database\ass_student2.mdb");
        con.Open();
        cmd = new OleDbCommand("select * from subject where subjectname like '" + txtsub.Text + "%'", con);
        
        da = new OleDbDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "subject");
        gvshow.DataSource = ds.Tables[0];
        gvshow.DataBind();
        con.Close();
    }

    protected void gvshow_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvshow.PageIndex = e.NewPageIndex;
        fnbindgrid();
    }
    protected void gvshow_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    protected void gvshow_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvshow.EditIndex = e.NewEditIndex;
        this.fnbindgrid();
    }
    protected void gvshow_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gvshow.Rows[e.RowIndex];
        int subjectid = Convert.ToInt32(gvshow.DataKeys[e.RowIndex].Values[0]);
        string subjectname = (row.FindControl("txtname") as TextBox).Text;
       
     
        string learningskill = (row.FindControl("txtlearn") as TextBox).Text; 
        string query = "update [subject] set [subjectname]='"+subjectname+"',[learningskill]='"+learningskill+"' where [subjectid]=@subjectid";
        string constr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Vikas\Documents\database\ass_student2.mdb";
        con = new OleDbConnection(constr);

        {

            cmd = new OleDbCommand(query,con);
            {
                cmd.Parameters.AddWithValue("@subjectid", subjectid);
               
                cmd.Parameters.AddWithValue("@subjectname", subjectname);
               
                cmd.Parameters.AddWithValue("@learningskill", learningskill);
                con.Open();

                cmd.ExecuteNonQuery();
             

               
            }
            con.Close();
        }
        gvshow.EditIndex = -1;
        this.fnbindgrid();
       

    }
    
    protected void gvshow_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = gvshow.Rows[e.RowIndex];
        int subjectid = Convert.ToInt32(gvshow.DataKeys[e.RowIndex].Values[0]);
        string query = "delete from subject where subjectid=@subjectid";
         string constr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Vikas\Documents\database\ass_student2.mdb";
        con = new OleDbConnection(constr);

        {

            cmd = new OleDbCommand(query,con);
            {

                cmd.Parameters.AddWithValue("@subjectid", subjectid);
                con.Open();

                cmd.ExecuteNonQuery();
                Response.Write(cmd.CommandText);


            }
            con.Close();
        }
        gvshow.EditIndex = -1;
        this.fnbindgrid();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Vikas\Documents\database\ass_student2.mdb");
        con.Open();
        cmd = new OleDbCommand("insert into subject values(" + txtsubid.Text + ",'"+txtsubname.Text+"',"+txtclass.Text+",'"+txtlearning.Text+"')",con);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void gvshow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      

    }
    protected void gvshow_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
    {
        gvshow.EditIndex = -1;
        this.fnbindgrid();
    }
}                                                                 