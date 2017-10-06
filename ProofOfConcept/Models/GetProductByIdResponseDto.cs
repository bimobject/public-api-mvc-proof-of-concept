namespace ProofOfConcept.Models
{
    public class GetProductByIdResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FileTypeDto FileType { get; set; }
    }
    
    public class FileTypeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}