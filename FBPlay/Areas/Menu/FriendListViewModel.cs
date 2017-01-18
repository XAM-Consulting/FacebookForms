using System;
using System.Collections.Generic;

namespace FBPlay
{
    public class FriendListViewModel
    {
        public List<FriendListCellViewModel> FriendList { get; set; }

        public FriendListViewModel()
        {
            FriendList = new List<FriendListCellViewModel>
            {
                new FriendListCellViewModel { Name = "Peter Green", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Jesse Jiang", Photo = "Jesse.png" },
                new FriendListCellViewModel { Name = "Justin Dons", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Peter Green", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Peter Green", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Michelle Patterson", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Justin Dons", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Peter Green", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Peter Green", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Michelle Patterson", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Justin Dons", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Peter Green", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Peter Green", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Michelle Patterson", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Justin Dons", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Peter Green", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Peter Green", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Michelle Patterson", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Justin Dons", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Peter Green", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Peter Green", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Michelle Patterson", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Justin Dons", Photo = "michael.jpg" },
                new FriendListCellViewModel { Name = "Peter Green", Photo = "michael.jpg" },
            };
        }
    }
}
