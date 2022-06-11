namespace haiku_mvc.Models
{
    public class PostModel
    {
        public int Id { get; set; }

        public int KullaniciId { get; set; }

        public string[] Icerik { get; set; }

        public DateTime Date { get; set; }

        public int Begeni { get; set; }

        public int Paylasim { get; set; }

    }
}
