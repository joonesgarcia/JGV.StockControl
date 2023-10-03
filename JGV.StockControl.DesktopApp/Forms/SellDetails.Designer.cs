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
            ((System.ComponentModel.ISupportInitialize)sellDetailsGridView).BeginInit();
            SuspendLayout();
            // 
            // sellDetailsGridView
            // 
            sellDetailsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sellDetailsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            sellDetailsGridView.BackgroundColor = SystemColors.Control;
            sellDetailsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            sellDetailsGridView.Location = new Point(12, 143);
            sellDetailsGridView.Name = "sellDetailsGridView";
            sellDetailsGridView.ReadOnly = true;
            sellDetailsGridView.RowHeadersVisible = false;
            sellDetailsGridView.RowHeadersWidth = 51;
            sellDetailsGridView.RowTemplate.Height = 29;
            sellDetailsGridView.Size = new Size(838, 344);
            sellDetailsGridView.TabIndex = 0;
            // 
            // SellDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 510);
            Controls.Add(sellDetailsGridView);
            Name = "SellDetailsForm";
            Text = "Detalhes da venda";
            Load += SellDetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)sellDetailsGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView sellDetailsGridView;
    }
}