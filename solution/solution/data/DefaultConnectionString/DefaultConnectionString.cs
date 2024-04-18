namespace database_api.data.ConnectionString;

public class DefaultConnectionString
{
    public const string SectionName = "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;Trust Server Certificate=True";
    public string ConnectionString { get; set; } = string.Empty;
}
