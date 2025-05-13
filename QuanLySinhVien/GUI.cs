using System.Data.SQLite;

namespace QuanLySinhVien
{
    public partial class GUI : Form
    {
        private MenuStrip menuStrip;
        private Label labelMaSinhVien;
        private Label labelHoVaTen;
        private Label labelNgaySinh;
        private Label labelQuocTich;
        private Label labelLop;
        private TextBox textBoxMaSinhVien;
        private TextBox textBoxHoVaTen;
        private DateTimePicker dateTimePicker;
        private ComboBox comboBoxQuocTich;
        private ComboBox comboBoxLop;
        private GroupBox groupBoxGioiTinh;
        private RadioButton radioButtonNam;
        private RadioButton radioButtonNu;
        private DataGridView dataGridView;
        private Button buttonThem;
        private Button buttonSua;
        private Button buttonXoa;
        private Button buttonLamMoi;

        public GUI()
        {
            InitializeComponent();
            DatabaseHelper.LoadData(dataGridView);
        }

        private bool IsInputValid()
        {
            return !string.IsNullOrWhiteSpace(textBoxMaSinhVien.Text) &&
                   !string.IsNullOrWhiteSpace(textBoxHoVaTen.Text) &&
                   comboBoxQuocTich.SelectedIndex != -1 &&
                   comboBoxLop.SelectedIndex != -1 &&
                   (radioButtonNam.Checked || radioButtonNu.Checked);
        }

        private SinhVien? GetSelectedSinhVien()
        {
            if (dataGridView.SelectedRows.Count == 0) return null;

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            return new SinhVien
            {
                MaSinhVien = selectedRow.Cells["MaSinhVien"].Value?.ToString() ?? string.Empty,
                HoTen = selectedRow.Cells["HoVaTen"].Value?.ToString() ?? string.Empty,
                NgaySinh = selectedRow.Cells["NgaySinh"].Value?.ToString() ?? string.Empty,
                QuocTich = selectedRow.Cells["QuocTich"].Value?.ToString() ?? string.Empty,
                Lop = selectedRow.Cells["Lop"].Value?.ToString() ?? string.Empty,
                GioiTinh = selectedRow.Cells["GioiTinh"].Value?.ToString() ?? string.Empty
            };
        }

        private void ButtonThem_Click(object sender, EventArgs e)
        {
            if (!IsInputValid())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SinhVien sinhVien = new SinhVien
            {
                MaSinhVien = textBoxMaSinhVien.Text,
                HoTen = textBoxHoVaTen.Text,
                NgaySinh = dateTimePicker.Value.ToString("dd/MM/yyyy"),
                QuocTich = comboBoxQuocTich.Text,
                Lop = comboBoxLop.Text,
                GioiTinh = radioButtonNam.Checked ? "Nam" : "Nữ"
            };

            DatabaseHelper.InsertSinhVien(sinhVien);
            DatabaseHelper.LoadData(dataGridView);

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["MaSinhVien"].Value?.ToString() == sinhVien.MaSinhVien)
                {
                    dataGridView.ClearSelection();
                    row.Selected = true;
                    dataGridView.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void ButtonSua_Click(object sender, EventArgs e)
        {
            SinhVien? sinhVien = GetSelectedSinhVien();
            if (sinhVien == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateForm updateForm = new UpdateForm(sinhVien);
            updateForm.ShowDialog();
            DatabaseHelper.LoadData(dataGridView);

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["MaSinhVien"].Value?.ToString() == sinhVien.MaSinhVien)
                {
                    dataGridView.ClearSelection();
                    row.Selected = true;
                    dataGridView.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            SinhVien? sinhVien = GetSelectedSinhVien();
            if (sinhVien == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DatabaseHelper.DeleteSinhVien(sinhVien.MaSinhVien);
                DatabaseHelper.LoadData(dataGridView);
            }
        }

        private void ButtonLamMoi_Click(object sender, EventArgs e)
        {
            DatabaseHelper.LoadData(dataGridView);
        }

        private void MenuItemSearch_Click() {
            SearchForm searchForm = new SearchForm(dataGridView);
            searchForm.ShowDialog();
        }
    }
}