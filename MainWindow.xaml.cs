using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using WpfApp1.Models;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
      //  public ObservableCollection<Emotion> Emotions { get; } = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
           // LoadEmotionsFromXml("Data/Verses.xml");
        }

        //private void LoadEmotionsFromXml(string path)
        //{
        //    try
        //    {
        //        var doc = XDocument.Load(path);
        //        var list = doc.Root?
        //            .Elements("Emotion")
        //            .Select(e => new Emotion
        //            {
        //                Name = (string)e.Attribute("Name") ?? (string)e.Element("Name") ?? string.Empty,
        //                Verses = e.Elements("Verse")
        //                          .Select(v => new Verse
        //                          {
        //                              // support both old format (inner text) and new format (child elements)
        //                              Text = (string)v.Element("Text") ?? (string)v ?? string.Empty,
        //                              Meaning = (string)v.Element("Meaning") ?? string.Empty,
        //                              Prayer = (string)v.Element("Prayer") ?? string.Empty
        //                          })
        //                          .Where(x => !string.IsNullOrWhiteSpace(x.Text))
        //                          .ToList()
        //            })
        //            .ToList();

        //        Emotions.Clear();
        //        if (list != null)
        //            foreach (var em in list) Emotions.Add(em);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(this, "Failed to load verses XML: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
      //  }

        //private void EmotionButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (sender is FrameworkElement fe && fe.Tag is Emotion emotion)
        //    {
        //        var win = new VersesWindow(emotion.Name, emotion.Verses);
        //        win.Owner = this;
        //        win.ShowDialog();
        //    }
        //}

        //private void EmotionButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (sender is FrameworkElement fe && fe.Tag is Emotion emotion)
        //    {
        //        // Pass emotion.Verses.Select(v => v.Text).ToList() if VersesWindow expects List<string>
        //        var win = new VersesWindow(emotion.Name, emotion.Verses.Select(v => v.Text).ToList());
        //        win.Owner = this;
        //        win.ShowDialog();
        //    }
        //}
    }
}