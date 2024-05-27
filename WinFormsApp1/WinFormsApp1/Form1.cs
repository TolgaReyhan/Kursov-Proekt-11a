using Business;
using Data;
using Data.Models;
using System.Drawing.Text;
using static Business.BankBusiness;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public BankBusiness bankBusiness = new BankBusiness();
        private int editId = 0;
        public Form1()
        {
            var db = new BankDbContext();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            ClearTextBoxes();
        }
        private void UpdateGrid()
        {
            dataGridView1.DataSource = bankBusiness.GetAll();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void ClearTextBoxes()
        {
            txtName.Text = "";
            txtBalance.Text = "0";
            txtWithdraw.Text = "0";
            txtDeposit.Text = "0";
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            var name = txtName.Text;
            double balance = 0;
            double.TryParse(txtBalance.Text, out balance);
            int withdraw = 0;
            int.TryParse(txtWithdraw.Text, out withdraw);
            int deposit = 0;
            int.TryParse(txtDeposit.Text, out deposit);
            Bank bank = new Bank();
            bank.Name = name;
            bank.Balance = balance;
            bank.Withdraw = withdraw;
            bank.Deposit = deposit;
            bankBusiness.Add(bank);
            UpdateGrid();
            ClearTextBoxes();
        }
        private void UpdateTextboxes(int id)
        {
            Bank update = bankBusiness.Get(id);
            txtName.Text = update.Name;
            txtBalance.Text = update.Balance.ToString();
            txtWithdraw.Text = update.Withdraw.ToString();
            txtDeposit.Text = update.Deposit.ToString();
        }
        private void ToggleSaveUpdate()
        {
            if (btnUpdate.Visible)
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
            else
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
        }
        private void DisableSelect()
        {
            dataGridView1.Enabled = false;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var item = dataGridView1.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                editId = id;
                UpdateTextboxes(id);
                ToggleSaveUpdate();
                DisableSelect();
            }
        }
        private Bank GetEditedBank()
        {
            Bank bank = new Bank();
            bank.Id = editId;
            var name = txtName.Text;
            double balance = 0;
            double.TryParse(txtBalance.Text, out balance);
            int withdraw = 0;
            int.TryParse(txtWithdraw.Text, out withdraw);
            int deposit = 0;
            int.TryParse(txtDeposit.Text, out deposit);
            bank.Name = name;
            bank.Balance = balance;
            bank.Withdraw = withdraw;
            bank.Deposit = deposit;
            return bank;
        }
        private void ResetSelect()
        {
            dataGridView1.ClearSelection();
            dataGridView1.Enabled = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Bank editedBank = GetEditedBank();
            bankBusiness.Update(editedBank);
            UpdateGrid();
            ResetSelect();
            ToggleSaveUpdate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var item = dataGridView1.SelectedRows[0].Cells;
                var id = int.Parse(item[0].Value.ToString());
                bankBusiness.Delete(id);
                UpdateGrid();
                ResetSelect();
            }
        }
    }
}
