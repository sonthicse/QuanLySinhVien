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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.SuspendLayout();

        // Form properties
        this.Text = "QUẢN LÝ SINH VIÊN";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Size = new Size(1500, 900);

        // Cố định kích thước Form
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        groupBoxGioiTinh.Controls.Add(radioButtonNam);
        groupBoxGioiTinh.Controls.Add(radioButtonNu);

        buttonThem.Click += ButtonThem_Click;
        buttonSua.Click += ButtonSua_Click;
        buttonXoa.Click += ButtonXoa_Click;
        buttonLamMoi.Click += ButtonLamMoi_Click;

        // Thêm các điều khiển vào Form
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

        this.ResumeLayout(false);
    }

    #endregion
}
