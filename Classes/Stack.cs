using System;
using System.Collections;

namespace Classes
{
    public class Stack
    {
        private ArrayList List = new ArrayList();

        public void Push(object obj)
        {
            if (obj is null)
                throw new InvalidOperationException("Cannot add 'null' to the stack");

            List.Add(obj);
        }

        public object Pop()
        {
            var lastIndex = List.Count - 1;
            var removed = List[lastIndex];

            List.RemoveAt(lastIndex);

            return removed;
        }

        public void Clear()
        {
            List.Clear();
        }

        public int Length()
        {
            return List.Count;
        }
    }
}
