using System;
using System.Collections.Generic;
using System.Text;
using Imdb.DataAccessLayer.Entity;

namespace Imdb.DataAccessLayer.Entity
{
   public class Cast
    {
        public Cast()
        {
            this.CastAndMovie = new List<CastOfMovie>();
        }
        public override string ToString()
        {
            return this.Name;
        }
        public int CastID { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime Born { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public List<CastOfMovie> CastAndMovie { get; set; }
    }
}
