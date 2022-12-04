using Imdb.DataAccessLayer.Context;
using Imdb.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imdb.DataAccessLayer.Function
{
   public class MovieDataAccessLayer
    {
        ImdbContext context = new ImdbContext();
        public void InsertMovie(Movie movie)
        {
            ImdbContext context = new ImdbContext();
            context.Movies.Add(movie);
            context.SaveChanges();
        }
        public bool FindMovie(string movieLink)
        {
            ImdbContext context = new ImdbContext();
            return context.Movies.Any(x => x.Link == movieLink);
        }
        public Movie GetMovie(string movieLink)
        {
            ImdbContext context = new ImdbContext();
            return  context.Movies.First(x => x.Link == movieLink);
        }
       
    }
}
