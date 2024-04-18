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

    [HttpGet]
    public IActionResult GetAnimals(string? orderBy)
    {
        return Ok(_animalService.GetAnimals(orderBy));
    }
    

    [HttpPut("{idAnimal:int}")]
    public IActionResult UpdateAnimal(int animalId, [FromBody] Animal updatedAnimal)
    {
        var affectedCount = _animalService.UpdateAnimal(animalId, updatedAnimal);
        if (affectedCount == 0)
            return NotFound();

        return Ok(affectedCount);
    }

    [HttpPost]
    public IActionResult AddAnimal([FromBody] Animal animal)
    {
        var affectedCount = _animalService.AddAnimal(animal);
        if (affectedCount == 0)
            return NotFound();

        return Ok(affectedCount);
    }

    [HttpDelete("{idAnimal:int}")]
    public IActionResult DeleteAnimal(int animalId)
    {
        var affectedCount = _animalService.DeleteAnimal(animalId);
        if (affectedCount == 0)
            return NotFound();

        return Ok(affectedCount);
    }
}