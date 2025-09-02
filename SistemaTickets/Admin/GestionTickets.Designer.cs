namespace SistemaTickets.Admin
{
    partial class GestionTickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionTickets));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.filtroBtn = new System.Windows.Forms.Button();
            this.editarBtn = new System.Windows.Forms.Button();
            this.razonTxtBox = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tipoMenu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.estadoTicket = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(7, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(56, 41);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 88;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(619, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 87;
            this.pictureBox1.TabStop = false;
            // 
            // filtroBtn
            // 
            this.filtroBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
            this.filtroBtn.FlatAppearance.BorderSize = 0;
            this.filtroBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtroBtn.Font = new System.Drawing.Font("Trebuchet MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.filtroBtn.ForeColor = System.Drawing.Color.White;
            this.filtroBtn.Location = new System.Drawing.Point(435, 120);
            this.filtroBtn.Margin = new System.Windows.Forms.Padding(4);
            this.filtroBtn.Name = "filtroBtn";
            this.filtroBtn.Size = new System.Drawing.Size(110, 29);
            this.filtroBtn.TabIndex = 86;
            this.filtroBtn.Text = "Filtrar";
            this.filtroBtn.UseVisualStyleBackColor = false;
            this.filtroBtn.Click += new System.EventHandler(this.filtroBtn_Click);
            // 
            // editarBtn
            // 
            this.editarBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(35)))), ((int)(((byte)(46)))));
            this.editarBtn.FlatAppearance.BorderSize = 0;
            this.editarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editarBtn.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.editarBtn.ForeColor = System.Drawing.Color.White;
            this.editarBtn.Location = new System.Drawing.Point(757, 383);
            this.editarBtn.Margin = new System.Windows.Forms.Padding(4);
            this.editarBtn.Name = "editarBtn";
            this.editarBtn.Size = new System.Drawing.Size(133, 43);
            this.editarBtn.TabIndex = 85;
            this.editarBtn.Text = "Editar";
            this.editarBtn.UseVisualStyleBackColor = false;
            this.editarBtn.Click += new System.EventHandler(this.editarBtn_Click);
            // 
            // razonTxtBox
            // 
            this.razonTxtBox.Location = new System.Drawing.Point(169, 254);
            this.razonTxtBox.Name = "razonTxtBox";
            this.razonTxtBox.Size = new System.Drawing.Size(400, 96);
            this.razonTxtBox.TabIndex = 84;
            this.razonTxtBox.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label10.Location = new System.Drawing.Point(63, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 29);
            this.label10.TabIndex = 83;
            this.label10.Text = "Razón:";
            // 
            // tipoMenu
            // 
            this.tipoMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoMenu.FormattingEnabled = true;
            this.tipoMenu.Items.AddRange(new object[] {
            "Regular",
            "Healthy",
            "Veggie",
            "Dinner"});
            this.tipoMenu.Location = new System.Drawing.Point(237, 166);
            this.tipoMenu.Name = "tipoMenu";
            this.tipoMenu.Size = new System.Drawing.Size(202, 24);
            this.tipoMenu.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(59, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 29);
            this.label2.TabIndex = 81;
            this.label2.Text = "Tipo de Menú:";
            // 
            // idTxtBox
            // 
            this.idTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.idTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idTxtBox.Location = new System.Drawing.Point(148, 122);
            this.idTxtBox.Name = "idTxtBox";
            this.idTxtBox.Size = new System.Drawing.Size(270, 26);
            this.idTxtBox.TabIndex = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.Location = new System.Drawing.Point(63, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 29);
            this.label5.TabIndex = 79;
            this.label5.Text = "ID:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(53)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(903, 39);
            this.label1.TabIndex = 78;
            this.label1.Text = "Edición de Tickets";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // estadoTicket
            // 
            this.estadoTicket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estadoTicket.FormattingEnabled = true;
            this.estadoTicket.Items.AddRange(new object[] {
            "Activo",
            "Cancelado",
            "Usado",
            "No Usado"});
            this.estadoTicket.Location = new System.Drawing.Point(169, 209);
            this.estadoTicket.Name = "estadoTicket";
            this.estadoTicket.Size = new System.Drawing.Size(202, 24);
            this.estadoTicket.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.Location = new System.Drawing.Point(63, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 29);
            this.label3.TabIndex = 89;
            this.label3.Text = "Estado:";
            // 
            // GestionTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 439);
            this.Controls.Add(this.estadoTicket);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.filtroBtn);
            this.Controls.Add(this.editarBtn);
            this.Controls.Add(this.razonTxtBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tipoMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idTxtBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "GestionTickets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionTickets";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button filtroBtn;
        private System.Windows.Forms.Button editarBtn;
        private System.Windows.Forms.RichTextBox razonTxtBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox tipoMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox estadoTicket;
        private System.Windows.Forms.Label label3;
    }
}