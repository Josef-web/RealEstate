using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.AppUserRepositories;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;
using RealEstate_Dapper_Api.Repositories.CategoryRepositories;
using RealEstate_Dapper_Api.Repositories.ContactRepository;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;
using RealEstate_Dapper_Api.Repositories.MessageRepositories;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;
using RealEstate_Dapper_Api.Repositories.ProductImageRepositories;
using RealEstate_Dapper_Api.Repositories.ProductRepositories;
using RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositories;
using RealEstate_Dapper_Api.Repositories.ServiceRepositories;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepositories;
using RealEstate_Dapper_Api.Repositories.TestimonialRepositories;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;
using RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepositories;

namespace RealEstate_Dapper_Api.Containers;

public static class Extensions
{
    public static void ContainerDependencies(this IServiceCollection services)
    {
        
       services.AddTransient<Context>();
       services.AddTransient<ICategoryRepository, CategoryRepository>();
       services.AddTransient<IProductRepository,ProductRepository>();
       services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
       services.AddTransient<IServiceRepository, ServiceRepository>();
       services.AddTransient<IBottomGridRepository, BottomGridRepository>();
       services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
       services.AddTransient<ITestimonialRepository, TestimonialRepository>();
       services.AddTransient<IEmployeeRepository, EmployeeRepository>();
       services.AddTransient<IStatisticsRepository, StatisticsRepository>();
       services.AddTransient<IContactRepository, ContactRepository>();
       services.AddTransient<IToDoListRepository, ToDoListRepository>();
       services.AddTransient<IStatisticRepository, StatisticRepository>();
       services.AddTransient<IChartRepository, ChartRepository>();
       services.AddTransient<ILastFiveProductsRepository, LastFiveProductsRepository>();
       services.AddTransient<IMessageRepository, MessageRepository>();
       services.AddTransient<IProductImageRepository, ProductImageRepository>();
       services.AddTransient<IAppUserRepository, AppUserRepository>();
       services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();
       services.AddTransient<ISubFeatureRpository, SubFeatureRepository>();
    }
}