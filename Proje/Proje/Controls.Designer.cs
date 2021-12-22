
namespace Proje
{
    partial class Controls
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
            this.txtNotes = new System.Windows.Forms.Button();
            this.txtUsers = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(50, 39);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(60, 60);
            this.txtNotes.TabIndex = 0;
            this.txtNotes.Text = "NOTES";
            this.txtNotes.UseVisualStyleBackColor = true;
            this.txtNotes.Click += new System.EventHandler(this.txtNotes_Click);
            // 
            // txtUsers
            // 
            this.txtUsers.Location = new System.Drawing.Point(116, 39);
            this.txtUsers.Name = "txtUsers";
            this.txtUsers.Size = new System.Drawing.Size(60, 60);
            this.txtUsers.TabIndex = 2;
            this.txtUsers.Text = "USERS";
            this.txtUsers.UseVisualStyleBackColor = true;
            this.txtUsers.Click += new System.EventHandler(this.txtUsers_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(50, 105);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 60);
            this.button4.TabIndex = 3;
            this.button4.Text = "EXIT";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Controls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 211);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtUsers);
            this.Controls.Add(this.txtNotes);
            this.Name = "Controls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controls";
            this.Load += new System.EventHandler(this.Controls_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button txtNotes;
        private System.Windows.Forms.Button txtUsers;
        private System.Windows.Forms.Button button4;
    }
}