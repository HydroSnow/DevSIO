namespace ex_forms
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
            this.input1 = new System.Windows.Forms.TextBox();
            this.input2 = new System.Windows.Forms.TextBox();
            this.droite = new System.Windows.Forms.Button();
            this.droite_all = new System.Windows.Forms.Button();
            this.gauche = new System.Windows.Forms.Button();
            this.gauche_all = new System.Windows.Forms.Button();
            this.bouton1_ajouter = new System.Windows.Forms.Button();
            this.bouton2_ajouter = new System.Windows.Forms.Button();
            this.textbox1 = new System.Windows.Forms.TextBox();
            this.textbox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // input1
            // 
            this.input1.Location = new System.Drawing.Point(12, 12);
            this.input1.Multiline = true;
            this.input1.Name = "input1";
            this.input1.Size = new System.Drawing.Size(131, 183);
            this.input1.TabIndex = 0;
            // 
            // input2
            // 
            this.input2.Location = new System.Drawing.Point(270, 12);
            this.input2.Multiline = true;
            this.input2.Name = "input2";
            this.input2.Size = new System.Drawing.Size(131, 183);
            this.input2.TabIndex = 1;
            // 
            // droite
            // 
            this.droite.Location = new System.Drawing.Point(172, 35);
            this.droite.Name = "droite";
            this.droite.Size = new System.Drawing.Size(75, 23);
            this.droite.TabIndex = 2;
            this.droite.Text = ">";
            this.droite.UseVisualStyleBackColor = true;
            this.droite.Click += new System.EventHandler(this.droite_Click);
            // 
            // droite_all
            // 
            this.droite_all.Location = new System.Drawing.Point(172, 64);
            this.droite_all.Name = "droite_all";
            this.droite_all.Size = new System.Drawing.Size(75, 23);
            this.droite_all.TabIndex = 3;
            this.droite_all.Text = ">>";
            this.droite_all.UseVisualStyleBackColor = true;
            this.droite_all.Click += new System.EventHandler(this.droite_all_Click);
            // 
            // gauche
            // 
            this.gauche.Location = new System.Drawing.Point(172, 93);
            this.gauche.Name = "gauche";
            this.gauche.Size = new System.Drawing.Size(75, 23);
            this.gauche.TabIndex = 4;
            this.gauche.Text = "<";
            this.gauche.UseVisualStyleBackColor = true;
            this.gauche.Click += new System.EventHandler(this.gauche_Click);
            // 
            // gauche_all
            // 
            this.gauche_all.Location = new System.Drawing.Point(172, 122);
            this.gauche_all.Name = "gauche_all";
            this.gauche_all.Size = new System.Drawing.Size(75, 23);
            this.gauche_all.TabIndex = 5;
            this.gauche_all.Text = "<<";
            this.gauche_all.UseVisualStyleBackColor = true;
            this.gauche_all.Click += new System.EventHandler(this.gauche_all_Click);
            // 
            // bouton1_ajouter
            // 
            this.bouton1_ajouter.Location = new System.Drawing.Point(39, 201);
            this.bouton1_ajouter.Name = "bouton1_ajouter";
            this.bouton1_ajouter.Size = new System.Drawing.Size(75, 23);
            this.bouton1_ajouter.TabIndex = 6;
            this.bouton1_ajouter.Text = "Ajouter";
            this.bouton1_ajouter.UseVisualStyleBackColor = true;
            this.bouton1_ajouter.Click += new System.EventHandler(this.bouton1_ajouter_Click);
            // 
            // bouton2_ajouter
            // 
            this.bouton2_ajouter.Location = new System.Drawing.Point(300, 201);
            this.bouton2_ajouter.Name = "bouton2_ajouter";
            this.bouton2_ajouter.Size = new System.Drawing.Size(75, 23);
            this.bouton2_ajouter.TabIndex = 7;
            this.bouton2_ajouter.Text = "Ajouter";
            this.bouton2_ajouter.UseVisualStyleBackColor = true;
            this.bouton2_ajouter.Click += new System.EventHandler(this.bouton2_ajouter_Click);
            // 
            // textbox1
            // 
            this.textbox1.Location = new System.Drawing.Point(26, 230);
            this.textbox1.Name = "textbox1";
            this.textbox1.Size = new System.Drawing.Size(100, 20);
            this.textbox1.TabIndex = 8;
            // 
            // textbox2
            // 
            this.textbox2.Location = new System.Drawing.Point(286, 230);
            this.textbox2.Name = "textbox2";
            this.textbox2.Size = new System.Drawing.Size(100, 20);
            this.textbox2.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(419, 266);
            this.Controls.Add(this.textbox2);
            this.Controls.Add(this.textbox1);
            this.Controls.Add(this.bouton2_ajouter);
            this.Controls.Add(this.bouton1_ajouter);
            this.Controls.Add(this.gauche_all);
            this.Controls.Add(this.gauche);
            this.Controls.Add(this.droite_all);
            this.Controls.Add(this.droite);
            this.Controls.Add(this.input2);
            this.Controls.Add(this.input1);
            this.Name = "Form1";
            this.Text = "Exercice Forms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input1;
        private System.Windows.Forms.TextBox input2;
        private System.Windows.Forms.Button droite;
        private System.Windows.Forms.Button droite_all;
        private System.Windows.Forms.Button gauche;
        private System.Windows.Forms.Button gauche_all;
        private System.Windows.Forms.Button bouton1_ajouter;
        private System.Windows.Forms.Button bouton2_ajouter;
        private System.Windows.Forms.TextBox textbox1;
        private System.Windows.Forms.TextBox textbox2;
    }
}

