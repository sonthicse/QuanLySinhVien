using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class SearchForm : Form
    {
        Label? labelTimKiem;
        TextBox? textBoxTimKiem;
        Button? buttonTimkiem;
        DataGridView dataGridView;

        public SearchForm(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
            InitializeComponent();
        }

        private void ButtonTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = textBoxTimKiem.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                bool isVisible = row.Cells.Cast<DataGridViewCell>().Any(cell => cell.Value != null && cell.Value.ToString()!.ToLower().Contains(keyword));
                row.Visible = isVisible;
            }

            this.Close();
        }
    }
}
