using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SQLite;

namespace QuanLySinhVien
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Khởi chạy ứng dụng
            ApplicationConfiguration.Initialize();
            Application.Run(new GUI());
        
        }
    
    }
}