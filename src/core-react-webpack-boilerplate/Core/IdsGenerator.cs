using System.Collections.Generic;
using System.Linq;

namespace core_react_webpack_boilerplate.Core
{
    public interface IGenerateIds
    {
        int GetNext(IEnumerable<int> keys);
    }

    public class IdsGenerator : IGenerateIds
    {
        public int GetNext(IEnumerable<int> keys)
        {
            return keys != null && keys.Count() > 0
                ? keys.Max() + 1
                : 1;
        }
    }
}
