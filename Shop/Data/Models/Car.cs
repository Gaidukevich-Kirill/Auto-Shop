namespace Shop.Data.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Img { get; set; }

        public ushort Price { get; set; }

        public bool IsFavorite { get; set; }

        public bool Avaliable { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
