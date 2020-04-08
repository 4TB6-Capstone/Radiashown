namespace GUI_Bitmap_Desktop
{
    partial class Radiashown
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Radiashown));
            this.startButton = new System.Windows.Forms.Button();
            this.emergencyButton = new System.Windows.Forms.Button();
            this.homeCheckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.setupButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.startButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.startButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startButton.Location = new System.Drawing.Point(1049, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(175, 51);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start Sweep";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // emergencyButton
            // 
            this.emergencyButton.AccessibleName = "";
            this.emergencyButton.BackColor = System.Drawing.Color.Firebrick;
            this.emergencyButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.emergencyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.emergencyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emergencyButton.Location = new System.Drawing.Point(1049, 69);
            this.emergencyButton.Name = "emergencyButton";
            this.emergencyButton.Size = new System.Drawing.Size(175, 51);
            this.emergencyButton.TabIndex = 6;
            this.emergencyButton.Text = "Emergency Stop";
            this.emergencyButton.UseVisualStyleBackColor = false;
            this.emergencyButton.Visible = false;
            this.emergencyButton.Click += new System.EventHandler(this.emergencyButton_Click);
            // 
            // homeCheckBox
            // 
            this.homeCheckBox.AutoSize = true;
            this.homeCheckBox.Location = new System.Drawing.Point(1082, 215);
            this.homeCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.homeCheckBox.Name = "homeCheckBox";
            this.homeCheckBox.Size = new System.Drawing.Size(110, 17);
            this.homeCheckBox.TabIndex = 7;
            this.homeCheckBox.Text = "Robots Are Home";
            this.homeCheckBox.UseVisualStyleBackColor = true;
            this.homeCheckBox.Click += new System.EventHandler(this.home_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(1032, 962);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.InitialImage")));
            this.pictureBox3.Location = new System.Drawing.Point(1102, 962);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 1000);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // setupButton
            // 
            this.setupButton.AccessibleName = "simButton";
            this.setupButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.setupButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.setupButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.setupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupButton.Location = new System.Drawing.Point(1049, 252);
            this.setupButton.Name = "setupButton";
            this.setupButton.Size = new System.Drawing.Size(175, 51);
            this.setupButton.TabIndex = 5;
            this.setupButton.Text = "Simulation";
            this.setupButton.UseVisualStyleBackColor = false;
            this.setupButton.Click += new System.EventHandler(this.simButton_Click);
            // 
            // Radiashown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1269, 1061);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.homeCheckBox);
            this.Controls.Add(this.emergencyButton);
            this.Controls.Add(this.setupButton);
            this.Controls.Add(this.startButton);
            this.Name = "Radiashown";
            this.Text = "Radiashown";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button emergencyButton;
        private System.Windows.Forms.CheckBox homeCheckBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button setupButton;
    }
}

