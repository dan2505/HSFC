namespace QueueProject
{
    class ShuntingQueue
    {
        private readonly object[] queue;
        private int back;

        public ShuntingQueue(int length)
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
            if (back != 0)
            {
                object found = queue[0];
            
                for (int i = 0; i < back; i++)
                {
                    queue[i] = queue[i + 1];
                }

                return found;
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
            for (int i = 0; i < back; i++)
            {
                temp = temp + queue[i] + " ";
            }
            return temp;
        }
    }
}