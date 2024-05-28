namespace RealEstate_Dapper_Api.Dtos.ProductDtos;

public class ResultLastFiveProductWithCategoryDto
{
    public int ProductID { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public int ProdudctCategory { get; set; }
    public string CategoryName { get; set; }
    public DateTime AdvertisementDate { get; set; }
}