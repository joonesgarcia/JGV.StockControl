namespace JGV.StockControl.DesktopApp.Forms
{
    partial class SellDetailsForm
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
            sellDetailsGridView = new DataGridView();
            labelDividaRestante = new Label();
            labelDividaRestanteValor = new Label();
            abaterDividaTextBox = new TextBox();
            labelAbaterDivida = new Label();
            dividaRestantePanel = new Panel();
            botaoAbaterDivida = new Button();
            ((System.ComponentModel.ISupportInitialize)sellDetailsGridView).BeginInit();
            dividaRestantePanel.SuspendLayout();
            SuspendLayout();
            // 
            // sellDetailsGridView
            // 
            sellDetailsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sellDetailsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            sellDetailsGridView.BackgroundColor = SystemColors.Control;
            sellDetailsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            sellDetailsGridView.Location = new Point(12, 197);
            sellDetailsGridView.Name = "sellDetailsGridView";
            sellDetailsGridView.ReadOnly = true;
            sellDetailsGridView.RowHeadersVisible = false;
            sellDetailsGridView.RowHeadersWidth = 51;
            sellDetailsGridView.RowTemplate.Height = 29;
            sellDetailsGridView.Size = new Size(838, 290);
            sellDetailsGridView.TabIndex = 0;
            // 
            // labelDividaRestante
            // 
            labelDividaRestante.AutoSize = true;
            labelDividaRestante.Location = new Point(21, 22);
            labelDividaRestante.Name = "labelDividaRestante";
            labelDividaRestante.Size = new Size(112, 20);
            labelDividaRestante.TabIndex = 1;
            labelDividaRestante.Text = "Dívida restante:";
            // 
            // labelDividaRestanteValor
            // 
            labelDividaRestanteValor.AutoSize = true;
            labelDividaRestanteValor.Location = new Point(151, 24);
            labelDividaRestanteValor.Name = "labelDividaRestanteValor";
            labelDividaRestanteValor.Size = new Size(0, 20);
            labelDividaRestanteValor.TabIndex = 2;
            // 
            // abaterDividaTextBox
            // 
            abaterDividaTextBox.Location = new Point(151, 67);
            abaterDividaTextBox.Name = "abaterDividaTextBox";
            abaterDividaTextBox.Size = new Size(84, 27);
            abaterDividaTextBox.TabIndex = 3;
            abaterDividaTextBox.TextChanged += ValidaValorAbatimento;
            // 
            // labelAbaterDivida
            // 
            labelAbaterDivida.AutoSize = true;
            labelAbaterDivida.Location = new Point(21, 70);
            labelAbaterDivida.Name = "labelAbaterDivida";
            labelAbaterDivida.Size = new Size(102, 20);
            labelAbaterDivida.TabIndex = 4;
            labelAbaterDivida.Text = "Abater dívida:";
            // 
            // dividaRestantePanel
            // 
            dividaRestantePanel.Controls.Add(botaoAbaterDivida);
            dividaRestantePanel.Controls.Add(labelAbaterDivida);
            dividaRestantePanel.Controls.Add(labelDividaRestante);
            dividaRestantePanel.Controls.Add(abaterDividaTextBox);
            dividaRestantePanel.Controls.Add(labelDividaRestanteValor);
            dividaRestantePanel.Location = new Point(489, 12);
            dividaRestantePanel.Name = "dividaRestantePanel";
            dividaRestantePanel.Size = new Size(361, 170);
            dividaRestantePanel.TabIndex = 5;
            // 
            // botaoAbaterDivida
            // 
            botaoAbaterDivida.BackColor = Color.LawnGreen;
            botaoAbaterDivida.FlatAppearance.BorderColor = Color.Black;
            botaoAbaterDivida.Location = new Point(228, 127);
            botaoAbaterDivida.Name = "botaoAbaterDivida";
            botaoAbaterDivida.Size = new Size(114, 29);
            botaoAbaterDivida.TabIndex = 5;
            botaoAbaterDivida.Text = "Confirma";
            botaoAbaterDivida.UseVisualStyleBackColor = false;
            botaoAbaterDivida.Click += BotaoAbaterDivida_Click;
            // 
            // SellDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 510);
            Controls.Add(dividaRestantePanel);
            Controls.Add(sellDetailsGridView);
            Name = "SellDetailsForm";
            Text = "Detalhes da venda";
            Load += SellDetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)sellDetailsGridView).EndInit();
            dividaRestantePanel.ResumeLayout(false);
            dividaRestantePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView sellDetailsGridView;
        private Label labelDividaRestante;
        private Label labelDividaRestanteValor;
        private TextBox abaterDividaTextBox;
        private Label labelAbaterDivida;
        private Panel dividaRestantePanel;
        private Button botaoAbaterDivida;
    }
}