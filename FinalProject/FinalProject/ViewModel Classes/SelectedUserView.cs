using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tweetinvi;
using Tweetinvi.Models;

namespace FinalProject
{
    class SelectedUserView : INotifyPropertyChanged, IUserView
    {
        public const int FOLLOWING = 0;
        public const int UNFOLLOWING = 1;
        public const int FOLLOWINGREQUEST = 2;

        private User user;
        private CurrentUser currentUser;

        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand followUserCommand;
        public ICommand FollowUserCommand
        {
            get{return followUserCommand ?? (followUserCommand = new RelayCommand(() => HandleFolllowButtonClick()));}
        }

        private ClickDelegate clickDelegate;
        private ICommand messageUserCommand;
        public ICommand MessageUserCommand
        {
          get{return messageUserCommand ?? (messageUserCommand = new RelayCommand(() => HandleMessageButtonClick()));}
        }

        public ImageBrush ProfilePic { get { return new ImageBrush(user.ProfilePic); } }

        public string Username{get { return user.Handle;}}

        private int follow;
        public int Follow
        {
            get{return follow;}
            set
            {
             if(value != follow)
                {
                    follow = value;
                    OnPropertyChanged(nameof(Follow));
                }
            }
        }
        
        private Visibility canDM;
        public Visibility CanDM
        {
            get{return canDM;}
            set
            {
                if( value!= canDM)
                {
                    canDM = value;
                    OnPropertyChanged(nameof(canDM));
                }
            }
        }
        public SelectedUserView(ClickDelegate click, CurrentUser cur, User sel)
        {
            clickDelegate = click;
            user = sel;
            currentUser = cur;
            Follow = GetFollowStatus();
            CanDM = DmStatus();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public int GetFollowStatus()
        {
            var relationship = Friendship.GetRelationshipDetailsBetween(currentUser.Handle, user.Handle);
            if (relationship.Following)
            {
                return FOLLOWING;
            }
            else if (relationship.FollowingRequested)
            {
                return FOLLOWINGREQUEST;
            }
            else
            {
                return UNFOLLOWING;
            }

        }
        public Visibility DmStatus()
        {
            var relationship = Friendship.GetRelationshipDetailsBetween(currentUser.Handle, user.Handle);
            return (relationship.CanSendDirectMessage) ? Visibility.Visible : Visibility.Collapsed;
        }

        public void HandleFolllowButtonClick()
        {
            if (Follow == FOLLOWING)
            {
                currentUser.UnfollowUser(user);
            }
            else if (Follow == UNFOLLOWING)
            {
                currentUser.FollowUser(user);
            }
            Follow = GetFollowStatus();
        }

        public void HandleMessageButtonClick()
        {
            var relationship = Friendship.GetRelationshipDetailsBetween(currentUser.Handle, user.Handle);
            if (!relationship.CanSendDirectMessage) { return; }

            var args = new ClickEventArgs(ClickType.ConversationSelect, user.Handle);
            clickDelegate?.Invoke(args);
        }
    }
}
