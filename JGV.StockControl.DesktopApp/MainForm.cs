using JGV.StockControl.DesktopApp.Forms;
using JGV.StockControl.Library.DAL.IRepository;

namespace JGV.StockControl.DesktopApp
{
    public partial class MainForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Random _random = new();

        private Button _currentButton;
        private Form _activeForm;

        private int _tempIndex;
        public MainForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeComponent();
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
            if (_activeForm != null)
                _activeForm.Close();

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
            OpenChildForm(new ProductsForm(_unitOfWork), (Button)sender);
        }

        private void SellsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SellsForm(_unitOfWork), (Button)sender);

        }

        private void ClientDebtsButton_Click(object sender, EventArgs e)
        {
            if (_activeForm != null)
                _activeForm.Close();
            ActivateButton(sender);
        }
    }
}