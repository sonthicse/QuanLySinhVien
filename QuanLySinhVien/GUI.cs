using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace QuanLySinhVien
{
    public partial class GUI : Form
    {
        // Tạo các Label
        Label labelMaSinhVien = new Label
        {
            Text = "Mã sinh viên",
            Location = new Point(50, 50),
            Font = new Font("Arial", 12)
        };
        Label labelHoVaTen = new Label
        {
            Text = "Họ và tên",
            Location = new Point(50, 100),
            Font = new Font("Arial", 12)
        };
        Label labelNgaySinh = new Label
        {
            Text = "Ngày sinh",
            Location = new Point(50, 150),
            Font = new Font("Arial", 12)
        };
        Label labelQuocTich = new Label
        {
            Text = "Quốc tịch",
            Location = new Point(900, 50),
            Font = new Font("Arial", 12)
        };
        Label labelLop = new Label
        {
            Text = "Lớp",
            Location = new Point(900, 100),
            Font = new Font("Arial", 12)
        };

        // Tạo các TextBox
        TextBox textBoxMaSinhVien = new TextBox
        {
            PlaceholderText = "202301318",
            Location = new Point(200, 50),
            Size = new Size(300, 30),
            Font = new Font("Arial", 12)
        };
        TextBox textBoxHoVaTen = new TextBox
        {
            PlaceholderText = "Nguyễn Văn A",
            Location = new Point(200, 100),
            Size = new Size(300, 30),
            Font = new Font("Arial", 12)
        };

        // Tạo DateTimePicker
        DateTimePicker dateTimePicker = new DateTimePicker
        {
            Location = new Point(200, 150),
            Size = new Size(300, 30),
            Font = new Font("Arial", 12)
        };

        // Tạo ComboBox
        ComboBox comboBoxQuocTich = new ComboBox
        {
            Location = new Point(1000, 50),
            Size = new Size(300, 30),
            Font = new Font("Arial", 12),
            Items = { "Việt Nam", "Mỹ" },
            SelectedIndex = -1,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        ComboBox comboBoxLop = new ComboBox
        {
            Location = new Point(1000, 100),
            Size = new Size(300, 30),
            Font = new Font("Arial", 12),
            Items = { "ANHTTT", "TT" },
            SelectedIndex = -1,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        // Tạo GroupBoxGioiTinh
        GroupBox groupBoxGioiTinh = new GroupBox
        {
            Text = "Giới tính",
            Location = new Point(1000, 150),
            Size = new Size(300, 80),
            Font = new Font("Arial", 12),
        };
        RadioButton radioButtonNam = new RadioButton
        {
            Text = "Nam",
            Location = new Point(20, 30),
            Font = new Font("Arial", 12)
        };
        RadioButton radioButtonNu = new RadioButton
        {
            Text = "Nữ",
            Location = new Point(150, 30),
            Font = new Font("Arial", 12)
        };
        // Tạo DataGridView
        DataGridView dataGridView = new DataGridView
        {
            Location = new Point(50, 300),
            Size = new Size(1400, 600),
            Font = new Font("Arial", 12),
            Columns = 
            {
                new DataGridViewTextBoxColumn { Name = "MaSinhVien", HeaderText = "Mã sinh viên" },
                new DataGridViewTextBoxColumn { Name = "HoVaTen", HeaderText = "Họ và tên" },
                new DataGridViewTextBoxColumn { Name = "NgaySinh", HeaderText = "Ngày sinh" },
                new DataGridViewTextBoxColumn { Name = "QuocTich", HeaderText = "Quốc tịch" },
                new DataGridViewTextBoxColumn { Name = "Lop", HeaderText = "Lớp" },
                new DataGridViewTextBoxColumn { Name = "GioiTinh", HeaderText = "Giới tính" }
            },
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false,
            AllowUserToAddRows = false,
            ReadOnly = true
        };

        // Tạo các Button
        Button buttonThem = new Button()
        {
            Text = "Thêm",
            Location = new Point(600, 250),
            Size = new Size(100, 30),
            Font = new Font("Arial", 12),
        };
        Button buttonSua = new Button()
        {
            Text = "Sửa",
            Location = new Point(700, 250),
            Size = new Size(100, 30),
            Font = new Font("Arial", 12)
        };
        Button buttonXoa = new Button()
        {
            Text = "Xóa",
            Location = new Point(800, 250),
            Size = new Size(100, 30),
            Font = new Font("Arial", 12)
        };
        Button buttonLamMoi = new Button()
        {
            Text = "Làm mới",
            Location = new Point(1350, 250),
            Size = new Size(100, 30),
            Font = new Font("Arial", 12)
        };

        private string? selectedMaSinhVien;

        public GUI()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string connectionString = $"Data Source=database\\database.db;Version=3;";

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM SinhVien";
                    using (var command = new SQLiteCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        dataGridView.Rows.Clear();
                        while (reader.Read())
                        {
                            dataGridView.Rows.Add(
                                reader["MaSinhVien"],
                                reader["HoTen"],
                                reader["NgaySinh"],
                                reader["QuocTich"],
                                reader["Lop"],
                                reader["GioiTinh"]
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonThem_Click(object sender, EventArgs e)
        {            
            if (string.IsNullOrWhiteSpace(textBoxMaSinhVien.Text) || string.IsNullOrWhiteSpace(textBoxHoVaTen.Text) || comboBoxQuocTich.SelectedIndex == -1 || comboBoxLop.SelectedIndex == -1 || (radioButtonNam != null && !radioButtonNam.Checked && radioButtonNu != null && !radioButtonNu.Checked))
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
                GioiTinh = groupBoxGioiTinh.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Text == "Nam")?.Checked == true ? "Nam" : "Nữ"
            };

            QuanLySinhVien.DatabaseHelper.InsertSinhVien(sinhVien);
            LoadData();

            MessageBox.Show("Thêm sinh viên thành công!");
        }

        private void ButtonSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            string selectedMaSinhVien = selectedRow.Cells["MaSinhVien"].Value.ToString();
            if (string.IsNullOrEmpty(selectedMaSinhVien))
            {
                MessageBox.Show("Vui lòng chọn sinh viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form formSua = new Form
            {
                Text = "Sửa thông tin sinh viên",
                Size = new Size(420, 500),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                MaximizeBox = false
            };
            Label labelHoTen = new Label
            {
                Text = "Họ và tên",
                Location = new Point(20, 20),
                Font = new Font("Arial", 12),
                Size = new Size(80, 30)
            };
            Label labelNgaySinh = new Label
            {
                Text = "Ngày sinh",
                Location = new Point(20, 70),
                Font = new Font("Arial", 12),
                Size = new Size(80, 30)
            };
            Label labelQuocTich = new Label
            {
                Text = "Quốc tịch",
                Location = new Point(20, 120),
                Font = new Font("Arial", 12),
                Size = new Size(80, 30)
            };
            Label labelLop = new Label
            {
                Text = "Lớp",
                Location = new Point(20, 170),
                Font = new Font("Arial", 12),
                Size = new Size(80, 30)
            };
            Label labelGioiTinh = new Label
            {
                Text = "Giới tính",
                Location = new Point(20, 220),
                Font = new Font("Arial", 12),
                Size = new Size(80, 30)
            };
            TextBox textBoxHoTen = new TextBox
            {
                Text = selectedRow.Cells["HoVaTen"].Value.ToString(),
                Location = new Point(100, 20),
                Size = new Size(280, 30),
                Font = new Font("Arial", 12)
            };
            DateTimePicker dateTimePicker = new DateTimePicker
            {
                Value = DateTime.Parse(selectedRow.Cells["NgaySinh"].Value.ToString()),
                Location = new Point(100, 70),
                Size = new Size(280, 30),
                Font = new Font("Arial", 12)
            };
            ComboBox comboBoxQuocTich = new ComboBox
            {
                Location = new Point(100, 120),
                Size = new Size(280, 30),
                Font = new Font("Arial", 12),
                Items = { "Việt Nam", "Mỹ" },
                SelectedIndex = selectedRow.Cells["QuocTich"].Value.ToString() == "Việt Nam" ? 0 : 1,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            ComboBox comboBoxLop = new ComboBox
            {
                Location = new Point(100, 170),
                Size = new Size(280, 30),
                Font = new Font("Arial", 12),
                Items = { "ANHTTT", "TT" },
                SelectedIndex = selectedRow.Cells["Lop"].Value.ToString() == "ANHTTT" ? 0 : 1,
                DropDownStyle = ComboBoxStyle.DropDownList                
            };
            RadioButton radioButtonNam = new RadioButton
            {
                Text = "Nam",
                Location = new Point(150, 220),
                Size = new Size(80, 30),
                Checked = selectedRow.Cells["GioiTinh"].Value.ToString() == "Nam",
                Font = new Font("Arial", 12)
            };
            RadioButton radioButtonNu = new RadioButton
            {
                Text = "Nữ",
                Location = new Point(250, 220),
                Size = new Size(80, 30),
                Checked = selectedRow.Cells["GioiTinh"].Value.ToString() == "Nữ",
                Font = new Font("Arial", 12)
            };
            Button buttonLuu = new Button
            {
                Text = "Lưu",
                Location = new Point(110, 270),
                Size = new Size(100, 30),
                Font = new Font("Arial", 12),
            };
            Button buttonHuy = new Button
            {
                Text = "Hủy",
                Location = new Point(210, 270),
                Size = new Size(100, 30),
                Font = new Font("Arial", 12)
            };
            buttonHuy.Click += (s, args) => formSua.Close();
            
            formSua.Controls.Add(labelHoTen);
            formSua.Controls.Add(labelNgaySinh);
            formSua.Controls.Add(labelQuocTich);
            formSua.Controls.Add(labelLop);
            formSua.Controls.Add(labelGioiTinh);
            formSua.Controls.Add(textBoxHoTen);
            formSua.Controls.Add(dateTimePicker);
            formSua.Controls.Add(comboBoxQuocTich);
            formSua.Controls.Add(comboBoxLop);
            formSua.Controls.Add(radioButtonNam);
            formSua.Controls.Add(radioButtonNu);
            formSua.Controls.Add(buttonLuu);
            formSua.Controls.Add(buttonHuy);
            formSua.ShowDialog(this);

            LoadData();
        }

        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            string selectedMaSinhVien = selectedRow.Cells["MaSinhVien"].Value.ToString();
            if (string.IsNullOrEmpty(selectedMaSinhVien))
            {
                MessageBox.Show("Vui lòng chọn sinh viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                QuanLySinhVien.DatabaseHelper.DeleteSinhVien(selectedMaSinhVien);
                LoadData();
                MessageBox.Show("Xóa sinh viên thành công!");
            }
        }

        private void ButtonLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            textBoxMaSinhVien.Clear();
            textBoxHoVaTen.Clear();
            dateTimePicker.Value = DateTime.Now;
            comboBoxQuocTich.SelectedIndex = -1;
            comboBoxLop.SelectedIndex = -1;
            radioButtonNam.Checked = false;
            radioButtonNu.Checked = false;
        }
    }
}