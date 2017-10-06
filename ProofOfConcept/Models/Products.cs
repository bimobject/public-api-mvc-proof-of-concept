using System;

namespace ProofOfConcept.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double EditionNumber { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public string DescriptionHtml { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string SpecificationHtml { get; set; }
        public string EanCode { get; set; }
        public bool IsAvailableWorldWide { get; set; }
        public string Permalink { get; set; }
        public GetProductByIdResponseDto Files { get; set; }
        public bool IsImperial { get; set; }
        public GetProductBrandsResponseDto Brand { get; set; }

        //public IdNameDto materialMain { get; set; }
        //public IdNameDto materialSecondary { get; set; }
        //public CountryDto designedIn { get; set; }
        //public CountryDto manufacturedIn { get; set; }
        //public IdNameDto Ifc { get; set; }
        //public string CoBieTypeCategory { get; set; }
        //public GetProductByIdResponseDto Classifications { get; set; }
        //public GetProductByIdResponseDto Region { get; set; }
    }
}
