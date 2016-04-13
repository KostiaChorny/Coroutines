using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coroutines
{
    public class Coroutine : ICoroutineCommand
    {
        IEnumerable<object> coroutine;
        public Coroutine(IEnumerable<object> coroutine)
        {
            this.coroutine = coroutine;
        }

        public Coroutine(Func<IEnumerable<object>> coroutineDelegate)
        {
            this.coroutine = coroutineDelegate();
        }
        public IEnumerator<object> Execute()
        {
            return coroutine.GetEnumerator();
        }
    }
}
