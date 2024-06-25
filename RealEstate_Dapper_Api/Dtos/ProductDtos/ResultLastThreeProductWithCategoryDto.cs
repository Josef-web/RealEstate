namespace RealEstate_Dapper_Api.Dtos.ProductDtos;

public class ResultLastThreeProductWithCategoryDto
{
    public int ProductID { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public int ProdudctCategory { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public string CoverImage { get; set; }
    public DateTime AdvertisementDate { get; set; }
}