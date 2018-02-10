namespace VoicePad
{
    partial class VoicePad_Window
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
            this.VoiceBox = new System.Windows.Forms.TextBox();
            this.AsmBox = new System.Windows.Forms.TextBox();
            this.FileBox = new System.Windows.Forms.TextBox();
            this.InsertBtn = new System.Windows.Forms.Button();
            this.checkBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.commentBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // VoiceBox
            // 
            this.VoiceBox.BackColor = System.Drawing.Color.Black;
            this.VoiceBox.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoiceBox.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.VoiceBox.Location = new System.Drawing.Point(12, 45);
            this.VoiceBox.Name = "VoiceBox";
            this.VoiceBox.ReadOnly = true;
            this.VoiceBox.Size = new System.Drawing.Size(372, 30);
            this.VoiceBox.TabIndex = 0;
            // 
            // AsmBox
            // 
            this.AsmBox.BackColor = System.Drawing.Color.Black;
            this.AsmBox.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AsmBox.ForeColor = System.Drawing.Color.LimeGreen;
            this.AsmBox.Location = new System.Drawing.Point(12, 82);
            this.AsmBox.Multiline = true;
            this.AsmBox.Name = "AsmBox";
            this.AsmBox.ReadOnly = true;
            this.AsmBox.Size = new System.Drawing.Size(280, 31);
            this.AsmBox.TabIndex = 1;
            // 
            // FileBox
            // 
            this.FileBox.BackColor = System.Drawing.Color.Black;
            this.FileBox.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileBox.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FileBox.Location = new System.Drawing.Point(12, 119);
            this.FileBox.Multiline = true;
            this.FileBox.Name = "FileBox";
            this.FileBox.ReadOnly = true;
            this.FileBox.Size = new System.Drawing.Size(280, 407);
            this.FileBox.TabIndex = 2;
            // 
            // InsertBtn
            // 
            this.InsertBtn.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertBtn.Location = new System.Drawing.Point(298, 82);
            this.InsertBtn.Name = "InsertBtn";
            this.InsertBtn.Size = new System.Drawing.Size(86, 31);
            this.InsertBtn.TabIndex = 3;
            this.InsertBtn.Text = "Insert";
            this.InsertBtn.UseVisualStyleBackColor = true;
            this.InsertBtn.Click += new System.EventHandler(this.InsertBtn_Click);
            // 
            // checkBtn
            // 
            this.checkBtn.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBtn.Location = new System.Drawing.Point(390, 44);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(86, 31);
            this.checkBtn.TabIndex = 4;
            this.checkBtn.Text = "Check";
            this.checkBtn.UseVisualStyleBackColor = true;
            this.checkBtn.Click += new System.EventHandler(this.checkBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.Location = new System.Drawing.Point(390, 82);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(86, 31);
            this.clearBtn.TabIndex = 5;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // commentBox
            // 
            this.commentBox.BackColor = System.Drawing.Color.Black;
            this.commentBox.Font = new System.Drawing.Font("Arial Unicode MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commentBox.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.commentBox.Location = new System.Drawing.Point(298, 119);
            this.commentBox.Multiline = true;
            this.commentBox.Name = "commentBox";
            this.commentBox.ReadOnly = true;
            this.commentBox.Size = new System.Drawing.Size(378, 407);
            this.commentBox.TabIndex = 6;
            // 
            // VoicePad_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::VoicePad.Properties.Resources.BinaryBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(688, 538);
            this.Controls.Add(this.commentBox);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.checkBtn);
            this.Controls.Add(this.InsertBtn);
            this.Controls.Add(this.FileBox);
            this.Controls.Add(this.AsmBox);
            this.Controls.Add(this.VoiceBox);
            this.Name = "VoicePad_Window";
            this.ShowIcon = false;
            this.Text = "VoicePad (AVR Assembly)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox VoiceBox;
        private System.Windows.Forms.TextBox AsmBox;
        private System.Windows.Forms.TextBox FileBox;
        private System.Windows.Forms.Button InsertBtn;
        private System.Windows.Forms.Button checkBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.TextBox commentBox;
    }
}

