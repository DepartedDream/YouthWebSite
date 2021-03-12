<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Novel.aspx.cs" Inherits="YouthWebSite.Novel" %>
<asp:Content ID="content1" ContentPlaceHolderID="headHolder" runat="server">
        <link href="/CSS/Novel.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="bodyHolder" runat="server">
        <div id="novel_intro_video_container">
            <video id="novel_intro_video" runat="server" ClientIDMode="Static" controls="controls" autoplay="autoplay"></video>
        </div>
        <div id="novel_intro">
            <div id="novel_cover"  runat="server" ClientIDMode="Static"></div>
            <div id="novel_name" runat="server" ClientIDMode="Static"></div>
            <div id="novel_detail"  runat="server" ClientIDMode="Static">
            </div>
        </div>
        <div id="novel_chapter_list"  runat="server" ClientIDMode="Static">
        </div>
        <div id="novel_chapter_info">
            <div id="novel_chapter_name"  runat="server" ClientIDMode="Static"></div>
            <div id="novel_chapter_content" runat="server" ClientIDMode="Static"></div>
        </div>
</asp:Content>