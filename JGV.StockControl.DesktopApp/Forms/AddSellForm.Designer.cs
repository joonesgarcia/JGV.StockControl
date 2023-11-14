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
            soldProductsLabel = new Label();
            downPaymentLabel = new Label();
            downPaymentTextBox = new TextBox();
            soldProductQuantityInput = new NumericUpDown();
            soldProductQuantityLabel = new Label();
            addSoldProductButton = new Button();
            AddSellButton = new Button();
            SelectedSoldProductsGrid = new DataGridView();
            availableProductsListView = new ListView();
            removeSoldProductButton = new Button();
            SellInitialDebtLabel = new Label();
            sellDebtValueText = new Label();
            ((System.ComponentModel.ISupportInitialize)soldProductQuantityInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SelectedSoldProductsGrid).BeginInit();
            SuspendLayout();
            // 
            // clientLabel
            // 
            clientLabel.AutoSize = true;
            clientLabel.Location = new Point(52, 48);
            clientLabel.Name = "clientLabel";
            clientLabel.Size = new Size(58, 20);
            clientLabel.TabIndex = 0;
            clientLabel.Text = "Cliente:";
            // 
            // clientComboBox
            // 
            clientComboBox.FormattingEnabled = true;
            clientComboBox.Location = new Point(52, 84);
            clientComboBox.Name = "clientComboBox";
            clientComboBox.Size = new Size(227, 28);
            clientComboBox.TabIndex = 1;
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(52, 150);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(44, 20);
            dateLabel.TabIndex = 2;
            dateLabel.Text = "Data:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(149, 150);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(130, 27);
            dateTimePicker1.TabIndex = 3;
            // 
            // soldProductsLabel
            // 
            soldProductsLabel.AutoSize = true;
            soldProductsLabel.Location = new Point(357, 43);
            soldProductsLabel.Name = "soldProductsLabel";
            soldProductsLabel.Size = new Size(223, 20);
            soldProductsLabel.TabIndex = 5;
            soldProductsLabel.Text = "Selecione os produtos vendidos:";
            // 
            // downPaymentLabel
            // 
            downPaymentLabel.AutoSize = true;
            downPaymentLabel.Location = new Point(52, 206);
            downPaymentLabel.Name = "downPaymentLabel";
            downPaymentLabel.Size = new Size(63, 20);
            downPaymentLabel.TabIndex = 6;
            downPaymentLabel.Text = "Entrada:";
            // 
            // downPaymentTextBox
            // 
            downPaymentTextBox.Location = new Point(149, 206);
            downPaymentTextBox.Name = "downPaymentTextBox";
            downPaymentTextBox.Size = new Size(130, 27);
            downPaymentTextBox.TabIndex = 7;
            downPaymentTextBox.TextChanged += DownPaymentTextBoxOnlyNumbers;
            // 
            // soldProductQuantityInput
            // 
            soldProductQuantityInput.Location = new Point(592, 331);
            soldProductQuantityInput.Maximum = new decimal(new int[] { 45, 0, 0, 0 });
            soldProductQuantityInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            soldProductQuantityInput.Name = "soldProductQuantityInput";
            soldProductQuantityInput.Size = new Size(150, 27);
            soldProductQuantityInput.TabIndex = 10;
            soldProductQuantityInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // soldProductQuantityLabel
            // 
            soldProductQuantityLabel.AutoSize = true;
            soldProductQuantityLabel.Location = new Point(357, 331);
            soldProductQuantityLabel.Name = "soldProductQuantityLabel";
            soldProductQuantityLabel.Size = new Size(90, 20);
            soldProductQuantityLabel.TabIndex = 11;
            soldProductQuantityLabel.Text = "Quantidade:";
            // 
            // addSoldProductButton
            // 
            addSoldProductButton.BackColor = Color.FromArgb(255, 224, 192);
            addSoldProductButton.Location = new Point(357, 387);
            addSoldProductButton.Name = "addSoldProductButton";
            addSoldProductButton.Size = new Size(187, 35);
            addSoldProductButton.TabIndex = 12;
            addSoldProductButton.Text = "Adicionar";
            addSoldProductButton.UseVisualStyleBackColor = false;
            addSoldProductButton.Click += AddSoldProductButton_Click;
            // 
            // AddSellButton
            // 
            AddSellButton.BackColor = Color.Green;
            AddSellButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            AddSellButton.ForeColor = SystemColors.ButtonHighlight;
            AddSellButton.Location = new Point(52, 331);
            AddSellButton.Name = "AddSellButton";
            AddSellButton.Size = new Size(227, 91);
            AddSellButton.TabIndex = 13;
            AddSellButton.Text = "Cadastrar venda";
            AddSellButton.UseVisualStyleBackColor = false;
            // 
            // SelectedSoldProductsGrid
            // 
            SelectedSoldProductsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SelectedSoldProductsGrid.BackgroundColor = SystemColors.Control;
            SelectedSoldProductsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SelectedSoldProductsGrid.Location = new Point(52, 468);
            SelectedSoldProductsGrid.Name = "SelectedSoldProductsGrid";
            SelectedSoldProductsGrid.RowHeadersWidth = 51;
            SelectedSoldProductsGrid.RowTemplate.Height = 29;
            SelectedSoldProductsGrid.Size = new Size(572, 305);
            SelectedSoldProductsGrid.TabIndex = 14;
            // 
            // availableProductsListView
            // 
            availableProductsListView.Location = new Point(357, 84);
            availableProductsListView.Name = "availableProductsListView";
            availableProductsListView.Size = new Size(385, 223);
            availableProductsListView.TabIndex = 15;
            availableProductsListView.UseCompatibleStateImageBehavior = false;
            availableProductsListView.View = View.Details;
            availableProductsListView.ItemSelectionChanged += AvailableProductsListView_ItemSelected;
            // 
            // removeSoldProductButton
            // 
            removeSoldProductButton.BackColor = Color.Silver;
            removeSoldProductButton.Location = new Point(550, 387);
            removeSoldProductButton.Name = "removeSoldProductButton";
            removeSoldProductButton.Size = new Size(187, 35);
            removeSoldProductButton.TabIndex = 16;
            removeSoldProductButton.Text = "Remover";
            removeSoldProductButton.UseVisualStyleBackColor = false;
            // 
            // SellInitialDebtLabel
            // 
            SellInitialDebtLabel.Anchor = AnchorStyles.Right;
            SellInitialDebtLabel.AutoSize = true;
            SellInitialDebtLabel.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            SellInitialDebtLabel.Location = new Point(664, 559);
            SellInitialDebtLabel.Name = "SellInitialDebtLabel";
            SellInitialDebtLabel.Size = new Size(88, 45);
            SellInitialDebtLabel.TabIndex = 17;
            SellInitialDebtLabel.Text = "Total";
            // 
            // sellDebtValueText
            // 
            sellDebtValueText.Anchor = AnchorStyles.Right;
            sellDebtValueText.AutoSize = true;
            sellDebtValueText.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            sellDebtValueText.Location = new Point(667, 626);
            sellDebtValueText.Name = "sellDebtValueText";
            sellDebtValueText.Size = new Size(0, 25);
            sellDebtValueText.TabIndex = 18;
            // 
            // AddSellForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 800);
            Controls.Add(sellDebtValueText);
            Controls.Add(SellInitialDebtLabel);
            Controls.Add(removeSoldProductButton);
            Controls.Add(availableProductsListView);
            Controls.Add(SelectedSoldProductsGrid);
            Controls.Add(AddSellButton);
            Controls.Add(addSoldProductButton);
            Controls.Add(soldProductQuantityLabel);
            Controls.Add(soldProductQuantityInput);
            Controls.Add(downPaymentTextBox);
            Controls.Add(downPaymentLabel);
            Controls.Add(soldProductsLabel);
            Controls.Add(dateTimePicker1);
            Controls.Add(dateLabel);
            Controls.Add(clientComboBox);
            Controls.Add(clientLabel);
            MinimumSize = new Size(818, 847);
            Name = "AddSellForm";
            Text = "Cadastro de venda";
            Load += AddSellForm_Load;
            ((System.ComponentModel.ISupportInitialize)soldProductQuantityInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)SelectedSoldProductsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label clientLabel;
        private ComboBox clientComboBox;
        private Label dateLabel;
        private DateTimePicker dateTimePicker1;
        private Label soldProductsLabel;
        private Label downPaymentLabel;
        private TextBox downPaymentTextBox;
        private NumericUpDown soldProductQuantityInput;
        private Label soldProductQuantityLabel;
        private Button addSoldProductButton;
        private Button AddSellButton;
        private DataGridView SelectedSoldProductsGrid;
        private ListView availableProductsListView;
        private Button removeSoldProductButton;
        private Label SellInitialDebtLabel;
        private Label sellDebtValueText;
    }
}