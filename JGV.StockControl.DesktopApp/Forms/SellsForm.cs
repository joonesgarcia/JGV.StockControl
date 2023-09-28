using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;

namespace JGV.StockControl.DesktopApp.Forms
{
    public partial class SellsForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        public SellsForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }
        private void SellsForm_Load(object sender, EventArgs e)
        {
            InitializeGridView();
        }
        private void InitializeGridView()
        {
            sellsGridView.AutoGenerateColumns = true;
            sellsGridView.DataSource = _unitOfWork.SellRepository.GetAll();
        }

        private void sellsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) {
                var sellId = sellsGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (sellId != null)
                {
                    var soldProducts = _unitOfWork.SellRepository
                        .GetSellById(int.Parse(sellId.ToString())).SoldProducts
                        .Select(sp => new SoldProductViewModel(sp.Product.Description, sp.Product.Cost, sp.Quantity, sp.SoldPrice))
                        .ToList();
                    SellDetailsForm sellDetailsForm = new SellDetailsForm(soldProducts, _unitOfWork);
                    sellDetailsForm.Show();
                }
            }
        }
    }
}
