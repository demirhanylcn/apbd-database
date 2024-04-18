using System.Data.SqlClient;
using database_api.data;
using database_api.data.Model;
using Microsoft.AspNetCore.Mvc;


public class AnimalRepository : IAnimalRepository
{
    
    public IEnumerable<Animal> GetAnimals()
    {
        SqlConnection connection =
            new SqlConnection(
                "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;");
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        
        command.CommandText = "SELECT * FROM ANIMAL";
        
        SqlDataReader dataReader = command.ExecuteReader();
        var animals = new List<Animal>();
        while (dataReader.Read())
        {
            var animal = new Animal()
            {
                Id = (int)dataReader["idAnimal"],
                name = dataReader["Name"].ToString(),
                description = dataReader["Description"].ToString(),
                category = dataReader["Category"].ToString(),
                area = dataReader["Area"].ToString(),
            };
            animals.Add(animal);
        }

        connection.Dispose();
        command.Dispose();
        return animals;
    }

    
    public Animal GetAnimal(int animalId)
    {
        SqlConnection connection =
            new SqlConnection(
                "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;");
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        
        command.CommandText = "SELECT * FROM ANIMAL WHERE idAnimal = @id";
        SqlDataReader dataReader = command.ExecuteReader();
        command.Parameters.AddWithValue("@id", animalId);

        var animal = new Animal()
        {
            Id = (int)dataReader["idAnimal"],
            name = dataReader["Name"].ToString(),
            description = dataReader["Description"].ToString(),
            category = dataReader["Category"].ToString(),
            area = dataReader["Area"].ToString(),
        };

        connection.Dispose();
        command.Dispose();
        return animal;
    }

    
    public int UpdateAnimal(int animalId, [FromBody] Animal updatedAnimal)
    {
        SqlConnection connection =
            new SqlConnection(
                "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;");
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "UPDATE ANIMAL SET Name = @name, Description = @description, Category = @category, Area = @area WHERE idAnimal = @oldId";
        

        command.Parameters.AddWithValue("@id", updatedAnimal.Id);
        command.Parameters.AddWithValue("@name", updatedAnimal.name);
        command.Parameters.AddWithValue("@description", updatedAnimal.description);
        command.Parameters.AddWithValue("@category", updatedAnimal.category);
        command.Parameters.AddWithValue("@area", updatedAnimal.area);
        command.Parameters.AddWithValue("@oldId", animalId);

        var affectedCount = command.ExecuteNonQuery();
        connection.Dispose();
        command.Dispose();
        return affectedCount;
    }
    public int DeleteAnimal(int animalId)
    {
        SqlConnection connection =
            new SqlConnection(
                "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;");
        SqlCommand command = new SqlCommand();
        connection.Open();
        
        command.CommandText = "DELETE FROM ANIMAL WHERE idAnimal = @id";
        command.Parameters.AddWithValue("@id", animalId);
        var affectedCount = command.ExecuteNonQuery();
        connection.Dispose();
        command.Dispose();
        return affectedCount;
    }
    public int AddAnimal([FromBody] Animal animal)
    {
        SqlConnection connection =
            new SqlConnection(
                "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;");
        SqlCommand command = new SqlCommand();
        connection.Open();
        
        command.CommandText =
            "INSERT INTO ANIMAL( Name, Description, Category, Area) VALUES (@name,@description,@category,@area)";
        
        
        command.Parameters.AddWithValue("@id", animal.Id);
        command.Parameters.AddWithValue("@name", animal.name);
        command.Parameters.AddWithValue("@description", animal.description);
        command.Parameters.AddWithValue("@category", animal.category);
        command.Parameters.AddWithValue("@area", animal.area);
        var affectedCount = command.ExecuteNonQuery();
        connection.Dispose();
        command.Dispose();
        return affectedCount;
    }
}