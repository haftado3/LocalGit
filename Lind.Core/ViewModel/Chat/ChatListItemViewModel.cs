

using Lind.Core.ViewModel.Chat.Design;

namespace Lind.Core.ViewModel.Chat
{
    public class ChatListItemViewModel :BaseViewModel
    {
        #region Singleton

        public static ChatListItemViewModel Instance => new ChatListItemDesignModel();

        #endregion

        public string Name { get; set; }
        public string Message { get; set; }

        public string Initials { get; set; }

        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// True if there are unread messages in this chat 
        /// </summary>
        public bool NewContentAvailable { get; set; }

        /// <summary>
        /// True if this item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }
    }
}
