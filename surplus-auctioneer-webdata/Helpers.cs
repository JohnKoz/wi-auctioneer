using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using surplus_auctioneer_models;
using surplus_auctioneer_webdata;
using System.Text.RegularExpressions;

namespace surplus_auctioneer_webdata
{
    public static class Helpers
    {
        public static List<Auction> GetAllAuctions()
        {

            ISurplusAuctionData ilData = new IllinoisAuctionData();

            var allAuctions = ilData.GetAllAuctions(false, false, null);

            ISurplusAuctionData mnData = new MinnesotaAuctionData();

            allAuctions = allAuctions.Concat(mnData.GetAllAuctions(false, false, null)).ToList<Auction>();

            ISurplusAuctionData wiData = new WisconsinAuctionData();

            allAuctions = allAuctions.Concat(wiData.GetAllAuctions(false, false, null)).ToList<Auction>();

            return allAuctions.ToList<Auction>();
        }

        public static Image GetImageFromURL(string url)
        {
            if (url.ToLower().Contains("none"))
                return null;

            Image img;
            try
            {
                WebClient wc = new WebClient();
                byte[] bytes = wc.DownloadData(url);
                MemoryStream ms = new MemoryStream(bytes);
                img = System.Drawing.Image.FromStream(ms);
            }
            catch
            {
                return null;
            }
            return img;
        }

        static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);
        public static string StripHTMLTags(string source)
        {
            return _htmlRegex.Replace(source, string.Empty);
        }

        public static String GetDataFromUrl(string url, string method = "GET")
        {
            string data = "";

#if DEBUG
            System.Net.ServicePointManager.Expect100Continue = false;
#endif

            HttpWebRequest request =
                (HttpWebRequest) WebRequest.Create(url);

            request.UseDefaultCredentials = true;
            request.AllowAutoRedirect = true;
            request.UserAgent = ".NET Framework";
            request.Method = method;
            request.ContentLength = 0;
            
            try
            {
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    data = readStream.ReadToEnd();

                    response.Close();
                    readStream.Close();

                    response.Dispose();
                    readStream.Dispose();
                }
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    data = new StreamReader(wex.Response.GetResponseStream())
                        .ReadToEnd();
                }
            }

            return data;
        }
    }
}
