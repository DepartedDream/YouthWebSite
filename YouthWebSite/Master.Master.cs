using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YouthWebSite
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * from Novel";
            DataSet ds = SqlHelper.GetDataSet(CommandType.Text, sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string novelId = Convert.ToString(ds.Tables[0].Rows[i][0]);
                string novelName = Convert.ToString(ds.Tables[0].Rows[i][1]);
                string navItemHtml = $"<div class=\"nav_item\"><a class=\"nav_item_href\" href=\"/Novel.aspx?novelId={novelId}&chapterId={novelId+"01"}\">{novelName}</a></div>";
                nav.InnerHtml = nav.InnerHtml + navItemHtml;
            }
            /*获取get方法传递的当前小说id*/
            string novelIdGet = Request.QueryString["novelId"];
            background.Style.Add("background-image", $"url(/resource/novel{novelIdGet}/background.png)");
        }
    }
}