using System.Data.SQLite;

namespace QuanLySinhVien
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = "Data Source=database\\database.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }
        public static void InsertSinhVien(SinhVien sinhVien)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                string insertQuery = @"
                    INSERT INTO SinhVien (MaSinhVien, HoTen, NgaySinh, QuocTich, Lop, GioiTinh)
                    VALUES (@MaSinhVien, @HoTen, @NgaySinh, @QuocTich, @Lop, @GioiTinh);";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@MaSinhVien", sinhVien.MaSinhVien);
                    command.Parameters.AddWithValue("@HoTen", sinhVien.HoTen);
                    command.Parameters.AddWithValue("@NgaySinh", sinhVien.NgaySinh);
                    command.Parameters.AddWithValue("@QuocTich", sinhVien.QuocTich);
                    command.Parameters.AddWithValue("@Lop", sinhVien.Lop);
                    command.Parameters.AddWithValue("@GioiTinh", sinhVien.GioiTinh);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateSinhVien(SinhVien sinhVien)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                string updateQuery = @"
                    UPDATE SinhVien
                    SET HoTen = @HoTen, NgaySinh = @NgaySinh, QuocTich = @QuocTich, Lop = @Lop, GioiTinh = @GioiTinh
                    WHERE MaSinhVien = @MaSinhVien;";

                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@MaSinhVien", sinhVien.MaSinhVien);
                    command.Parameters.AddWithValue("@HoTen", sinhVien.HoTen);
                    command.Parameters.AddWithValue("@NgaySinh", sinhVien.NgaySinh);
                    command.Parameters.AddWithValue("@QuocTich", sinhVien.QuocTich);
                    command.Parameters.AddWithValue("@Lop", sinhVien.Lop);
                    command.Parameters.AddWithValue("@GioiTinh", sinhVien.GioiTinh);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteSinhVien(string selectedMaSinhVien)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM SinhVien WHERE MaSinhVien = @MaSinhVien";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaSinhVien", selectedMaSinhVien);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
