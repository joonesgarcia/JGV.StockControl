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
            dividaRestantePanel = new Panel();
            SellDateValue = new Label();
            SellDateLabel = new Label();
            cancellSellBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)sellDetailsGridView).BeginInit();
            dividaRestantePanel.SuspendLayout();
            SuspendLayout();
            // 
            // sellDetailsGridView
            // 
            sellDetailsGridView.AllowUserToAddRows = false;
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
            sellDetailsGridView.CellClick += SoldProductsView_CellClick;
            // 
            // labelDividaRestante
            // 
            labelDividaRestante.AutoSize = true;
            labelDividaRestante.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            labelDividaRestante.ForeColor = Color.Red;
            labelDividaRestante.Location = new Point(26, 97);
            labelDividaRestante.Name = "labelDividaRestante";
            labelDividaRestante.Size = new Size(162, 30);
            labelDividaRestante.TabIndex = 1;
            labelDividaRestante.Text = "Dívida restante:";
            // 
            // labelDividaRestanteValor
            // 
            labelDividaRestanteValor.AutoSize = true;
            labelDividaRestanteValor.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            labelDividaRestanteValor.ForeColor = Color.Red;
            labelDividaRestanteValor.Location = new Point(218, 97);
            labelDividaRestanteValor.Name = "labelDividaRestanteValor";
            labelDividaRestanteValor.Size = new Size(0, 30);
            labelDividaRestanteValor.TabIndex = 2;
            // 
            // dividaRestantePanel
            // 
            dividaRestantePanel.BackColor = Color.LightGray;
            dividaRestantePanel.Controls.Add(SellDateValue);
            dividaRestantePanel.Controls.Add(SellDateLabel);
            dividaRestantePanel.Controls.Add(labelDividaRestante);
            dividaRestantePanel.Controls.Add(labelDividaRestanteValor);
            dividaRestantePanel.Location = new Point(12, 26);
            dividaRestantePanel.Name = "dividaRestantePanel";
            dividaRestantePanel.Size = new Size(361, 156);
            dividaRestantePanel.TabIndex = 5;
            // 
            // SellDateValue
            // 
            SellDateValue.AutoSize = true;
            SellDateValue.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SellDateValue.Location = new Point(218, 42);
            SellDateValue.Name = "SellDateValue";
            SellDateValue.Size = new Size(0, 25);
            SellDateValue.TabIndex = 4;
            // 
            // SellDateLabel
            // 
            SellDateLabel.AutoSize = true;
            SellDateLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SellDateLabel.Location = new Point(26, 42);
            SellDateLabel.Name = "SellDateLabel";
            SellDateLabel.Size = new Size(137, 25);
            SellDateLabel.TabIndex = 3;
            SellDateLabel.Text = "Data da venda:";
            // 
            // cancellSellBtn
            // 
            cancellSellBtn.BackColor = Color.IndianRed;
            cancellSellBtn.FlatStyle = FlatStyle.Popup;
            cancellSellBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cancellSellBtn.ForeColor = SystemColors.ButtonHighlight;
            cancellSellBtn.Location = new Point(693, 135);
            cancellSellBtn.Name = "cancellSellBtn";
            cancellSellBtn.Size = new Size(157, 47);
            cancellSellBtn.TabIndex = 6;
            cancellSellBtn.Text = "Cancelar venda";
            cancellSellBtn.UseVisualStyleBackColor = false;
            cancellSellBtn.Click += CancellSellBtn_Click;
            // 
            // SellDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 510);
            Controls.Add(cancellSellBtn);
            Controls.Add(dividaRestantePanel);
            Controls.Add(sellDetailsGridView);
            Name = "SellDetailsForm";
            Text = "Detalhes da venda";
            ((System.ComponentModel.ISupportInitialize)sellDetailsGridView).EndInit();
            dividaRestantePanel.ResumeLayout(false);
            dividaRestantePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView sellDetailsGridView;
        private Label labelDividaRestante;
        private Label labelDividaRestanteValor;
        private Panel dividaRestantePanel;
        private Label SellDateValue;
        private Label SellDateLabel;
        private Button cancellSellBtn;
    }
}