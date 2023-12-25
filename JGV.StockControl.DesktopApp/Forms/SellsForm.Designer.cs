namespace JGV.StockControl.DesktopApp.Forms
{
    partial class SellsForm
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
            sellsGridView = new DataGridView();
            addSellBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)sellsGridView).BeginInit();
            SuspendLayout();
            // 
            // sellsGridView
            // 
            sellsGridView.AllowUserToDeleteRows = false;
            sellsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sellsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            sellsGridView.BackgroundColor = SystemColors.Control;
            sellsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            sellsGridView.Location = new Point(12, 179);
            sellsGridView.Name = "sellsGridView";
            sellsGridView.ReadOnly = true;
            sellsGridView.RowHeadersVisible = false;
            sellsGridView.RowHeadersWidth = 51;
            sellsGridView.RowTemplate.Height = 29;
            sellsGridView.Size = new Size(935, 374);
            sellsGridView.TabIndex = 0;
            sellsGridView.CellClick += SellsGridView_CellClick;
            // 
            // addSellBtn
            // 
            addSellBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addSellBtn.BackColor = Color.DarkSeaGreen;
            addSellBtn.Cursor = Cursors.Hand;
            addSellBtn.Location = new Point(677, 99);
            addSellBtn.MinimumSize = new Size(161, 0);
            addSellBtn.Name = "addSellBtn";
            addSellBtn.Size = new Size(161, 53);
            addSellBtn.TabIndex = 1;
            addSellBtn.Text = "Cadastrar venda";
            addSellBtn.UseVisualStyleBackColor = false;
            addSellBtn.Click += AddSellBtn_Click;
            // 
            // SellsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 578);
            Controls.Add(addSellBtn);
            Controls.Add(sellsGridView);
            Name = "SellsForm";
            Text = "SellsForm";
            Load += SellsForm_Load;
            ((System.ComponentModel.ISupportInitialize)sellsGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView sellsGridView;
        private Button addSellBtn;
    }
}