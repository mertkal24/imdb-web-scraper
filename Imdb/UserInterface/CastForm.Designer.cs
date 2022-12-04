
namespace Imdb.UserInterface
{
    partial class CastForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.castPictureBox = new System.Windows.Forms.PictureBox();
            this.knownForMovie = new System.Windows.Forms.ListBox();
            this.castBio = new System.Windows.Forms.Label();
            this.dateOfBorn = new System.Windows.Forms.Label();
            this.backMoviePage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.castPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // castPictureBox
            // 
            this.castPictureBox.Location = new System.Drawing.Point(37, 12);
            this.castPictureBox.Name = "castPictureBox";
            this.castPictureBox.Size = new System.Drawing.Size(216, 212);
            this.castPictureBox.TabIndex = 0;
            this.castPictureBox.TabStop = false;
            // 
            // knownForMovie
            // 
            this.knownForMovie.FormattingEnabled = true;
            this.knownForMovie.ItemHeight = 20;
            this.knownForMovie.Location = new System.Drawing.Point(37, 267);
            this.knownForMovie.Name = "knownForMovie";
            this.knownForMovie.Size = new System.Drawing.Size(216, 104);
            this.knownForMovie.TabIndex = 1;
            // 
            // castBio
            // 
            this.castBio.Location = new System.Drawing.Point(274, 12);
            this.castBio.Name = "castBio";
            this.castBio.Size = new System.Drawing.Size(244, 212);
            this.castBio.TabIndex = 2;
            this.castBio.Text = "Bio";
            this.castBio.Click += new System.EventHandler(this.castBio_Click);
            // 
            // dateOfBorn
            // 
            this.dateOfBorn.AutoSize = true;
            this.dateOfBorn.Location = new System.Drawing.Point(295, 267);
            this.dateOfBorn.Name = "dateOfBorn";
            this.dateOfBorn.Size = new System.Drawing.Size(50, 20);
            this.dateOfBorn.TabIndex = 3;
            this.dateOfBorn.Text = "label1";
            // 
            // backMoviePage
            // 
            this.backMoviePage.Location = new System.Drawing.Point(397, 357);
            this.backMoviePage.Name = "backMoviePage";
            this.backMoviePage.Size = new System.Drawing.Size(94, 70);
            this.backMoviePage.TabIndex = 4;
            this.backMoviePage.Text = "Film Sayfasına Dön";
            this.backMoviePage.UseVisualStyleBackColor = true;
            this.backMoviePage.Click += new System.EventHandler(this.backMoviePage_Click);
            // 
            // CastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 450);
            this.Controls.Add(this.backMoviePage);
            this.Controls.Add(this.dateOfBorn);
            this.Controls.Add(this.castBio);
            this.Controls.Add(this.knownForMovie);
            this.Controls.Add(this.castPictureBox);
            this.Name = "CastForm";
            this.Text = "CastForm";
            this.Load += new System.EventHandler(this.CastForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.castPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox castPictureBox;
        private System.Windows.Forms.ListBox knownForMovie;
        private System.Windows.Forms.Label castBio;
        private System.Windows.Forms.Label dateOfBorn;
        private System.Windows.Forms.Button backMoviePage;
    }
}