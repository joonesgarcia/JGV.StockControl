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

        private void RefreshSellsForm(object? sender, FormClosedEventArgs e)
            => sellsGridView.DataSource = _unitOfWork.SellRepository.GetAll();

        private void SellsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                var sellId = Convert.ToInt32(sellsGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                if (sellId > 0)
                {
                    SellDetailsForm sellDetailsForm = new(sellId, _unitOfWork);
                    sellDetailsForm.Show();
                }
            }
        }

        private void AddSellBtn_Click(object sender, EventArgs e)
        {
            AddSellForm addSellForm = new(_unitOfWork);
            addSellForm.Show();

            addSellForm.FormClosed += RefreshSellsForm;
        }
    }
}
