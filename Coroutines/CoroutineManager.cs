using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coroutines
{
    class CoroutineManager
    {
        List<Stack<IEnumerator<object>>> coroutines = new List<Stack<IEnumerator<object>>>();

        public void RegisterCoroutine(IEnumerable<object> coroutine)
        {
            var coroutineChain = new Stack<IEnumerator<object>>();
            coroutineChain.Push(coroutine.GetEnumerator());
            coroutines.Add(coroutineChain);
        }

        public void RegisterCoroutine(Func<IEnumerable<object>> coroutineDelegate)
        {
            RegisterCoroutine(coroutineDelegate());
        }

        public void Start()
        {
            int i = -1;
            while (true)
            {
                if (i < coroutines.Count - 1) i++; else i = 0;
                if (coroutines.Count == 0) break;

                if (!coroutines[i].Peek().MoveNext())
                {
                    coroutines[i].Pop();
                    if (coroutines[i].Count == 0)
                        coroutines.RemoveAt(i);
                    continue;
                }

                var command = coroutines[i].Peek().Current as ICoroutineCommand;
                if (command != null)
                {
                    coroutines[i].Push(command.Execute());
                }
            }
        }
    }
}
