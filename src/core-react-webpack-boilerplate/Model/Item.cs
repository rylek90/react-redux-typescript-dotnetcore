namespace core_react_webpack_boilerplate.Model
{
    public class Item
    {
        public int Id;
        public readonly string Name;
        public readonly bool IsDone;
        public readonly string Description;

        public Item(int id, string name, string description, bool isDone = false)
        {
            Id = id;
            Name = name;
            IsDone = isDone;
            Description = description;
        }
    }
}
