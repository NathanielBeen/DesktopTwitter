using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tweetinvi;
using Tweetinvi.Models;

namespace FinalProject
{
    class SelectedUserView : INotifyPropertyChanged
    {
        public const int FOLLOWING = 0;
        public const int UNFOLLOWING = 1;
        public const int FOLLOWINGREQUEST = 2;
        private User user;
        private CurrentUser currentUser;
        private IRelationshipDetails relationship;
        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand followUserCommand;
        public ICommand FollowUserCommand
        {
            get
            {
                return followUserCommand ?? (followUserCommand = new RelayCommand(() => handleFolllowButtonClick()));
            }
        }

        public string Username
        {
            get { return user.Handle;}
        }

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

        private bool canDM;
        public bool CanDM
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
        public SelectedUserView(CurrentUser cur, User sel)
        {
            user = sel;
            currentUser = cur;
            relationship = Friendship.GetRelationshipDetailsBetween(currentUser.Name, user.Name);
            Follow = GetFollowStatus();
            CanDM = DmStatus();
        }
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public int GetFollowStatus()
        {
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
        public bool DmStatus()
        {
            return relationship.CanSendDirectMessage;
        }
        public void handleFolllowButtonClick()
        {
            if (Follow == FOLLOWING)
            {
                currentUser.unfollowUser(user);
            }
            else if (Follow == UNFOLLOWING)
            {
                currentUser.followUser(user);
            }
        }

    }
}
