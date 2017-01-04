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

namespace surplus_auctioneer_webdata
{
    public static class Helpers
    {
        public static List<Auction> GetAllAuctions()
        {
            ISurplusAuctionData wiData = new WisconsinAuctionData();

            var allAuctions = wiData.GetAllAuctions(false, false, null);

            ISurplusAuctionData ilData = new IllinoisAuctionData();

            allAuctions = allAuctions.Concat(ilData.GetAllAuctions(false, false, null)).ToList<Auction>();

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

        public static String GetDataFromUrl(string url)
        {

#if DEBUG
            System.Net.ServicePointManager.Expect100Continue = false;
#endif

            HttpWebRequest request =
                (HttpWebRequest) WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            string data = "";

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
            }

            return data;
        }
    }
}
