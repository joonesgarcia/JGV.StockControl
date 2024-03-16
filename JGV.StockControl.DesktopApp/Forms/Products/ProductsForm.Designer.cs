namespace JGV.StockControl.DesktopApp.Forms
{
    partial class ProductsForm
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
            productsGridView = new DataGridView();
            addProductBtn = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)productsGridView).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // productsGridView
            // 
            productsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            productsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            productsGridView.BackgroundColor = SystemColors.Control;
            productsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productsGridView.Location = new Point(12, 179);
            productsGridView.Name = "productsGridView";
            productsGridView.ReadOnly = true;
            productsGridView.RowHeadersVisible = false;
            productsGridView.RowHeadersWidth = 51;
            productsGridView.RowTemplate.Height = 29;
            productsGridView.Size = new Size(939, 375);
            productsGridView.TabIndex = 0;
            // 
            // addProductBtn
            // 
            addProductBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addProductBtn.BackColor = Color.PowderBlue;
            addProductBtn.FlatStyle = FlatStyle.Flat;
            addProductBtn.Location = new Point(803, 104);
            addProductBtn.Name = "addProductBtn";
            addProductBtn.Size = new Size(148, 39);
            addProductBtn.TabIndex = 1;
            addProductBtn.Text = "Adicionar novo";
            addProductBtn.UseVisualStyleBackColor = false;
            addProductBtn.Click += addProductBtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(addProductBtn);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(973, 183);
            panel1.TabIndex = 2;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 578);
            Controls.Add(productsGridView);
            Controls.Add(panel1);
            Name = "ProductsForm";
            Text = "ProductsForm";
            Load += ProductsForm_Load;
            ((System.ComponentModel.ISupportInitialize)productsGridView).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView productsGridView;
        private Button addProductBtn;
        private Panel panel1;
    }
}