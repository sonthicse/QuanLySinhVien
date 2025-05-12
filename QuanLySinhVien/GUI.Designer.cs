namespace QuanLySinhVien;

partial class GUI
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise false.</param>
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.SuspendLayout();

        InitializeFormProperties();

        InitializeLabels();
        InitializeTextBoxes();
        InitializeComboBoxes();
        InitializeButtons();
        InitializeDateTimePicker();
        InitializeDataGridView();
        InitializeGroupBox();
        InitializeMenuStrip();

        AddControlsToForm();

        this.ResumeLayout(false);
    }

    private void InitializeMenuStrip()
    {
        menuStrip = new MenuStrip
        {
            Dock = DockStyle.Top,
            Font = new Font("Arial", 10)
        };

        ToolStripMenuItem menuItemFile = new ToolStripMenuItem("File");
        ToolStripMenuItem menuItemExit = new ToolStripMenuItem("Exit");
        menuItemExit.Click += (s, e) => this.Close();
        menuItemFile.DropDownItems.Add(menuItemExit);

        menuStrip.Items.Add(menuItemFile);
    }

    private void InitializeFormProperties()
    {
        this.Text = "QUẢN LÝ SINH VIÊN";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Size = new Size(1500, 900);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
    }

    private void InitializeLabels()
    {
        labelMaSinhVien = new Label
        {
            Text = "Mã sinh viên",
            Location = new Point(50, 50),
            Font = new Font("Arial", 12)
        };
        labelHoVaTen = new Label
        {
            Text = "Họ và tên",
            Location = new Point(50, 100),
            Font = new Font("Arial", 12)
        };
        labelNgaySinh = new Label
        {
            Text = "Ngày sinh",
            Location = new Point(50, 150),
            Font = new Font("Arial", 12)
        };
        labelQuocTich = new Label
        {
            Text = "Quốc tịch",
            Location = new Point(900, 50),
            Font = new Font("Arial", 12)
        };
        labelLop = new Label
        {
            Text = "Lớp",
            Location = new Point(900, 100),
            Font = new Font("Arial", 12)
        };
    }

    private void InitializeTextBoxes()
    {
        textBoxMaSinhVien = new TextBox
        {
            PlaceholderText = "202301318",
            Location = new Point(200, 50),
            Size = new Size(300, 30),
            Font = new Font("Arial", 12)
        };
        textBoxHoVaTen = new TextBox
        {
            PlaceholderText = "Nguyễn Văn A",
            Location = new Point(200, 100),
            Size = new Size(300, 30),
            Font = new Font("Arial", 12)
        };
    }

    private void InitializeComboBoxes()
    {
        comboBoxQuocTich = new ComboBox
        {
            Location = new Point(1000, 50),
            Size = new Size(300, 30),
            Font = new Font("Arial", 12),
            Items = { "Việt Nam", "Mỹ" },
            SelectedIndex = -1,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        comboBoxLop = new ComboBox
        {
            Location = new Point(1000, 100),
            Size = new Size(300, 30),
            Font = new Font("Arial", 12),
            Items = { "ANHTTT", "TT" },
            SelectedIndex = -1,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
    }

    private void InitializeButtons()
    {
        buttonThem = new Button
        {
            Text = "Thêm",
            Location = new Point(600, 250),
            Size = new Size(100, 30),
            Font = new Font("Arial", 12)
        };
        buttonSua = new Button
        {
            Text = "Sửa",
            Location = new Point(700, 250),
            Size = new Size(100, 30),
            Font = new Font("Arial", 12)
        };
        buttonXoa = new Button
        {
            Text = "Xóa",
            Location = new Point(800, 250),
            Size = new Size(100, 30),
            Font = new Font("Arial", 12)
        };
        buttonLamMoi = new Button
        {
            Text = "Làm mới",
            Location = new Point(1350, 250),
            Size = new Size(100, 30),
            Font = new Font("Arial", 12)
        };

        buttonThem.Click += ButtonThem_Click;
        buttonSua.Click += ButtonSua_Click;
        buttonXoa.Click += ButtonXoa_Click;
        buttonLamMoi.Click += ButtonLamMoi_Click;
    }

    private void InitializeDateTimePicker()
    {
        dateTimePicker = new DateTimePicker
        {
            Location = new Point(200, 150),
            Size = new Size(300, 30),
            Font = new Font("Arial", 12),
            Format = DateTimePickerFormat.Custom,
            CustomFormat = "dd/MM/yyyy"
        };
    }

    private void InitializeDataGridView()
    {
        dataGridView = new DataGridView
        {
            Location = new Point(50, 300),
            Size = new Size(1400, 520),
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
            ReadOnly = true,
            TabStop = false,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToResizeRows = false,
            AllowUserToResizeColumns = false,
            AllowUserToOrderColumns = false
        };
    }

    private void InitializeGroupBox()
    {
        groupBoxGioiTinh = new GroupBox
        {
            Text = "Giới tính",
            Location = new Point(1000, 150),
            Size = new Size(300, 80),
            Font = new Font("Arial", 12),
        };
        radioButtonNam = new RadioButton
        {
            Text = "Nam",
            Location = new Point(20, 30),
            Font = new Font("Arial", 12)
        };
        radioButtonNu = new RadioButton
        {
            Text = "Nữ",
            Location = new Point(150, 30),
            Font = new Font("Arial", 12)
        };

        groupBoxGioiTinh.Controls.Add(radioButtonNam);
        groupBoxGioiTinh.Controls.Add(radioButtonNu);
    }

    private void AddControlsToForm()
    {
        this.Controls.Add(menuStrip);
        this.Controls.Add(labelMaSinhVien);
        this.Controls.Add(labelHoVaTen);
        this.Controls.Add(labelNgaySinh);
        this.Controls.Add(labelQuocTich);
        this.Controls.Add(labelLop);
        this.Controls.Add(textBoxMaSinhVien);
        this.Controls.Add(textBoxHoVaTen);
        this.Controls.Add(dateTimePicker);
        this.Controls.Add(comboBoxQuocTich);
        this.Controls.Add(comboBoxLop);
        this.Controls.Add(dataGridView);
        this.Controls.Add(groupBoxGioiTinh);
        this.Controls.Add(buttonThem);
        this.Controls.Add(buttonSua);
        this.Controls.Add(buttonXoa);
        this.Controls.Add(buttonLamMoi);
    }

    #endregion
}
