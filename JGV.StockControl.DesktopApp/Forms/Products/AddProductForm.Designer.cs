namespace JGV.StockControl.DesktopApp.Forms.Products
{
    partial class AddProductForm
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
            descriptionLbl = new Label();
            quantityLbl = new Label();
            costLbl = new Label();
            priceLbl = new Label();
            promotionlbl = new Label();
            descriptionInput = new TextBox();
            costInput = new TextBox();
            priceInput = new TextBox();
            promotionInput = new TextBox();
            quantityInput = new NumericUpDown();
            insertBtn = new Button();
            cleanInputsBtn = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)quantityInput).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // descriptionLbl
            // 
            descriptionLbl.AutoSize = true;
            descriptionLbl.Location = new Point(38, 58);
            descriptionLbl.Name = "descriptionLbl";
            descriptionLbl.Size = new Size(53, 20);
            descriptionLbl.TabIndex = 0;
            descriptionLbl.Text = "Nome:";
            // 
            // quantityLbl
            // 
            quantityLbl.AutoSize = true;
            quantityLbl.Location = new Point(38, 111);
            quantityLbl.Name = "quantityLbl";
            quantityLbl.Size = new Size(90, 20);
            quantityLbl.TabIndex = 1;
            quantityLbl.Text = "Quantidade:";
            // 
            // costLbl
            // 
            costLbl.AutoSize = true;
            costLbl.Location = new Point(38, 164);
            costLbl.Name = "costLbl";
            costLbl.Size = new Size(109, 20);
            costLbl.TabIndex = 2;
            costLbl.Text = "Preço de custo:";
            // 
            // priceLbl
            // 
            priceLbl.AutoSize = true;
            priceLbl.Location = new Point(38, 223);
            priceLbl.Name = "priceLbl";
            priceLbl.Size = new Size(114, 20);
            priceLbl.TabIndex = 3;
            priceLbl.Text = "Preço de venda:";
            // 
            // promotionlbl
            // 
            promotionlbl.AutoSize = true;
            promotionlbl.Location = new Point(38, 277);
            promotionlbl.Name = "promotionlbl";
            promotionlbl.Size = new Size(80, 20);
            promotionlbl.TabIndex = 4;
            promotionlbl.Text = "Promoção:";
            // 
            // descriptionInput
            // 
            descriptionInput.Location = new Point(158, 55);
            descriptionInput.Name = "descriptionInput";
            descriptionInput.Size = new Size(380, 27);
            descriptionInput.TabIndex = 5;
            // 
            // costInput
            // 
            costInput.Location = new Point(158, 164);
            costInput.Name = "costInput";
            costInput.Size = new Size(154, 27);
            costInput.TabIndex = 7;
            // 
            // priceInput
            // 
            priceInput.Location = new Point(158, 220);
            priceInput.Name = "priceInput";
            priceInput.Size = new Size(154, 27);
            priceInput.TabIndex = 8;
            // 
            // promotionInput
            // 
            promotionInput.Location = new Point(158, 277);
            promotionInput.Multiline = true;
            promotionInput.Name = "promotionInput";
            promotionInput.Size = new Size(380, 92);
            promotionInput.TabIndex = 9;
            // 
            // quantityInput
            // 
            quantityInput.BorderStyle = BorderStyle.FixedSingle;
            quantityInput.Location = new Point(158, 109);
            quantityInput.Maximum = new decimal(new int[] { 45, 0, 0, 0 });
            quantityInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            quantityInput.Name = "quantityInput";
            quantityInput.Size = new Size(85, 27);
            quantityInput.TabIndex = 11;
            quantityInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // insertBtn
            // 
            insertBtn.BackColor = Color.PowderBlue;
            insertBtn.FlatStyle = FlatStyle.Flat;
            insertBtn.Location = new Point(340, 25);
            insertBtn.Name = "insertBtn";
            insertBtn.Size = new Size(101, 29);
            insertBtn.TabIndex = 12;
            insertBtn.Text = "Inserir";
            insertBtn.UseVisualStyleBackColor = false;
            insertBtn.Click += insertBtn_Click;
            // 
            // cleanInputsBtn
            // 
            cleanInputsBtn.BackColor = Color.NavajoWhite;
            cleanInputsBtn.FlatStyle = FlatStyle.Flat;
            cleanInputsBtn.Location = new Point(456, 25);
            cleanInputsBtn.Name = "cleanInputsBtn";
            cleanInputsBtn.Size = new Size(101, 29);
            cleanInputsBtn.TabIndex = 13;
            cleanInputsBtn.Text = "Limpar";
            cleanInputsBtn.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(cleanInputsBtn);
            panel1.Controls.Add(insertBtn);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 409);
            panel1.Name = "panel1";
            panel1.Size = new Size(569, 75);
            panel1.TabIndex = 14;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 484);
            Controls.Add(panel1);
            Controls.Add(quantityInput);
            Controls.Add(promotionInput);
            Controls.Add(priceInput);
            Controls.Add(costInput);
            Controls.Add(descriptionInput);
            Controls.Add(promotionlbl);
            Controls.Add(priceLbl);
            Controls.Add(costLbl);
            Controls.Add(quantityLbl);
            Controls.Add(descriptionLbl);
            Name = "AddProductForm";
            Text = "Adicionar produto";
            ((System.ComponentModel.ISupportInitialize)quantityInput).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label descriptionLbl;
        private Label quantityLbl;
        private Label costLbl;
        private Label priceLbl;
        private Label promotionlbl;
        private TextBox descriptionInput;
        private TextBox costInput;
        private TextBox priceInput;
        private TextBox promotionInput;
        private NumericUpDown quantityInput;
        private Button insertBtn;
        private Button cleanInputsBtn;
        private Panel panel1;
    }
}