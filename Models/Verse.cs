using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.Models
{
    public class Verse : INotifyPropertyChanged
    {
        private string? _text;
        private string? _meaning;
        private string? _prayer;
        private bool _isFavorite;

        public string? Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public string? Meaning
        {
            get => _meaning;
            set => SetProperty(ref _meaning, value);
        }

        public string? Prayer
        {
            get => _prayer;
            set => SetProperty(ref _prayer, value);
        }

        public bool IsFavorite
        {
            get => _isFavorite;
            set => SetProperty(ref _isFavorite, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}