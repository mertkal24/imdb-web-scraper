using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Imdb.DataAccessLayer.Entity;
using Imdb.ImdbCore;


namespace Imdb.UserInterface
{
    public partial class Form1 : Form
    {
        MovieManagement manage = new MovieManagement();
        CastManagement castManage = new CastManagement();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void getMovie_Click(object sender, EventArgs e)
        {
            moviesListBox.Items.Clear();
            foreach (Movie item in manage.FindMovie(searchTxt.Text))
            {
                moviesListBox.Items.Add(item);
            }

        }

        private void moviesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            directorListBox.Items.Clear();
            writerListbox.Items.Clear();
            actorListBox.Items.Clear();
            Movie movie = (Movie)moviesListBox.SelectedItem;
            manage.FindMovieDb(movie.Link);
            if(manage.FindMovieDb(movie.Link))
            {
               movie=manage.GetMovieInDb(movie.Link);
                foreach (Cast director in manage.GetDirector(movie.MovieID))
                {
                    directorListBox.Items.Add(director);
                }
                foreach(Cast writer in manage.GetWriter(movie.MovieID))
                {
                    writerListbox.Items.Add(writer);
                }
                foreach (Cast star in manage.GetActor(movie.MovieID))
                {
                    actorListBox.Items.Add(star);
                }
                try
                {
                    moviePosterPictureBox.Load(movie.PictureLink);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Resim Bulunamadı: " + ex.Message);

                }
                MovieDescriptionLbl.Text = "Movie Description \n" + movie.MovieDescription;

            }
            else
            {
                manage.GetMovieInImdbAndInsertDatabase(movie);                               
                MovieDescriptionLbl.Text +="\n"+ movie.MovieDescription;
                foreach  (Cast actor in manage.GetActor(movie.MovieID))
                {
                    actorListBox.Items.Add(actor);
                }
                foreach (Cast director in manage.GetDirector(movie.MovieID))
                {
                    directorListBox.Items.Add(director);
                }
                foreach (Cast writer in manage.GetWriter(movie.MovieID))
                {
                    writerListbox.Items.Add(writer);
                }
                try
                {
                    moviePosterPictureBox.Load(movie.PictureLink);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Resim Bulunamadı: " + ex.Message);

                }

            }
        }

        private void actorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cast newCast =(Cast)actorListBox.SelectedItem;
            CastForm castForm = new CastForm();
            newCast = castManage.GetCastDetailImdb(newCast);
            castForm.cast = newCast;
            this.Hide();
            castForm.ShowDialog();
            this.Show();
            
            
        }

        private void directorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cast newCast = (Cast)directorListBox.SelectedItem;
            CastForm castForm = new CastForm();
            newCast = castManage.GetCastDetailImdb(newCast);
            castForm.cast = newCast;
            this.Hide();
            castForm.ShowDialog();
            this.Show();
        }

        private void writerListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cast newCast = (Cast)writerListbox.SelectedItem;
            CastForm castForm = new CastForm();
            newCast = castManage.GetCastDetailImdb(newCast);
            castForm.cast = newCast;
            this.Hide();
            castForm.ShowDialog();
            this.Show();
        }
    }
}
