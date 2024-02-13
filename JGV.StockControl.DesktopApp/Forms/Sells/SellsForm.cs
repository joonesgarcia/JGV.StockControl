using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using static System.ComponentModel.Design.ObjectSelectorEditor;

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
            LoadClientComboBox();
            RefreshSellsForm();
        }
        private void InitializeGridView()
        {
            sellsGridView.AutoGenerateColumns = true;
            sellsGridView.DataSource = _unitOfWork.SellRepository.GetAll();
        }

        private void RefreshSellsFormAfterCloseAddSellForm(object? sender, FormClosedEventArgs e)
            => sellsGridView.DataSource = _unitOfWork.SellRepository.GetAll();
        private void SellsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                var sellId = Convert.ToInt32(sellsGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                if (sellId > 0)
                {
                    SellDetailsForm sellDetailsForm = new(sellId, _unitOfWork);
                    sellDetailsForm.ShowDialog();
                }
            }
        }

        private void AddSellBtn_Click(object sender, EventArgs e)
        {
            AddSellForm addSellForm = new(_unitOfWork);
            addSellForm.Show();

            addSellForm.FormClosed += RefreshSellsFormAfterCloseAddSellForm;
        }
        private void RefreshSellsForm(int? clientId = null)
        {
            if (clientId == null)
            {
                sellsGridView.DataSource = _unitOfWork.SellRepository.GetAll();
                return;
            }
            Client? selectedClient = _unitOfWork.ClientRepository.GetClientById(clientId);
            if (selectedClient != null)
            {
                sellsGridView.DataSource = _unitOfWork.SellRepository.GetAll(selectedClient);
                return;
            }
        }

        private void LoadClientComboBox()
        {
            clientComboBox.DataSource = _unitOfWork.ClientRepository.GetAll();
            clientComboBox.DisplayMember = "Name";
            clientComboBox.ValueMember = "Id";
            clientComboBox.SelectedItem = null;
        }
        private void ClientComboBoxSelectionChanged(object? sender, EventArgs e)
        {
            if (clientComboBox.SelectedItem != null)
            {
                Client selected = clientComboBox.SelectedItem as Client;
                RefreshSellsForm(selected!.Id);
            }
        }
        private void CleanClientFilterBtn_Click(object sender, EventArgs e)
        {
            clientComboBox.SelectedItem = null;
            RefreshSellsForm();
        }
    }
}
