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
    public partial class AddSellForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddSellForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }

        private void AddSellForm_Load(object sender, EventArgs e)
        {
            clientComboBox.DataSource = _unitOfWork.ClientRepository.GetAll();
            clientComboBox.DisplayMember = "Name";
            clientComboBox.ValueMember = "Id";
        }
    }
}
