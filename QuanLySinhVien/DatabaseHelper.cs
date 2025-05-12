using System.Data.SQLite;

namespace QuanLySinhVien
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = $"Data Source=database\\database.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }

        private static bool IsSinhVienExists(string maSinhVien)
        {
            using (var connection = GetConnection())
            {
                string query = "SELECT COUNT(*) FROM SinhVien WHERE MaSinhVien = @MaSinhVien";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaSinhVien", maSinhVien);
                    long count = (long)command.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Mã sinh viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public static void InsertSinhVien(SinhVien sinhVien)
        {
            if (IsSinhVienExists(sinhVien.MaSinhVien))
            {
                return;
            }
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO SinhVien (MaSinhVien, HoTen, NgaySinh, QuocTich, Lop, GioiTinh) VALUES (@MaSinhVien, @HoTen, @NgaySinh, @QuocTich, @Lop, @GioiTinh)";
                    using (var command = new SQLiteCommand(query, connection))
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
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm sinh viên: {ex.Message}");
            }
        }

        public static void UpdateSinhVien(SinhVien sinhVien)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE SinhVien SET HoTen = @HoTen, NgaySinh = @NgaySinh, QuocTich = @QuocTich, Lop = @Lop, GioiTinh = @GioiTinh WHERE MaSinhVien = @MaSinhVien";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaSinhVien", sinhVien.MaSinhVien);
                        command.Parameters.AddWithValue("@HoTen", sinhVien.HoTen);
                        command.Parameters.AddWithValue("@NgaySinh", sinhVien.NgaySinh);
                        command.Parameters.AddWithValue("@QuocTich", sinhVien.QuocTich);
                        command.Parameters.AddWithValue("@Lop", sinhVien.Lop);
                        command.Parameters.AddWithValue("@GioiTinh", sinhVien.GioiTinh);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Sửa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi sửa sinh viên: {ex.Message}");
            }
        }

        public static void DeleteSinhVien(string maSinhVien)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM SinhVien WHERE MaSinhVien = @MaSinhVien";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaSinhVien", maSinhVien);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa sinh viên: {ex.Message}");
            }
        }

        public static void LoadData(DataGridView dataGridView)
        {
            try
            {
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
                        dataGridView.Sort(dataGridView.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                        dataGridView.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
