namespace Core.Models
{
    public class User : IdKey
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Record { get; set; }

        public int CoinsCount = 0;
    }
}
