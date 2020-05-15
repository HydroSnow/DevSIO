namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.button_a = new System.Windows.Forms.Button();
            this.button_b = new System.Windows.Forms.Button();
            this.button_c = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_effacer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_a
            // 
            this.button_a.Location = new System.Drawing.Point(13, 14);
            this.button_a.Name = "button_a";
            this.button_a.Size = new System.Drawing.Size(75, 23);
            this.button_a.TabIndex = 0;
            this.button_a.Text = "a";
            this.button_a.UseVisualStyleBackColor = true;
            this.button_a.Click += new System.EventHandler(this.button_a_Click);
            // 
            // button_b
            // 
            this.button_b.Location = new System.Drawing.Point(94, 14);
            this.button_b.Name = "button_b";
            this.button_b.Size = new System.Drawing.Size(75, 23);
            this.button_b.TabIndex = 1;
            this.button_b.Text = "b";
            this.button_b.UseVisualStyleBackColor = true;
            this.button_b.Click += new System.EventHandler(this.button_b_Click);
            // 
            // button_c
            // 
            this.button_c.Location = new System.Drawing.Point(175, 14);
            this.button_c.Name = "button_c";
            this.button_c.Size = new System.Drawing.Size(75, 23);
            this.button_c.TabIndex = 2;
            this.button_c.Text = "c";
            this.button_c.UseVisualStyleBackColor = true;
            this.button_c.Click += new System.EventHandler(this.button_c_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 20);
            this.textBox1.TabIndex = 3;
            // 
            // button_effacer
            // 
            this.button_effacer.Location = new System.Drawing.Point(13, 69);
            this.button_effacer.Name = "button_effacer";
            this.button_effacer.Size = new System.Drawing.Size(237, 23);
            this.button_effacer.TabIndex = 4;
            this.button_effacer.Text = "effacer";
            this.button_effacer.UseVisualStyleBackColor = true;
            this.button_effacer.Click += new System.EventHandler(this.button_effacer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Exemple de programme simple en C#";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_effacer);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_c);
            this.Controls.Add(this.button_b);
            this.Controls.Add(this.button_a);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_a;
        private System.Windows.Forms.Button button_b;
        private System.Windows.Forms.Button button_c;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_effacer;
        private System.Windows.Forms.Label label1;
    }
}

