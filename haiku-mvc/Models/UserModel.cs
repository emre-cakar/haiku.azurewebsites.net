namespace haiku_mvc.Models
{
    public class UserModel
    {

        public int Id { get; set; }

        public string AdSoyad { get; set; }

        public string KullaniciAdi { get; set; }

        public string Email { get; set; }

        public string Sifre { get; set; }

        public int ToplamTakip { get; set; }

        public int ToplamTakipci { get; set; }

        public int ToplamHaiku { get; set; }

        public int ToplamBegeni { get; set; }

        public int ToplamReshare { get; set; }

    }
}
