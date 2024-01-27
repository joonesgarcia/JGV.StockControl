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
            clientValue = new Label();
            clientLabel = new Label();
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
            debtDetailsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            panel1.Controls.Add(clientValue);
            panel1.Controls.Add(clientLabel);
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
            // clientValue
            // 
            clientValue.AutoSize = true;
            clientValue.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            clientValue.Location = new Point(188, 92);
            clientValue.Name = "clientValue";
            clientValue.Size = new Size(0, 22);
            clientValue.TabIndex = 7;
            // 
            // clientLabel
            // 
            clientLabel.AutoSize = true;
            clientLabel.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            clientLabel.Location = new Point(34, 92);
            clientLabel.Name = "clientLabel";
            clientLabel.Size = new Size(69, 22);
            clientLabel.TabIndex = 6;
            clientLabel.Text = "Cliente:";
            // 
            // valorLabel
            // 
            valorLabel.AutoSize = true;
            valorLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            valorLabel.Location = new Point(540, 81);
            valorLabel.Name = "valorLabel";
            valorLabel.Size = new Size(60, 25);
            valorLabel.TabIndex = 5;
            valorLabel.Text = "Valor:";
            // 
            // abaterDividaBtn
            // 
            abaterDividaBtn.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
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
            abaterDividaLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            abaterDividaLabel.Location = new Point(540, 22);
            abaterDividaLabel.Name = "abaterDividaLabel";
            abaterDividaLabel.Size = new Size(124, 25);
            abaterDividaLabel.TabIndex = 3;
            abaterDividaLabel.Text = "Abater dívida";
            // 
            // abaterDividaTextBox
            // 
            abaterDividaTextBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            abaterDividaTextBox.Location = new Point(609, 74);
            abaterDividaTextBox.Name = "abaterDividaTextBox";
            abaterDividaTextBox.Size = new Size(129, 32);
            abaterDividaTextBox.TabIndex = 2;
            abaterDividaTextBox.TextChanged += ValidaValorAbatimento;
            // 
            // dividaRestanteValue
            // 
            dividaRestanteValue.AutoSize = true;
            dividaRestanteValue.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            dividaRestanteValue.Location = new Point(188, 37);
            dividaRestanteValue.Name = "dividaRestanteValue";
            dividaRestanteValue.Size = new Size(0, 22);
            dividaRestanteValue.TabIndex = 1;
            // 
            // dividaRestanteLabel
            // 
            dividaRestanteLabel.AutoSize = true;
            dividaRestanteLabel.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            dividaRestanteLabel.Location = new Point(34, 37);
            dividaRestanteLabel.Name = "dividaRestanteLabel";
            dividaRestanteLabel.Size = new Size(133, 22);
            dividaRestanteLabel.TabIndex = 0;
            dividaRestanteLabel.Text = "Dívida restante:";
            // 
            // DebtDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 858);
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
        private Label clientValue;
        private Label clientLabel;
    }
}