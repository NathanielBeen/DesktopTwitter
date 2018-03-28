using FinalProject.ViewModel_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FinalProject
{
    public delegate void ClickDelegate(int type, string value);

    public class MainWindowView : INotifyPropertyChanged
    {
        public const int USER_SELECT = 0;

        public const int MAIN_VIEW = 0;
        public const int USER_VIEW = 1;
        public const int DM_VIEW = 2;

        private TwitterApplication application;
        public MessageCollectionView MessageView { get; }
        public TweetSenderView SenderView { get; private set; }

        private int viewMode;
        public int ViewMode
        {
            get { return viewMode; }
            set
            {
                if (value != viewMode)
                {
                    viewMode = value;
                    updateViewModels(value);
                    OnPropertyChanged(nameof(ViewMode));
                }
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowView(TwitterApplication app)
        {
            application = app;
            selectedUser = app.User;

            MessageView = new MessageCollectionView(app, new ClickDelegate(HandleClick));
            SenderView = new TweetSenderView(app);
            ViewMode = MAIN_VIEW;
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void updateViewModels(int newView)
        {
            MessageView.ChangeViewMode(newView, selectedUser);
            switch (newView)
            {
                case MAIN_VIEW:
                    SenderView = new TweetSenderView(application);
                    break;
                case USER_VIEW:
                    SenderView = new TweetSenderView(application, selectedUser.Handle);
                    break;

            }
        }

        public void HandleClick(int type, string value)
        {
            switch (type)
            {
                case USER_SELECT:
                    ChangeSelectedUser(value);
                    break;
            }
        }

        public void ChangeSelectedUser(string username)
        {
            User user = new User(username);
            SelectedUser = user;
            ViewMode = USER_VIEW;
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
}
