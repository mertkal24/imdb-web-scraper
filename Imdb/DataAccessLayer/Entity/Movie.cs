using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.DataAccessLayer.Entity
{
    public class Movie
    {
        public Movie()
        {
            this.CastAndMovie = new List<CastOfMovie>();
        }
        public override string ToString()
        {
            return this.Name + " (" + this.Date + ")";
        }
        public int MovieID { get; set; }
        public string Name { get; set; }
        public int Date { get; set; }       
        public string Link { get; set;}
        public string PictureLink { get; set; }
        public string MovieDescription { get; set; }
        public string MovieLink { get; set; }
        public string SubTitleLink { get; set; }
        public string TorrentLink { get; set; }
        public List<CastOfMovie> CastAndMovie { get; set; }

    }
}
