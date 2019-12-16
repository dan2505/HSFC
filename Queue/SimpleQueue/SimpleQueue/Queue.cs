namespace QueueProject
{
    class Queue
    {
        private readonly object[] queue;
        private int front, back;

        public Queue(int length)
        {
            queue = new object[length];
        }

        public void Enqueue(object str)
        {
            if (back < queue.Length)
            {
                queue[back] = str;
                back++;
            }
        }

        public object Dequeue()
        {
            if (front != back)
            {
                front++;
                return queue[front - 1];
            }
            return null;
        }

        public int GetLength()
        {
            return back;
        }

        public override string ToString()
        {
            string temp = "";
            for (int i = front; i < back; i++)
            {
                temp = temp + queue[i] + " ";
            }
            return temp;
        }
    }
}
