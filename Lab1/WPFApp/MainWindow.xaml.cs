using BusinessObjects;
using Services;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public MainWindow()
        {
            InitializeComponent();
            _productService = new ProductService();
            _categoryService = new CategoryService();
            LoadCategories();
            LoadProducts();
        }
        public void LoadCategories()
        {
            try
            {
                var categories = _categoryService.GetCategories();
                cboCategory.ItemsSource = categories;
                cboCategory.DisplayMemberPath = "CategoryName";
                cboCategory.SelectedValuePath = "CategoryId";
                cboCategory.SelectedIndex = 1;
            }
            catch (Exception ex) { 
                MessageBox.Show($"Xảy ra lỗi: {ex.Message} khi lấy danh sách loại sản phẩm");
            }
            
        }
        public void LoadProducts()
        {
            try
            {
                List<Product> products = _productService.GetProducts();
                dgData.ItemsSource = products;
                dgData.Items.Refresh();
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Xảy ra lỗi: {ex.Message} khi lấy danh sách sản phẩm");
            }
            finally { 
                ResetInput();
            }
        }
        public void ResetInput()
        {
            txtProductID.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtUnitsInStock.Text = string.Empty;
            cboCategory.SelectedValue = 0;
        }
        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dataGrid = sender as DataGrid;
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                if (row == null)
                {
                    // Nếu dòng chưa được tạo, hãy thử đợi một chút và thử lại
                    return;
                }
                DataGridCell rowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                string id = ((TextBlock)rowColumn.Content).Text;
                var product = _productService.GetProductById(int.Parse(id));
                txtProductID.Text = product.ProductId.ToString();
                txtProductName.Text = product.ProductName.ToString();
                txtPrice.Text = product.UnitPrice.ToString();
                txtUnitsInStock.Text = product.UnitsInstock.ToString();
                cboCategory.SelectedValue = product.CategpryId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xảy ra lỗi: {ex.Message} khi hiển thị sản phẩm");
            }
            

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = new Product
                {
                    ProductName = txtProductName.Text,
                    UnitPrice = decimal.Parse(txtPrice.Text),
                    UnitsInstock = short.Parse(txtUnitsInStock.Text),
                    CategpryId = int.Parse(cboCategory.SelectedValue.ToString()),
                };
                _productService.AddProduct(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xảy ra lỗi: {ex.Message} khi hiển thêm một sản phẩm mới");
            }
            finally
            {
                LoadProducts();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = new Product(int.Parse(txtProductID.Text), txtProductName.Text, (int)cboCategory.SelectedValue, short.Parse(txtUnitsInStock.Text), decimal.Parse(txtPrice.Text));
                //{
                //    ProductId = int.Parse(txtProductID.Text),
                //    ProductName = txtProductName.Text,
                //    CategpryId = (int)cboCategory.SelectedValue,
                //    UnitsInstock = short.Parse(txtUnitsInStock.Text),
                //    UnitPrice = decimal.Parse(txtPrice.Text)
                //};
                _productService.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xảy ra lỗi: {ex.Message} khi cập nhật một sản phẩm");
            }
            finally
            {
                LoadProducts();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var productId = int.Parse(txtProductID.Text);
                _productService.DeleteProduct(productId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xảy ra lỗi: {ex.Message} khi xóa một sản phẩm");
            }
            finally
            {
                LoadProducts();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}