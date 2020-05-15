using System.Windows.Forms;

namespace cs_pictionary
{
    partial class Fenetre
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.DrawPanel = new System.Windows.Forms.Panel();
            this.ChatBox = new System.Windows.Forms.TextBox();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.InputButton = new System.Windows.Forms.Button();
            this.ColorButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ClearButton = new System.Windows.Forms.Button();
            this.Width3px = new System.Windows.Forms.RadioButton();
            this.Width5px = new System.Windows.Forms.RadioButton();
            this.Width8px = new System.Windows.Forms.RadioButton();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.Width12px = new System.Windows.Forms.RadioButton();
            this.WidthPanel = new System.Windows.Forms.Panel();
            this.WidthPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DrawPanel
            // 
            this.DrawPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DrawPanel.Location = new System.Drawing.Point(12, 12);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(485, 402);
            this.DrawPanel.TabIndex = 0;
            this.DrawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPanel_Paint);
            this.DrawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseDown);
            this.DrawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseMove);
            this.DrawPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseUp);
            // 
            // ChatBox
            // 
            this.ChatBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChatBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatBox.Location = new System.Drawing.Point(503, 12);
            this.ChatBox.Multiline = true;
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatBox.Size = new System.Drawing.Size(285, 402);
            this.ChatBox.TabIndex = 2;
            // 
            // InputBox
            // 
            this.InputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBox.Location = new System.Drawing.Point(503, 420);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(225, 26);
            this.InputBox.TabIndex = 3;
            this.InputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputBox_KeyPress);
            // 
            // InputButton
            // 
            this.InputButton.Location = new System.Drawing.Point(734, 420);
            this.InputButton.Name = "InputButton";
            this.InputButton.Size = new System.Drawing.Size(54, 26);
            this.InputButton.TabIndex = 4;
            this.InputButton.Text = "Envoyer";
            this.InputButton.UseVisualStyleBackColor = true;
            this.InputButton.Click += new System.EventHandler(this.InputButton_Click);
            // 
            // ColorButton
            // 
            this.ColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.ColorButton.ForeColor = System.Drawing.Color.Black;
            this.ColorButton.Location = new System.Drawing.Point(12, 420);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(61, 30);
            this.ColorButton.TabIndex = 5;
            this.ColorButton.Text = "Couleur";
            this.ColorButton.UseVisualStyleBackColor = false;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(79, 420);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(48, 30);
            this.ClearButton.TabIndex = 9;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Width3px
            // 
            this.Width3px.AutoSize = true;
            this.Width3px.Location = new System.Drawing.Point(60, 7);
            this.Width3px.Name = "Width3px";
            this.Width3px.Size = new System.Drawing.Size(45, 17);
            this.Width3px.TabIndex = 10;
            this.Width3px.Text = "3 px";
            this.Width3px.UseVisualStyleBackColor = true;
            this.Width3px.CheckedChanged += new System.EventHandler(this.Width3px_CheckedChanged);
            // 
            // Width5px
            // 
            this.Width5px.AutoSize = true;
            this.Width5px.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Width5px.Checked = true;
            this.Width5px.Location = new System.Drawing.Point(110, 7);
            this.Width5px.Name = "Width5px";
            this.Width5px.Size = new System.Drawing.Size(45, 17);
            this.Width5px.TabIndex = 11;
            this.Width5px.TabStop = true;
            this.Width5px.Text = "5 px";
            this.Width5px.UseVisualStyleBackColor = true;
            this.Width5px.CheckedChanged += new System.EventHandler(this.Width5px_CheckedChanged);
            // 
            // Width8px
            // 
            this.Width8px.AutoSize = true;
            this.Width8px.Location = new System.Drawing.Point(161, 7);
            this.Width8px.Name = "Width8px";
            this.Width8px.Size = new System.Drawing.Size(45, 17);
            this.Width8px.TabIndex = 12;
            this.Width8px.Text = "8 px";
            this.Width8px.UseVisualStyleBackColor = true;
            this.Width8px.CheckedChanged += new System.EventHandler(this.Width8px_CheckedChanged);
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(9, 9);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(43, 13);
            this.WidthLabel.TabIndex = 13;
            this.WidthLabel.Text = "Largeur";
            // 
            // Width12px
            // 
            this.Width12px.AutoSize = true;
            this.Width12px.Location = new System.Drawing.Point(214, 7);
            this.Width12px.Name = "Width12px";
            this.Width12px.Size = new System.Drawing.Size(51, 17);
            this.Width12px.TabIndex = 14;
            this.Width12px.Text = "12 px";
            this.Width12px.UseVisualStyleBackColor = true;
            this.Width12px.CheckedChanged += new System.EventHandler(this.Width12px_CheckedChanged);
            // 
            // WidthPanel
            // 
            this.WidthPanel.Controls.Add(this.WidthLabel);
            this.WidthPanel.Controls.Add(this.Width12px);
            this.WidthPanel.Controls.Add(this.Width3px);
            this.WidthPanel.Controls.Add(this.Width8px);
            this.WidthPanel.Controls.Add(this.Width5px);
            this.WidthPanel.Location = new System.Drawing.Point(133, 420);
            this.WidthPanel.Name = "WidthPanel";
            this.WidthPanel.Size = new System.Drawing.Size(291, 30);
            this.WidthPanel.TabIndex = 15;
            // 
            // Fenetre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 462);
            this.Controls.Add(this.WidthPanel);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ColorButton);
            this.Controls.Add(this.InputButton);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.DrawPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Fenetre";
            this.Text = "Pictionary";
            this.WidthPanel.ResumeLayout(false);
            this.WidthPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel DrawPanel;
        private System.Windows.Forms.TextBox ChatBox;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Button InputButton;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ClearButton;
        private RadioButton Width3px;
        private RadioButton Width5px;
        private RadioButton Width8px;
        private Label WidthLabel;
        private RadioButton Width12px;
        private Panel WidthPanel;
    }
}

