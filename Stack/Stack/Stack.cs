namespace Stack
{
    public class Stack
    {
        private int top;
        private readonly object[] stack;

        public Stack(int size)
        {
            stack = new object[size];
        }

        public bool Push(object obj)
        {
            if (top < stack.Length)
            {
                top++;
                stack[top] = obj;

                return true;
            }
            return false;
        }

        public object Pop()
        {
            if (top > 0)
            {
                top--;
                return stack[top];
            }
            return null;
        }

        public int Depth()
        {
            return top;
        }

        public object Peek()
        {
            return stack[top];
        }

        public bool IsEmpty()
        {
            return top == 0;
        }
    }
}
