﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.ChartDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;

public class ChartRepository:IChartRepository
{
    private readonly Context _context;

    public ChartRepository(Context context)
    {
        _context = context;
    }


    public async Task<List<ResultChartDto>> GetFiveCityForChart()
    {
        string query = "SELECT TOP(5) City,Count(*) AS 'CityCount' FROM Product GROUP BY City ORDER BY CityCount DESC";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultChartDto>(query);
            return values.ToList();
        }
    }
}