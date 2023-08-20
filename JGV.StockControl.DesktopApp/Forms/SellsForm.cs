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
            ///sellsGridView.DataSource = _unitOfWork.SellRepository.GetAll();
        }


    }
}
