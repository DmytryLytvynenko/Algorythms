using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    class Program
    {
        public enum MoveAction 
        {
            Stay,
            Right,
            Left
        }
        static void Main(string[] args)
        {
            string startString = "abbaabba";
            int startHeadPosition = 2;
            List<char> alphavite = new List<char> {' ', 'a', 'b' };
            bool moovingDirectionRight = false;
            TuringMachine turingMachine = new TuringMachine(startString, startHeadPosition, moovingDirectionRight, alphavite);
            State q1 = new State(turingMachine);
            State q2 = new State(turingMachine);
            State q3 = new State(turingMachine);
            State q4 = new State(turingMachine);
            turingMachine.InitializeStartState(q1);

            q1.AddCommand('a', TuringMachine.MoveAction.Left, false, q1);
            q1.AddCommand('b', TuringMachine.MoveAction.Left, false, q1);
            q1.AddCommand(' ', TuringMachine.MoveAction.Stay, false, q2);

            q2.AddCommand('a', TuringMachine.MoveAction.Right, false, q3);
            q2.AddCommand('b', TuringMachine.MoveAction.Right, false, q3);
            q2.AddCommand(' ', TuringMachine.MoveAction.Right, false, q3);

            q3.AddCommand('a', TuringMachine.MoveAction.Right, false, q4);
            q3.AddCommand('a', TuringMachine.MoveAction.Right, false, q4);

            q4.AddCommand('a', TuringMachine.MoveAction.Stay, true, null,'1');
            q4.AddCommand('b', TuringMachine.MoveAction.Stay, true, null,'1');
            turingMachine.ShowBody();

            turingMachine.StartProdram();

            turingMachine.ShowBody();
            Console.ReadKey();
        }
    }

    public class TuringMachine
    {
        public enum MoveAction
        {
            Stay,
            Right,
            Left
        }
        public bool MoveRight { get; private set; } = true;

        private int head = 0;
        private List<char> body = new List<char>();
        private List<char> alphavite = new List<char>();
        private State startState;
        public TuringMachine(string startString, int headPosition, bool moovingDirectionRight, List<char> _alphavite)
        {
            body.AddRange(startString);
            head = headPosition;
            MoveRight = moovingDirectionRight;
            alphavite = _alphavite;
        }
        public void InitializeStartState(State _startState)
        {
            startState = _startState;
        }
        public char GetAlphaviteByIndex(int index)
        {
            return alphavite[index];
        }
        public void MoveHead(MoveAction action)
        {
            switch (action)
            {
                case MoveAction.Stay:
                    break;
                case MoveAction.Right:
                    head++;
                    if (head == body.Count)
                    {
                        body.Add(alphavite[0]);
                    }
                    break;
                case MoveAction.Left:
                    head--;
                    if (head == -1)
                    {
                        PasteFirst(alphavite[0]);
                        head = 0;
                    }
                    break;
                default:
                    break;
            }
        }        
        public void StartProdram()
        {
            bool endOfProgramm = false;
            int returnCode;
            State currentState = startState;

            while (!endOfProgramm)
            { 
                if (currentState == null)
                {
                    Console.WriteLine("currentState is null");
                    return;
                }
                returnCode = currentState.ExecuteState(GetCellValue());
                if (returnCode == 1)
                {
                    endOfProgramm = true;
                    Console.WriteLine("End of program!");
                }
                else
                {
                    currentState = currentState.NextState;
                }
            }

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
        public void PasteFirst(char value)
        {
            body.Add(' ');

            char temp;

            for (int i = body.Count - 1; i > 0; i--)
            {
                temp = body[i - 1];
                body[i] = temp;
            }
            body[0] = value;
        }
        public void PasteCharLast(char value)
        {
            body.Add(value);
        }
        private string GetBody()
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
        public char GetCellValue() 
        {
            return body[head];
        }
    }
    public class State
    {
        public List<Command> commands = new List<Command>();
        public TuringMachine TuringMachine { get; private set; }
        public State NextState { get; private set; }
        public State(TuringMachine turingMachine)
        {
            TuringMachine = turingMachine;
        }
        public void AddCommand(char symbol, TuringMachine.MoveAction moveAction = TuringMachine.MoveAction.Stay, bool endOfStates = false, State nextState = null, char writeSymbol = '_')
        {
            commands.Add(new Command(symbol, moveAction, endOfStates, nextState, writeSymbol));
        }
        public int ExecuteState(char input)
        {
            int returnCode = 1;
            for (int i = 0; i < commands.Count; i++)
            {
                if (input == commands[i].Symbol)
                {
                    NextState = commands[i].NextState;
                    returnCode = commands[i].ExecuteCommand(TuringMachine);
                    break;
                }
            }
            return returnCode;
        }
        public class Command
        {
            public char Symbol { get; private set; }
            public bool EndOfStates { get; private set; }
            public State NextState { get; private set; }
            public char WriteSymbol { get; private set; }
            public TuringMachine.MoveAction MoveAction { get; private set; }

            public Command(char symbol, TuringMachine.MoveAction moveAction = TuringMachine.MoveAction.Stay, bool endOfStates = false, State nextState = null, char writeSymbol = '_')
            {
                Symbol = symbol;
                WriteSymbol = writeSymbol;
                MoveAction = moveAction;
                NextState = nextState;
                EndOfStates = endOfStates;
            }
            public int ExecuteCommand(TuringMachine turingMachine)
            {

                if (WriteSymbol != '_')
                {
                    turingMachine.PasteChar(WriteSymbol);
                }
                turingMachine.MoveHead(MoveAction);


                if (EndOfStates)
                {
                    return 1;
                }
                return 0;
            }
        }
    }
}
