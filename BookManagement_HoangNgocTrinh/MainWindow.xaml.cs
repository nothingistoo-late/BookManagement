using BookManagement.BLL.Service;
using BookManagement.DAL.Entities;
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

namespace BookManagement_HoangNgocTrinh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private BookService _bookService = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BookMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGridBook(_bookService.GetAllBook());

        }

        private void FillDataGridBook(List<Book> list)
        {
            BookListDataGrid.ItemsSource = null;
            BookListDataGrid.ItemsSource = list;
          
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Book? selected = BookListDataGrid.SelectedItem as Book;
            if (selected == null) 
            { 
                MessageBox.Show("Please Pick A Book To Delete!!!","Invalid Book",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Do You Readlly Want To Delete This Book???", "Deleted!!!", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
                _bookService.DeleteBook(selected);
            FillDataGridBook(_bookService.GetAllBook());
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            BookDetailWindow d = new BookDetailWindow();
            d.ShowDialog();
            FillDataGridBook(_bookService.GetAllBook());
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Book? selected = BookListDataGrid.SelectedItem as Book;
            if (selected == null)
            {
                MessageBox.Show("Please Pick A Book To Update!!!", "Invalid Book", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            BookDetailWindow d = new();
            d.EditedOne = selected;
            d.ShowDialog();

            FillDataGridBook (_bookService.GetAllBook());

        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are You Sure Want To Exit!!!", "Exit!!!!", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }
    }
}