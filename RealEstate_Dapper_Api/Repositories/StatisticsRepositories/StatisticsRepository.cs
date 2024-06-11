using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories;

public class StatisticsRepository:IStatisticsRepository
{
    private readonly Context _context;
    
    public StatisticsRepository(Context context)
    {
        _context = context;
    }
    
    public int CategoryCount()
    {
        string query = "SELECT COUNT(*) FROM Category";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }

    public int ActiveCategoryCount()
    {
        string query = "SELECT COUNT(*) FROM Category WHERE CategoryStatus=1";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }

    public int PassiveCategoryCount()
    {
        string query = "SELECT Count(*) FROM Category WHERE CategoryStatus=0";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }

    public int ProductCount()
    {
        string query = "SELECT COUNT(*) FROM Product";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }

    public int ApartmentCount()
    {
        string query = "SELECT COUNT(*) FROM Product WHERE Title LIKE '%Daire%'";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }

    public string EmployeeNameByMaxProductCount()
    {
        string query = "SELECT Name,COUNT(*) 'product_count' FROM Product INNER JOIN Employee ON Product.EmployeeID=Employee.EmployeeID GROUP BY Name ORDER BY product_count DESC";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<string>(query);
            return values;
        }
    }

    public string CategoryNameByMaxProductCount()
    {
        string query = "SELECT TOP(1) CategoryName, Count(*) FROM Product INNER JOIN Category ON Product.ProductCategory=Category.CategoryID GROUP BY CategoryName ORDER BY COUNT(*) DESC";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<string>(query);
            return values;
        }
    }

    public decimal AverageProductPriceByRent()
    {
        string query = "SELECT Avg(Price) FROM Product WHERE Type='Kiralık'";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }

    public decimal AverageProductPriceBySale()
    {
        string query = "SELECT Avg(Price) FROM Product WHERE Type='Satılık'";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }

    public string CityNameByMaxProductCount()
    {
        string query = "SELECT TOP(1) City,COUNT(*) as 'product_count' FROM Product GROUP BY City ORDER BY product_count DESC";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<string>(query);
            return values;
        }
    }

    public int DifferentCityCount()
    {
        string query = "SELECT COUNT(DISTINCT(City)) FROM Product";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }

    public decimal LastProductPrice()
    {
        string query = "SELECT TOP(1)Price FROM Product ORDER BY ProductID DESC";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<decimal>(query);
            return values;
        }
    }

    public string NewestBuildingYear()
    {
        string query = "SELECT TOP(1)BuildYear FROM ProductDetails ORDER BY BuildYear DESC";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<string>(query);
            return values;
        }
    }

    public string OldestBuildingYear()
    {
        string query = "SELECT TOP(1)BuildYear FROM ProductDetails ORDER BY BuildYear ASC";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<string>(query);
            return values;
        }
    }

    public int AverageRoomCount()
    {
        string query = "SELECT Avg(RoomCount) FROM ProductDetails";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }

    public int ActiveEmployeeCount()
    {
        string query = "SELECT COUNT(*) FROM Employee WHERE Status=1";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }
}