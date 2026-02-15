using Web_Library.ViewModels;

namespace Web_Library.ViewModels.User
{
    public class UserViewModel : UserFormModel
    {
        public Guid Id { get; set; }

        public bool IsBlocked { get; set; }
        public IEnumerable<UserBookHistoryModel> UserHistory { get; set; } = new HashSet<UserBookHistoryModel>();

    }
}
