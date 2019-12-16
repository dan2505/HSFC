using System;
using System.Collections.Generic;
using System.Text;

namespace QueueProject
{
    class Queue
    {
        private string[] queue;
        private int front, back;

        public Queue(int length)
        {
            queue = new string[length];
        }

        public void Enqueue(string str)
        {
            if (back < queue.Length)
            {
                queue[back] = str;
                back++;
            }
        }
        
        public string Dequeue()
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
                temp = temp + ", " + queue[i];
            }
            return temp;
        }
    }
}
