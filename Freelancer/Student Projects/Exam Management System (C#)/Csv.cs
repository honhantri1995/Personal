using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HeThongThiTracNghiem
{
    // Enum để lưu các kết quả thực thi có thể xảy ra sau khi đọc/ghi file CSV
    enum CsvResult
    {
        Success,
        Fail,
        RecordIdNotFound,
        DuplicateRecordId,
    }

    class Csv
    {
        private string _filePath;

        public Csv(string path)
        {
            _filePath = path;
        }

        // Đọc line và rã nó thành các item (dựa theo dấu ,)
        public List<string> ReadCsvLine(string line)
        {
            List<string> items = new List<string>();
            // Đảm bảo list 'items' rỗng bằng cách xóa hết phần tử của nó
            if (items.Count > 0)
            {
                items.Clear();
            }

            // Nếu line rỗng, thì bỏ qua không đọc line này
            if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line))
            {
                return items;
            }
            // Nếu line bắt đầu bằng ký tư '#' thì đây là một comment
            // nên không cần lưu thông tin của line này, mà bỏ qua để dọc các line tiếp theo
            if (line[0] == '#')
            {
                return items;
            }

            // Tách các phần tử trong một line
            // Mỗi phần tử tương ứng với một thuộc tính của record
            // Sau đó, lưu tất cả thuộc tính của một record vào list 'items'
            string[] itemArray = line.Split(',');
            foreach (string item in itemArray)
            {
                item.Trim();
                items.Add(item);
            }

            return items;
        }

        // Đọc tất cả record (cùng với thuộc tính của chúng) từ file CSV
        // và lưu tất cả vào tham số đầu ra là list 'records'
        public bool ReadAll(List<List<string>> records)
        {
            try
            {
                // Mở file CSV ở chế độ đọc
                using (var sr = new StreamReader(_filePath))
                {
                    List<string> items = new List<string>(); // list lưu tất cả item của mỗi row (dòng)

                    // Trong từng line của file CSV, đọc và lưu thông tin
                    while (sr.Peek() >= 0)
                    {
                        // Trong từng line, tách từng item của record và lưu vào list 'items'
                        items = ReadCsvLine(sr.ReadLine());

                        // Nếu đó là line chứa record (k phải comment, ...), lưu record vào list 'records'
                        if (items.Count > 0)
                        {
                            records.Add(items);
                        }
                    }
                }
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Đọc tất cả record (cùng với thuộc tính của chúng) từ file CSV miễn sao khớp với điền kiện được chọn
        // và lưu tất cả vào tham số đầu ra là list 'records'
        public bool ReadAll_WithContition(List<List<string>> records, int itemId, string itemValue)
        {
            try
            {
                // Mở file CSV ở chế độ đọc
                using (var sr = new StreamReader(_filePath))
                {
                    List<string> items = new List<string>(); // list lưu tất cả item của mỗi row (dòng)

                    // Trong từng line của file CSV, đọc và lưu thông tin
                    while (sr.Peek() >= 0)
                    {
                        // Trong từng line, tách từng item của record và lưu vào list 'items'
                        items = ReadCsvLine(sr.ReadLine());

                        // Nếu đó là line chứa record (k phải comment, ...),
                        // và đúng với điều kiện muốn tìm
                        // lưu record vào list 'records'
                        if (items.Count > 0 && items[itemId].CompareTo(itemValue) == 0)
                        {
                            records.Add(items);
                        }
                    }
                }
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Thêm record mới vào file CSV
        public bool AddRecord(List<string> newRecord)
        {
            try
            {
                // Mở file CSV ở chế độ viết và append mode
                using (var sw = new StreamWriter(_filePath, true))
                {
                    for (int i = 0; i < newRecord.Count; i++)
                    {
                        if (i == 0) sw.Write("\n");
                        else sw.Write(",");

                        sw.Write(newRecord[i]);
                    }
                }
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Cập nhật record theo ID
        // Hàm trả về false nếu xử lý file CSV bị lỗi, hoặc ID không tồn tại
        public CsvResult UpdateRecord(string id, List<string> newRecord)
        {
            // Trước tiên, kiểm tra record có tồn tại không
            if (!IsExistRecord(id))
            {
                return CsvResult.RecordIdNotFound;
            }

            List<string> items = new List<string>();    // list lưu tất cả item của mỗi row (dòng)
            bool result = true;

            try
            {
                // Mở file CSV chính ở chế độ đọc
                using (var sr = new StreamReader(_filePath))
                {
                    // Tạo file CSV tạm
                    FileInfo fi = new FileInfo(HangSo.CSV_TMP_FILEPATH);
                    using (FileStream fs = fi.Create())
                    {
                        // Sau khi tạo xong thì close process tạo. Không làm gì nữa hết
                    }

                    // Mở file CSV tạm ở chế độ viết và append mode
                    using (var sw = new StreamWriter(HangSo.CSV_TMP_FILEPATH, true))
                    {
                        // Trong từng line của file CSV, đọc và lưu thông tin
                        while (sr.Peek() >= 0)
                        {
                            // Trong từng line, tách từng item của record và lưu vào list 'items'
                            string line = sr.ReadLine();
                            items = ReadCsvLine(line);

                            // Nếu đó là line chứa record (k phải comment, ...), lưu record vào list 'records'
                            if (items.Count > 0)
                            {
                                // Nếu tìm thấy record muốn update, ghi nội dung của record mới vào file CSV tạm
                                if (string.Compare(items[0], id, true) == 0)
                                {
                                    // Tách item trong record hiện tại theo ',' và lưu vào List 'oldRecord'
                                    // Mục đích: Trong trường hợp newRecord có item rỗng, thì lấy nội dung của item đó từ oldRecord
                                    List<string> oldRecord = new List<string>();
                                    oldRecord = line.Split(',').ToList<string>();
                                    // Nếu 'oldRecord' và 'newRecord' có size k giống nhau ==> quá trình add vào list trước khi gọi hàm UpdateRecord có vấn đề
                                    if (oldRecord.Count != newRecord.Count)
                                    {
                                        result = false;
                                        break;
                                    }

                                    for (int i = 0; i < newRecord.Count; i++)
                                    {
                                        if (i == 0) sw.Write("\n");
                                        else sw.Write(",");

                                        // Nếu newRecord có item rỗng, thì lấy nội dung của item đó từ oldRecord
                                        if (newRecord[i].CompareTo("") == 0)
                                        {
                                            sw.Write(oldRecord[i]);
                                        }
                                        // Nếu không, lấy nội dung của item từ 'newRecord'
                                        else
                                        {
                                            sw.Write(newRecord[i]);
                                        }
                                    }
                                }
                                // Nếu không, ghi lại line của file CSV chính vào CSV tạm
                                else
                                {
                                    sw.Write("\n" + line);
                                }
                            }
                            // Nếu line rỗng hoặc comment, vẫn ghi lại line của file CSV chính vào CSV tạm
                            else
                            {
                                sw.Write(line);
                            }
                        }
                    }
                }

                // Nếu fail, delete file csv tạm và thoát khỏi hàm
                if (!result)
                {
                    File.Delete(HangSo.CSV_TMP_FILEPATH);
                    return CsvResult.Fail;
                }

                // Xóa file CSV chính
                File.Delete(_filePath);

                // Đổi tên file tạm thành file CSV chính
                File.Move(HangSo.CSV_TMP_FILEPATH, _filePath);

                return CsvResult.Success;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return CsvResult.Fail;
            }
        }

        // Xóa record theo ID
        // Hàm trả về false nếu xử lý file CSV bị lỗi, hoặc ID không tồn tại
        public CsvResult RemoveRecord(string id)
        {
            // Trước tiên, kiểm tra record có tồn tại không
            if (!IsExistRecord(id))
            {
                return CsvResult.RecordIdNotFound;
            }

            List<string> items = new List<string>();    // list lưu tất cả item của mỗi row (dòng)

            try
            {
                // Mở file CSV chính ở chế độ đọc
                using (var sr = new StreamReader(_filePath))
                {
                    // Tạo file CSV tạm
                    FileInfo fi = new FileInfo(HangSo.CSV_TMP_FILEPATH);
                    using (FileStream fs = fi.Create())
                    {
                        // Sau khi tạo xong thì close process tạo. Không làm gì nữa hết
                    }

                    // Mở file CSV tạm ở chế độ viết và append mode
                    using (var sw = new StreamWriter(HangSo.CSV_TMP_FILEPATH, true))
                    {
                        // Trong từng line của file CSV, đọc và lưu thông tin
                        while (sr.Peek() >= 0)
                        {
                            // Trong từng line, tách từng item của record và lưu vào list 'items'
                            string line = sr.ReadLine();
                            items = ReadCsvLine(line);

                            // Nếu đó là line chứa record (k phải comment, ...), lưu record vào list 'records'
                            if (items.Count > 0)
                            {
                                // Nếu tìm thấy record muốn xóa, không ghi nội dung của nó vào file CSV tạm
                                if (string.Compare(items[0], id, true) == 0)
                                {
                                    continue;
                                }
                                // Nếu không, ghi lại line của file CSV chính vào CSV tạm
                                else
                                {
                                    sw.Write("\n" + line);
                                }
                            }
                            // Nếu line rỗng hoặc comment, vẫn ghi lại line của file CSV chính vào CSV tạm
                            else
                            {
                                sw.Write(line);
                            }
                        }
                    }
                }

                // Xóa file CSV chính
                File.Delete(_filePath);

                // Đổi tên file tạm thành file CSV chính
                File.Move(HangSo.CSV_TMP_FILEPATH, _filePath);

                return CsvResult.Success;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return CsvResult.Fail;
            }
        }

        // Kiểm tra thử record có tồn tại hay không
        public bool IsExistRecord(string id)
        {
            try
            {
                // Mở file CSV ở chế độ đọc
                using (var sr = new StreamReader(_filePath))
                {
                    List<string> items = new List<string>(); // list lưu tất cả item của mỗi row (dòng)

                    // Trong từng line của file CSV, đọc và lưu thông tin
                    while (sr.Peek() >= 0)
                    {
                        // Trong từng line, tách từng item của record và lưu vào list 'items'
                        items = ReadCsvLine(sr.ReadLine());

                        // Nếu đó là line chứa record (k phải comment, ...), lưu record vào list 'records'
                        if (items.Count > 0)
                        {
                            // Nếu tìm thấy record, return true
                            if (string.Compare(items[0], id, true) == 0)
                            {
                                return true;
                            }
                        }
                    }
                    // Nếu không tìm thấy record, return false
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}