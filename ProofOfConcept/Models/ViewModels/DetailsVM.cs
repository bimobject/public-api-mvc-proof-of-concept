using Newtonsoft.Json;
using System;

namespace ProofOfConcept.Models.ViewModels
{
    [JsonObjectAttribute]
    public class DetailsVM
    {
        public string Id { get; set; }
        public int IdNr { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public double EditionNumber { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public bool IsImperial { get; set; }
        public string DescriptionPlainText { get; set; }
        public string SpecificationHtml { get; set; }
        public string EanCode { get; set; }
        public bool IsAvailableWorldWide { get; set; }
        public GetProductByIdResponseDto[] Files { get; set; }
        public GetProductBrandsResponseDto Brand { get; set; }
        public string[] ImageUrls { get; set; }
    }
}
