using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using WpfApp1.Helpers;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Emotion> Emotions { get; } = new();

        public ICommand OpenVersesCommand { get; }

        public MainViewModel()
        {
            OpenVersesCommand = new RelayCommand(param =>
            {
                if (param is Emotion emotion)
                {
                    var owner = Application.Current?.MainWindow;
                    var win = new VersesWindow(emotion.Name, emotion.Verses);
                    if (owner != null) win.Owner = owner;
                    win.ShowDialog();
                }
            });

            LoadEmotionsFromXml("Data/Verses.xml");
        }

        private void LoadEmotionsFromXml(string path)
        {
            try
            {
                var doc = XDocument.Load(path);
                var list = doc.Root?
                    .Elements("Emotion")
                    .Select(e => new Emotion
                    {
                        Name = (string?)e.Attribute("Name") ?? (string?)e.Element("Name") ?? string.Empty,
                        Verses = e.Elements("Verse")
                                  .Select(v => new Verse
                                  {
                                      Text = (string?)v.Element("Text") ?? (string?)v ?? string.Empty,
                                      Meaning = (string?)v.Element("Meaning") ?? string.Empty,
                                      Prayer = (string?)v.Element("Prayer") ?? string.Empty
                                  })
                                  .Where(x => !string.IsNullOrWhiteSpace(x.Text))
                                  .ToList()
                    })
                    .ToList();

                Emotions.Clear();
                if (list != null)
                    foreach (var em in list) Emotions.Add(em);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Application.Current?.MainWindow, "Failed to load verses XML: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}