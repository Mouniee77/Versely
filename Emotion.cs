using System.Collections.Generic;

namespace WpfApp1.Models
{
    public class Emotion
    {
        //  public string Name { get; set; }
        //  public string Icon { get; set; } // optional, path or glyph
        //  public List<string> Verses { get; set; } = new List<string>();
        public string Name { get; set; }
       // public List<Verse> Verses { get; set; }
        public List<Verse> Verses { get; set; } = new List<Verse>();

        //public string Name { get; set; } = string.Empty;
        //public List<string> Verses { get; set; } = new();
    }
}
