using System.Data;
using Microsoft.Data.SqlClient;

namespace RealEstate_Dapper_Api.Models.DapperContext;

public class Context
{
    private readonly IConfiguration _configuration;
    private readonly string _connectiontString;

    public Context(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectiontString = _configuration.GetConnectionString("SqlCon");
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectiontString);
}