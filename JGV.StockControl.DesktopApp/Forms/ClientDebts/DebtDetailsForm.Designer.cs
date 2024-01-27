namespace JGV.StockControl.DesktopApp.Forms
{
    partial class DebtDetailsForm
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
            debtDetailsGridView = new DataGridView();
            panel1 = new Panel();
            valorLabel = new Label();
            abaterDividaBtn = new Button();
            abaterDividaLabel = new Label();
            abaterDividaTextBox = new TextBox();
            dividaRestanteValue = new Label();
            dividaRestanteLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)debtDetailsGridView).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // debtDetailsGridView
            // 
            debtDetailsGridView.AllowUserToAddRows = false;
            debtDetailsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            debtDetailsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            debtDetailsGridView.BackgroundColor = SystemColors.Control;
            debtDetailsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            debtDetailsGridView.Location = new Point(12, 208);
            debtDetailsGridView.Name = "debtDetailsGridView";
            debtDetailsGridView.ReadOnly = true;
            debtDetailsGridView.RowHeadersVisible = false;
            debtDetailsGridView.RowHeadersWidth = 51;
            debtDetailsGridView.RowTemplate.Height = 29;
            debtDetailsGridView.Size = new Size(776, 288);
            debtDetailsGridView.TabIndex = 1;
            debtDetailsGridView.CellClick += DebtDetailsGridView_CellClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(valorLabel);
            panel1.Controls.Add(abaterDividaBtn);
            panel1.Controls.Add(abaterDividaLabel);
            panel1.Controls.Add(abaterDividaTextBox);
            panel1.Controls.Add(dividaRestanteValue);
            panel1.Controls.Add(dividaRestanteLabel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 190);
            panel1.TabIndex = 2;
            // 
            // valorLabel
            // 
            valorLabel.AutoSize = true;
            valorLabel.Location = new Point(545, 73);
            valorLabel.Name = "valorLabel";
            valorLabel.Size = new Size(46, 20);
            valorLabel.TabIndex = 5;
            valorLabel.Text = "Valor:";
            // 
            // abaterDividaBtn
            // 
            abaterDividaBtn.Location = new Point(540, 118);
            abaterDividaBtn.Name = "abaterDividaBtn";
            abaterDividaBtn.Size = new Size(198, 56);
            abaterDividaBtn.TabIndex = 4;
            abaterDividaBtn.Text = "Abater";
            abaterDividaBtn.UseVisualStyleBackColor = true;
            // 
            // abaterDividaLabel
            // 
            abaterDividaLabel.AutoSize = true;
            abaterDividaLabel.Location = new Point(540, 15);
            abaterDividaLabel.Name = "abaterDividaLabel";
            abaterDividaLabel.Size = new Size(99, 20);
            abaterDividaLabel.TabIndex = 3;
            abaterDividaLabel.Text = "Abater dívida";
            // 
            // abaterDividaTextBox
            // 
            abaterDividaTextBox.Location = new Point(608, 70);
            abaterDividaTextBox.Name = "abaterDividaTextBox";
            abaterDividaTextBox.Size = new Size(103, 27);
            abaterDividaTextBox.TabIndex = 2;
            abaterDividaTextBox.TextChanged += ValidaValorAbatimento;
            // 
            // dividaRestanteValue
            // 
            dividaRestanteValue.AutoSize = true;
            dividaRestanteValue.Location = new Point(159, 30);
            dividaRestanteValue.Name = "dividaRestanteValue";
            dividaRestanteValue.Size = new Size(0, 20);
            dividaRestanteValue.TabIndex = 1;
            // 
            // dividaRestanteLabel
            // 
            dividaRestanteLabel.AutoSize = true;
            dividaRestanteLabel.Location = new Point(25, 30);
            dividaRestanteLabel.Name = "dividaRestanteLabel";
            dividaRestanteLabel.Size = new Size(112, 20);
            dividaRestanteLabel.TabIndex = 0;
            dividaRestanteLabel.Text = "Dívida restante:";
            // 
            // DebtDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 508);
            Controls.Add(panel1);
            Controls.Add(debtDetailsGridView);
            Name = "DebtDetailsForm";
            Text = "Detalhes da dívida";
            ((System.ComponentModel.ISupportInitialize)debtDetailsGridView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView debtDetailsGridView;
        private Panel panel1;
        private Label valorLabel;
        private Button abaterDividaBtn;
        private Label abaterDividaLabel;
        private TextBox abaterDividaTextBox;
        private Label dividaRestanteValue;
        private Label dividaRestanteLabel;
    }
}