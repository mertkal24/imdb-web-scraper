using Imdb.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Imdb.UserInterface
{
    public partial class CastForm : Form
    {
        public CastForm()
        {

            InitializeComponent();
        }
        public Cast cast { get; set; }
        public Form1 backForm { get; set;}

        private void castBio_Click(object sender, EventArgs e)
        {

        }

        private void CastForm_Load(object sender, EventArgs e)
        {
            castPictureBox.Load(cast.Image);
            castBio.Text = cast.Bio;            
            dateOfBorn.Text = cast.Born.Day.ToString()+"."+cast.Born.Month.ToString()+"."+cast.Born.Year.ToString();

        }

        private void backMoviePage_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
