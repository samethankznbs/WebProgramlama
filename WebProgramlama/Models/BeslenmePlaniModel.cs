namespace yazlabyeto.Models
{
    public class BeslenmePlaniModel
    {
        public int Id { get; set; }
        public string hedef { get; set; }

        public string gunlukOgun { get; set; }

        public string kaloriHedef { get; set; }

        public DateTime beslenmePlanBaslangicTarihi { get; set; }

        public string planSuresi { get; set; }

        public int? AppDanisanId { get; set; }

    }
}
