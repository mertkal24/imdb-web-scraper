using Imdb.DataAccessLayer.Context;
using Imdb.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imdb.DataAccessLayer.Function
{
    public class CastDal
    {
        
        public void InsertCast(Cast cast)
        {
            ImdbContext context = new ImdbContext();
            context.Casts.Add(cast);
            context.SaveChanges();
        }
        public bool FindCast(string castLink)
        {
            ImdbContext context = new ImdbContext();
            return context.Casts.Any(x => x.Link == castLink);
        }
        public Cast GetCast(string castLink)
        {
            ImdbContext context = new ImdbContext();
            Cast nCast = context.Casts.First(x => x.Link == castLink);
            return nCast; 
        }
    }
}
