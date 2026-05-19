using System.Windows.Forms;

namespace ExpressBar
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListBox listBoxProducts;
        private System.Windows.Forms.ListBox listBoxCart;
        private System.Windows.Forms.TextBox textBoxOrderHistory;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.NumericUpDown numericQuantity;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnRemoveFromCart;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.Button btnCompleteOrder;
        private System.Windows.Forms.Button btnClearHistory;
        private System.Windows.Forms.Button btnSearchProduct;
        private System.Windows.Forms.Button btnShowStats;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.Button btnPreviewReceipt;
        private System.Windows.Forms.Button btnViewFullHistory;
        private System.Windows.Forms.Button btnExportHistory;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.GroupBox groupBoxProducts;
        private System.Windows.Forms.GroupBox groupBoxCart;
        private System.Windows.Forms.GroupBox groupBoxHistory;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelHistoryControls;
        private System.Windows.Forms.Label lblHistoryInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxProducts = new System.Windows.Forms.ListBox();
            this.listBoxCart = new System.Windows.Forms.ListBox();
            this.textBoxOrderHistory = new System.Windows.Forms.TextBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.numericQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.btnRemoveFromCart = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.btnCompleteOrder = new System.Windows.Forms.Button();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.btnShowStats = new System.Windows.Forms.Button();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.btnPreviewReceipt = new System.Windows.Forms.Button();
            this.btnViewFullHistory = new System.Windows.Forms.Button();
            this.btnExportHistory = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblHistoryInfo = new System.Windows.Forms.Label();
            this.groupBoxProducts = new System.Windows.Forms.GroupBox();
            this.groupBoxCart = new System.Windows.Forms.GroupBox();
            this.groupBoxHistory = new System.Windows.Forms.GroupBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelHistoryControls = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).BeginInit();
            this.groupBoxProducts.SuspendLayout();
            this.groupBoxCart.SuspendLayout();
            this.groupBoxHistory.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelHistoryControls.SuspendLayout();
            this.SuspendLayout();

            // Form1
            this.Text = "Экспресс-Бар - Система управления заказами с печатью чеков";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(1300, 850);
            this.MinimumSize = new System.Drawing.Size(1300, 850);
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // panelTop
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Size = new System.Drawing.Size(1284, 580);
            this.panelTop.Padding = new System.Windows.Forms.Padding(10);

            // panelBottom
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 250;
            this.panelBottom.Location = new System.Drawing.Point(0, 580);
            this.panelBottom.Size = new System.Drawing.Size(1284, 250);
            this.panelBottom.Padding = new System.Windows.Forms.Padding(10);

            // groupBoxProducts
            this.groupBoxProducts.Text = "📋 Меню товаров";
            this.groupBoxProducts.Location = new System.Drawing.Point(12, 12);
            this.groupBoxProducts.Size = new System.Drawing.Size(380, 550);
            this.groupBoxProducts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            this.groupBoxProducts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxProducts.BackColor = System.Drawing.Color.White;
            this.groupBoxProducts.Padding = new System.Windows.Forms.Padding(10);

            // lblSearch
            this.lblSearch.Text = "🔍 Поиск:";
            this.lblSearch.Location = new System.Drawing.Point(10, 35);
            this.lblSearch.Size = new System.Drawing.Size(60, 25);
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);

            // textBoxSearch
            this.textBoxSearch.Location = new System.Drawing.Point(80, 32);
            this.textBoxSearch.Size = new System.Drawing.Size(180, 27);
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 9F);

            // btnSearchProduct
            this.btnSearchProduct.Text = "Найти";
            this.btnSearchProduct.Location = new System.Drawing.Point(270, 31);
            this.btnSearchProduct.Size = new System.Drawing.Size(90, 28);
            this.btnSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearchProduct.BackColor = System.Drawing.Color.LightBlue;
            this.btnSearchProduct.UseVisualStyleBackColor = false;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);

            // listBoxProducts
            this.listBoxProducts.Location = new System.Drawing.Point(10, 70);
            this.listBoxProducts.Size = new System.Drawing.Size(355, 410);
            this.listBoxProducts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listBoxProducts.IntegralHeight = false;

            // lblQuantity
            this.lblQuantity.Text = "Количество:";
            this.lblQuantity.Location = new System.Drawing.Point(10, 495);
            this.lblQuantity.Size = new System.Drawing.Size(80, 25);
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);

            // numericQuantity
            this.numericQuantity.Location = new System.Drawing.Point(100, 493);
            this.numericQuantity.Size = new System.Drawing.Size(80, 27);
            this.numericQuantity.Minimum = 1;
            this.numericQuantity.Maximum = 99;
            this.numericQuantity.Value = 1;
            this.numericQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);

            // btnAddToCart
            this.btnAddToCart.Text = "➕ Добавить в заказ";
            this.btnAddToCart.Location = new System.Drawing.Point(190, 490);
            this.btnAddToCart.Size = new System.Drawing.Size(175, 35);
            this.btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddToCart.BackColor = System.Drawing.Color.LightGreen;
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);

            this.groupBoxProducts.Controls.Add(this.lblSearch);
            this.groupBoxProducts.Controls.Add(this.textBoxSearch);
            this.groupBoxProducts.Controls.Add(this.btnSearchProduct);
            this.groupBoxProducts.Controls.Add(this.listBoxProducts);
            this.groupBoxProducts.Controls.Add(this.lblQuantity);
            this.groupBoxProducts.Controls.Add(this.numericQuantity);
            this.groupBoxProducts.Controls.Add(this.btnAddToCart);

            // groupBoxCart
            this.groupBoxCart.Text = "🛒 Текущий заказ";
            this.groupBoxCart.Location = new System.Drawing.Point(405, 12);
            this.groupBoxCart.Size = new System.Drawing.Size(450, 550);
            this.groupBoxCart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            this.groupBoxCart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxCart.BackColor = System.Drawing.Color.White;
            this.groupBoxCart.Padding = new System.Windows.Forms.Padding(10);

            // listBoxCart
            this.listBoxCart.Location = new System.Drawing.Point(10, 25);
            this.listBoxCart.Size = new System.Drawing.Size(425, 400);
            this.listBoxCart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listBoxCart.IntegralHeight = false;

            // lblTotal
            this.lblTotal.Text = "💰 Итого: 0 руб.";
            this.lblTotal.Location = new System.Drawing.Point(10, 440);
            this.lblTotal.Size = new System.Drawing.Size(425, 35);
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnRemoveFromCart
            this.btnRemoveFromCart.Text = "➖ Удалить из заказа";
            this.btnRemoveFromCart.Location = new System.Drawing.Point(10, 490);
            this.btnRemoveFromCart.Size = new System.Drawing.Size(135, 40);
            this.btnRemoveFromCart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemoveFromCart.BackColor = System.Drawing.Color.LightCoral;
            this.btnRemoveFromCart.UseVisualStyleBackColor = false;
            this.btnRemoveFromCart.Click += new System.EventHandler(this.btnRemoveFromCart_Click);

            // btnClearCart
            this.btnClearCart.Text = "🗑 Очистить корзину";
            this.btnClearCart.Location = new System.Drawing.Point(155, 490);
            this.btnClearCart.Size = new System.Drawing.Size(135, 40);
            this.btnClearCart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClearCart.BackColor = System.Drawing.Color.LightYellow;
            this.btnClearCart.UseVisualStyleBackColor = false;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);

            // btnPrintReceipt
            this.btnPrintReceipt.Text = "🖨 Печать чека";
            this.btnPrintReceipt.Location = new System.Drawing.Point(300, 490);
            this.btnPrintReceipt.Size = new System.Drawing.Size(135, 40);
            this.btnPrintReceipt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrintReceipt.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPrintReceipt.UseVisualStyleBackColor = false;
            this.btnPrintReceipt.Click += new System.EventHandler(this.btnPrintReceipt_Click);

            this.groupBoxCart.Controls.Add(this.listBoxCart);
            this.groupBoxCart.Controls.Add(this.lblTotal);
            this.groupBoxCart.Controls.Add(this.btnRemoveFromCart);
            this.groupBoxCart.Controls.Add(this.btnClearCart);
            this.groupBoxCart.Controls.Add(this.btnPrintReceipt);

            // Кнопки управления справа
            // btnCompleteOrder
            this.btnCompleteOrder.Text = "✅ Оформить заказ";
            this.btnCompleteOrder.Location = new System.Drawing.Point(870, 20);
            this.btnCompleteOrder.Size = new System.Drawing.Size(190, 45);
            this.btnCompleteOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCompleteOrder.BackColor = System.Drawing.Color.Gold;
            this.btnCompleteOrder.UseVisualStyleBackColor = false;
            this.btnCompleteOrder.Click += new System.EventHandler(this.btnCompleteOrder_Click);

            // btnPreviewReceipt
            this.btnPreviewReceipt.Text = "👁 Предпросмотр чека";
            this.btnPreviewReceipt.Location = new System.Drawing.Point(1070, 20);
            this.btnPreviewReceipt.Size = new System.Drawing.Size(190, 45);
            this.btnPreviewReceipt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPreviewReceipt.BackColor = System.Drawing.Color.Orange;
            this.btnPreviewReceipt.UseVisualStyleBackColor = false;
            this.btnPreviewReceipt.Click += new System.EventHandler(this.btnPreviewReceipt_Click);

            // btnShowStats
            this.btnShowStats.Text = "📊 Статистика";
            this.btnShowStats.Location = new System.Drawing.Point(870, 80);
            this.btnShowStats.Size = new System.Drawing.Size(190, 45);
            this.btnShowStats.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShowStats.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnShowStats.UseVisualStyleBackColor = false;
            this.btnShowStats.Click += new System.EventHandler(this.btnShowStats_Click);

            // btnClearHistory
            this.btnClearHistory.Text = "🗑 Очистить историю";
            this.btnClearHistory.Location = new System.Drawing.Point(1070, 80);
            this.btnClearHistory.Size = new System.Drawing.Size(190, 45);
            this.btnClearHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClearHistory.BackColor = System.Drawing.Color.LightGray;
            this.btnClearHistory.UseVisualStyleBackColor = false;
            this.btnClearHistory.Click += new System.EventHandler(this.btnClearHistory_Click);

            // panelHistoryControls
            this.panelHistoryControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHistoryControls.Height = 40;
            this.panelHistoryControls.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelHistoryControls.Padding = new System.Windows.Forms.Padding(5);

            // btnViewFullHistory
            this.btnViewFullHistory.Text = "📄 Просмотр в полном окне";
            this.btnViewFullHistory.Location = new System.Drawing.Point(10, 6);
            this.btnViewFullHistory.Size = new System.Drawing.Size(180, 28);
            this.btnViewFullHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewFullHistory.BackColor = System.Drawing.Color.White;
            this.btnViewFullHistory.UseVisualStyleBackColor = false;
            this.btnViewFullHistory.Click += new System.EventHandler(this.btnViewFullHistory_Click);

            // btnExportHistory
            this.btnExportHistory.Text = "💾 Экспорт истории";
            this.btnExportHistory.Location = new System.Drawing.Point(200, 6);
            this.btnExportHistory.Size = new System.Drawing.Size(150, 28);
            this.btnExportHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportHistory.BackColor = System.Drawing.Color.White;
            this.btnExportHistory.UseVisualStyleBackColor = false;
            this.btnExportHistory.Click += new System.EventHandler(this.btnExportHistory_Click);

            // lblHistoryInfo
            this.lblHistoryInfo.Text = "Всего заказов: 0 | Общая выручка: 0 руб.";
            this.lblHistoryInfo.Location = new System.Drawing.Point(900, 10);
            this.lblHistoryInfo.Size = new System.Drawing.Size(360, 25);
            this.lblHistoryInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHistoryInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.panelHistoryControls.Controls.Add(this.btnViewFullHistory);
            this.panelHistoryControls.Controls.Add(this.btnExportHistory);
            this.panelHistoryControls.Controls.Add(this.lblHistoryInfo);

            // groupBoxHistory
            this.groupBoxHistory.Text = "📜 История заказов";
            this.groupBoxHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxHistory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxHistory.BackColor = System.Drawing.Color.White;
            this.groupBoxHistory.Padding = new System.Windows.Forms.Padding(10);

            // textBoxOrderHistory
            this.textBoxOrderHistory.Location = new System.Drawing.Point(6, 24);
            this.textBoxOrderHistory.Multiline = true;
            this.textBoxOrderHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOrderHistory.Size = new System.Drawing.Size(1258, 180);
            this.textBoxOrderHistory.Font = new System.Drawing.Font("Consolas", 9F);
            this.textBoxOrderHistory.BackColor = System.Drawing.Color.Black;
            this.textBoxOrderHistory.ForeColor = System.Drawing.Color.Lime;
            this.textBoxOrderHistory.ReadOnly = true;
            this.textBoxOrderHistory.WordWrap = false;
            this.textBoxOrderHistory.AcceptsReturn = true;
            this.textBoxOrderHistory.AcceptsTab = false;
            this.textBoxOrderHistory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            this.groupBoxHistory.Controls.Add(this.textBoxOrderHistory);

            // Добавление элементов на панели
            this.panelTop.Controls.Add(this.groupBoxProducts);
            this.panelTop.Controls.Add(this.groupBoxCart);
            this.panelTop.Controls.Add(this.btnCompleteOrder);
            this.panelTop.Controls.Add(this.btnPreviewReceipt);
            this.panelTop.Controls.Add(this.btnShowStats);
            this.panelTop.Controls.Add(this.btnClearHistory);

            this.panelBottom.Controls.Add(this.panelHistoryControls);
            this.panelBottom.Controls.Add(this.groupBoxHistory);

            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);

            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).EndInit();
            this.groupBoxProducts.ResumeLayout(false);
            this.groupBoxProducts.PerformLayout();
            this.groupBoxCart.ResumeLayout(false);
            this.groupBoxHistory.ResumeLayout(false);
            this.groupBoxHistory.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelHistoryControls.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}