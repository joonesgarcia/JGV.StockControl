namespace JGV.StockControl.DesktopApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMenu = new Panel();
            clientDebtsButton = new Button();
            SellsButton = new Button();
            productsButton = new Button();
            logoPanel = new Panel();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(158, 159, 165);
            panelMenu.Controls.Add(clientDebtsButton);
            panelMenu.Controls.Add(SellsButton);
            panelMenu.Controls.Add(productsButton);
            panelMenu.Controls.Add(logoPanel);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(203, 599);
            panelMenu.TabIndex = 0;
            // 
            // clientDebtsButton
            // 
            clientDebtsButton.FlatAppearance.BorderSize = 0;
            clientDebtsButton.FlatStyle = FlatStyle.Flat;
            clientDebtsButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            clientDebtsButton.ForeColor = SystemColors.ButtonHighlight;
            clientDebtsButton.Image = Properties.Resources.debt__1__removebg_preview;
            clientDebtsButton.Location = new Point(0, 425);
            clientDebtsButton.Name = "clientDebtsButton";
            clientDebtsButton.Padding = new Padding(0, 0, 0, 20);
            clientDebtsButton.Size = new Size(203, 174);
            clientDebtsButton.TabIndex = 3;
            clientDebtsButton.Text = "Clientes/Dividas";
            clientDebtsButton.TextAlign = ContentAlignment.BottomCenter;
            clientDebtsButton.TextImageRelation = TextImageRelation.TextAboveImage;
            clientDebtsButton.UseVisualStyleBackColor = true;
            clientDebtsButton.Click += clientDebtsButton_Click;
            // 
            // SellsButton
            // 
            SellsButton.FlatAppearance.BorderSize = 0;
            SellsButton.FlatStyle = FlatStyle.Flat;
            SellsButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            SellsButton.ForeColor = SystemColors.ButtonHighlight;
            SellsButton.Image = Properties.Resources.handshake__1__removebg_preview;
            SellsButton.Location = new Point(0, 251);
            SellsButton.Name = "SellsButton";
            SellsButton.Padding = new Padding(0, 0, 0, 20);
            SellsButton.Size = new Size(203, 174);
            SellsButton.TabIndex = 2;
            SellsButton.Text = "Vendas";
            SellsButton.TextAlign = ContentAlignment.BottomCenter;
            SellsButton.TextImageRelation = TextImageRelation.TextAboveImage;
            SellsButton.UseVisualStyleBackColor = true;
            SellsButton.Click += SellsButton_Click;
            // 
            // productsButton
            // 
            productsButton.FlatAppearance.BorderSize = 0;
            productsButton.FlatStyle = FlatStyle.Flat;
            productsButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            productsButton.ForeColor = SystemColors.ButtonHighlight;
            productsButton.Image = Properties.Resources.boxes__2__removebg_preview;
            productsButton.Location = new Point(0, 77);
            productsButton.Name = "productsButton";
            productsButton.Padding = new Padding(0, 0, 0, 20);
            productsButton.Size = new Size(203, 174);
            productsButton.TabIndex = 1;
            productsButton.Text = "Estoque";
            productsButton.TextAlign = ContentAlignment.BottomCenter;
            productsButton.TextImageRelation = TextImageRelation.TextAboveImage;
            productsButton.UseVisualStyleBackColor = true;
            productsButton.Click += productsButton_Click;
            // 
            // logoPanel
            // 
            logoPanel.BackColor = Color.FromArgb(108, 108, 112);
            logoPanel.Dock = DockStyle.Top;
            logoPanel.Location = new Point(0, 0);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(203, 77);
            logoPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 599);
            Controls.Add(panelMenu);
            Name = "MainForm";
            Text = "Controle de vendas";
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel logoPanel;
        private Button clientDebtsButton;
        private Button SellsButton;
        private Button productsButton;
    }
}