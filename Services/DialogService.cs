using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versely.Interfaces;
using WpfApp1;
using WpfApp1.Models;
using System.Windows;


namespace Versely.Services
{
    public class DialogService : IDialogService
    {
        public void ShowVerses(string title, object data)
        {
            if (data is not System.Collections.Generic.List<Verse> verses)
                return;

            var win = new VersesWindow(title, verses)
            {
                Owner = Application.Current.MainWindow
            };

            win.ShowDialog();
        }
    }
    
}
