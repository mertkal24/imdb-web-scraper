using System;
using System.Collections.Generic;
using System.Text;
using Imdb.DataAccessLayer.Entity;

namespace Imdb.DataAccessLayer.Entity
{
   public class CastOfMovie
    {
        public int MovieID { get; set; }
        public Movie Movie { get; set; }
        public int CastID { get; set; }
        public Cast Cast { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}
