﻿
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
    public delegate void ClickDelegate(ClickEventArgs args);

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

        private ViewMode viewMode;
        public ViewMode ViewMode
        {
            get { return viewMode; }
            set
            {
                if (value != viewMode)
                {
                    viewMode = value;
                    if (viewMode == ViewMode.MainView || viewMode == ViewMode.ConversationView) { SelectedUser = application.User; }
                    UpdateViewModels(value);
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
            viewMode = ViewMode.MainView;
            UpdateViewModels(viewMode);
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void UpdateViewModels(ViewMode newView)
        {
            MessageView.ChangeViewMode(newView, selectedUser);
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

            }
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
                    
            }
        }

        public void ChangeSelectedUser(User user)
        {
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
