using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace SMBot
{
    public class NVC
    {
        [ThreadStatic]
        public static NameValueCollection Create = new NameValueCollection() { { "username", "" }, { "displayName", "" }, { "password", "" }, { "email", "" }, { "month", "" }, { "day", "" }, { "year", "" } };
    }

    class HTTP
    {
        public string Post(string uri, NameValueCollection pairs) {
            byte[] response = null;
            using (WebClient client = new WebClient())
                response = client.UploadValues(uri, pairs);
            return System.Text.Encoding.UTF8.GetString(response);
        }

        public string Get(string Url)
        {
            return Get(Url, false, null);
        }

        public string Get(string url, bool useCookies, NameValueCollection cookies) {
            try {
                using (WebClient client = new WebClient()) {
                    if (useCookies) 
                        for (int i = 0; i < cookies.Count; i++) 
                            client.Headers.Add(HttpRequestHeader.Cookie, cookies.GetKey(i) + "=" + cookies.Get(i) + (cookies.Count > 1 ? ";" : ""));
                    return client.DownloadString(url);
                }
            } catch (WebException ex) { return ex.Message; }
        }

        // PostBytes needs to be "{}" for StreamMe
        public bool WebReqByMethod(string address, string method, string accept, string acceptEncoding, string acceptLanguage, string referal, string contentType, byte[] postBytes, CookieContainer cont)
        {
            try {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(address);
                req.Proxy = null;
                req.Timeout = 1000;
                req.KeepAlive = true;
                req.Accept = accept;
                req.CookieContainer = cont;
                req.Headers["Accept-Encoding"] = acceptEncoding;
                req.Headers["Accept-Language"] = acceptLanguage;
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.115 Safari/537.36";
                req.Referer = referal;
                req.ContentType = contentType;
                req.Method = method;
                req.ContentLength = postBytes.Length;
                Stream postStream = req.GetRequestStream();
                postStream.Write(postBytes, 0, postBytes.Length);
                postStream.Close();
                return true;
            } catch { return false; }
        }
    }

    class ArgBuilder
    {
        private class KeyValuesPair
        {
            public string Name { get; set; }
            public string[] Values { get; set; }
        }

        public static void Insert(NameValueCollection col, int index, string name, string value)
        {
            if (index < 0 || index > col.Count)
                throw new ArgumentOutOfRangeException();

            if (col.GetKey(index) == value)
            {
                col.Add(name, value);
            } else {
                List<KeyValuesPair> items = new List<KeyValuesPair>();
                int size = col.Count;
                for (int i = index; i < size; i++) {
                    string key = col.GetKey(index);
                    items.Add(new KeyValuesPair {
                        Name = key,
                        Values = col.GetValues(index),
                    });
                    col.Remove(key);
                }
                
                col.Add(name, value);

                foreach (var item in items) {
                    foreach (var v in item.Values) {
                        col.Add(item.Name, v);
                    }
                }
            }
        }
    }
}
