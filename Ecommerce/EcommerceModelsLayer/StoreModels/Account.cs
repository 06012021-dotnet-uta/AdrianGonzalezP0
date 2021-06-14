namespace StoreModels
{
    /// <summary>
    /// The Account class is responsible for keeping the Customers Username and password
    /// </summary>
    public class Account
    {
        public string Username { get; set; } // User Password
        protected string Password { get; set; }

        public Account(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public string accountInfo()
        {
            string account_info = $"Username:{this.Username}\nPassword: {this.Password}";
            return account_info;
        }

    }
}