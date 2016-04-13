using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coroutines
{
    public class WaitForSeconds : ICoroutineCommand
    {
        int milliseconds;
        DateTime timeToGo;

        public WaitForSeconds(int milliseconds)
        {
            this.milliseconds = milliseconds;
            this.timeToGo = DateTime.Now.AddMilliseconds(milliseconds);
        }

        public IEnumerator<object> Execute()
        {
            while (true)
            {
                if (DateTime.Now < timeToGo)
                    yield return null;
                else
                    yield break;
            }
        }
    }
}
