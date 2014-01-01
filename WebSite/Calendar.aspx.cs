using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class Calendar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Calendar1.SelectedDate = new DateTime(1900, 1, 1);
      
            int myYear = System.DateTime.Now.Year+10;
            for (int i = 0; i < 100; i++)
            {
               
                int myYear1 = myYear - i;
                DropDownList1.Items.Add(myYear1.ToString());

            }

            for (int i = 1; i < 13; i++)
            {
             
                
                DropDownList2.Items.Add(i.ToString()+"月");

               
            }

            DropDownList1.SelectedValue = System.DateTime.Today.Year.ToString();
            DropDownList2.SelectedValue = System.DateTime.Today.Month.ToString() + "月";
       
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        
        doJavascript(Calendar1.SelectedDate.ToString("yyyy/MM/dd"));

    }

    
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)   
    {
       
        Calendar1.VisibleDate = new DateTime(Convert.ToInt32(DropDownList1.SelectedValue), Convert.ToInt32(DropDownList2.SelectedValue.ToString().Replace("月","")), 1);
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Calendar1.VisibleDate = new DateTime(Convert.ToInt32(DropDownList1.SelectedValue), Convert.ToInt32(DropDownList2.SelectedValue.ToString().Replace("月", "")), 1);
    }
    protected void btnToday_Click(object sender, EventArgs e)
    {
        Calendar1.VisibleDate = System.DateTime.Today;
        DropDownList1.SelectedValue = System.DateTime.Today.Year.ToString();
        DropDownList2.SelectedValue = System.DateTime.Today.Month.ToString()+"月";
    }
    protected void btnQuit_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "WindowClose", "window.close();", true);
    }

    private void doJavascript(string strDate)
    {
        Literal liJavascriptCode = new Literal();
        liJavascriptCode.Text = "<script>postValueToMain('" + strDate + "');</script>";
        Page.Controls.Add(liJavascriptCode);
    }

}