using System.Collections.Generic;

namespace testThree
{
    class test3
    {
        int count = 0;
        int maxNum = 20;
        int minIndex = 0;
        List<int> stack = new List<int>();

        public test3(int maxNum = 20)
        {
            this.maxNum = maxNum;
        }

        public void push(int value)
        {
            if (count == maxNum - 1)
            {
                return;
            }
            if (count == 0)
            {
                stack.Add(value);
                count++;
            }
            else
            {
                if (stack[minIndex] >= value)
                    minIndex = count;
                stack.Add(value);
                count++;
            }
        }

        public int GetMin()
        {
            return stack[minIndex];
        }

        public int pop()
        {
            return stack[count];
        }
    }
}

