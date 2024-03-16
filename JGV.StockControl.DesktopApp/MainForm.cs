using JGV.StockControl.DesktopApp.Forms;
using JGV.StockControl.DesktopApp.Forms.Products;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using JGV.StockControl.Library.DAL.Repository;
using JGV.StockControl.Library.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JGV.StockControl.DesktopApp
{
    public partial class MainForm : Form
    {
        private readonly Random _random = new();

        private Button _currentButton;
        private Form _activeForm;

        private int _tempIndex;

        private readonly IServiceProvider _serviceProvider;

        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        private Color SelectRandomColor()
        {
            int index = _random.Next(ThemeColor.ThemeColors.Count);
            while (_tempIndex == index)
                index = _random.Next(ThemeColor.ThemeColors.Count);
            _tempIndex = index;
            string color = ThemeColor.ThemeColors[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object buttonSender)
        {
            if (buttonSender != null)
            {
                if (_currentButton != (Button)buttonSender)
                {
                    DisableButtons();
                    Color randomColor = SelectRandomColor();
                    _currentButton = (Button)buttonSender;
                    _currentButton.BackColor = randomColor;
                    _currentButton.ForeColor = SystemColors.ButtonHighlight;
                    _currentButton.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
                    panelRightDetail.BackColor = randomColor;
                }
            }
        }
        private void DisableButtons()
        {
            foreach (Control otherButton in panelMenu.Controls)
            {
                if (otherButton.GetType() == typeof(Button))
                {
                    otherButton.BackColor = Color.FromArgb(158, 159, 165);
                    otherButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                }
            }
        }
        private void OpenChildForm(Form childForm, Button buttonSender)
        {
            _activeForm?.Close();

            ActivateButton(buttonSender);
            _activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            this.panelContent.Controls.Add(childForm);
            this.panelContent.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        private void ProductsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductsForm(
                _serviceProvider.GetService<ProductsService>()!, 
                _serviceProvider.GetService<AddProductForm>()!), 
                (Button)sender);
        }

        private void SellsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SellsForm(
                _serviceProvider.GetService<ISellRepository>()!,
                _serviceProvider.GetService<ClientsService>()!,
                _serviceProvider.GetService<SellsService>()!,
                _serviceProvider.GetService<SellDetailsForm>()!,
                _serviceProvider.GetService<AddSellForm>()!),
                (Button)sender);
        }

        private void ClientDebtsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ClientDebtsForm(_serviceProvider.GetService<UnitOfWork>()!, _serviceProvider.GetService<DebtDetailsForm>()!), (Button)sender);
        }
    }
}