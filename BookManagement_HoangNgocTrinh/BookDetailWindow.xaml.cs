using BookManagement.BLL.Service;
using BookManagement.DAL.Entities;
using System;
using System.Collections.Generic;
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
            return true;
        }
    }
}
