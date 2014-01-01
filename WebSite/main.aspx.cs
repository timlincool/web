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

public partial class main : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            //for (var i = this.form.elements.length - 1; i >= 0; i--) this.form.elements[i].disabled = false;
            this.txtDate.Enabled = false;
            this.txtMan.Enabled = false;
            this.txtPlace.Enabled = false;
            this.txtSchedule.Enabled = false;
            this.btnCal.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnMan.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnInsert.Enabled= false;
            this.btnUpdate.Enabled = false;
            this.btnCal.BackColor = System.Drawing.ColorTranslator.FromHtml("#B8B9BB");
            this.btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#B8B9BB");                        
            this.btnMan.BackColor = System.Drawing.ColorTranslator.FromHtml("#B8B9BB");
            this.btnDelete.BackColor = System.Drawing.ColorTranslator.FromHtml("#B8B9BB");
            this.btnInsert.BackColor = System.Drawing.ColorTranslator.FromHtml("#B8B9BB");
            this.btnUpdate.BackColor = System.Drawing.ColorTranslator.FromHtml("#B8B9BB");    



            SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testhwDBConnectionString"].ConnectionString);
            
            try
            {
                cn.Open();
                              
                this.btnInsert.Enabled = true;
                this.btnUpdate.Enabled = true;
                this.btnInsert.BackColor = System.Drawing.ColorTranslator.FromHtml("#FE5852");
                this.btnUpdate.BackColor = System.Drawing.ColorTranslator.FromHtml("#FE5852");


            }
            catch (SqlException)
            {
                this.lbInfor.Text = "資料庫連接錯誤，請先連接才能使用網頁";
            }
            finally
            {
                if (null != cn)
                {
                    cn.Close();
                    cn.Dispose();
                }
            
            }

        }
          
        //this.btnMan.OnClientClick = "window.open('man.aspx');";
        //this.btnCal.OnClientClick = "window.open('Calender.aspx');";

                   
    }

  


    protected void btnInsert_Click(object sender, EventArgs e)
    {
       
            //for (var i = this.form.elements.length - 1; i >= 0; i--) this.form.elements[i].disabled = false;
       

            this.txtDate.Enabled = true;
            this.txtMan.Enabled = true;
            this.txtPlace.Enabled = true;
            this.txtSchedule.Enabled = true;
            this.btnCal.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnMan.Enabled = true;
            this.btnSave.Enabled = true;

            this.btnCal.BackColor = System.Drawing.ColorTranslator.FromHtml("#FE5852");
            this.btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#FE5852");
            this.btnMan.BackColor = System.Drawing.ColorTranslator.FromHtml("#FE5852");
            this.btnDelete.BackColor = System.Drawing.ColorTranslator.FromHtml("#FE5852");


            this.txtflag.Text = "insert";
            this.lbInfor.Text = "";
            this.txtDate.Text = "";
            this.txtMan.Text = "";
            this.txtPlace.Text = "";
            this.txtSchedule.Text = "";

              
                      
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        this.txtDate.Enabled = true;
        this.txtMan.Enabled = true;
        this.txtPlace.Enabled = true;
        this.txtSchedule.Enabled = true;
        this.btnCal.Enabled = true;
        this.btnDelete.Enabled = true;
        this.btnMan.Enabled = true;
        this.btnSave.Enabled = true;

        this.btnCal.BackColor = System.Drawing.ColorTranslator.FromHtml("#FE5852");
        this.btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#FE5852");
        this.btnMan.BackColor = System.Drawing.ColorTranslator.FromHtml("#FE5852");
        this.btnDelete.BackColor = System.Drawing.ColorTranslator.FromHtml("#FE5852");


        this.txtflag.Text = "update";
        this.lbInfor.Text = "";

        var time = this.txtDate.Text;
        var man = this.txtMan.Text;
        var place = this.txtPlace.Text;
        var schedule = this.txtSchedule.Text;

        string sqlselect = @"Select TOP 1 id,time,place,man,schedule From activity ORDER BY id DESC";
        SqlConnection cn = new SqlConnection();
       
        String connectionstring = WebConfigurationManager.ConnectionStrings["testhwDBConnectionString"].ConnectionString; 
       

        SqlCommand com = new SqlCommand(sqlselect, cn);

        System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter();
        System.Data.DataSet ds = new DataSet();


        if (connectionstring != null)
        {
            try
            {
                cn.ConnectionString = connectionstring;
                cn.Open();
                da.SelectCommand = com;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    this.txtDate.Text = ds.Tables[0].Rows[0]["time"].ToString();
                    this.txtMan.Text = ds.Tables[0].Rows[0]["man"].ToString();
                    this.txtPlace.Text = ds.Tables[0].Rows[0]["place"].ToString();
                    this.txtSchedule.Text = ds.Tables[0].Rows[0]["schedule"].ToString();
                }
                else
                {
                    this.lbInfor.Text = "尚未有活動，請先新增";

                }


            }
            catch (SqlException)
            {
                this.lbInfor.Text = "資料庫連接錯誤";
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
      
       }
    protected void btnCal_Click(object sender, EventArgs e)
    {
        //Response.Write("<script>window.open('Calender.aspx');</script>");
    }
    protected void btnCal_Click1(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
      
     var time = this.txtDate.Text;
    var man = this.txtMan.Text;
    var place = this.txtPlace.Text;
    var schedule = this.txtSchedule.Text;
        //不可所有欄都沒資料
    if (time + man + place + schedule != "")
    {

        //string sqlselect = @"Select TOP 1 id,time,place,man,schedule From activity ORDER BY id DESC";
        //string sqldelete = "delete   activity where id=( Select TOP 1 id From activity ORDER BY id DESC)";
        string sqlinsert = @"insert into activity (time ,place ,man,schedule) values (@time ,@place ,@man,@schedule)";
        string sqlupdate = @"update activity SET  time=@time ,place =@place,man=@man,schedule=@schedule where id=(Select TOP 1 id From activity ORDER BY id DESC)";
        //string connectionString = "Data Source=TIM"+"\\"+"SQLEXPRESS;Initial Catalog=testhwDB;Persist Security Info=True;User ID=test;Password=test123";
        SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testhwDBConnectionString"].ConnectionString);
        SqlCommand comUpdate = new SqlCommand(sqlupdate, cn);
        SqlCommand comInsert = new SqlCommand(sqlinsert, cn);
        

        if (this.txtflag.Text.ToString().Equals(""))
        {

            this.lbInfor.Text = "錯誤";

        }

        try
        {
            #region 按下新增

            if (this.txtflag.Text.ToString().Equals("insert"))
            {

                int count = 1;
                cn.Open();
                //dbsqlCommandSecurity(sqlCommandselect, time, man, place, schedule);

                dbsqlCommandSecurity(comInsert, time, man, place, schedule);

                //count = (int)com.ExecuteScalar();
                if (count > 0)
                {
                    comInsert.ExecuteNonQuery();
                    this.lbInfor.Text = "已新增";
                    comInsert.Dispose();

                }
                else
                {

                    this.lbInfor.Text = "輸入格式錯誤";
                }

                this.txtflag.Text = "";
            }
            #endregion



            #region 按下修改
            if (this.txtflag.Text.ToString().Equals("update"))
            {

                int count = 1;
                cn.Open();
                //dbsqlCommandSecurity(sqlCommandselect, time, man, place, schedule);

                dbsqlCommandSecurity(comUpdate, time, man, place, schedule);
                //count = (int)com.ExecuteScalar();
                if (count > 0)
                {
                    comUpdate.ExecuteNonQuery();
                    this.lbInfor.Text = "已修改";
                    comUpdate.Dispose();

                }
                else
                {

                    this.lbInfor.Text = "輸入格式錯誤";
                }




                this.txtflag.Text = "";
            }
            #endregion


            
        }
        catch (SqlException)
        {

            this.lbInfor.Text = "資料庫連接錯誤";
        }
        finally
        {
            if (null != cn)
            {
                cn.Close();
                cn.Dispose();
            }

            if (null != comUpdate)
            {
                comUpdate.Dispose();
            }

            if (null != comUpdate)
            {
                comUpdate.Dispose();
            }
        }



        this.txtDate.Text = "";
        this.txtMan.Text = "";
        this.txtPlace.Text = "";
        this.txtSchedule.Text = "";

        this.btnSave.Enabled = false;
    }
    else
    {
        this.lbInfor.Text = "不可所有欄都沒資料";
    }
             
    }
    
    
    protected void dbsqlCommandSecurity(SqlCommand sqlCommand, string time, string man, string place, string schedule)
    {

        /*sqlCommand.Parameters.Add("@time", SqlDbType.NVarChar);
        sqlCommand.Parameters["@time"].Value = time;*/
        sqlCommand.Parameters.AddWithValue("@time", time);
        sqlCommand.Parameters.AddWithValue("@man", man);
        sqlCommand.Parameters.AddWithValue("@place", place);
        sqlCommand.Parameters.AddWithValue("@schedule", schedule);
      
       
    }

 


    protected void btnDelete_Click(object sender, EventArgs e)
    {


        string sqldelete = @"delete activity where id=( Select TOP 1 id From activity ORDER BY id DESC)";
        SqlConnection cn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testhwDBConnectionString"].ConnectionString);
        SqlCommand com = new SqlCommand(sqldelete, cn);
        try
        {
            cn.Open();
            com.ExecuteNonQuery();


            this.lbInfor.Text = "最近一筆資料已刪除";
            this.txtflag.Text = "";
        }
        catch (SqlException)
        {
            this.lbInfor.Text = "資料庫連接錯誤";
        }
        finally
        {
            if (null != cn)
            {
                cn.Close();
                cn.Dispose();
            }
            if (null != com)
            {
                com.Dispose();
            }
        }
        
       

        

        this.txtDate.Text="";
        this.txtMan.Text = "";
        this.txtPlace.Text = "";
        this.txtSchedule.Text = "";
     

    }
    protected void btnMan_Click(object sender, EventArgs e)
    {
        
        //this.btnMan.OnClientClick = "window.open('man.aspx'); return false; ";
            //OnClientClick="window.open('man.aspx'); return false;"
    }
}