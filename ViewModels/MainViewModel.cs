using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Versely.Interfaces;
using Versely.Services;
using Versely.ViewModels;
using WpfApp1.Helpers;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly EmotionService _emotionService;

        private readonly IDialogService _dialogService;
        public ObservableCollection<Emotion> Emotions { get; }

        // NEW: Selected state
        private Emotion _selectedEmotion;
        public Emotion SelectedEmotion
        {
            get => _selectedEmotion;
            set
            {
                _selectedEmotion = value;
                OnPropertyChanged();

                OpenVersesCommand.RaiseCanExecuteChanged();
                ClearSelectionCommand.RaiseCanExecuteChanged();
            }
        }
        public RelayCommand OpenVersesCommand { get; }
        public RelayCommand ClearSelectionCommand { get; }
      //  public ICommand OpenVersesCommand { get; }

//        public MainViewModel()
//        {
//            _dialogService = new DialogService();

//            _emotionService = new EmotionService();
//            Emotions = _emotionService.LoadEmotions("Data/Verses.xml");

//            //OpenVersesCommand = new RelayCommand(
//            //     execute: OpenVerses,
//            //     canExecute: () => SelectedEmotion != null
//            // );


//            OpenVersesCommand = new RelayCommand(
//    execute: async () => await OpenVersesAsync(),
//    canExecute: () => SelectedEmotion != null && !IsBusy
//);


//            ClearSelectionCommand = new RelayCommand(
//                execute: () => SelectedEmotion = null,
//                canExecute: () => SelectedEmotion != null
//            );


//        }

        public MainViewModel(
            EmotionService emotionService,
            IDialogService dialogService)
        {
            _emotionService = emotionService;
            _dialogService = dialogService;

            Emotions = _emotionService.LoadEmotions("Data/Verses.xml");

            OpenVersesCommand = new RelayCommand(
                async () => await OpenVersesAsync(),
                () => SelectedEmotion != null && !IsBusy
            );

            ClearSelectionCommand = new RelayCommand(
                () => SelectedEmotion = null,
                () => SelectedEmotion != null
            );
        }
        private async Task OpenVersesAsync()
        {
            IsBusy = true;

            await Task.Delay(100); // simulate real work

            _dialogService.ShowVerses(
                SelectedEmotion.Name,
                SelectedEmotion.Verses
            );

            IsBusy = false;
        }


        private void OpenVerses()
        {
            if (SelectedEmotion == null) return;

            _dialogService.ShowVerses(
                SelectedEmotion.Name,
                SelectedEmotion.Verses
            );
        }

        private bool _isBusy; 
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();

                OpenVersesCommand.RaiseCanExecuteChanged();
            }
        }
    }
}
