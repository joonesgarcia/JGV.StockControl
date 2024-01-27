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
            ((System.ComponentModel.ISupportInitialize)debtDetailsGridView).BeginInit();
            SuspendLayout();
            // 
            // debtDetailsGridView
            // 
            debtDetailsGridView.AllowUserToAddRows = false;
            debtDetailsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            debtDetailsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            debtDetailsGridView.BackgroundColor = SystemColors.Control;
            debtDetailsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            debtDetailsGridView.Location = new Point(12, 175);
            debtDetailsGridView.Name = "debtDetailsGridView";
            debtDetailsGridView.ReadOnly = true;
            debtDetailsGridView.RowHeadersVisible = false;
            debtDetailsGridView.RowHeadersWidth = 51;
            debtDetailsGridView.RowTemplate.Height = 29;
            debtDetailsGridView.Size = new Size(776, 263);
            debtDetailsGridView.TabIndex = 1;
            debtDetailsGridView.CellClick += DebtDetailsGridView_CellClick;
            // 
            // DebtDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(debtDetailsGridView);
            Name = "DebtDetails";
            Text = "Detalhes da dívida";
            ((System.ComponentModel.ISupportInitialize)debtDetailsGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView debtDetailsGridView;
    }
}