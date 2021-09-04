
namespace Bingo_Card_Generator
{
    partial class Tile_Create
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
            this.LblName = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LblDesc = new System.Windows.Forms.Label();
            this.LblImage = new System.Windows.Forms.Label();
            this.TbImage = new System.Windows.Forms.TextBox();
            this.RtbDesc = new System.Windows.Forms.RichTextBox();
            this.BtnImageFind = new System.Windows.Forms.Button();
            this.LblDiff = new System.Windows.Forms.Label();
            this.CombDiff = new System.Windows.Forms.ComboBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(29, 18);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(42, 15);
            this.LblName.TabIndex = 0;
            this.LblName.Text = "Name:";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(29, 36);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(129, 23);
            this.TbName.TabIndex = 0;
            // 
            // LblDesc
            // 
            this.LblDesc.AutoSize = true;
            this.LblDesc.Location = new System.Drawing.Point(29, 65);
            this.LblDesc.Name = "LblDesc";
            this.LblDesc.Size = new System.Drawing.Size(70, 15);
            this.LblDesc.TabIndex = 2;
            this.LblDesc.Text = "Description:";
            // 
            // LblImage
            // 
            this.LblImage.AutoSize = true;
            this.LblImage.Location = new System.Drawing.Point(29, 184);
            this.LblImage.Name = "LblImage";
            this.LblImage.Size = new System.Drawing.Size(70, 15);
            this.LblImage.TabIndex = 4;
            this.LblImage.Text = "Image Path:";
            // 
            // TbImage
            // 
            this.TbImage.Location = new System.Drawing.Point(29, 202);
            this.TbImage.Name = "TbImage";
            this.TbImage.Size = new System.Drawing.Size(100, 23);
            this.TbImage.TabIndex = 2;
            // 
            // RtbDesc
            // 
            this.RtbDesc.Location = new System.Drawing.Point(29, 83);
            this.RtbDesc.Name = "RtbDesc";
            this.RtbDesc.Size = new System.Drawing.Size(129, 96);
            this.RtbDesc.TabIndex = 1;
            this.RtbDesc.Text = "";
            // 
            // BtnImageFind
            // 
            this.BtnImageFind.Location = new System.Drawing.Point(135, 202);
            this.BtnImageFind.Name = "BtnImageFind";
            this.BtnImageFind.Size = new System.Drawing.Size(23, 23);
            this.BtnImageFind.TabIndex = 4;
            this.BtnImageFind.Text = "...";
            this.BtnImageFind.UseVisualStyleBackColor = true;
            this.BtnImageFind.Click += new System.EventHandler(this.BtnImageFind_Click);
            // 
            // LblDiff
            // 
            this.LblDiff.AutoSize = true;
            this.LblDiff.Location = new System.Drawing.Point(29, 228);
            this.LblDiff.Name = "LblDiff";
            this.LblDiff.Size = new System.Drawing.Size(58, 15);
            this.LblDiff.TabIndex = 8;
            this.LblDiff.Text = "Difficulty:";
            // 
            // CombDiff
            // 
            this.CombDiff.FormattingEnabled = true;
            this.CombDiff.Location = new System.Drawing.Point(29, 246);
            this.CombDiff.Name = "CombDiff";
            this.CombDiff.Size = new System.Drawing.Size(129, 23);
            this.CombDiff.TabIndex = 5;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(29, 275);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(129, 23);
            this.BtnAdd.TabIndex = 6;
            this.BtnAdd.Text = "Finish Tile";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // Tile_Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 315);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.CombDiff);
            this.Controls.Add(this.LblDiff);
            this.Controls.Add(this.BtnImageFind);
            this.Controls.Add(this.RtbDesc);
            this.Controls.Add(this.TbImage);
            this.Controls.Add(this.LblImage);
            this.Controls.Add(this.LblDesc);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LblName);
            this.Name = "Tile_Create";
            this.Text = "Tile_Create";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LblDesc;
        private System.Windows.Forms.Label LblImage;
        private System.Windows.Forms.TextBox TbImage;
        private System.Windows.Forms.RichTextBox RtbDesc;
        private System.Windows.Forms.Button BtnImageFind;
        private System.Windows.Forms.Label LblDiff;
        private System.Windows.Forms.ComboBox CombDiff;
        private System.Windows.Forms.Button BtnAdd;
    }
}