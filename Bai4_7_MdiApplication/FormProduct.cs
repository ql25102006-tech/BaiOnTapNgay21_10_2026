using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Bai4_7_MdiApplication
{
    public partial class FormProduct : Form
    {
        private BindingList<Product> listProducts = new BindingList<Product>();
        private BindingSource bindingSource = new BindingSource();

        public FormProduct()
        {
            InitializeComponent();
        }

        private void FormProduct_Load(object? sender, EventArgs e)
        {
            cboCategory.Items.AddRange(new object[] { "Điện tử", "Gia dụng", "Thực phẩm", "Văn phòng phẩm" });
            cboCategory.SelectedIndex = 0;

            CauHinhDataGridView();

            listProducts.Add(new Product("SP01", "Laptop Dell Vostro", "Điện tử", 18500000m, 10));
            listProducts.Add(new Product("SP02", "Bàn phím cơ DareU", "Điện tử", 650000m, 25));
            listProducts.Add(new Product("SP03", "Nồi chiên không dầu", "Gia dụng", 1200000m, 15));
            listProducts.Add(new Product("SP04", "Bánh Cosy mè", "Thực phẩm", 45000m, 100));

            bindingSource.DataSource = listProducts;
            dgvProducts.DataSource = bindingSource;

            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;

            ThongBaoVeFormCha($"Đã nạp danh sách {listProducts.Count} sản phẩm.");
        }

        private void ThongBaoVeFormCha(string thongBao)
        {
            (this.MdiParent as FormMain)?.CapNhatTrangThai(thongBao);
        }

        private void CauHinhDataGridView()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductId",
                HeaderText = "Mã SP",
                Width = 90
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Tên sản phẩm",
                Width = 180
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "Danh mục",
                Width = 120
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Đơn giá (VNĐ)",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "#,##0 VNĐ",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Số lượng",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
        }

        private void dgvProducts_SelectionChanged(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Product sp)
            {
                txtProductId.Text = sp.ProductId;
                txtProductName.Text = sp.ProductName;
                cboCategory.SelectedItem = sp.Category;
                txtPrice.Text = sp.Price.ToString("N0");
                txtQuantity.Text = sp.Quantity.ToString();
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            string id = txtProductId.Text.Trim();
            string name = txtProductName.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Mã và tên sản phẩm không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal.TryParse(txtPrice.Text.Replace(",", "").Trim(), out decimal price);
            int.TryParse(txtQuantity.Text.Trim(), out int qty);

            Product newProd = new Product(id, name, cboCategory.SelectedItem?.ToString() ?? "Điện tử", price, qty);
            listProducts.Add(newProd);
            bindingSource.Position = listProducts.IndexOf(newProd);

            ThongBaoVeFormCha($"Đã thêm sản phẩm mới: [{newProd.ProductId}] {newProd.ProductName}");
            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Product sp)
            {
                sp.ProductName = txtProductName.Text.Trim();
                sp.Category = cboCategory.SelectedItem?.ToString() ?? "Điện tử";
                decimal.TryParse(txtPrice.Text.Replace(",", "").Trim(), out decimal price);
                int.TryParse(txtQuantity.Text.Trim(), out int qty);
                sp.Price = price;
                sp.Quantity = qty;

                bindingSource.ResetCurrentItem();
                ThongBaoVeFormCha($"Đã cập nhật thông tin sản phẩm [{sp.ProductId}].");
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (bindingSource.Current is Product sp)
            {
                DialogResult dr = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sản phẩm [{sp.ProductId} - {sp.ProductName}]?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    string info = $"[{sp.ProductId}] {sp.ProductName}";
                    listProducts.Remove(sp);
                    ThongBaoVeFormCha($"Đã xóa sản phẩm {info}.");
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            txtProductId.Clear();
            txtProductName.Clear();
            cboCategory.SelectedIndex = 0;
            txtPrice.Clear();
            txtQuantity.Clear();
            txtProductId.Focus();
        }
    }
}
