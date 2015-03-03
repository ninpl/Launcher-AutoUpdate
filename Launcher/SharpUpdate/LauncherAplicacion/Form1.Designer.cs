namespace LauncherAplicacion
{
    partial class LauncherApp
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnCheckUpdate = new System.Windows.Forms.Button();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnCheckUpdate
            // 
            this.BtnCheckUpdate.Location = new System.Drawing.Point(66, 316);
            this.BtnCheckUpdate.Name = "BtnCheckUpdate";
            this.BtnCheckUpdate.Size = new System.Drawing.Size(187, 58);
            this.BtnCheckUpdate.TabIndex = 0;
            this.BtnCheckUpdate.Text = "Check for Updates";
            this.BtnCheckUpdate.UseVisualStyleBackColor = true;
            this.BtnCheckUpdate.Click += new System.EventHandler(this.BtnCheckUpdate_Click);
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Location = new System.Drawing.Point(135, 78);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(42, 13);
            this.lbl_Version.TabIndex = 1;
            this.lbl_Version.Text = "Version";
            // 
            // LauncherApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 386);
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.BtnCheckUpdate);
            this.Name = "LauncherApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCheckUpdate;
        private System.Windows.Forms.Label lbl_Version;
    }
}

