namespace yazlabyeto.Models
{
    public class EgzersizProgramiModel
    {
        public int Id { get; set; }
        public string egzersizAdi { get; set; }

        public string hedef { get; set; }

        public int setSayisi { get; set; }

        public int tekrarSayisi { get; set; }

        public DateTime programBaslangicTarihi { get; set; }

        public string programSuresi { get; set; }

        public int AppDanisanId { get; set; }
        


    }
}
