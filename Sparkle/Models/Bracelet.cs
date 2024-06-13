namespace SparkelStrands.Models
{
    public class Bracelete
    {

        public int Id { get; set; }
        public string Material { get; set; }
        public double Length { get; set; } // Length in centimeters
        public int Beads { get; set; }
        public string Color { get; set; }
        public string ClaspType { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }

    }
}
