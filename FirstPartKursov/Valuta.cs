using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Net;
using System.Xml.Linq;

namespace FirstPartKursov
{
    class Valuta
    {
        public static double usd;
        public static double euro;

        /// <summary>
        /// функция скачивания содержимого с сайта цбр
        /// </summary>
        /// <returns></returns>
        public string download_site()
        {
            string content = "";
            HttpWebRequest req;
            HttpWebResponse resp;
            StreamReader sr;

            req = (HttpWebRequest)WebRequest.Create("http://www.cbr.ru/scripts/XML_daily.asp");
            resp = (HttpWebResponse)req.GetResponse();
            sr = new StreamReader(resp.GetResponseStream(), Encoding.GetEncoding("windows-1251"));
            content = sr.ReadToEnd();
            sr.Close();
            return content;


        }

        /// <summary>
        /// функция поиска нужных курсов (евро, доллар)
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public string get_valute(string html)
        {
            string valute = "";
            bool check = false;
            using (XmlReader reader = XmlReader.Create(new StringReader(html)))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Text:
                            if (check)
                            {
                                valute += reader.Value + Environment.NewLine;
                                check = false;
                            }
                            if (reader.Value.Equals("Доллар США") || reader.Value.Equals("Евро"))
                            {
                                check = true;
                                valute += reader.Value + Environment.NewLine;
                                break;
                            }
                            break;
                    }
                }
            }
            valute = valute.Replace("\r\n", "|");
            usd = Convert.ToDouble(valute.Split('|')[1]);
            euro = Convert.ToDouble(valute.Split('|')[3]);
            valute = valute.TrimEnd('|');
            return valute;
        }
    }
}
