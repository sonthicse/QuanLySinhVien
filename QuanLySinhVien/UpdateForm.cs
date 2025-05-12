namespace QuanLySinhVien
{
    public partial class UpdateForm : Form
    {
        private SinhVien updateSinhVien;

        // Create and configure controls
        private Label labelMaSinhVien;
        private Label labelHoVaTen;
        private Label labelNgaySinh;
        private Label labelQuocTich;
        private Label labelLop;
        private Label labelGioiTinh;
        private TextBox textBoxMaSinhVien;
        private TextBox textBoxHoVaTen;
        private DateTimePicker dateTimePicker;
        private ComboBox comboBoxQuocTich;
        private ComboBox comboBoxLop;
        private RadioButton radioButtonNam;
        private RadioButton radioButtonNu;
        private Button buttonLuu;
        private Button buttonHuy;

        public UpdateForm(SinhVien sinhVien)
        {
            this.updateSinhVien = sinhVien;
            InitializeComponent();
        }

        private void ButtonLuu_Click(object? sender, EventArgs e)
        {
            updateSinhVien.HoTen = textBoxHoVaTen.Text;
            updateSinhVien.NgaySinh = dateTimePicker.Value.ToString("dd/MM/yyyy");
            updateSinhVien.QuocTich = comboBoxQuocTich.SelectedItem?.ToString() ?? string.Empty;
            updateSinhVien.Lop = comboBoxLop.SelectedItem?.ToString() ?? string.Empty;
            updateSinhVien.GioiTinh = radioButtonNam.Checked ? "Nam" : "Nữ";
            MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DatabaseHelper.UpdateSinhVien(updateSinhVien);
            this.Close();
        }

        private void ButtonHuy_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
