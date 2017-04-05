using System.Collections.Generic;
using core_react_webpack_boilerplate.Core;
using core_react_webpack_boilerplate.Model;
using Microsoft.AspNetCore.Mvc;

namespace core_react_webpack_boilerplate.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemsRepository _repository;

        public ItemsController(IItemsRepository repository)
        {
            _repository = repository;
        }

        [Route("api/items/all")]
        [HttpGet]
        public IReadOnlyCollection<Item> GetAll()
        {
            return _repository.GetAll();
        }

        [Route("api/items/{id:int}/delete")]
        [HttpDelete]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        [HttpGet]
        [Route("api/items/{id:int}")]
        public Item GetSingle(int id)
        {
            return _repository.GetSingle(id);
        }

        [HttpPut]
        [Route("api/items/{id:int}/update")]
        public void Update(int id, string name, string description, bool isDone)
        {
            _repository.Update(id, name, description, isDone);
        }
        
        [HttpPost]
        [Route("api/items/add")]
        public void Add(string name, string description)
        {
            _repository.Add(name, description);
        }
    }
}
