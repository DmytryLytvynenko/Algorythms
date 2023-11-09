using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string startString = "abbaabba";
            int startHeadPosition = 2;
            char[] alphavite = new char[] { 'a', 'b' };
            bool moovingDirectionRight = false;
            bool headReachedEnd = false;
            TuringMachine turingMachine = new TuringMachine(startString, startHeadPosition, moovingDirectionRight);

            turingMachine.ShowBody();

            while (!headReachedEnd)
            {
                headReachedEnd = turingMachine.MoveHead();
                turingMachine.ShowBody();
            }
            turingMachine.ChangeMoveDirection();
            turingMachine.MoveHead();
            turingMachine.PasteChar('1');

            turingMachine.ShowBody();
            Console.ReadKey();
        }
    }

    public class TuringMachine
    {
        public bool MoveRight { get; private set; } = true;

        private int head = 0;
        private List<char> body = new List<char>();
        public TuringMachine(string startString, int headPosition, bool moovingDirectionRight)
        {
            body.AddRange(startString);
            head = headPosition;
            MoveRight = moovingDirectionRight;
        }

        public string GetBody()
        {
            return new string(body.ToArray());
        }        
        public void ShowBody()
        {
            string body = GetBody();
            for (int i = 0; i < head; i++)
            {
                Console.Write(body[i]);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(body[head]);
            Console.ResetColor();

            for (int i = head + 1; i < body.Length; i++)
            {
                Console.Write(body[i]);
            }

            Console.WriteLine();
        }
        private char GetCellValue() 
        {
            return body[head];
        }
        public bool MoveHead()
        {
            bool headReachedEnd;
            if (MoveRight)
            {
                head++;
                headReachedEnd = head >= body.Count - 1;
                if (headReachedEnd)
                    head = body.Count - 1;

                return headReachedEnd;
            }
            else
            {
                head--;
                headReachedEnd = head <= 0;
                if (headReachedEnd)
                    head = 0;

                return headReachedEnd;
            }

            if (headReachedEnd)
                return headReachedEnd;


        }
        public void ChangeMoveDirection()
        {
            MoveRight = !MoveRight;
        }
        public bool CompareCell(char value)
        {
            if (body[head].Equals(value))
                return true;
            else
                return false;
        }
        public void DeleteLastChar()
        {
            body.RemoveAt(body.Count - 1);
        }
        public void DeleteChar()
        {
            body.RemoveAt(head);
        }
        public void PasteChar(char value)
        {
            body.Add(' ');

            char temp;

            for (int i = body.Count - 1; i > head; i--)
            {
                temp = body[i - 1];
                body[i] = temp;
            }
            body[head] = value;
        }
        public void PasteCharLast(char value)
        {
            body.Add(value);
        }
    }
}
