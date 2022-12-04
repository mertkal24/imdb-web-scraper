
namespace Imdb.UserInterface
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.getMovie = new System.Windows.Forms.Button();
            this.moviesListBox = new System.Windows.Forms.ListBox();
            this.MovieDescriptionLbl = new System.Windows.Forms.Label();
            this.moviePosterPictureBox = new System.Windows.Forms.PictureBox();
            this.directorListBox = new System.Windows.Forms.ListBox();
            this.writerListbox = new System.Windows.Forms.ListBox();
            this.actorListBox = new System.Windows.Forms.ListBox();
            this.subTitleDowlandButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.moviePosterPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTxt
            // 
            this.searchTxt.Location = new System.Drawing.Point(29, 23);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(175, 27);
            this.searchTxt.TabIndex = 0;
            // 
            // getMovie
            // 
            this.getMovie.Location = new System.Drawing.Point(233, 21);
            this.getMovie.Name = "getMovie";
            this.getMovie.Size = new System.Drawing.Size(94, 29);
            this.getMovie.TabIndex = 1;
            this.getMovie.Text = "Getir";
            this.getMovie.UseVisualStyleBackColor = true;
            this.getMovie.Click += new System.EventHandler(this.getMovie_Click);
            // 
            // moviesListBox
            // 
            this.moviesListBox.FormattingEnabled = true;
            this.moviesListBox.ItemHeight = 20;
            this.moviesListBox.Location = new System.Drawing.Point(29, 92);
            this.moviesListBox.Name = "moviesListBox";
            this.moviesListBox.Size = new System.Drawing.Size(450, 164);
            this.moviesListBox.TabIndex = 2;
            this.moviesListBox.SelectedIndexChanged += new System.EventHandler(this.moviesListBox_SelectedIndexChanged);
            // 
            // MovieDescriptionLbl
            // 
            this.MovieDescriptionLbl.Location = new System.Drawing.Point(506, 280);
            this.MovieDescriptionLbl.Name = "MovieDescriptionLbl";
            this.MovieDescriptionLbl.Size = new System.Drawing.Size(327, 159);
            this.MovieDescriptionLbl.TabIndex = 3;
            this.MovieDescriptionLbl.Text = "Movie Description";
            // 
            // moviePosterPictureBox
            // 
            this.moviePosterPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.moviePosterPictureBox.Location = new System.Drawing.Point(506, 23);
            this.moviePosterPictureBox.Name = "moviePosterPictureBox";
            this.moviePosterPictureBox.Size = new System.Drawing.Size(327, 235);
            this.moviePosterPictureBox.TabIndex = 4;
            this.moviePosterPictureBox.TabStop = false;
            // 
            // directorListBox
            // 
            this.directorListBox.FormattingEnabled = true;
            this.directorListBox.ItemHeight = 20;
            this.directorListBox.Location = new System.Drawing.Point(183, 280);
            this.directorListBox.Name = "directorListBox";
            this.directorListBox.Size = new System.Drawing.Size(144, 164);
            this.directorListBox.TabIndex = 5;
            this.directorListBox.SelectedIndexChanged += new System.EventHandler(this.directorListBox_SelectedIndexChanged);
            // 
            // writerListbox
            // 
            this.writerListbox.FormattingEnabled = true;
            this.writerListbox.ItemHeight = 20;
            this.writerListbox.Location = new System.Drawing.Point(335, 280);
            this.writerListbox.Name = "writerListbox";
            this.writerListbox.Size = new System.Drawing.Size(144, 164);
            this.writerListbox.TabIndex = 6;
            this.writerListbox.SelectedIndexChanged += new System.EventHandler(this.writerListbox_SelectedIndexChanged);
            // 
            // actorListBox
            // 
            this.actorListBox.FormattingEnabled = true;
            this.actorListBox.ItemHeight = 20;
            this.actorListBox.Location = new System.Drawing.Point(29, 282);
            this.actorListBox.Name = "actorListBox";
            this.actorListBox.Size = new System.Drawing.Size(144, 164);
            this.actorListBox.TabIndex = 7;
            this.actorListBox.SelectedIndexChanged += new System.EventHandler(this.actorListBox_SelectedIndexChanged);
            // 
            // subTitleDowlandButton
            // 
            this.subTitleDowlandButton.Location = new System.Drawing.Point(385, 21);
            this.subTitleDowlandButton.Name = "subTitleDowlandButton";
            this.subTitleDowlandButton.Size = new System.Drawing.Size(94, 65);
            this.subTitleDowlandButton.TabIndex = 8;
            this.subTitleDowlandButton.Text = "Altyazı İndir";
            this.subTitleDowlandButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Actors";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Directors";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Writers";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 469);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.subTitleDowlandButton);
            this.Controls.Add(this.actorListBox);
            this.Controls.Add(this.writerListbox);
            this.Controls.Add(this.directorListBox);
            this.Controls.Add(this.moviePosterPictureBox);
            this.Controls.Add(this.MovieDescriptionLbl);
            this.Controls.Add(this.moviesListBox);
            this.Controls.Add(this.getMovie);
            this.Controls.Add(this.searchTxt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.moviePosterPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchTxt;
        private System.Windows.Forms.Button getMovie;
        private System.Windows.Forms.ListBox moviesListBox;
        private System.Windows.Forms.Label MovieDescriptionLbl;
        private System.Windows.Forms.PictureBox moviePosterPictureBox;
        private System.Windows.Forms.ListBox directorListBox;
        private System.Windows.Forms.ListBox writerListbox;
        private System.Windows.Forms.ListBox actorListBox;
        private System.Windows.Forms.Button subTitleDowlandButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

