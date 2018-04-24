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
    class SearchView : INotifyPropertyChanged
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

        private bool inSearch;
        public bool InSearch
        {
            get { return inSearch; }
            set
            {
                if (inSearch != value)
                {
                    inSearch = value;
                    OnPropertyChanged(nameof(inSearch));
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
        public ICommand SearchButtonCommand { get { return searchButtonCommand ?? (searchButtonCommand = new RelayCommand(() => HandleSearchButtonClick())); } }

        private ClickDelegate clickDelegate;

        public event PropertyChangedEventHandler PropertyChanged;

        public SearchView(ClickDelegate del)
        {
            clickDelegate = del;
            Visibility = Visibility.Visible;
            InSearch = false;
        }

        public void HandleSearchButtonClick()
        {
            if (inSearch) { ExitSearch(); }
            else { Search(); }
        }

        public void Search()
        {
            inSearch = true;
            ClickType type = (searchType) ? ClickType.TweetSearch : ClickType.UserSearch;
            clickDelegate?.Invoke(new ClickEventArgs(type, text));
        }

        public void ExitSearch()
        {
            inSearch = false;
            clickDelegate?.Invoke(new ClickEventArgs(ClickType.ExitSearch, ""));
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
