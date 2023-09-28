using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;

namespace JGV.StockControl.DesktopApp.Forms
{
    public partial class SellDetailsForm : Form
    {
        private readonly List<SoldProductViewModel> _soldProductsViewModel;
        private readonly IUnitOfWork _unitOfWork;
        public SellDetailsForm(List<SoldProductViewModel> soldProductsViewModel, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _soldProductsViewModel = soldProductsViewModel;
            _unitOfWork = unitOfWork;
        }

        private void SellDetailsForm_Load(object sender, EventArgs e)
        {
            InitializeGridView();
        }
        private void InitializeGridView()
        {
            sellDetailsGridView.AutoGenerateColumns = true;
            sellDetailsGridView.DataSource = _soldProductsViewModel;
        }
    }
}
