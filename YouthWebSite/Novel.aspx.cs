using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace YouthWebSite
{
    public partial class Novel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*获取get方法传递的当前小说和章节id*/
            string novelIdGet = Request.QueryString["novelId"];
            string chapterIdGet = Request.QueryString["chapterId"];
            if (chapterIdGet.Remove(0, 2) == "1")//判断是否为序章，只有序章有介绍
            {
                /*生成小说介绍信息*/
                DataSet ds1 = SqlHelper.GetDataSet(CommandType.Text, "select * from Novel where NovelId=@NovelId", new SqlParameter("@NovelId", novelIdGet));
                string novelName = Convert.ToString(ds1.Tables[0].Rows[0][1]);
                string novelDetail = Convert.ToString(ds1.Tables[0].Rows[0][2]);
                novel_name.InnerText = novelName;
                novel_detail.InnerText = novelDetail;
                /*修改小说封面路径*/
                novel_cover.Style.Add("background-image", $"url(/Resource/novel{novelIdGet}/cover_img.png);");
                /*修改介绍视频路径*/
                novel_intro_video.Attributes.Add("src", $"/resource/novel{novelIdGet}/video.mp4");
            }
            else 
            {
                novel_name.Visible = false;//隐藏小说名称
                novel_cover.Visible = false;//隐藏封面
                novel_intro_video.Visible = false;//隐藏介绍视频
                novel_detail.Visible = false;//隐藏介绍
            }
            /*生成章节列表*/
            DataSet ds2 = SqlHelper.GetDataSet(CommandType.Text, "select * from Chapter where NovelId=@NovelId", new SqlParameter("@NovelId", novelIdGet));
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                string chapterItemId = Convert.ToString(ds2.Tables[0].Rows[i][0]);
                string chapterItemName = Convert.ToString(ds2.Tables[0].Rows[i][1]);
                string novelChapterItemHtml = $"<div class=\"novel_chapter_item\"><a class=\"novel_chapter_item_href\" href=Novel.aspx?novelId={novelIdGet}&chapterId={chapterItemId}>{chapterItemName}</a></div>";
                novel_chapter_list.InnerHtml = novel_chapter_list.InnerHtml + novelChapterItemHtml;
            }
            /*生成小说内容*/
            DataSet ds3 = SqlHelper.GetDataSet(CommandType.Text, "select * from Chapter where ChapterId=@ChapterId", new SqlParameter("@ChapterId", chapterIdGet));
            string chapterName = Convert.ToString(ds3.Tables[0].Rows[0][1]);
            string chapterContent = Convert.ToString(ds3.Tables[0].Rows[0][2]);
            novel_chapter_name.InnerText = novel_chapter_name.InnerText + chapterName;
            novel_chapter_content.InnerHtml = novel_chapter_content.InnerHtml + chapterContent;
        }
    }
}