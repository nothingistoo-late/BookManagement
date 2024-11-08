using BookManagement.BLL.Service;
using BookManagement.DAL.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookManagement_HoangNgocTrinh
{
    /// <summary>
    /// Interaction logic for BookDetailWindow.xaml
    /// </summary>
    public partial class BookDetailWindow : Window
    {
        private BookService _bookService = new();
        private CategoryService _categoryService = new();

        public Book EditedOne { get; set; }

        public BookDetailWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            FillComboBox();

            BookIdTextBox.IsEnabled = false;
            if (EditedOne != null)
            {
                FillElement();
            }

        }

        private void FillElement()
        {
            BookIdTextBox.Text = EditedOne.BookId.ToString();
            BookNameTextBox.Text = EditedOne.BookName;
            DescriptionTextBox.Text = EditedOne.Description;
            PublicationDateDatePicker.SelectedDate = EditedOne.PublicationDate;
            QuantityTextBox.Text = EditedOne.Quantity.ToString();
            PriceTextBox.Text = EditedOne.Price.ToString();
            AuthorTextBox.Text = EditedOne.Author.ToString();
            BookCategoryIdComboBox.SelectedValue = EditedOne.BookCategoryId;

        }
        private void FillComboBox()
        {
            BookCategoryIdComboBox.ItemsSource = _categoryService.GetAll();
            BookCategoryIdComboBox.DisplayMemberPath = "BookGenreType";
            BookCategoryIdComboBox.SelectedValuePath = "BookCategoryId";
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!checkVar())
                return;
            Book obj = new Book();
            obj.BookName = BookNameTextBox.Text;
            obj.Description = DescriptionTextBox.Text;
            obj.PublicationDate = (DateTime)PublicationDateDatePicker.SelectedDate;
            obj.Quantity = int.Parse(QuantityTextBox.Text);
            obj.Price = double.Parse(PriceTextBox.Text);
            obj.Author = AuthorTextBox.Text;
            obj.BookCategoryId = (int)BookCategoryIdComboBox.SelectedValue;

            if (EditedOne != null)
            {
                obj.BookId = int.Parse(BookIdTextBox.Text);
                _bookService.UpdateBook(obj);
            }
            else _bookService.CreateBook(obj);
            this.Close();
        }
        private bool checkVar()
        {
            if (BookNameTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Book Name Is Require!!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (BookNameTextBox.Text.Length < 5 || BookNameTextBox.Text.Length >90 )
            {
                MessageBox.Show("Book Name Length Must Be In >5 and <90!!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            TextInfo textInfor = CultureInfo.CurrentCulture.TextInfo;

            string BookName = BookNameTextBox.Text.Trim();

            BookName = textInfor.ToTitleCase(BookName.ToLower());
            BookNameTextBox.Text = BookName;

            if (DescriptionTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Description Is Required!!!", "Required Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!PublicationDateDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Publication Date Is Required!!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (QuantityTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Quantity Is Rquired!!!", "Required Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            bool convertStatus = int.TryParse(QuantityTextBox.Text, out int quantity);

            if (!convertStatus)
            {
                MessageBox.Show("Quantity Must Be A Number!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (quantity <= 0 || quantity > 4000000)
            {
                MessageBox.Show("Quantity Must Between 0 and 4 000 000!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (PriceTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Price Is Rquired!!!", "Required Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

             convertStatus = double.TryParse(PriceTextBox.Text, out double price);

            if (!convertStatus)
            {
                MessageBox.Show("Price Must Be A Number!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (price <= 0 || price > 4000000)
            {
                MessageBox.Show("Price Must Between 0 And 4 000 000!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (AuthorTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Author Name Is Required!!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (BookCategoryIdComboBox.SelectedValue == null)
            {
                MessageBox.Show("Supplier ID Is Required!!!", "Require Information", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
