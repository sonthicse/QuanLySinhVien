namespace QuanLySinhVien
{
    partial class SearchForm
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
            this.Text = "Tìm kiếm";
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 110);

            InitializeLabels();
            InitializeTextBoxes();
            InitializeButtons();

            AddControlsToForm();
        }

        private void InitializeLabels()
        {
            labelTimKiem = new Label
            {
                Text = "Tìm kiếm",
                Location = new Point(20, 20),
                Size = new Size(100, 30),
                Font = new Font("Arial", 12)
            };
        }

        private void InitializeTextBoxes()
        {
            textBoxTimKiem = new TextBox
            {
                PlaceholderText = "Nguyễn Văn A",
                Location = new Point(120, 15),
                Size = new Size(260, 30),
                Font = new Font("Arial", 12)
            };
        }

        private void InitializeButtons()
        {
            buttonTimkiem = new Button
            {
                Text = "Tìm kiếm",
                Location = new Point(210, 60),
                Size = new Size(80, 30),
                Font = new Font("Arial", 12)
            };
            buttonTimkiem.Click += ButtonTimKiem_Click;
        }

        private void AddControlsToForm()
        {
            this.Controls.Add(labelTimKiem);
            this.Controls.Add(textBoxTimKiem);
            this.Controls.Add(buttonTimkiem);
        }

        #endregion
    }
}