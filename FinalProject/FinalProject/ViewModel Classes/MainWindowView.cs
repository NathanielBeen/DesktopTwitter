
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace FinalProject
{
    public delegate void ClickDelegate(ClickEventArgs args);

    public delegate void TweetDelegate(TweetEventArgs args);

    public class MainWindowView : INotifyPropertyChanged
    {
        private TwitterApplication application;
        public MessageCollectionView MessageView { get; }

        private ISenderView senderView;
        public ISenderView SenderView
        {
            get { return senderView; }
            set
            {
                if (value != senderView)
                {
                    senderView = value;
                    OnPropertyChanged(nameof(SenderView));
                }
            }
        }

        private IUserView userView;
        public IUserView UserView
        {
            get { return userView; }
            set
            {
                if (value != userView)
                {
                    userView = value;
                    OnPropertyChanged(nameof(UserView));
                }
            }
        }

        public SearchView SearchView { get; }
        public FilterMenuView FilterView { get; }

        private ViewMode viewMode;
        public ViewMode ViewMode
        {
            get { return viewMode; }
            set
            {
                viewMode = value;
                if (viewMode == ViewMode.MainView || viewMode == ViewMode.ConversationView || viewMode == ViewMode.SearchView) { SelectedUser = application.User; }
                UpdateViewModels(value);
                OnPropertyChanged(nameof(ViewMode));
            }
        }

        private Account currentAccount;
        public string UsernameString { get { return "You are logged in as: " + currentAccount.Username + " using twitter account: " + application.User.Handle; } }

        private User selectedUser;
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                if (value != selectedUser)
                {
                    selectedUser = value;
                    OnPropertyChanged(nameof(selectedUser));
                }
            }
        }

        private Search currentSearch;

        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand logoutCommand;
        public ICommand LogoutCommand { get { return logoutCommand ?? (logoutCommand = new RelayCommand(() => handleLogout())); } }

        public MainWindowView(TwitterApplication app, Account curAccount)
        {
            application = app;
            selectedUser = app.User;
            currentAccount = curAccount;
            MessageView = new MessageCollectionView(app, new ClickDelegate(HandleClick));
            SenderView = new TweetSenderView(app);
            UserView = new OwnUserView(selectedUser);
            SearchView = new SearchView(new ClickDelegate(HandleClick));
            FilterView = new FilterMenuView(app, new ClickDelegate(HandleClick));
            viewMode = ViewMode.MainView;
            UpdateViewModels(viewMode);
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void UpdateViewModels(ViewMode newView)
        {
            MessageView.ChangeViewMode(newView, selectedUser, currentSearch);
            SearchView.ChangeViewMode(newView);
            updateUserView();
            switch (newView)
            {
                case ViewMode.MainView:
                    SenderView = new TweetSenderView(application);
                    break;
                case ViewMode.UserView:
                    SenderView = new TweetSenderView(application, selectedUser.Handle);
                    break;
                case ViewMode.ConversationView:
                    SenderView = null;
                    break;
                case ViewMode.DMView:
                    SenderView = new DirectMessageSenderView(application, selectedUser.Handle);
                    break;
                case ViewMode.SearchView:
                    SenderView = new TweetSenderView(application);
                    break;

            }
        }

        public void updateUserView()
        {
            if (selectedUser.Equals(application.User))
            {
                UserView = new OwnUserView(selectedUser);
            }
            else { UserView = new SelectedUserView(new ClickDelegate(HandleClick), application.User, selectedUser); }
        }

        public void HandleClick(ClickEventArgs args)
        {
            switch (args.Type)
            {
                case ClickType.UserSelect:
                    ChangeSelectedUser(new User(args.Value));
                    ViewMode = ViewMode.UserView;
                    break;
                case ClickType.ConversationSelect:
                    ChangeSelectedUser(new User(args.Value));
                    ViewMode = ViewMode.DMView;
                    break;
                case ClickType.UserSearch:
                    currentSearch = new Search(args.Value, false);
                    ViewMode = ViewMode.SearchView;
                    break;
                case ClickType.TweetSearch:
                    currentSearch = new Search(args.Value, true);
                    ViewMode = ViewMode.SearchView;
                    break;
                case ClickType.ExitSearch:
                    ViewMode = ViewMode.MainView;
                    break;
                case ClickType.OpenFilter:
                    FilterView.Visibility = Visibility.Visible;
                    break;
                case ClickType.SubmitFilter:
                    FilterView.Visibility = Visibility.Collapsed;
                    MessageView.ChangeViewMode(ViewMode, selectedUser, currentSearch);
                    break;

            }
        }

        public void ChangeSelectedUser(User user)
        {
            SelectedUser = user;
        }

        public void handleLogout()
        {
            var window = new ApplicationLogin();
            foreach (Window w in App.Current.Windows)
            {
                if (!w.Equals(window)) { w.Close(); }
            }
            window.Show();
        }
    }

    public class IntToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }

    class ViewModelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.GetType() ?? null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolInverterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return !(bool)value;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return !(bool)value;
            }
            return value;
        }

    }
}