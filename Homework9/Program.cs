using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections;

namespace pachong
{
    class Program
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            Program myCrawler = new Program();
            string startUrl = "https://baidu.com/";
            if (args.Length >= 1) startUrl = args[0];

            myCrawler.urls.Add(startUrl, false);
            
            new Thread(myCrawler.Crawl).Start();
            
            Console.ReadLine();
        }

        private void Crawl()
        {
            Console.WriteLine("开始");
            //while (true)
            //{
            //    string current = null;
            //    foreach (string url in urls.Keys)
            //    {
            //        if ((bool)urls[url]) continue;
            //        current = url;
            //    }
            //    if (current == null || count > 10) break;

            //    Console.WriteLine("下载页面" + current);

            //    string html = DownLoad(current);

            //    urls[current] = true;
            //    count++;

            //    Parse(html);

            //}
            //Parallel.For(0, 10, i =>
            //{
            //    string current = null;
            //    foreach (string url in urls.Keys)
            //    {
            //        if ((bool)urls[url]) continue;

            //        current = url;
            //    }
            //    //if (current == null || count > 10)

            //    Console.WriteLine("下载页面"+current);

            //    string html = DownLoad(current);

            //    urls[current] = true;
            //    count++;

            //    Parse(html);
            //});

            ParallelLoopResult result = Parallel.For(0, 50, (i, state) =>
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                    //Thread.Sleep(1000);
                }
                if (current == null) state.Break();
                Console.WriteLine("下载页面" + current);

                string html = DownLoad(current);

                urls[current] = true;
                count++;

                Parse(html);

            });
            Console.WriteLine("结束");
            Console.WriteLine(DateTime.Now);
            Console.ReadLine();
        }

        public string DownLoad(string url)
        {
            try
            {
                
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                
                return html;
            }
            catch(Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"','\\','#',' ','>');
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }

}
