namespace ProofOfConcept.Models
{
    public class GetProductBrandsResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Permalink { get; set; }
        public string ImageUrl { get; set; }
        public int NumberOfProducts { get; set; }
    }
}