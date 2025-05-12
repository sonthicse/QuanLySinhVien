namespace QuanLySinhVien
{
    partial class Update
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();

            InitializeFormProperties();

            InitializeLabels();
            InitializeTextBoxes();
            InitializeComboBoxes();
            InitializeRadioButtons();
            InitializeDateTimePicker();
            InitializeButtons();

            AddControlsToForm();

            this.ResumeLayout(false);
        }

        private void InitializeFormProperties()
        {
            this.Size = new System.Drawing.Size(420, 420);
            this.Text = "Cập nhật thông tin sinh viên";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void InitializeLabels()
        {
            labelMaSinhVien = new Label
            {
                Text = "Mã sinh viên",
                Location = new Point(20, 20),
                Font = new Font("Arial", 12),
                Size = new Size(100, 30)
            };
            labelHoVaTen = new Label
            {
                Text = "Họ và tên",
                Location = new Point(20, 70),
                Font = new Font("Arial", 12),
                Size = new Size(80, 30)
            };
            labelNgaySinh = new Label
            {
                Text = "Ngày sinh",
                Location = new Point(20, 120),
                Font = new Font("Arial", 12),
                Size = new Size(80, 30)
            };
            labelQuocTich = new Label
            {
                Text = "Quốc tịch",
                Location = new Point(20, 170),
                Font = new Font("Arial", 12),
                Size = new Size(80, 30)
            };
            labelLop = new Label
            {
                Text = "Lớp",
                Location = new Point(20, 220),
                Font = new Font("Arial", 12),
                Size = new Size(80, 30)
            };
            labelGioiTinh = new Label
            {
                Text = "Giới tính",
                Location = new Point(20, 270),
                Font = new Font("Arial", 12),
                Size = new Size(80, 30)
            };
        }

        private void InitializeTextBoxes()
        {
            textBoxMaSinhVien = new TextBox
            {
                Text = updateSinhVien.MaSinhVien,
                Location = new Point(120, 15),
                Size = new Size(280, 30),
                Font = new Font("Arial", 12),
                ReadOnly = true,
                Enabled = false
            };
            textBoxHoVaTen = new TextBox
            {
                Text = updateSinhVien.HoTen,
                Location = new Point(120, 65),
                Size = new Size(280, 30),
                Font = new Font("Arial", 12)
            };
        }

        private void InitializeComboBoxes()
        {
            comboBoxQuocTich = new ComboBox
            {
                Location = new Point(120, 165),
                Size = new Size(280, 30),
                Font = new Font("Arial", 12),
                Items = { "Việt Nam", "Mỹ" },
                SelectedIndex = updateSinhVien.QuocTich == "Việt Nam" ? 0 : 1,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            comboBoxLop = new ComboBox
            {
                Location = new Point(120, 215),
                Size = new Size(280, 30),
                Font = new Font("Arial", 12),
                Items = { "ANHTTT", "TT" },
                SelectedIndex = updateSinhVien.Lop == "ANHTTT" ? 0 : 1,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
        }

        private void InitializeRadioButtons()
        {
            radioButtonNam = new RadioButton
            {
                Text = "Nam",
                Location = new Point(150, 265),
                Size = new Size(80, 30),
                Checked = updateSinhVien.GioiTinh == "Nam",
                Font = new Font("Arial", 12)
            };
            radioButtonNu = new RadioButton
            {
                Text = "Nữ",
                Location = new Point(250, 265),
                Size = new Size(80, 30),
                Checked = updateSinhVien.GioiTinh == "Nữ",
                Font = new Font("Arial", 12)
            };
        }

        private void InitializeDateTimePicker()
        {
            dateTimePicker = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Location = new Point(120, 115),
                Size = new Size(280, 30),
                Font = new Font("Arial", 12)
            };
            dateTimePicker.Value = DateTime.ParseExact(updateSinhVien.NgaySinh, "dd/MM/yyyy", null);
        }

        private void InitializeButtons()
        {
            buttonLuu = new Button
            {
                Text = "Lưu",
                Location = new Point(110, 310),
                Size = new Size(100, 30),
                Font = new Font("Arial", 12)
            };
            buttonHuy = new Button
            {
                Text = "Hủy",
                Location = new Point(210, 310),
                Size = new Size(100, 30),
                Font = new Font("Arial", 12)
            };

            buttonLuu.Click += ButtonLuu_Click;
            buttonHuy.Click += ButtonHuy_Click;
        }

        private void AddControlsToForm()
        {
            this.Controls.Add(labelMaSinhVien);
            this.Controls.Add(labelHoVaTen);
            this.Controls.Add(labelNgaySinh);
            this.Controls.Add(labelQuocTich);
            this.Controls.Add(labelLop);
            this.Controls.Add(labelGioiTinh);
            this.Controls.Add(textBoxMaSinhVien);
            this.Controls.Add(textBoxHoVaTen);
            this.Controls.Add(dateTimePicker);
            this.Controls.Add(comboBoxQuocTich);
            this.Controls.Add(comboBoxLop);
            this.Controls.Add(radioButtonNam);
            this.Controls.Add(radioButtonNu);
            this.Controls.Add(buttonLuu);
            this.Controls.Add(buttonHuy);
        }

        #endregion
    }
}