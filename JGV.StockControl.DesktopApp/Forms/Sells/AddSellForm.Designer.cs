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
            sellDateInput = new DateTimePicker();
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
            discountTextValue = new Label();
            impossibleSellLable = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)soldProductQuantityInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SelectedSoldProductsGrid).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // clientLabel
            // 
            clientLabel.AutoSize = true;
            clientLabel.Location = new Point(39, 62);
            clientLabel.Name = "clientLabel";
            clientLabel.Size = new Size(58, 20);
            clientLabel.TabIndex = 0;
            clientLabel.Text = "Cliente:";
            // 
            // clientComboBox
            // 
            clientComboBox.FormattingEnabled = true;
            clientComboBox.Location = new Point(39, 115);
            clientComboBox.Name = "clientComboBox";
            clientComboBox.Size = new Size(227, 28);
            clientComboBox.TabIndex = 1;
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(39, 186);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(44, 20);
            dateLabel.TabIndex = 2;
            dateLabel.Text = "Data:";
            // 
            // sellDateInput
            // 
            sellDateInput.Format = DateTimePickerFormat.Short;
            sellDateInput.Location = new Point(136, 186);
            sellDateInput.Name = "sellDateInput";
            sellDateInput.Size = new Size(130, 27);
            sellDateInput.TabIndex = 3;
            // 
            // soldProductsLabel
            // 
            soldProductsLabel.AutoSize = true;
            soldProductsLabel.Location = new Point(367, 32);
            soldProductsLabel.Name = "soldProductsLabel";
            soldProductsLabel.Size = new Size(223, 20);
            soldProductsLabel.TabIndex = 5;
            soldProductsLabel.Text = "Selecione os produtos vendidos:";
            // 
            // downPaymentLabel
            // 
            downPaymentLabel.AutoSize = true;
            downPaymentLabel.Location = new Point(39, 242);
            downPaymentLabel.Name = "downPaymentLabel";
            downPaymentLabel.Size = new Size(63, 20);
            downPaymentLabel.TabIndex = 6;
            downPaymentLabel.Text = "Entrada:";
            // 
            // downPaymentTextBox
            // 
            downPaymentTextBox.Location = new Point(136, 242);
            downPaymentTextBox.Name = "downPaymentTextBox";
            downPaymentTextBox.Size = new Size(130, 27);
            downPaymentTextBox.TabIndex = 7;
            downPaymentTextBox.Text = "0";
            downPaymentTextBox.TextChanged += DownPaymentTextBoxOnlyNumbers;
            // 
            // soldProductQuantityInput
            // 
            soldProductQuantityInput.Location = new Point(602, 320);
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
            soldProductQuantityLabel.Location = new Point(367, 320);
            soldProductQuantityLabel.Name = "soldProductQuantityLabel";
            soldProductQuantityLabel.Size = new Size(90, 20);
            soldProductQuantityLabel.TabIndex = 11;
            soldProductQuantityLabel.Text = "Quantidade:";
            // 
            // addSoldProductButton
            // 
            addSoldProductButton.BackColor = Color.PowderBlue;
            addSoldProductButton.Location = new Point(367, 376);
            addSoldProductButton.Name = "addSoldProductButton";
            addSoldProductButton.Size = new Size(187, 35);
            addSoldProductButton.TabIndex = 12;
            addSoldProductButton.Text = "Adicionar item";
            addSoldProductButton.UseVisualStyleBackColor = false;
            addSoldProductButton.Click += AddSoldProductButton_Click;
            // 
            // AddSellButton
            // 
            AddSellButton.BackColor = Color.Green;
            AddSellButton.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            AddSellButton.ForeColor = SystemColors.ButtonHighlight;
            AddSellButton.Location = new Point(619, 690);
            AddSellButton.Name = "AddSellButton";
            AddSellButton.Size = new Size(169, 79);
            AddSellButton.TabIndex = 13;
            AddSellButton.Text = "Cadastrar venda";
            AddSellButton.UseVisualStyleBackColor = false;
            AddSellButton.Click += AddSellButton_Click;
            // 
            // SelectedSoldProductsGrid
            // 
            SelectedSoldProductsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SelectedSoldProductsGrid.BackgroundColor = SystemColors.Control;
            SelectedSoldProductsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SelectedSoldProductsGrid.Location = new Point(18, 464);
            SelectedSoldProductsGrid.Name = "SelectedSoldProductsGrid";
            SelectedSoldProductsGrid.RowHeadersWidth = 51;
            SelectedSoldProductsGrid.RowTemplate.Height = 29;
            SelectedSoldProductsGrid.Size = new Size(572, 305);
            SelectedSoldProductsGrid.TabIndex = 14;
            // 
            // availableProductsListView
            // 
            availableProductsListView.Location = new Point(367, 73);
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
            removeSoldProductButton.Location = new Point(560, 376);
            removeSoldProductButton.Name = "removeSoldProductButton";
            removeSoldProductButton.Size = new Size(187, 35);
            removeSoldProductButton.TabIndex = 16;
            removeSoldProductButton.Text = "Remover item";
            removeSoldProductButton.UseVisualStyleBackColor = false;
            removeSoldProductButton.Click += RemoveSoldProductButton_Click;
            // 
            // SellInitialDebtLabel
            // 
            SellInitialDebtLabel.Anchor = AnchorStyles.Right;
            SellInitialDebtLabel.AutoSize = true;
            SellInitialDebtLabel.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            SellInitialDebtLabel.Location = new Point(39, 338);
            SellInitialDebtLabel.Name = "SellInitialDebtLabel";
            SellInitialDebtLabel.Size = new Size(95, 45);
            SellInitialDebtLabel.TabIndex = 17;
            SellInitialDebtLabel.Text = "Total:";
            // 
            // sellDebtValueText
            // 
            sellDebtValueText.Anchor = AnchorStyles.Right;
            sellDebtValueText.AutoSize = true;
            sellDebtValueText.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            sellDebtValueText.Location = new Point(175, 350);
            sellDebtValueText.Name = "sellDebtValueText";
            sellDebtValueText.Size = new Size(0, 30);
            sellDebtValueText.TabIndex = 18;
            // 
            // discountTextValue
            // 
            discountTextValue.AutoSize = true;
            discountTextValue.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            discountTextValue.ForeColor = SystemColors.ControlText;
            discountTextValue.Location = new Point(660, 748);
            discountTextValue.Name = "discountTextValue";
            discountTextValue.Size = new Size(0, 25);
            discountTextValue.TabIndex = 19;
            // 
            // impossibleSellLable
            // 
            impossibleSellLable.AutoSize = true;
            impossibleSellLable.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            impossibleSellLable.ForeColor = Color.Red;
            impossibleSellLable.Location = new Point(297, 436);
            impossibleSellLable.Name = "impossibleSellLable";
            impossibleSellLable.Size = new Size(0, 25);
            impossibleSellLable.TabIndex = 20;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(availableProductsListView);
            panel1.Controls.Add(soldProductsLabel);
            panel1.Controls.Add(soldProductQuantityInput);
            panel1.Controls.Add(sellDebtValueText);
            panel1.Controls.Add(soldProductQuantityLabel);
            panel1.Controls.Add(SellInitialDebtLabel);
            panel1.Controls.Add(addSoldProductButton);
            panel1.Controls.Add(removeSoldProductButton);
            panel1.Controls.Add(clientComboBox);
            panel1.Controls.Add(downPaymentTextBox);
            panel1.Controls.Add(clientLabel);
            panel1.Controls.Add(downPaymentLabel);
            panel1.Controls.Add(dateLabel);
            panel1.Controls.Add(sellDateInput);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 441);
            panel1.TabIndex = 21;
            // 
            // AddSellForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 800);
            Controls.Add(panel1);
            Controls.Add(impossibleSellLable);
            Controls.Add(discountTextValue);
            Controls.Add(SelectedSoldProductsGrid);
            Controls.Add(AddSellButton);
            MinimumSize = new Size(818, 847);
            Name = "AddSellForm";
            Text = "Cadastro de venda";
            Load += AddSellForm_Load;
            ((System.ComponentModel.ISupportInitialize)soldProductQuantityInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)SelectedSoldProductsGrid).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label clientLabel;
        private ComboBox clientComboBox;
        private Label dateLabel;
        private DateTimePicker sellDateInput;
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
        private Label discountTextValue;
        private Label impossibleSellLable;
        private Panel panel1;
    }
}