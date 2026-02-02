using System.Collections.ObjectModel;
using System.Windows;
using System.Xml.Linq;
using WpfApp1.Models;

namespace Versely.Services
{
    public class EmotionService
    {
        public ObservableCollection<Emotion> LoadEmotions(string path)
        {
            var emotions = new ObservableCollection<Emotion>();

            try
            {
                var doc = XDocument.Load(path);
                var list = doc.Root?
                    .Elements("Emotion")
                    .Select(e => new Emotion
                    {
                        Name = (string?)e.Attribute("Name")
                               ?? (string?)e.Element("Name")
                               ?? string.Empty,

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

                if (list != null)
                {
                    foreach (var em in list)
                        emotions.Add(em);
                }
            }
            catch (Exception ex)
            {
                // TEMP: we'll remove MessageBox later
                MessageBox.Show("Failed to load verses XML: " + ex.Message);
            }

            return emotions;
        }
    }
}
