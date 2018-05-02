using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FinalProject
{
    public class SearchView : INotifyPropertyChanged
    {
        private Visibility visibility;
        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
                if (visibility != value)
                {
                    visibility = value;
                    OnPropertyChanged(nameof(Visibility));
                }
            }
        }

        private Visibility exitVisibility;
        public Visibility ExitVisibility
        {
            get { return exitVisibility; }
            set
            {
                if (exitVisibility != value)
                {
                    exitVisibility = value;
                    OnPropertyChanged(nameof(ExitVisibility));
                }
            }
        }

        private bool searchType;
        public bool SearchType
        {
            get { return searchType; }
            set
            {
                if (searchType != value)
                {
                    searchType = value;
                    OnPropertyChanged(nameof(SearchType));
                }
            }
        }

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }

        private ICommand searchButtonCommand;
        public ICommand SearchButtonCommand { get { return searchButtonCommand ?? (searchButtonCommand = new RelayCommand(() => Search())); } }

        private ICommand exitSearchCommand;
        public ICommand ExitSearchCommand { get { return exitSearchCommand ?? (exitSearchCommand = new RelayCommand(() => ExitSearch())); } }

        private ClickDelegate clickDelegate;

        public event PropertyChangedEventHandler PropertyChanged;

        public SearchView(ClickDelegate del)
        {
            clickDelegate = del;
            Visibility = Visibility.Visible;
            ExitVisibility = Visibility.Hidden;
            Text = String.Empty;
        }

        
        public void Search()
        {
            ExitVisibility = Visibility.Visible;
            ClickType type = (searchType) ? ClickType.TweetSearch : ClickType.UserSearch;
            clickDelegate?.Invoke(new ClickEventArgs(type, Text));
        }

        public void ExitSearch()
        {
            ExitVisibility = Visibility.Hidden;
            clickDelegate?.Invoke(new ClickEventArgs(ClickType.ExitSearch, ""));
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void ChangeViewMode(ViewMode mode)
        {
            if (mode == ViewMode.MainView || mode == ViewMode.SearchView)
            {
                Visibility = Visibility.Visible;
            }
            else
            {
                Visibility = Visibility.Collapsed;
            }
        }
    }
}
