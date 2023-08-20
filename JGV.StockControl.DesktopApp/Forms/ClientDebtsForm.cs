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
            // ... add data
        }
    }
}
