using database_api.data.Model;
using database_api.data.Services;
using Microsoft.AspNetCore.Mvc;

namespace database_api.data;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private IAnimalService _animalService;


    public AnimalsController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet("{orderBy:string}")]
    public IActionResult GetAnimals(string orderBy)
    {
        var animals = _animalService.GetAnimals();
        if (!string.IsNullOrEmpty(orderBy))
        {
            switch (orderBy.ToLower())
            {
                case "name":
                    animals = animals.OrderBy(a => a.name).ToList();
                    break;
                case "description":
                    animals = animals.OrderBy(a => a.description).ToList();
                    break;
                case "id":
                    animals = animals.OrderBy(a => a.Id).ToList();
                    break;
                case "category":
                    animals = animals.OrderBy(a => a.category).ToList();
                    break;
                case "area":
                    animals = animals.OrderBy(a => a.area).ToList();
                    break;
                default:
                    animals = animals.OrderBy(a => a.name).ToList();
                    break;
            }
        }

        return Ok(animals);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal updatedAnimal)
    {
        var animal = _animalService.GetAnimal(id);
        if (animal == null)
        {
            return NotFound("given animal is not found.");
        }
        animal.name = updatedAnimal.name;
        animal.description = updatedAnimal.description;
        animal.category = updatedAnimal.category;
        animal.area = updatedAnimal.area;
        _animalService.UpdateAnimal(animal);
        return Ok(animal);
    }
}