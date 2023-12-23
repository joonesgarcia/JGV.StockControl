using JGV.StockControl.Library;
using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;
using System.Globalization;

namespace JGV.StockControl.DesktopApp.Forms
{
    public partial class SellDetailsForm : Form
    {
        private readonly List<SoldProductViewModel> _soldProducts;
        private readonly IUnitOfWork _unitOfWork;
        public SellDetailsForm(List<SoldProductViewModel> soldProducts, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _soldProducts = soldProducts;
            _unitOfWork = unitOfWork;
        }

        private void SellDetailsForm_Load(object sender, EventArgs e)
        {
            InitializeGridView();
            InitializeDividaRestantePanel();
        }
        private void InitializeGridView()
        {
            sellDetailsGridView.AutoGenerateColumns = true;
            sellDetailsGridView.DataSource = _soldProducts;
        }
        private void InitializeDividaRestantePanel()
        {
            AtualizaDividaRestante();


        }
        private void AbaterDividaTextBoxOnlyNumbers(object sender, EventArgs e)
        {
            if (!decimal.TryParse(abaterDividaTextBox.Text, out _))
            {
                abaterDividaTextBox.Clear();
                abaterDividaTextBox.Text = "0";
            }
        }
        private void AtualizaDividaRestante()
        {
            labelDividaRestanteValor.Text = _soldProducts
            .Select(p => Tools.ExtractNumericValue(p.SoldPrice) * p.Quantity)
            .Sum()
            .ToString("C", new CultureInfo("pt-BR"));
        }

        private void BotaoAbaterDivida_Click(object sender, EventArgs e)
        {
            decimal valorAbater = Convert.ToDecimal(abaterDividaTextBox);

            if (valorAbater <= 0)
                return;

            if (valorAbater >= Tools.ExtractNumericValue(labelDividaRestanteValor.Text))
                valorAbater = Tools.ExtractNumericValue(labelDividaRestanteValor.Text);



            AtualizaDividaRestante();
        }
    }
}
