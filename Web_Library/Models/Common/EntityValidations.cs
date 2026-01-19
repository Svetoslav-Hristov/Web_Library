namespace Web_Library.Models.Common
{
    public static class EntityValidations
    {
        public static class User
        {
            public const int FirstNameUserMaxLength = 50;
            public const int LastNameUserMaxLength = 50;
            public const int AddressMaxLength = 200;
            public const int PhoneNumberMaxLength = 20;
            public const int EmailAddressMaxLength = 150;

        }
        public static class Book
        {
            public const int TitleMaxLength = 100;
            public const int AuthorMaxLengthName = 100;

        }
    }
}
