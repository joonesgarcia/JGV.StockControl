using JGV.StockControl.DesktopApp.Events;
using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.Models;
using JGV.StockControl.Library.DAL.Repository;
using JGV.StockControl.Library.Services;
using static JGV.StockControl.Library.Services.ClientsService;

namespace JGV.StockControl.DesktopApp.Forms
{
    public partial class SellsForm : Form
    {
        private readonly ISellRepository sellRepository;

        private readonly ClientsService clientService;
        private readonly SellsService sellsService;

        private readonly SellDetailsForm detailsForm;
        private readonly AddSellForm addSellForm;

        public event EventHandler<SellSelectedEventArgs> SellSelected;

        public SellsForm(ISellRepository sellRepository, ClientsService clientService, SellsService sellsService, SellDetailsForm detailsForm, AddSellForm addSellForm)
        {
            InitializeComponent();

            this.sellsService = sellsService;
            this.detailsForm = detailsForm;
            this.addSellForm = addSellForm;
            this.sellRepository = sellRepository;
            this.clientService = clientService;

            SellSelected += detailsForm.HandleSellSelected;
        }

        #region ::: Grid/Client filter form load  :::
        private void SellsForm_Load(object sender, EventArgs e)
        {
            LoadSellsGridView();
            LoadClientComboBox();
        }
        private void LoadSellsGridView()
        {
            sellsGridView.AutoGenerateColumns = true;
            sellsGridView.DataSource = sellsService.GetAllSellsView();
        }
        private void LoadClientComboBox()
        {
            clientComboBox.SelectedIndexChanged -= ClientComboBoxSelectionChanged;
            clientComboBox.DataSource = clientService.GetAllClients().ToList();
            clientComboBox.DisplayMember = "Name";
            clientComboBox.ValueMember = "Id";
            clientComboBox.SelectedItem = null;
            clientComboBox.SelectedIndexChanged += ClientComboBoxSelectionChanged;

        }
        #endregion

        #region ::: Events :::
        // Client filter events
        private void ClientComboBoxSelectionChanged(object? sender, EventArgs e)
        {
            if (clientComboBox.SelectedItem != null)
            {
                ClientInfo selected = (ClientInfo)clientComboBox.SelectedItem;
                RefreshSellsGridView(selected.Id);
            }
        }
        private void CleanClientFilterBtn_Click(object sender, EventArgs e)
        {
            clientComboBox.SelectedItem = null;
            RefreshSellsGridView();
        }

        // Add new sell events
        private void AddSellBtn_Click(object sender, EventArgs e)
        {
            addSellForm.ShowDialog();
            addSellForm.FormClosed += RefreshSellsFormAfterCloseAddSellForm;
        }
        private void RefreshSellsFormAfterCloseAddSellForm(object? sender, FormClosedEventArgs e)
        => sellsGridView.DataSource = sellsService.GetAllSellsView();

        // Grid events
        private void OnSellSelected(SellOutputModel sell)
        => SellSelected.Invoke(this, new SellSelectedEventArgs(sell));

        private void SellsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                var sellId = Convert.ToInt32(sellsGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                Sell? sell = sellRepository.GetSellById(sellId);

                if (sell != null)
                {
                    OnSellSelected(sellsService.GetSellView(sell)) ;
                    detailsForm.ShowDialog();            
                }
            }
        }
        private void RefreshSellsGridView(int? clientId = null)
        {
            if (clientId == null)
            {
                sellsGridView.DataSource = sellsService.GetAllSellsView();
                return;
            }
            sellsGridView.DataSource = sellsService.GetAllSellsView(clientId);
        }
        #endregion
    }
}
