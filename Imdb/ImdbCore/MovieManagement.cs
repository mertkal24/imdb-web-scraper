
using Imdb.DataAccessLayer.Context;
using Imdb.DataAccessLayer.Entity;
using Imdb.DataAccessLayer.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;



namespace Imdb.ImdbCore
{
  public class MovieManagement
    {
        MovieDataAccessLayer dataAccess = new MovieDataAccessLayer();
        CastOfMovieDal castOfMoviedal = new CastOfMovieDal();
        CastDal castDal = new CastDal();
        ImdbContext context = new ImdbContext();
        public List<Movie> FindMovie(string movieName)
        {
            List<Movie> movieList = new List<Movie>();
            WebClient wClient = new WebClient();
            string result = wClient.DownloadString("https://www.imdb.com/find?q=" + movieName);
            string startKey = "<table class=\"findList\">";
            string endKey = "</table>";
            int startIndex = result.IndexOf(startKey);
            int endIndex = result.IndexOf(endKey, startIndex);
            result = result.Substring(startIndex, endIndex - startIndex);
            startKey = " <td class=\"result_text\"> <a href=\"";
            endKey = "\" >";
            startIndex = result.IndexOf(startKey) + startKey.Length;
            endIndex = result.IndexOf(endKey, startIndex);
            while (startIndex > startKey.Length)
            {
                Movie film = new Movie();
                film.Link = result.Substring(startIndex, endIndex - startIndex);
                startIndex = endIndex + endKey.Length;
                endKey = "</a>";
                endIndex = result.IndexOf(endKey, startIndex);
                film.Name = result.Substring(startIndex, endIndex - startIndex);
                startKey = " (";
                endKey = ") ";
                startIndex = result.IndexOf(startKey, endIndex) + startKey.Length;
                endIndex = result.IndexOf(endKey, startIndex);
                int defaultDate;
                bool control;
                control = int.TryParse(result.Substring(startIndex, endIndex - startIndex), out defaultDate);
                film.Date = (control ? Convert.ToInt32(result.Substring(startIndex, endIndex - startIndex)) : 0);
                startKey = "<td class=\"result_text\"> <a href=\"";
                endKey = "\" >";
                startIndex = result.IndexOf(startKey, endIndex) + startKey.Length;
                endIndex = result.IndexOf(endKey, startIndex);
                movieList.Add(film);
            }
            //GetCast


            return movieList;
        }
        public bool FindMovieDb(string movieLink)
        {
            return dataAccess.FindMovie(movieLink);
        }
        public Movie GetMovieInDb(string movieLink)
        {
            return dataAccess.GetMovie(movieLink);
        }       
        public Movie GetMovieInImdbAndInsertDatabase(Movie movie)
        {
            //GetPoster
            string key, endKey;
            int startIndex, endIndex;
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString("https://www.imdb.com" + movie.Link);           
            key = "<div class=\"poster\">";
            endKey = "</div>";
            startIndex = result.IndexOf(key) + key.Length;
            endIndex = result.IndexOf(endKey, startIndex);
            if (endIndex == -1)
            {
                movie.PictureLink= "https://lh3.googleusercontent.com/proxy/zEWD2kQb4zY6ndsFwqBHxPaMJVVL-UO2214EsrvzRnq7VVAxJEUVmgUH7-c1jMYWB-4Uc8KLkMnazu1xLVrHJ97kOAUb8lDECklRXcYLrsNnRX_Z0OGwfAg";
            }
            string picture = result.Substring(startIndex, endIndex - startIndex);
            key = "src=\"";
            endKey = "\" />";
            startIndex = picture.IndexOf(key) + key.Length;
            endIndex = picture.IndexOf(endKey, startIndex);
            if (endIndex == -1)
            {
                movie.PictureLink = "https://lh3.googleusercontent.com/proxy/zEWD2kQb4zY6ndsFwqBHxPaMJVVL-UO2214EsrvzRnq7VVAxJEUVmgUH7-c1jMYWB-4Uc8KLkMnazu1xLVrHJ97kOAUb8lDECklRXcYLrsNnRX_Z0OGwfAg"; 
            }
            picture = picture.Substring(startIndex, endIndex - startIndex);
            movie.PictureLink = picture;
            //GetDescription           
            result = webClient.DownloadString("https://www.imdb.com" + movie.Link);
            key = "<div class=\"summary_text\">";
            endKey = "</div>";
            startIndex = result.IndexOf(key) + key.Length;
            endIndex = result.IndexOf(endKey, startIndex);
             string descResult = result.Substring(startIndex, endIndex - startIndex).Trim();
            key = "<a href=\"";
            endKey = "</a>";
            startIndex = descResult.IndexOf(key);
            if (startIndex != -1)
            {
                endIndex = descResult.IndexOf(endKey, startIndex) + endKey.Length + key.Length;
                string delete = descResult.Substring(startIndex, endIndex - startIndex);
                descResult = descResult.Replace(delete, " ");
            }
            movie.MovieDescription = descResult;
            //SubTitleLink
            string subTitleresult = webClient.DownloadString("https://turkcealtyazi.org/find.php?cat=sub&find=" + movie.Name);
            key = "<div class=\"portalust\">";
            endKey = "title=";
            startIndex = subTitleresult.IndexOf(key);
            endIndex = subTitleresult.IndexOf(endKey, startIndex);
            subTitleresult = subTitleresult.Substring(startIndex, endIndex - startIndex);
            key = "<a href=\"";
            endKey = "\"";
            startIndex = subTitleresult.IndexOf(key) + key.Length;
            endIndex = subTitleresult.IndexOf(endKey, startIndex);
            subTitleresult = subTitleresult.Substring(startIndex, endIndex - startIndex);
            subTitleresult = webClient.DownloadString("https://turkcealtyazi.org" + subTitleresult);
            if (subTitleresult.Contains("/"))
            {
                key = "id=\"altyazilar";
                endKey = "title=";
                startIndex = subTitleresult.IndexOf(key);
                endIndex = subTitleresult.IndexOf(endKey, startIndex) + endKey.Length;
                subTitleresult = subTitleresult.Substring(startIndex, endIndex - startIndex);
                key = "<a itemprop=\"url\"";
                endKey = "html\" ";
                startIndex = subTitleresult.IndexOf(key) + key.Length;
                endIndex = subTitleresult.IndexOf(endKey, startIndex) + endKey.Length;
                subTitleresult = subTitleresult.Substring(startIndex, endIndex - startIndex);
                key = "href=\"";
                endKey = "\"";
                startIndex = subTitleresult.IndexOf(key) + key.Length;
                endIndex = subTitleresult.IndexOf(endKey, startIndex);
                subTitleresult = subTitleresult.Substring(startIndex, endIndex - startIndex);
                movie.SubTitleLink = subTitleresult;
            }
            else
            {
                movie.SubTitleLink = "Yok";
            }         
            dataAccess.InsertMovie(movie);            
            //ACTOR
            key = "\"actor\":";
            endKey = ",\n  \"";
            startIndex = result.IndexOf(key);
            endIndex = result.IndexOf(endKey, startIndex);
            string info = result.Substring(startIndex, endIndex - startIndex);
            if (startIndex > -1)
            {
                key = "\"Person\",";
                endKey = "}";
                startIndex = info.IndexOf(key) + key.Length;
                endIndex = info.IndexOf(endKey, startIndex) + endKey.Length;
                while (startIndex > key.Length)
                {
                    CastOfMovie ncast = new CastOfMovie();
                    Cast newCast = new Cast();
                    key = "\"url\": \"";
                    endKey = "\",";
                    startIndex = info.IndexOf(key, startIndex) + key.Length;
                    endIndex = info.IndexOf(endKey, startIndex);
                    newCast.Link = info.Substring(startIndex, endIndex - startIndex);
                    key = "\"name\": \"";
                    endKey = "\"";
                    startIndex = info.IndexOf(key, startIndex) + key.Length;
                    endIndex = info.IndexOf(endKey, startIndex);
                    newCast.Name = info.Substring(startIndex, endIndex - startIndex);
                    key = "\"Person\",";
                    endKey = "}";
                    startIndex = info.IndexOf(key, endIndex) + key.Length;
                    if (castDal.FindCast(newCast.Link))
                    {

                        newCast = castDal.GetCast(newCast.Link);
                        ncast.CastID = newCast.CastID;
                        ncast.MovieID = movie.MovieID;
                        ncast.RoleID = 3;
                        newCast.CastAndMovie.Add(ncast);
                        movie.CastAndMovie.Add(ncast);
                        castOfMoviedal.InsertCastOfMovie(ncast);
                    }
                    else
                    {
                        castDal.InsertCast(newCast);                   
                        ncast.CastID = newCast.CastID;
                        ncast.MovieID = movie.MovieID;
                        ncast.RoleID = 3;
                        newCast.CastAndMovie.Add(ncast);
                        movie.CastAndMovie.Add(ncast);
                        castOfMoviedal.InsertCastOfMovie(ncast);
                    }

                }
            }
            //Director
            key = "\"director\":";
            endKey = "\"creator\":";
            startIndex = result.IndexOf(key);
            if (startIndex > -1)
            {
                endIndex = result.IndexOf(endKey, startIndex);
                if (endIndex == -1)
                {
                    endKey = "  },\n";
                    endIndex = result.IndexOf(endKey, startIndex);
                }
                info = result.Substring(startIndex, endIndex - startIndex);
                key = "\"Person\",";
                endKey = "}";
                startIndex = info.IndexOf(key) + key.Length;
                endIndex = info.IndexOf(endKey, startIndex) + endKey.Length;
                List<Cast> newDirector = new List<Cast>();
                while (startIndex > key.Length)
                {
                    CastOfMovie ncast = new CastOfMovie();
                    Cast newCast = new Cast();
                    key = "\"url\": \"";
                    endKey = "\",";
                    startIndex = info.IndexOf(key, startIndex) + key.Length;
                    endIndex = info.IndexOf(endKey, startIndex);
                    newCast.Link = info.Substring(startIndex, endIndex - startIndex);
                    key = "\"name\": \"";
                    endKey = "\"";
                    startIndex = info.IndexOf(key, startIndex) + key.Length;
                    endIndex = info.IndexOf(endKey, startIndex);
                    newCast.Name = info.Substring(startIndex, endIndex - startIndex);
                    key = "\"Person\",";
                    endKey = "}";
                    startIndex = info.IndexOf(key, endIndex) + key.Length;
                    endIndex = info.IndexOf(endKey, startIndex) + endKey.Length;
                    if (castDal.FindCast(newCast.Link))
                    {
                        newCast = castDal.GetCast(newCast.Link);
                        ncast.CastID = newCast.CastID;
                        ncast.MovieID = movie.MovieID;
                        ncast.RoleID = 1;
                        newCast.CastAndMovie.Add(ncast);
                        movie.CastAndMovie.Add(ncast);
                        castOfMoviedal.InsertCastOfMovie(ncast);
                    }
                    else
                    {
                        castDal.InsertCast(newCast);
                        ncast.CastID = newCast.CastID;
                        ncast.MovieID = movie.MovieID;
                        ncast.RoleID = 1;
                        newCast.CastAndMovie.Add(ncast);
                        movie.CastAndMovie.Add(ncast);
                        castOfMoviedal.InsertCastOfMovie(ncast);
                    }
                   
                }
            }
            //Writer
            key = "\"creator\":";
            endKey = "\"@type\": \"Organization\",";
            startIndex = result.IndexOf(key);
            if (startIndex > -1)
            {
                endIndex = result.IndexOf(endKey, startIndex);
                if (endIndex == -1)
                {
                    endKey = " },\n";
                }
                endIndex = result.IndexOf(endKey, startIndex);
                info = result.Substring(startIndex, endIndex - startIndex);
                key = "\"Person\",";
                endKey = "}";
                startIndex = info.IndexOf(key) + key.Length;
                endIndex = info.IndexOf(endKey, startIndex) + endKey.Length;
                List<Movie> newWriter = new List<Movie>();
                while (startIndex > key.Length)
                {
                    CastOfMovie ncast = new CastOfMovie();
                    Cast newCast = new Cast();
                    key = "\"url\": \"";
                    endKey = "\",";
                    startIndex = info.IndexOf(key, startIndex) + key.Length;
                    endIndex = info.IndexOf(endKey, startIndex);
                    newCast.Link = info.Substring(startIndex, endIndex - startIndex);
                    key = "\"name\": \"";
                    endKey = "\"";
                    startIndex = info.IndexOf(key, startIndex) + key.Length;
                    endIndex = info.IndexOf(endKey, startIndex);
                    newCast.Name = info.Substring(startIndex, endIndex - startIndex);
                    key = "\"Person\",";
                    endKey = "}";
                    startIndex = info.IndexOf(key, endIndex) + key.Length;
                    endIndex = info.IndexOf(endKey, startIndex) + endKey.Length;
                    if (castDal.FindCast(newCast.Link))
                    {
                        newCast = castDal.GetCast(newCast.Link);
                        ncast.CastID = newCast.CastID;
                        ncast.MovieID = movie.MovieID;
                        ncast.RoleID = 2;                        
                        movie.CastAndMovie.Add(ncast);
                        castOfMoviedal.InsertCastOfMovie(ncast);
                    }
                    else
                    {
                        castDal.InsertCast(newCast);
                        ncast.CastID = newCast.CastID;
                        ncast.MovieID = movie.MovieID;
                        ncast.RoleID = 2;
                        newCast.CastAndMovie.Add(ncast);
                        movie.CastAndMovie.Add(ncast);
                        castOfMoviedal.InsertCastOfMovie(ncast);
                    }           
                }
            }
            return movie;
        }
        public List<Cast> GetDirector(int movieId)
        {
            List<Cast> director = new List<Cast>();           
            var query = context.Casts.Join(context.CastOfMovies, c =>c.CastID, co => co.CastID,(c, co) => new { Cast = c, CastOfMovie = co}).Where(x=>x.CastOfMovie.RoleID==1).ToList().Where(x=>x.CastOfMovie.MovieID==movieId).ToList();
            foreach (var item in query)
            {
                director.Add(item.Cast);
            }
            return director;
        }
        public List<Cast> GetWriter(int movieId)
        {
            List<Cast> writer = new List<Cast>();
            var query = context.Casts.Join(context.CastOfMovies, c => c.CastID, co => co.CastID, (c, co) => new { Cast = c, CastOfMovie = co }).Where(x => x.CastOfMovie.RoleID == 2).ToList().Where(x => x.CastOfMovie.MovieID == movieId).ToList();  
           foreach(var item in query)
            {
                writer.Add(item.Cast);
            }
            return writer;
        }
        public List<Cast> GetActor(int movieId)
        {
            List<Cast> actor = new List<Cast>();
            var query = context.Casts.Join(context.CastOfMovies, c => c.CastID, co => co.CastID, (c, co) => new { Cast = c, CastOfMovie = co }).Where(x => x.CastOfMovie.RoleID == 3).ToList().Where(x => x.CastOfMovie.MovieID == movieId).ToList();
            foreach (var item in query)
            {
                actor.Add(item.Cast);
            }
            return actor;
        }  
    }
   
}
