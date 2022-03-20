
namespace EyeTracking
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChooseCamera = new System.Windows.Forms.ComboBox();
            this.Start = new System.Windows.Forms.Button();
            this.CameraView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CameraView)).BeginInit();
            this.SuspendLayout();
            // 
            // ChooseCamera
            // 
            this.ChooseCamera.FormattingEnabled = true;
            this.ChooseCamera.Location = new System.Drawing.Point(11, 6);
            this.ChooseCamera.Name = "ChooseCamera";
            this.ChooseCamera.Size = new System.Drawing.Size(244, 21);
            this.ChooseCamera.TabIndex = 0;
            this.ChooseCamera.SelectedIndexChanged += new System.EventHandler(this.ChooseCamera_SelectedIndexChanged);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(266, 6);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(85, 20);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // CameraView
            // 
            this.CameraView.Location = new System.Drawing.Point(11, 40);
            this.CameraView.Name = "CameraView";
            this.CameraView.Size = new System.Drawing.Size(640, 480);
            this.CameraView.TabIndex = 2;
            this.CameraView.TabStop = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(680, 537);
            this.Controls.Add(this.CameraView);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.ChooseCamera);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CameraView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ChooseCamera;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.PictureBox CameraView;
    }
}

