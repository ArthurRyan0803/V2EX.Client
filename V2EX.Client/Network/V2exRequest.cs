﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using V2EX.Client.Configurations;
using V2EX.Client.Helpers;
using V2EX.Client.Utils;

namespace V2EX.Client.Network
{
    public class V2EXRequest
    {
        public static HtmlDocument GetHtmlDoc(string url)
        {
            var isCookieEmpty = string.IsNullOrEmpty(RequestHeaders.Instance.PrivateCookie);
            var request = new V2EXRequest(url, V2EXRequestMethod.Get);
            if (isCookieEmpty)
            {
                var doc = request.Load(out var cookies);
                var privateCookie = cookies.Cast<Cookie>()
                    .First(x => x.Name == RequestHeaders.Instance.PrivateCookieName);
                RequestHeaders.Instance.PrivateCookie = $"{privateCookie.Name}={privateCookie.Value}";
                return doc;
            }
            return request.Load();
        }

        private readonly HtmlWeb _htmlWeb;
        private readonly string _url;

        public V2EXRequest(string url , V2EXRequestMethod method)
        {
            Predication.CheckNotNull(url);
            _url = url;
            _htmlWeb = new HtmlWeb();
            _htmlWeb.PreRequest += request =>
            {
                request.Method = method == V2EXRequestMethod.Get ? HttpHelper.GetMethod : HttpHelper.PostMethod;
                HttpHelper.AttachRequestHeaders(request);
                return true;
            };
        }

        public HtmlDocument Load()
        {
            return _htmlWeb.Load(_url);
        }

        public HtmlDocument Load(out CookieCollection cookies)
        {
            CookieCollection result = null;
            _htmlWeb.PreRequest += request =>
            {
                request.CookieContainer = new CookieContainer();
                return true;
            };
            _htmlWeb.PostResponse += (request, response) =>
            {
                result = response.Cookies;
            };
            var doc = _htmlWeb.Load(_url);
            cookies = result;
            return doc;
        }

        public async Task<HtmlDocument> LoadAsync()
        {
            return await Task.Factory.StartNew(() => _htmlWeb.Load(_url));
        }
    }
}