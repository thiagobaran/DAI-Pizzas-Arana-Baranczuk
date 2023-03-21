using Microsoft.AspNetCore.Mvc;


namespace Pizzas.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzasController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<PizzasController> _logger;

    public PizzasController(ILogger<PizzasController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetPizzas")]
    
    
  public IActionResult GetAll()
    {

        IActionResult respuesta;

        List<Pizzas> entityList;

        entityList = Models.BD.GetAll();

        respuesta = Ok(entityList);

        return respuesta;

    }
    [HttpGet("{id}")]

    public IActionResult GetById(int id)
    {

        IActionResult respuesta = null;

        Pizzas entity;

        entity = Models.BD.GetById(id);

        if (entity == null)
        {

            respuesta = NotFound();

        }
        else
        {

            respuesta = Ok(entity);

        }

        return respuesta;

    }
    [HttpPost]

    public IActionResult Create(Pizzas pizza)
    {

        int
        intRowsAffected;

        intRowsAffected = Models.BD.Insert(pizza);

        return CreatedAtAction(nameof(Create), new { id = pizza.IdPizza }, pizza);

    }
    [HttpDelete("{id}")]

    public IActionResult DeleteById(int id)
    {

        IActionResult respuesta = null;

        Pizzas entity;

        int intRowsAffected = 0;

        entity = Models.BD.GetById(id);

        if (entity == null)
        {

            respuesta = NotFound();

        }
        else
        {

            intRowsAffected = Models.BD.DeleteById(id);

            if (intRowsAffected > 0)
            {

                respuesta = Ok(entity);

            }
            else
            {

                respuesta = NotFound();

            }

        }

        return respuesta;

    }


}

