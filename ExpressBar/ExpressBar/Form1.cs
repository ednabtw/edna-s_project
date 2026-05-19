using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;

namespace ExpressBar
{
    public partial class Form1 : Form
    {
        private List<Product> products = new List<Product>();
        private List<Order> currentOrder = new List<Order>();
        private double totalAmount = 0;
        private PrintDocument printDocument = new PrintDocument();
        private string receiptContent = "";

        public Form1()
        {
            InitializeComponent();
            InitializeProducts();
            LoadProductsToListBox();
            UpdateCartDisplay();
            UpdateHistoryInfo(); // Добавлено: обновление информации о истории

            // Настройка печати
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        private void InitializeProducts()
        {
            products.Add(new Product { Id = 1, Name = "Эспрессо", Price = 150, Category = "Кофе" });
            products.Add(new Product { Id = 2, Name = "Капучино", Price = 200, Category = "Кофе" });
            products.Add(new Product { Id = 3, Name = "Латте", Price = 220, Category = "Кофе" });
            products.Add(new Product { Id = 4, Name = "Американо", Price = 180, Category = "Кофе" });
            products.Add(new Product { Id = 5, Name = "Чай черный", Price = 120, Category = "Чай" });
            products.Add(new Product { Id = 6, Name = "Чай зеленый", Price = 120, Category = "Чай" });
            products.Add(new Product { Id = 7, Name = "Сэндвич с курицей", Price = 250, Category = "Еда" });
            products.Add(new Product { Id = 8, Name = "Круассан", Price = 180, Category = "Еда" });
            products.Add(new Product { Id = 9, Name = "Сок апельсиновый", Price = 150, Category = "Напитки" });
            products.Add(new Product { Id = 10, Name = "Вода", Price = 100, Category = "Напитки" });
            products.Add(new Product { Id = 11, Name = "Пицца Маргарита", Price = 350, Category = "Еда" });
            products.Add(new Product { Id = 12, Name = "Хот-дог", Price = 200, Category = "Еда" });
        }

        private void LoadProductsToListBox()
        {
            listBoxProducts.Items.Clear();
            foreach (var product in products)
            {
                listBoxProducts.Items.Add($"{product.Name} - {product.Price} руб.");
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (listBoxProducts.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите товар для добавления в заказ!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = (int)numericQuantity.Value;
            if (quantity <= 0)
            {
                MessageBox.Show("Количество должно быть больше 0!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedProduct = products[listBoxProducts.SelectedIndex];
            var existingOrder = currentOrder.FirstOrDefault(o => o.Product.Id == selectedProduct.Id);

            if (existingOrder != null)
            {
                existingOrder.Quantity += quantity;
            }
            else
            {
                currentOrder.Add(new Order
                {
                    Product = selectedProduct,
                    Quantity = quantity,
                    OrderTime = DateTime.Now
                });
            }

            UpdateCartDisplay();
            numericQuantity.Value = 1;
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (listBoxCart.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите товар для удаления из корзины!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentOrder.RemoveAt(listBoxCart.SelectedIndex);
            UpdateCartDisplay();
        }

        private void UpdateCartDisplay()
        {
            listBoxCart.Items.Clear();
            totalAmount = 0;

            foreach (var order in currentOrder)
            {
                double itemTotal = order.Product.Price * order.Quantity;
                totalAmount += itemTotal;
                listBoxCart.Items.Add($"{order.Product.Name} x{order.Quantity} = {itemTotal:F2} руб.");
            }

            lblTotal.Text = $"💰 Итого: {totalAmount:F2} руб.";
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (currentOrder.Count > 0)
            {
                var result = MessageBox.Show("Очистить всю корзину?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    currentOrder.Clear();
                    UpdateCartDisplay();
                }
            }
        }

        private string GenerateReceipt()
        {
            StringBuilder receipt = new StringBuilder();
            int width = 40; // Ширина чека в символах

            // Верхняя граница
            receipt.AppendLine(new string('-', width));
            receipt.AppendLine(CenterText("ЭКСПРЕСС-БАР", width));
            receipt.AppendLine(CenterText("КАССОВЫЙ ЧЕК", width));
            receipt.AppendLine(new string('-', width));
            receipt.AppendLine($"Дата: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
            receipt.AppendLine($"Чек №: {DateTime.Now:yyyyMMddHHmmss}");
            receipt.AppendLine(new string('-', width));

            // Заголовки
            receipt.AppendLine(FormatRow("Товар", "Кол-во", "Цена", "Сумма", width));
            receipt.AppendLine(new string('-', width));

            // Товары
            foreach (var order in currentOrder)
            {
                double itemTotal = order.Product.Price * order.Quantity;
                receipt.AppendLine(FormatOrderRow(order.Product.Name, order.Quantity, order.Product.Price, itemTotal, width));
            }

            receipt.AppendLine(new string('-', width));

            // Итог
            receipt.AppendLine(FormatTotal("ИТОГО:", totalAmount, width));
            receipt.AppendLine(FormatTotal("НАЛИЧНЫМИ:", totalAmount, width));
            receipt.AppendLine(new string('-', width));

            // Нижняя часть
            receipt.AppendLine(CenterText("СПАСИБО ЗА ПОКУПКУ!", width));
            receipt.AppendLine(CenterText("ЖДЕМ ВАС СНОВА!", width));
            receipt.AppendLine(new string('-', width));

            return receipt.ToString();
        }

        private string CenterText(string text, int width)
        {
            if (text.Length >= width)
                return text;

            int spaces = (width - text.Length) / 2;
            return new string(' ', spaces) + text;
        }

        private string FormatRow(string col1, string col2, string col3, string col4, int width)
        {
            // Форматирование строки заголовка
            return $"{col1,-15} {col2,4} {col3,6} {col4,8}";
        }

        private string FormatOrderRow(string productName, int quantity, double price, double total, int width)
        {
            // Обрезаем длинное название
            if (productName.Length > 15)
                productName = productName.Substring(0, 13) + "..";

            return $"{productName,-15} {quantity,4} x {price,5:F0} = {total,7:F2}";
        }

        private string FormatTotal(string label, double amount, int width)
        {
            string amountStr = $"{amount:F2} руб.";
            return $"{label,-15} {amountStr,20}";
        }

        private void PrintReceipt()
        {
            if (currentOrder.Count == 0)
            {
                MessageBox.Show("Нет товаров для печати чека!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            receiptContent = GenerateReceipt();

            // Показываем диалог выбора принтера
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Настройка для чекового принтера
                    printDocument.DefaultPageSettings.PaperSize = new PaperSize("Чек", 300, 600);
                    printDocument.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);

                    printDocument.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при печати: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Используем моноширинный шрифт для чеков
            Font printFont = new Font("Consolas", 9, FontStyle.Regular);
            Font boldFont = new Font("Consolas", 9, FontStyle.Bold);

            float yPos = e.MarginBounds.Top;
            float leftMargin = e.MarginBounds.Left;
            float lineHeight = printFont.GetHeight(e.Graphics) + 2;

            string[] lines = receiptContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                // Используем жирный шрифт для итогов и заголовков
                Font currentFont = printFont;
                if (line.Contains("ИТОГО:") || line.Contains("НАЛИЧНЫМИ:") ||
                    line.Contains("ЭКСПРЕСС-БАР") || line.Contains("КАССОВЫЙ ЧЕК"))
                {
                    currentFont = boldFont;
                }

                e.Graphics.DrawString(line, currentFont, Brushes.Black, leftMargin, yPos);
                yPos += lineHeight;

                // Проверяем, не вышли ли за пределы страницы
                if (yPos + lineHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
            printFont.Dispose();
            boldFont.Dispose();
        }

        // Обновленный метод для оформления заказа
        private void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            if (currentOrder.Count == 0)
            {
                MessageBox.Show("Корзина пуста! Добавьте товары в заказ.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Оформить заказ на сумму {totalAmount:F2} руб.?",
                "Подтверждение заказа", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Создаем StringBuilder для построения строки заказа
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                sb.AppendLine($"=== ЗАКАЗ #{DateTime.Now:HHmmss} ===");
                sb.AppendLine($"Время: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                sb.AppendLine("Товары:");

                foreach (var order in currentOrder)
                {
                    sb.AppendLine($"- {order.Product.Name} x{order.Quantity} = {order.Product.Price * order.Quantity:F2} руб.");
                }

                sb.AppendLine($"ИТОГО: {totalAmount:F2} руб.");
                sb.AppendLine("===================");
                sb.AppendLine(); // Пустая строка для разделения

                string orderDetails = sb.ToString();

                // Добавляем текст в историю
                textBoxOrderHistory.AppendText(orderDetails);

                // Прокручиваем вниз
                textBoxOrderHistory.SelectionStart = textBoxOrderHistory.Text.Length;
                textBoxOrderHistory.ScrollToCaret();

                // Обновляем информационную панель
                UpdateHistoryInfo();

                LogToFile(orderDetails);

                // Спрашиваем о печати чека
                DialogResult printResult = MessageBox.Show("Распечатать чек?", "Печать чека",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (printResult == DialogResult.Yes)
                {
                    PrintReceipt();
                }

                totalAmount = 0;
                currentOrder.Clear();
                UpdateCartDisplay();

                MessageBox.Show("Заказ успешно оформлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            if (currentOrder.Count == 0)
            {
                MessageBox.Show("Нет активного заказа для печати чека!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintReceipt();
        }

        private void LogToFile(string orderDetails)
        {
            string logPath = "orders_log.txt";
            try
            {
                System.IO.File.AppendAllText(logPath, orderDetails, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении лога: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обновленный метод очистки истории
        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxOrderHistory.Text))
            {
                var result = MessageBox.Show("Очистить историю заказов?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    textBoxOrderHistory.Clear();
                    UpdateHistoryInfo(); // Обновляем информацию после очистки
                }
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadProductsToListBox();
                return;
            }

            listBoxProducts.Items.Clear();
            var searchResults = products.Where(p => p.Name.ToLower().Contains(searchText)).ToList();

            if (searchResults.Count == 0)
            {
                listBoxProducts.Items.Add("Товары не найдены");
            }
            else
            {
                foreach (var product in searchResults)
                {
                    listBoxProducts.Items.Add($"{product.Name} - {product.Price} руб.");
                }
            }
        }

        private void btnShowStats_Click(object sender, EventArgs e)
        {
            var completedOrders = textBoxOrderHistory.Text;
            if (string.IsNullOrEmpty(completedOrders))
            {
                MessageBox.Show("Нет завершенных заказов для статистики.", "Статистика",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            double totalRevenue = 0;
            var lines = completedOrders.Split('\n');
            foreach (var line in lines)
            {
                if (line.Contains("ИТОГО:"))
                {
                    string amountStr = line.Replace("ИТОГО:", "").Replace("руб.", "").Trim();
                    if (double.TryParse(amountStr, out double amount))
                    {
                        totalRevenue += amount;
                    }
                }
            }

            int orderCount = System.Text.RegularExpressions.Regex.Matches(completedOrders, "=== ЗАКАЗ").Count;

            MessageBox.Show($"СТАТИСТИКА ЗА СЕССИЮ:\n\n" +
                          $"Всего заказов: {orderCount}\n" +
                          $"Общая выручка: {totalRevenue:F2} руб.\n" +
                          $"Средний чек: {(orderCount > 0 ? totalRevenue / orderCount : 0):F2} руб.",
                          "Статистика", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPreviewReceipt_Click(object sender, EventArgs e)
        {
            if (currentOrder.Count == 0)
            {
                MessageBox.Show("Нет товаров для просмотра чека!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string receipt = GenerateReceipt();

            Form previewForm = new Form();
            previewForm.Text = "Предпросмотр чека";
            previewForm.Size = new System.Drawing.Size(500, 600);
            previewForm.StartPosition = FormStartPosition.CenterParent;
            previewForm.MinimumSize = new System.Drawing.Size(400, 400);

            TextBox tb = new TextBox();
            tb.Dock = DockStyle.Fill;
            tb.Font = new Font("Consolas", 9);
            tb.Text = receipt;
            tb.ReadOnly = true;
            tb.Multiline = true;
            tb.ScrollBars = ScrollBars.Both;
            tb.WordWrap = false;
            tb.BackColor = Color.White;

            Button btnClose = new Button();
            btnClose.Text = "Закрыть";
            btnClose.Dock = DockStyle.Bottom;
            btnClose.Height = 40;
            btnClose.BackColor = System.Drawing.Color.LightGray;
            btnClose.Click += (s, ev) => previewForm.Close();

            Button btnPrint = new Button();
            btnPrint.Text = "Печать чека";
            btnPrint.Dock = DockStyle.Bottom;
            btnPrint.Height = 40;
            btnPrint.BackColor = System.Drawing.Color.LightSteelBlue;
            btnPrint.Click += (s, ev) =>
            {
                previewForm.Close();
                PrintReceipt();
            };

            Panel buttonPanel = new Panel();
            buttonPanel.Height = 40;
            buttonPanel.Dock = DockStyle.Bottom;

            btnPrint.Location = new System.Drawing.Point(0, 0);
            btnPrint.Width = 250;
            btnClose.Location = new System.Drawing.Point(250, 0);
            btnClose.Width = 250;

            buttonPanel.Controls.Add(btnPrint);
            buttonPanel.Controls.Add(btnClose);

            previewForm.Controls.Add(tb);
            previewForm.Controls.Add(buttonPanel);
            previewForm.ShowDialog();
        }

        // Новый метод для просмотра истории в полном окне
        private void btnViewFullHistory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxOrderHistory.Text))
            {
                MessageBox.Show("История заказов пуста!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Form fullHistoryForm = new Form();
            fullHistoryForm.Text = "Полная история заказов";
            fullHistoryForm.Size = new System.Drawing.Size(800, 600);
            fullHistoryForm.StartPosition = FormStartPosition.CenterParent;
            fullHistoryForm.MinimumSize = new System.Drawing.Size(600, 400);

            TextBox tbHistory = new TextBox();
            tbHistory.Dock = DockStyle.Fill;
            tbHistory.Multiline = true;
            tbHistory.ScrollBars = ScrollBars.Both;
            tbHistory.Font = new Font("Consolas", 9);
            tbHistory.Text = textBoxOrderHistory.Text;
            tbHistory.ReadOnly = true;
            tbHistory.WordWrap = false;
            tbHistory.BackColor = Color.Black;
            tbHistory.ForeColor = Color.Lime;

            Button btnClose = new Button();
            btnClose.Text = "Закрыть";
            btnClose.Dock = DockStyle.Bottom;
            btnClose.Height = 40;
            btnClose.BackColor = System.Drawing.Color.LightGray;
            btnClose.Click += (s, ev) => fullHistoryForm.Close();

            Button btnCopy = new Button();
            btnCopy.Text = "Копировать в буфер";
            btnCopy.Dock = DockStyle.Bottom;
            btnCopy.Height = 40;
            btnCopy.BackColor = System.Drawing.Color.LightSteelBlue;
            btnCopy.Click += (s, ev) =>
            {
                Clipboard.SetText(tbHistory.Text);
                MessageBox.Show("История скопирована в буфер обмена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            Panel buttonPanel = new Panel();
            buttonPanel.Height = 40;
            buttonPanel.Dock = DockStyle.Bottom;

            btnCopy.Location = new System.Drawing.Point(0, 0);
            btnCopy.Width = 200;
            btnClose.Location = new System.Drawing.Point(200, 0);
            btnClose.Width = 200;

            buttonPanel.Controls.Add(btnCopy);
            buttonPanel.Controls.Add(btnClose);

            fullHistoryForm.Controls.Add(tbHistory);
            fullHistoryForm.Controls.Add(buttonPanel);
            fullHistoryForm.ShowDialog();
        }

        // Новый метод для экспорта истории в файл
        private void btnExportHistory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxOrderHistory.Text))
            {
                MessageBox.Show("Нет истории для экспорта!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Сохранить историю заказов";
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.FileName = $"История_заказов_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, textBoxOrderHistory.Text, Encoding.UTF8);
                    MessageBox.Show($"История успешно сохранена в файл:\n{saveFileDialog.FileName}", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Новый метод для обновления информации о истории
        private void UpdateHistoryInfo()
        {
            string history = textBoxOrderHistory.Text;
            if (string.IsNullOrEmpty(history))
            {
                lblHistoryInfo.Text = "Всего заказов: 0 | Общая выручка: 0 руб.";
                return;
            }

            double totalRevenue = 0;
            var lines = history.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                if (line.Contains("ИТОГО:"))
                {
                    string amountStr = line.Replace("ИТОГО:", "").Replace("руб.", "").Trim();
                    if (double.TryParse(amountStr, out double amount))
                    {
                        totalRevenue += amount;
                    }
                }
            }

            int orderCount = System.Text.RegularExpressions.Regex.Matches(history, "=== ЗАКАЗ").Count;
            lblHistoryInfo.Text = $"Всего заказов: {orderCount} | Общая выручка: {totalRevenue:F2} руб.";
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }

    public class Order
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderTime { get; set; }
    }
}