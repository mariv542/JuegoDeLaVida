namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox = new PictureBox();
            btnCargarArchivo = new Button();
            btnInciarSimulacion = new Button();
            btnDetenerSimulacion = new Button();
            labelNumeroSimulacion = new Label();
            labelContadorGeneracion = new Label();
            pbGrid = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGrid).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(12, 106);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(396, 388);
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            pictureBox.Click += pictureBox1_Click;
            // 
            // btnCargarArchivo
            // 
            btnCargarArchivo.Location = new Point(12, 12);
            btnCargarArchivo.Name = "btnCargarArchivo";
            btnCargarArchivo.Size = new Size(158, 23);
            btnCargarArchivo.TabIndex = 2;
            btnCargarArchivo.Text = "Cargar Archivo";
            btnCargarArchivo.UseVisualStyleBackColor = true;
            btnCargarArchivo.Click += btnCargarArchivo_Click;
            // 
            // btnInciarSimulacion
            // 
            btnInciarSimulacion.Location = new Point(12, 41);
            btnInciarSimulacion.Name = "btnInciarSimulacion";
            btnInciarSimulacion.Size = new Size(158, 23);
            btnInciarSimulacion.TabIndex = 3;
            btnInciarSimulacion.Text = "Iniciar simulacion";
            btnInciarSimulacion.UseVisualStyleBackColor = true;
            btnInciarSimulacion.Click += btnInciarSimulacion_Click;
            // 
            // btnDetenerSimulacion
            // 
            btnDetenerSimulacion.Location = new Point(263, 12);
            btnDetenerSimulacion.Name = "btnDetenerSimulacion";
            btnDetenerSimulacion.Size = new Size(145, 23);
            btnDetenerSimulacion.TabIndex = 4;
            btnDetenerSimulacion.Text = "Detener simulacion";
            btnDetenerSimulacion.UseVisualStyleBackColor = true;
            btnDetenerSimulacion.Click += btnDetenerSimulacion_Click;
            // 
            // labelNumeroSimulacion
            // 
            labelNumeroSimulacion.AutoSize = true;
            labelNumeroSimulacion.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNumeroSimulacion.Location = new Point(14, 69);
            labelNumeroSimulacion.Name = "labelNumeroSimulacion";
            labelNumeroSimulacion.Size = new Size(218, 25);
            labelNumeroSimulacion.TabIndex = 5;
            labelNumeroSimulacion.Text = "Numero de simulacion:";
            // 
            // labelContadorGeneracion
            // 
            labelContadorGeneracion.AutoSize = true;
            labelContadorGeneracion.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelContadorGeneracion.Location = new Point(238, 69);
            labelContadorGeneracion.Name = "labelContadorGeneracion";
            labelContadorGeneracion.Size = new Size(23, 25);
            labelContadorGeneracion.TabIndex = 6;
            labelContadorGeneracion.Text = "0";
            // 
            // pbGrid
            // 
            pbGrid.Location = new Point(0, 0);
            pbGrid.Name = "pbGrid";
            pbGrid.Size = new Size(100, 50);
            pbGrid.TabIndex = 7;
            pbGrid.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Thistle;
            ClientSize = new Size(420, 506);
            Controls.Add(labelContadorGeneracion);
            Controls.Add(labelNumeroSimulacion);
            Controls.Add(btnDetenerSimulacion);
            Controls.Add(btnInciarSimulacion);
            Controls.Add(btnCargarArchivo);
            Controls.Add(pictureBox);
            Controls.Add(pbGrid);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Juego de la vida";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();


        }

        #endregion
        private PictureBox pictureBox;
        private Button btnCargarArchivo;
        private Button btnInciarSimulacion;
        private Button btnDetenerSimulacion;
        private Label labelNumeroSimulacion;
        private Label labelContadorGeneracion;
    }
}
