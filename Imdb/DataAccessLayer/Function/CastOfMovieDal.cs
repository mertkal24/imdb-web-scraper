using Imdb.DataAccessLayer.Context;
using Imdb.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.DataAccessLayer.Function
{
   public class CastOfMovieDal
    {
        
        public void InsertCastOfMovie (CastOfMovie newCastOfMovie)
        {
            ImdbContext context = new ImdbContext();
            context.CastOfMovies.Add(newCastOfMovie);
            context.SaveChanges();
        }
    }
}
