using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class man : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        
    }
    protected void btnQuit_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "WindowClose", "window.close();", true);
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        
        String temp = "";
        string sqlselect = @"Select  id,name From man ";
        SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testhwDBConnectionString"].ConnectionString);
        SqlCommand com = new SqlCommand(sqlselect, cn);
        System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter();
        System.Data.DataSet ds = new DataSet();
        try
        {
            cn.Open();
            da.SelectCommand = com;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {


                }
            }

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox myCheckbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");


                if (myCheckbox.Checked == true)
                {

                    temp += ds.Tables[0].Rows[i]["name"].ToString() + ",";
                }
            }
            if (temp != "")
                temp = temp.Remove(temp.Length - 1);
            doJavascript(temp);




        }
        catch (SqlException)
        {
            this.Label2.Text = "資料庫連接錯誤";
        }
        finally
        {

            if (null != cn)
            {
                cn.Close();
                cn.Dispose();
            }
            if (null != com)
            { com.Dispose(); }
            if (null != da)
            { da.Dispose(); }
            if (null != ds)
            { ds.Dispose(); }
        
        }
       

        


        
        

    }

    private void doJavascript(string strDate)
    {
        Literal liJavascriptCode = new Literal();
        liJavascriptCode.Text = "<script>postValueToMain('" + strDate + "');</script>";
        Page.Controls.Add(liJavascriptCode);
    }





        

    
}