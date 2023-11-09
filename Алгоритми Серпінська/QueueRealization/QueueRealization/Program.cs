using System;
using System.Collections.Generic;

namespace QueueRealization
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = "0";
            int queueLength = 10;

            #region QueueAsArray
/*
            QueueAsArray<string> queueArray = new QueueAsArray<string>(queueLength);

            for (int i = 0; i < queueArray.Length; i++)
            {
                Console.WriteLine(value);
                queueArray.Enqueue(value);
                value = (Convert.ToInt32(value) + 1).ToString();
            }
            Console.WriteLine();
            for (int i = 0; i < queueArray.Length; i++)
            {
                Console.WriteLine(queueArray.Dequeue());
            }*/

            #endregion

            #region QueueAsList

            QueueAsList<string> queueAsList = new QueueAsList<string>();

            for (int i = 0; i < queueLength; i++)
            {
                Console.WriteLine(value);
                queueAsList.Enqueue(value);
                value = (Convert.ToInt32(value) + 1).ToString();
            }
            Console.WriteLine();
            for (int i = 0; i < queueLength; i++)
            {
                Console.WriteLine(queueAsList.Dequeue());

            }

            #endregion

            Console.ReadKey();
        }
    }

    class QueueAsArray<T> where T : class
    {
        public int Length { get; private set; }
        private int _last = -1;
        private T[] _queue;
        public QueueAsArray(int length)
        {
            _queue = new T[length];
            Length = length;
        }

        public void Enqueue(T value)
        {
            if (_last >= Length - 1)
            {
                return;
            }
            _last++;
            _queue[_last] = value;
        }
        public T Dequeue()
        {
            if (IsEmpty())
                return null;

            T value = _queue[Length - _last - 1];
            _queue[Length - _last - 1] = null;
            _last--;
            return value;
        }
        public T GetLast()
        {
            if (_last < 0)
            {
                return null;
            }
            return _queue[Length - _last - 1];
        }
        public void Clear()
        {
            for (int i = _last; i < Length; i++)
            {
                _queue[i] = null;
            }
            _last = -1;
        }
        public bool IsEmpty()
        {
            return GetLast() == null;
        }
    }

    class QueueAsList<T> where T : class
    {
        public int Length { get; private set; } = 0;
        private List<T> _queue;
        public QueueAsList()
        {
            _queue = new List<T>();
        }

        public void Enqueue(T value)
        {
            Length++;
            _queue.Add(value);
        }
        public T Dequeue()
        {
            if (IsEmpty())
                return null;

            T value = _queue[0];
            _queue.RemoveAt(0);
            Length--;
            return value;
        }
        public T GetLast()
        {
            return _queue[0];
        }
        public void Clear()
        {
            _queue.RemoveRange(0, Length - 1);
            Length = 0;
        }
        public bool IsEmpty()
        {
            return Length == 0;
        }
    }
}

