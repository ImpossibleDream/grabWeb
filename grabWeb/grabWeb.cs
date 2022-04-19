using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace grabWeb
{
    class grabWeb
    {
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient ())
            {
                string html = client.DownloadString("https://www.microsoft.com/en-us/translator/business/languages");
                //Console.WriteLine(html);
                //Console.ReadLine();

                using (StreamWriter sw = new StreamWriter("C:\\Users\\admin\\Desktop\\Microsoft Translator languages.html"))
                {
                    sw.Write(TranslatorLanguage (html));

                }
                Console.ReadLine();
            }
        }

        public static  string TranslatorLanguage(string htmlStr)
        {
            string Language;
            bool exist=true;

            /*string withoutNString = htmlStr.Replace("\n", "");
            string withoutRString = withoutNString.Replace("\r", "");
            string withoutTString = withoutRString.Replace("\t", "");
            string newString = withoutTString.Replace("\\", "    ");

            htmlStr  = Regex.Match(newString, @"<table.*>.*</table>").ToString();
            htmlStr = Regex.Replace(htmlStr, @"<div.*>.*</div>", "", RegexOptions.IgnoreCase);
            htmlStr = Regex.Replace(htmlStr, @"<p.*>.*</p>", "", RegexOptions.IgnoreCase);
            Regex reg = new Regex(@"<table.*?>[\s\S]*?<\/table>");
            MatchCollection match = reg.Matches(htmlStr);
            string newHtml = match[0].ToString();
            return newHtml;*/

            htmlStr = Regex.Match (htmlStr ,@"<table.*?>[\s\S]*?<\/table>").ToString();
            htmlStr = Regex.Replace(htmlStr , "âœ”", "true");
            htmlStr = Regex.Replace(htmlStr, "â€“", "-");
            return htmlStr ;
        }

    }
}