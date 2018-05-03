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
    public class FilterMenuView : INotifyPropertyChanged
    {
        private TwitterApplication application;
        private ClickDelegate clickDelegate;

        private string userWhitelist;
        public string UserWhitelist
        {
            get { return userWhitelist; }
            set
            {
                if (userWhitelist != value)
                {
                    userWhitelist = value;
                    OnPropertyChanged(nameof(UserWhitelist));
                }
            }
        }

        private string userBlacklist;
        public string UserBlacklist
        {
            get { return userBlacklist; }
            set
            {
                if (userBlacklist != value)
                {
                    userBlacklist = value;
                    OnPropertyChanged(nameof(UserBlacklist));
                }
            }
        }

        private string wordWhitelist;
        public string WordWhitelist
        {
            get { return wordWhitelist; }
            set
            {
                if (wordWhitelist != value)
                {
                    wordWhitelist = value;
                    OnPropertyChanged(nameof(WordWhitelist));
                }
            }
        }

        private string wordBlacklist;
        public string WordBlacklist
        {
            get { return wordBlacklist; }
            set
            {
                if (wordBlacklist != value)
                {
                    wordBlacklist = value;
                    OnPropertyChanged(nameof(WordBlacklist));
                }
            }
        }

        private Visibility visibility;
        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
                if (visibility != value)
                {
                    visibility = value;
                    if (visibility == Visibility.Visible) { ResetFields(); }
                    OnPropertyChanged(nameof(Visibility));
                }
            }
        }

        private ICommand submitChangesCommand;
        public ICommand SubmitChangesCommand { get { return submitChangesCommand ?? (submitChangesCommand = new RelayCommand(() => SubmitChanges())); } }

        private ICommand resetCommand;
        public ICommand ResetCommand { get { return resetCommand ?? (resetCommand = new RelayCommand(() => CloseAndReset())); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public FilterMenuView(TwitterApplication app, ClickDelegate del)
        {
            application = app;
            clickDelegate = del;

            UserWhitelist = String.Empty;
            UserBlacklist = String.Empty;
            WordBlacklist = String.Empty;
            WordWhitelist = String.Empty;
            Visibility = Visibility.Collapsed;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void SubmitChanges()
        {
            MessageFilter filter = application.Filter;
            filter.BuildOrUpdateComponent(FilterType.UserBlackList, ConvertTextToWordList(new StringInput(UserBlacklist)));
            filter.BuildOrUpdateComponent(FilterType.UserWhiteList, ConvertTextToWordList(new StringInput(UserWhitelist)));
            filter.BuildOrUpdateComponent(FilterType.WordBlackList, ConvertTextToWordList(new StringInput(WordBlacklist)));
            filter.BuildOrUpdateComponent(FilterType.WordWhiteList, ConvertTextToWordList(new StringInput(WordWhitelist)));
            clickDelegate?.Invoke(new ClickEventArgs(ClickType.SubmitFilter, ""));
        }

        public void CloseAndReset()
        {
            ResetFields();
            Visibility = Visibility.Collapsed;
        }

        public void ResetFields()
        {
            MessageFilter filter = application.Filter;
            UserWhitelist = String.Empty;
            UserBlacklist = String.Empty;
            WordBlacklist = String.Empty;
            WordWhitelist = String.Empty;
<<<<<<< HEAD:FinalProject/FinalProject/ViewModel Classes/FilterMenuView.cs
            foreach (var entry in filter.FilterComponents) { ResetFieldToFilter(entry.Key, entry.Value); }
=======
            foreach (var entry in filter.FilterComponents) { resetFieldToFilter(entry.Key, entry.Value); }
>>>>>>> origin/master:FinalProject/FinalProject/ViewModel Classes/FilterMenuView.cs
        }

        public void ResetFieldToFilter(FilterType type, IFilterComponent component)
        {
            string text = (component == null) ? String.Empty : ConvertWordListToText(component.GetItems());
            switch (type)
            {
                case FilterType.UserBlackList:
                    UserBlacklist = text;
                    break;
                case FilterType.UserWhiteList:
                    UserWhitelist = text;
                    break;
                case FilterType.WordBlackList:
                    WordBlacklist = text;
                    break;
                case FilterType.WordWhiteList:
                    WordWhitelist = text;
                    break;
                default:
                    break;
            }
        }

        public List<FilterItem> ConvertTextToWordList(StringInput text)
        {
            var trimmed = new List<FilterItem>();
            var untrimmed = text.Input.Split(',');

            foreach (string word in untrimmed)
            {
                if (word.Length > 0) { trimmed.Add(new FilterItem(word.Trim())); }
            }
            return trimmed;
        }

        public string ConvertWordListToText(List<FilterItem> wordList)
        {
            
            return string.Join(",", wordList.Select(s => s.Content).ToList());
        }
    }
}
