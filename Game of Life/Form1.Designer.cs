namespace GridTest
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtCursorPositionX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateMap = new System.Windows.Forms.Button();
            this.txtCursorPositionY = new System.Windows.Forms.TextBox();
            this.txtQuadradoY = new System.Windows.Forms.TextBox();
            this.txtQuadradoX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEstadoCel = new System.Windows.Forms.TextBox();
            this.btnRunSimulation = new System.Windows.Forms.Button();
            this.btnCreateRandomArray = new System.Windows.Forms.Button();
            this.chExibirLinhas = new System.Windows.Forms.CheckBox();
            this.btnRunStopSimulation = new System.Windows.Forms.Button();
            this.chSimulacaoAuto = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 700);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // txtCursorPositionX
            // 
            this.txtCursorPositionX.Location = new System.Drawing.Point(843, 9);
            this.txtCursorPositionX.Name = "txtCursorPositionX";
            this.txtCursorPositionX.ReadOnly = true;
            this.txtCursorPositionX.Size = new System.Drawing.Size(58, 20);
            this.txtCursorPositionX.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(738, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Coordenada mouse";
            // 
            // btnCreateMap
            // 
            this.btnCreateMap.Location = new System.Drawing.Point(877, 268);
            this.btnCreateMap.Name = "btnCreateMap";
            this.btnCreateMap.Size = new System.Drawing.Size(120, 36);
            this.btnCreateMap.TabIndex = 28;
            this.btnCreateMap.Text = "Criar Grade Vazia";
            this.btnCreateMap.UseVisualStyleBackColor = true;
            this.btnCreateMap.Click += new System.EventHandler(this.btnCreateMap_Click);
            // 
            // txtCursorPositionY
            // 
            this.txtCursorPositionY.Location = new System.Drawing.Point(907, 9);
            this.txtCursorPositionY.Name = "txtCursorPositionY";
            this.txtCursorPositionY.ReadOnly = true;
            this.txtCursorPositionY.Size = new System.Drawing.Size(58, 20);
            this.txtCursorPositionY.TabIndex = 29;
            // 
            // txtQuadradoY
            // 
            this.txtQuadradoY.Location = new System.Drawing.Point(907, 35);
            this.txtQuadradoY.Name = "txtQuadradoY";
            this.txtQuadradoY.ReadOnly = true;
            this.txtQuadradoY.Size = new System.Drawing.Size(58, 20);
            this.txtQuadradoY.TabIndex = 31;
            // 
            // txtQuadradoX
            // 
            this.txtQuadradoX.Location = new System.Drawing.Point(843, 35);
            this.txtQuadradoX.Name = "txtQuadradoX";
            this.txtQuadradoX.ReadOnly = true;
            this.txtQuadradoX.Size = new System.Drawing.Size(58, 20);
            this.txtQuadradoX.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(738, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Coordenada Celula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(738, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Estado da Celula";
            // 
            // txtEstadoCel
            // 
            this.txtEstadoCel.Location = new System.Drawing.Point(843, 62);
            this.txtEstadoCel.Name = "txtEstadoCel";
            this.txtEstadoCel.ReadOnly = true;
            this.txtEstadoCel.Size = new System.Drawing.Size(58, 20);
            this.txtEstadoCel.TabIndex = 34;
            // 
            // btnRunSimulation
            // 
            this.btnRunSimulation.Location = new System.Drawing.Point(741, 322);
            this.btnRunSimulation.Name = "btnRunSimulation";
            this.btnRunSimulation.Size = new System.Drawing.Size(120, 36);
            this.btnRunSimulation.TabIndex = 35;
            this.btnRunSimulation.Text = "Proxima Geração";
            this.btnRunSimulation.UseVisualStyleBackColor = true;
            this.btnRunSimulation.Click += new System.EventHandler(this.btnRunSimulation_Click);
            // 
            // btnCreateRandomArray
            // 
            this.btnCreateRandomArray.Location = new System.Drawing.Point(741, 268);
            this.btnCreateRandomArray.Name = "btnCreateRandomArray";
            this.btnCreateRandomArray.Size = new System.Drawing.Size(120, 36);
            this.btnCreateRandomArray.TabIndex = 36;
            this.btnCreateRandomArray.Text = "Criar Grade Aleatória";
            this.btnCreateRandomArray.UseVisualStyleBackColor = true;
            this.btnCreateRandomArray.Click += new System.EventHandler(this.button1_Click);
            // 
            // chExibirLinhas
            // 
            this.chExibirLinhas.AutoSize = true;
            this.chExibirLinhas.Checked = true;
            this.chExibirLinhas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chExibirLinhas.Location = new System.Drawing.Point(741, 144);
            this.chExibirLinhas.Name = "chExibirLinhas";
            this.chExibirLinhas.Size = new System.Drawing.Size(126, 17);
            this.chExibirLinhas.TabIndex = 38;
            this.chExibirLinhas.Text = "Exibir linhas na grade";
            this.chExibirLinhas.UseVisualStyleBackColor = true;
            this.chExibirLinhas.CheckedChanged += new System.EventHandler(this.chExibirLinhas_CheckedChanged);
            // 
            // btnRunStopSimulation
            // 
            this.btnRunStopSimulation.Location = new System.Drawing.Point(877, 322);
            this.btnRunStopSimulation.Name = "btnRunStopSimulation";
            this.btnRunStopSimulation.Size = new System.Drawing.Size(120, 36);
            this.btnRunStopSimulation.TabIndex = 39;
            this.btnRunStopSimulation.Text = "Rodar/Parar Simulação";
            this.btnRunStopSimulation.UseVisualStyleBackColor = true;
            this.btnRunStopSimulation.Click += new System.EventHandler(this.btnRunStopSimulation_Click);
            // 
            // chSimulacaoAuto
            // 
            this.chSimulacaoAuto.AutoSize = true;
            this.chSimulacaoAuto.Enabled = false;
            this.chSimulacaoAuto.Location = new System.Drawing.Point(741, 167);
            this.chSimulacaoAuto.Name = "chSimulacaoAuto";
            this.chSimulacaoAuto.Size = new System.Drawing.Size(131, 17);
            this.chSimulacaoAuto.TabIndex = 40;
            this.chSimulacaoAuto.Text = "Simulação Automatica";
            this.chSimulacaoAuto.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 735);
            this.Controls.Add(this.chSimulacaoAuto);
            this.Controls.Add(this.btnRunStopSimulation);
            this.Controls.Add(this.chExibirLinhas);
            this.Controls.Add(this.btnCreateRandomArray);
            this.Controls.Add(this.btnRunSimulation);
            this.Controls.Add(this.txtEstadoCel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuadradoY);
            this.Controls.Add(this.txtQuadradoX);
            this.Controls.Add(this.txtCursorPositionY);
            this.Controls.Add(this.btnCreateMap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCursorPositionX);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Game of Life";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtCursorPositionX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateMap;
        private System.Windows.Forms.TextBox txtCursorPositionY;
        private System.Windows.Forms.TextBox txtQuadradoY;
        private System.Windows.Forms.TextBox txtQuadradoX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEstadoCel;
        private System.Windows.Forms.Button btnRunSimulation;
        private System.Windows.Forms.Button btnCreateRandomArray;
        private System.Windows.Forms.CheckBox chExibirLinhas;
        private System.Windows.Forms.Button btnRunStopSimulation;
        private System.Windows.Forms.CheckBox chSimulacaoAuto;
    }
}

