namespace JGV.StockControl.DesktopApp.Forms
{
    partial class AddSellForm
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
            clientLabel = new Label();
            clientComboBox = new ComboBox();
            dateLabel = new Label();
            dateTimePicker1 = new DateTimePicker();
            soldProductsListView = new ListView();
            soldProductsLabel = new Label();
            downPaymentLabel = new Label();
            downPaymentTextBox = new TextBox();
            SuspendLayout();
            // 
            // clientLabel
            // 
            clientLabel.AutoSize = true;
            clientLabel.Location = new Point(31, 85);
            clientLabel.Name = "clientLabel";
            clientLabel.Size = new Size(58, 20);
            clientLabel.TabIndex = 0;
            clientLabel.Text = "Cliente:";
            // 
            // clientComboBox
            // 
            clientComboBox.FormattingEnabled = true;
            clientComboBox.Location = new Point(31, 124);
            clientComboBox.Name = "clientComboBox";
            clientComboBox.Size = new Size(227, 28);
            clientComboBox.TabIndex = 1;
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(31, 180);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(44, 20);
            dateLabel.TabIndex = 2;
            dateLabel.Text = "Data:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(31, 219);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(112, 27);
            dateTimePicker1.TabIndex = 3;
            // 
            // soldProductsListView
            // 
            soldProductsListView.Location = new Point(388, 87);
            soldProductsListView.Name = "soldProductsListView";
            soldProductsListView.Size = new Size(358, 340);
            soldProductsListView.TabIndex = 4;
            soldProductsListView.UseCompatibleStateImageBehavior = false;
            // 
            // soldProductsLabel
            // 
            soldProductsLabel.AutoSize = true;
            soldProductsLabel.Location = new Point(388, 41);
            soldProductsLabel.Name = "soldProductsLabel";
            soldProductsLabel.Size = new Size(135, 20);
            soldProductsLabel.TabIndex = 5;
            soldProductsLabel.Text = "Produtos vendidos:";
            // 
            // downPaymentLabel
            // 
            downPaymentLabel.AutoSize = true;
            downPaymentLabel.Location = new Point(31, 287);
            downPaymentLabel.Name = "downPaymentLabel";
            downPaymentLabel.Size = new Size(63, 20);
            downPaymentLabel.TabIndex = 6;
            downPaymentLabel.Text = "Entrada:";
            // 
            // downPaymentTextBox
            // 
            downPaymentTextBox.Location = new Point(31, 329);
            downPaymentTextBox.Name = "downPaymentTextBox";
            downPaymentTextBox.Size = new Size(125, 27);
            downPaymentTextBox.TabIndex = 7;
            // 
            // AddSellForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(downPaymentTextBox);
            Controls.Add(downPaymentLabel);
            Controls.Add(soldProductsLabel);
            Controls.Add(soldProductsListView);
            Controls.Add(dateTimePicker1);
            Controls.Add(dateLabel);
            Controls.Add(clientComboBox);
            Controls.Add(clientLabel);
            Name = "AddSellForm";
            Text = "Cadastro de venda";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label clientLabel;
        private ComboBox clientComboBox;
        private Label dateLabel;
        private DateTimePicker dateTimePicker1;
        private ListView soldProductsListView;
        private Label soldProductsLabel;
        private Label downPaymentLabel;
        private TextBox downPaymentTextBox;
    }
}