namespace JGV.StockControl.DesktopApp.Forms
{
    partial class ClientDebtsForm
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
            ClientDebtsGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)ClientDebtsGridView).BeginInit();
            SuspendLayout();
            // 
            // ClientDebtsGridView
            // 
            ClientDebtsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ClientDebtsGridView.BackgroundColor = SystemColors.Control;
            ClientDebtsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ClientDebtsGridView.Location = new Point(12, 103);
            ClientDebtsGridView.Name = "ClientDebtsGridView";
            ClientDebtsGridView.RowHeadersWidth = 51;
            ClientDebtsGridView.RowTemplate.Height = 29;
            ClientDebtsGridView.Size = new Size(1015, 435);
            ClientDebtsGridView.TabIndex = 0;
            // 
            // ClientDebtsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 550);
            Controls.Add(ClientDebtsGridView);
            Name = "ClientDebtsForm";
            Text = "ClientDebtsForm";
            Load += ClientDebtsForm_Load;
            ((System.ComponentModel.ISupportInitialize)ClientDebtsGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView ClientDebtsGridView;
    }
}