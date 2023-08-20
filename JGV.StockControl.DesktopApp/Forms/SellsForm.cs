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
    public partial class SellsForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        public SellsForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }

        private void sellsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            InitializeGridView();
        }
        private void InitializeGridView()
        {
            sellsGridView.AutoGenerateColumns = true;
            sellsGridView.DataSource = _unitOfWork.SellRepository.GetAll();
        }
    }
}
