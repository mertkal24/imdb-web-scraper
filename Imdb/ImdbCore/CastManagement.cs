using Imdb.DataAccessLayer.Entity;
using Imdb.DataAccessLayer.Function;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Imdb.ImdbCore
{
    public class CastManagement
    {
        CastDal castDal = new CastDal();
        public Cast GetCastDetailImdb(Cast cast)
        {
            WebClient wbClient = new WebClient();
            string directorPage = wbClient.DownloadString("https://www.imdb.com/" +cast.Link );
            string key = "<div class=\"name-trivia-bio-text\">";
            string endKey = "<span class=\"see-more inline nobr-only\">";
            int startIndex = directorPage.IndexOf(key);
            int endIndex;
            string info = "";
            if (startIndex == -1)
            {
                cast.Bio = "Biyografi Bilgisi Yok";
            }
            else
            {
                endIndex = directorPage.IndexOf(endKey, startIndex);
                info = directorPage.Substring(startIndex, endIndex - startIndex);
                key = "<div class=\"inline\">";
                endKey = "...";
                startIndex = info.IndexOf(key) + key.Length;
                endIndex = info.IndexOf(endKey, startIndex);
                if (endIndex == -1)
                {
                    endKey = ". ";
                    endIndex = info.IndexOf(endKey, startIndex);

                }
                info = info.Substring(startIndex, endIndex - startIndex);
                key = "<a href=\"";
                endKey = "\">";
                startIndex = info.IndexOf(key);
                while (startIndex > -1)
                {
                    endIndex = info.IndexOf(endKey, startIndex) + endKey.Length;
                    string delete = info.Substring(startIndex, endIndex - startIndex);
                    info = info.Replace(delete, " ");
                    startIndex = info.IndexOf(key);
                    if (startIndex != -1)
                    {
                        endIndex = info.IndexOf(endKey, startIndex);
                    }
                }
                info = info.Replace("</a>", " ");
                info = info.Trim();
                cast.Bio = info;
            }
            //image
            string castPicture = wbClient.DownloadString("https://www.imdb.com/" + cast.Link);
            key = "<td id=\"img_primary\">";
            endKey = "</div>";
            startIndex = castPicture.IndexOf(key) + key.Length;
            endIndex = castPicture.IndexOf(endKey, startIndex);
            info = castPicture.Substring(startIndex, endIndex - startIndex);
            key = "src=\"";
            endKey = "\" />";
            startIndex = info.IndexOf(key) + key.Length;
            endIndex = info.IndexOf(endKey, startIndex);
            if (endIndex == -1)
            {
                cast.Image = "https://m.besir.org.tr/img/resimyok.png";
            }
            else
            {
                info = info.Substring(startIndex, endIndex - startIndex);
                cast.Image = info;
            }
            //BornDate
            WebClient wc = new WebClient();
            string bornInfo = wc.DownloadString("https://www.imdb.com/" + cast.Link);
            key = "<div id=\"name-born-info\" class=\"txt-block\">";
            endKey = "<a href=\"";
            startIndex = bornInfo.IndexOf(key) + key.Length;
            endIndex = bornInfo.IndexOf(endKey, startIndex);
            bornInfo = bornInfo.Substring(startIndex, endIndex - startIndex);
            key = "<time datetime=\"";
            endKey = "\">";
            startIndex = bornInfo.IndexOf(key) + key.Length;
            endIndex = bornInfo.IndexOf(endKey, startIndex);
            bornInfo = bornInfo.Substring(startIndex, endIndex - startIndex);
            try
            {
                cast.Born = DateTime.Parse(bornInfo);
            }
            catch
            {
                cast.Born = DateTime.Parse("1.01.1753");
            }

            


            return cast;
        }
    }
}
