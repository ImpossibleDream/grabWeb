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

        public static string TranslatorLanguage(string htmlStr)
        {
            string Language;
            bool exist=true;

            /*string reg_style = "<style[^>]*[\\s\\S]*?<\\/style>";
            string reg_script = "<script[^>]*[\\s\\S]*?<\\/script>";
            string reg_html = "<[^>]+>";

            htmlStr = Regex.Replace(htmlStr, reg_style,"");
            htmlStr = Regex.Replace(htmlStr, reg_script, "");
            //htmlStr = Regex.Replace(htmlStr, reg_html, "");
            htmlStr = Regex.Replace(htmlStr, "\\s*|\t|\r|\n", "");
            //htmlStr = htmlStr.Replace("", "");
            return htmlStr.Trim();*/

            string withoutNString = htmlStr.Replace("\n", " ");
            string withoutRString = withoutNString.Replace("\r", " ");
            string withoutTString = withoutRString.Replace("\t", " ");
            string newString = withoutTString.Replace("\\", " ");

            htmlStr  = Regex.Match(newString, @"<table.*>.*</table>").ToString();
            //htmlStr  = Regex.Replace(htmlStr , @"<!--(?s).*?-->", "", RegexOptions.IgnoreCase);
            //htmlStr  = Regex.Replace(htmlStr , @" ", "", RegexOptions.IgnoreCase);
            htmlStr = Regex.Replace(htmlStr, @"<div.*>.*</div>", "", RegexOptions.IgnoreCase);
            htmlStr = Regex.Replace(htmlStr, @"<p.*>.*</p>", "", RegexOptions.IgnoreCase);
            Regex reg = new Regex(@"<table.*?>[\s\S]*?<\/table>");
            MatchCollection match = reg.Matches(htmlStr);
            string newHtml = match[0].ToString();
            return newHtml;
            //return htmlStr.Trim();
        }

    }
}