
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
        public const int CONVO_SELECT = 1;

        public const int MAIN_VIEW = 0;
        public const int USER_VIEW = 1;
        public const int CONVERSATION_VIEW = 2;
        public const int DM_VIEW = 3;

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

        private int viewMode;
        public int ViewMode
        {
            get { return viewMode; }
            set
            {
                if (value != viewMode)
                {
                    viewMode = value;
                    if (viewMode == MAIN_VIEW || viewMode == CONVERSATION_VIEW) { SelectedUser = application.User; }
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
            viewMode = MAIN_VIEW;
            updateViewModels(viewMode);
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
                case CONVERSATION_VIEW:
                    SenderView = null;
                    break;
                case DM_VIEW:
                    SenderView = new DirectMessageSenderView(application, selectedUser.Handle);
                    break;

            }
        }

        public void HandleClick(int type, string value)
        {
            switch (type)
            {
                case USER_SELECT:
                    ChangeSelectedUser(value);
                    ViewMode = USER_VIEW;
                    break;
                case CONVO_SELECT:
                    ChangeSelectedUser(value);
                    ViewMode = DM_VIEW;
                    break;
                    
            }
        }

        public void ChangeSelectedUser(string username)
        {
            User user = new User(username);
            SelectedUser = user;
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
}
