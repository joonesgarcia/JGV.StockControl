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
        private readonly IUnitOfWork _unitOfWork;
        private BindingList<ClientDebtViewModel> clientDebtView;

        public ClientDebtsForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
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
            clientDebtView = new BindingList<ClientDebtViewModel>(_unitOfWork.DebtsRepository.GetClientsDebtView());
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

                DebtDetailsForm sellDetailsForm = new(_unitOfWork, clientDebt);
                sellDetailsForm.Show();

                sellDetailsForm.FormClosed += RefreshClientDebtsGridOnDebtDetailsClose;
            }
        }
    }
}
