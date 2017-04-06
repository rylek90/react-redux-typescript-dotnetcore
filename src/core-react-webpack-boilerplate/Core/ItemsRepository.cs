using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using core_react_webpack_boilerplate.Model;

namespace core_react_webpack_boilerplate.Core
{
    public interface IItemsRepository
    {
        void Add(string name, string description);
        void Delete(int id);
        IReadOnlyCollection<Item> GetAll();
        Item GetSingle(int id);
        void Update(int id, string name, string description, bool isDone);
    }

    internal class ItemsRepository : IItemsRepository
    {
        private readonly ConcurrentDictionary<int, Item> _repository = new ConcurrentDictionary<int, Item>
        {
            [1] = new Item(1, "Sample", "Description"),
            [2] = new Item(2, "Sample2", "Description2")
        };

        private readonly IGenerateIds _idsGenerator;

        public ItemsRepository(IGenerateIds idsGenerator)
        {
            _idsGenerator = idsGenerator;
        }

        public void Add(string name, string description)
        {
            var id = _idsGenerator.GetNext(_repository.Keys);
            _repository.TryAdd(id, new Item(id, name, description));
        }

        public void Delete(int id)
        {
            _repository.TryRemove(id, out var _);
        }

        public IReadOnlyCollection<Item> GetAll()
        {
            return _repository.Values.ToList();
        }

        public Item GetSingle(int id)
        {
            _repository.TryGetValue(id, out var item);
            return item;
        }

        public void Update(int id, string name, string description, bool isDone)
        {
            var newItem = new Item(id, name, description, isDone);
            _repository.AddOrUpdate(id, newItem, (key, existingItem) => newItem);
        }
    }
}
