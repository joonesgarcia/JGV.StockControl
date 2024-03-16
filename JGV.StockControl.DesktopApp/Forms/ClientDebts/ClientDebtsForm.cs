using JGV.StockControl.DesktopApp.Events;
using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JGV.StockControl.DesktopApp.Forms
{
    public partial class ClientDebtsForm : Form
    {
        public event EventHandler<DebtSelectedEventArgs> DebtSelected;

        private readonly IUnitOfWork _unitOfWork;
        private readonly DebtDetailsForm _debtDetailsForm;

        private BindingList<ClientDebtOutputModel> clientDebtView;

        public ClientDebtsForm(IUnitOfWork unitOfWork, DebtDetailsForm debtDetailsForm)
        {
            InitializeComponent();

            _unitOfWork = unitOfWork;

            _debtDetailsForm = debtDetailsForm;
            _debtDetailsForm.FormClosed += RefreshClientDebtsGridOnDebtDetailsClose;

            DebtSelected += _debtDetailsForm.HandleDebtSelected;
        }

        private void ClientDebtsForm_Load(object sender, EventArgs e)
        {
            InitializeGridView();
        }
        private void InitializeGridView()
        {
            ClientDebtsGridView.AutoGenerateColumns = true;
            RefreshClientDebtsGrid();
            ClientDebtsGridView.Columns["Id"].Visible = false;
        }
        private void RefreshClientDebtsGrid()
        {
            clientDebtView = new BindingList<ClientDebtOutputModel>(_unitOfWork.DebtsRepository.GetClientsDebtView());
            ClientDebtsGridView.DataSource = clientDebtView;
        }
        private void RefreshClientDebtsGridOnDebtDetailsClose(object? sender, FormClosedEventArgs e)
        => RefreshClientDebtsGrid();
        private void ClientDebtsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var clientName = Convert.ToString(ClientDebtsGridView.Rows[e.RowIndex].Cells[1].Value);
                var clientDebt = clientDebtView.ToList()
                    .Single(x => x.ClientName.Equals(clientName));

                _debtDetailsForm.Show();

            }
        }
        private void OnDebtSelected(ClientDebtOutputModel debt)
        {

        }
    }
}
