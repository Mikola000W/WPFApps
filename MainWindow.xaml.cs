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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MojArkusz
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }

        // Konstruktor klasy Book
        public Book(string title, string author, int year, string isbn)
        {
            Title = title;
            Author = author;
            Year = year;
            ISBN = isbn;
        }

        public string DisplayBook()
        {
            return $"Tytuł: {Title}, Autor: {Author}, Rok: {Year}, ISBN: {ISBN}";
        }
    }

    public partial class MainWindow : Window
    {
        private List<Book> books = new List<Book>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            int year;
            string isbn = txtISBN.Text;

            if (title == "")
            {
                MessageBox.Show("Podaj tytuł!", "Błąd", MessageBoxButton.OK);
                return;

            }
            else if (author == ""){
                MessageBox.Show("Podaj autora!(Jeśli nie znasz wpisz: Nieznany)", "Błąd", MessageBoxButton.OK);
                return;
            }
            else if (!int.TryParse(txtYear.Text, out year))
            {
                MessageBox.Show("Podaj rok wydania!", "Błąd", MessageBoxButton.OK);
                return;
            }
            else if (int.Parse(txtYear.Text) > 2024)
            {
                MessageBox.Show("Podaj poprawny rok wydania!", "Błąd", MessageBoxButton.OK);
                return;
            }

            Book newBook = new Book(title, author, year, isbn);
            books.Add(newBook);

            txtTitle.Clear();
            txtAuthor.Clear();
            txtYear.Clear();
            txtISBN.Clear();

            UpdateBookList();
        }

        private void UpdateBookList()
        {
            txtBookList.Clear();
            foreach (var book in books)
            {
                txtBookList.AppendText(book.DisplayBook() + Environment.NewLine);
            }
        }
    }
}