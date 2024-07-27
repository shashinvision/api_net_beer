using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace api_net.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class BeerController : ControllerBase
  {

    List<BeersModel> Beers = new List<BeersModel>
            {
                new BeersModel(1, "Beer 1"),
                new BeersModel(2, "Beer 2"),
                new BeersModel(3, "Beer 3"),
                new BeersModel(4, "Beer 4"),
                new BeersModel(5, "Beer 5"),
            };
    [HttpGet(Name = "GetBeers")]
    public List<BeersModel> Get()
    {
      return Beers;
    }
    
    [HttpGet("{id}", Name = "GetBeerById")]
    public ActionResult<BeersModel> GetById(int id)
    {
        var beer = Beers.Find(b => b.Id == id);
        if (beer == null)
        {
            return NotFound();
        }

        return beer;
    }
    
    [HttpPut("{id}", Name = "EditBeer")]
    public List<BeersModel> Put(int id, [FromBody] BeersModel beer)
    {
      Beers[id-1] = beer;
      return Beers;
    }
    

    [HttpPost(Name = "PostBeers")]
    public List<BeersModel> Post([FromBody] string name)
    {
      Beers.Add(new BeersModel(Beers.Count + 1, name));
      return Beers;
    }

    [HttpPut(Name = "PutBeers")]
    public List<BeersModel> Put([FromBody] BeersModel beer)
    {
      Beers.Add(beer);
      return Beers;
    }

    [HttpDelete(Name = "DeleteBeers")]
    public List<BeersModel> Delete([FromBody] BeersModel beer)
    {
      Beers.Remove(beer);
      return Beers;
    }


  }
}