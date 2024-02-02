namespace GigsNearMe
{
    // Used to deserialize the database connection secrets retrieved from 
    // Secrets Manager
    internal class DbSecret
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Engine {get; set;}
        public string DbInstanceIdentifier {get; set;}
    }
}
