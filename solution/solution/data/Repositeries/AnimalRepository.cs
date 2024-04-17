using database_api.data.Model;
using System.Data.SqlClient;


namespace database_api.data;

public class AnimalRepository : IAnimalRepository
{
    private IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IEnumerable<Animal> GetAnimals()
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal";
        
        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read())
        {
            var animal = new Animal()
            {
                Id = (int)dr["IdStudent"],
                name = dr["FirstName"].ToString(),
                description = dr["LastName"].ToString(),
                category = dr["Email"].ToString(),
                area = dr["Address"].ToString(),
            };
            animals.Add(animal);
        }
        
        return animals;
    }
}


