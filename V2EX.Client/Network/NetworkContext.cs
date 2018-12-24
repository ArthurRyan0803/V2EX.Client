﻿using System;
using System.Net;
using HtmlAgilityPack;
using V2EX.Client.Helpers;
using V2EX.Client.Utils;
using V2EX.Helpers;

namespace V2EX.Client.Network
{
    public static class NetworkContext
    {
        private const string VerificationImageDivPath =
            "//body/div[@id='Wrapper']/div[@class='content']/div[@id='Main']/div[@class='box']/div[@class='cell']/form/table/tr[3]/td[2]/div[1]";
        public static string Cookie { get; private set; }

        //public static Image DownloadVerificationCodeImage()
        //{
        //    if (GetLoginVerificationCodeImageUrl(out var relativeUrl))
        //    {
        //        var stream = HttpHelper.GetResponseStream(Url.Home + relativeUrl);
        //        return Image.FromStream(stream);
        //    }

        //    return null;
        //}
        
        //public static string GetTabHtml(string tabName)
        //{
        //    return HttpHelper.GetResponseContent(Url.Tab + tabName);
        //}

        //public static string GetLoginPageHtml()
        //{
        //    return HttpHelper.GetResponseContent(Url.SignIn);
        //}

        //public static LoginInfo GetLoginInfo()
        //{
        //    var web = new HtmlWeb();
        //    CookieCollection cookies = null;
        //    web.PreRequest += request =>
        //    {
        //        request.CookieContainer = new CookieContainer();
        //        return true;
        //    };
        //    web.PostResponse += (_, response) =>
        //    {
        //        cookies = response.Cookies;
        //    };
        //    var html = web.Load(new Uri(Url.SignIn));
        //    var style = html.DocumentNode
        //        .SelectSingleNode(VerificationImageDivPath)
        //        .Attributes["style"];
        //    var url = HtmlParseHelper.GetVerificationImageUrl(style?.Value);
        //    return new LoginInfo(url, cookies);
        //}
    }

    public class LoginInfo
    {
        public string VerificationCodeImageUrl { get; }
        public CookieCollection Cookies { get; }

        public LoginInfo(string verificationCodeImageUrl, CookieCollection cookies)
        {
            Predication.CheckNotNull(verificationCodeImageUrl);
            Predication.CheckNotNull(cookies);
            VerificationCodeImageUrl = verificationCodeImageUrl;
            Cookies = cookies;
        }
    }
}