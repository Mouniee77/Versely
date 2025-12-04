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
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for VersesWindow.xaml
    /// </summary>
    public partial class VersesWindow : Window
    {
        //public VersesWindow(string emotionName, List<string> verses)
        //{
        //    InitializeComponent();
        //    Title = emotionName;
        //    TitleText.Text = emotionName;
        //    VersesList.ItemsSource = verses;
        //}
        public VersesWindow(string title, List<Verse> verses)
        {
            InitializeComponent();
            Title = title;
            TitleText.Text = title;
            // Bind the ListBox to the verse texts (or set ItemsSource = verses to bind Verse objects)
            VersesList.ItemsSource = verses ?? new List<Verse>();

           // VersesList.ItemsSource = verses.Select(v => v.Text).ToList();
        }
        private void Close_Click(object sender, RoutedEventArgs e) => Close();
    }
}

