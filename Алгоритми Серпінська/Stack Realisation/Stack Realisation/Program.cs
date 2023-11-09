using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack_Realisation
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = "0";
            int stackLength = 10;
            /*            StackAsArray<string> stack = new StackAsArray<string>(stackLength);

                        for (int i = 0; i < stack.Length; i++)
                        {
                            Console.WriteLine(value);
                            stack.Push(value);
                            value = (Convert.ToInt32(value) + 1).ToString();
                        }
                        Console.WriteLine();
                        for (int i = 0; i < stack.Length; i++)
                        {
                            Console.WriteLine(stack.Pop());

                        }
                        Console.WriteLine(stack.Pop());*/
            StackAsList<string> stack = new StackAsList<string>();

            for (int i = 0; i < stackLength; i++)
            {
                Console.WriteLine(value);
                stack.Push(value);
                value = (Convert.ToInt32(value) + 1).ToString();
            }
            Console.WriteLine();
            for (int i = 0; i < stackLength; i++)
            {
                Console.WriteLine(stack.Pop());

            }
            Console.WriteLine(stack.Pop());
            Console.ReadKey();
        }
    }

    class  StackAsArray<T> where T : class
    {
        public int Length { get; private set; }
        private int _last = 0;
        private T[] _stack; 
        public StackAsArray(int length)
        {
            _stack = new T[length];
            Length = length;
            _last = Length;
        }

        public void Push(T value)
        {
            if (_last > 0)
            {
                _last--;
                _stack[_last] = value;
            }
        }
        public T Pop()
        {
            if (IsEmpty())
                return null;

            T value = _stack[_last];
            _stack[_last] = null;
            _last++;
            return value;
        }
        public T GetLast()
        {
            if (_last >= Length)
            {
                return null;
            }
            return _stack[_last];
        }
        public void Clear()
        {
            for (int i = _last; i < Length; i++)
            {
                _stack[i] = null;
            }
            _last = Length - 1;
        }
        public bool IsEmpty() 
        {
            return GetLast() == null;
        }
    }

    class StackAsList<T> where T : class
    {
        public int Length { get; private set; } = 0;
        private int _last = -1;
        private List<T> _stack;
        public StackAsList()
        {
            _stack = new List<T>();
        }

        public void Push(T value)
        {
            _last++;
            Length++;
            _stack.Add(value);
        }
        public T Pop()
        {
            if (IsEmpty())
                return null;

            T value = _stack[_last];
            _stack.RemoveAt(_last);
            _last--;
            Length--;
            return value;
        }
        public T GetLast()
        {
            if (_last < 0)
            {
                return null;
            }
            return _stack[_last];
        }
        public void Clear()
        {
            _stack.RemoveRange(0, _stack.Count - 1);
            _last = -1;
            Length = 0;
        }
        public bool IsEmpty()
        {
            return GetLast() == null;
        }
    }
}
