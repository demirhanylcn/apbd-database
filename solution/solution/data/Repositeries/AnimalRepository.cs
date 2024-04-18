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
                "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;Trust Server Certificate=True");
        SqlCommand command = new SqlCommand();
        command.CommandText = "SELECT * FROM ANIMAL";
        connection.Open();
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
                "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;Trust Server Certificate=True");
        SqlCommand command = new SqlCommand();
        connection.Open();
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
                "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;Trust Server Certificate=True");
        SqlCommand command = new SqlCommand();
        command.CommandText = "UPDATE ANIMAL SET idAnimal = @id, name = @name WHERE idAnimal = @oldId";
        connection.Open();

        command.Parameters.AddWithValue("@id", updatedAnimal.Id);
        command.Parameters.AddWithValue("@name", updatedAnimal.name);
        command.Parameters.AddWithValue("@description", updatedAnimal.description);
        command.Parameters.AddWithValue("@category", updatedAnimal.category);
        command.Parameters.AddWithValue("@area", updatedAnimal.area);
        command.Parameters.AddWithValue("@oldId", animalId);

        command.ExecuteNonQuery(); // When the operation is INSERT,DELETE,UPDATE 
        connection.Dispose();
        command.Dispose();

        var affectedCount = command.ExecuteNonQuery();
        return affectedCount;
    }
    public int DeleteAnimal(int animalId)
    {
        SqlConnection connection =
            new SqlConnection(
                "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;Trust Server Certificate=True");
        SqlCommand command = new SqlCommand();
        connection.Open();
        command.CommandText = "DELETE FROM ANIMAL WHERE idAnimal = @id";
        command.Parameters.AddWithValue("@id", animalId);
        
        connection.Dispose();
        command.Dispose();
        var affectedCount = command.ExecuteNonQuery();
        return affectedCount;
    }
    public int AddAnimal([FromBody] Animal animal)
    {
        SqlConnection connection =
            new SqlConnection(
                "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;Trust Server Certificate=True");
        SqlCommand command = new SqlCommand();
        command.CommandText =
            "INSERT INTO ANIMAL(idAnimal, Name, Description, Category, Area) VALUES (@id,@name,@description,@category,@area)";
        
        connection.Open();
        command.Parameters.AddWithValue("@id", animal.Id);
        command.Parameters.AddWithValue("@name", animal.name);
        command.Parameters.AddWithValue("@description", animal.description);
        command.Parameters.AddWithValue("@category", animal.category);
        command.Parameters.AddWithValue("@area", animal.area);
        
        connection.Dispose();
        command.Dispose();
        var affectedCount = command.ExecuteNonQuery();
        return affectedCount;
    }
}