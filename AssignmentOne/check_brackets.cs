using System;

namespace AssignmentOne
{
    internal class Bracket {
        private readonly char _type;
        private int _position;
        
        public Bracket(char type, int position) {
            _type = type;
            _position = position;
        }

        bool Match(char c) {
            switch (_type)
            {
                case '[' when c == ']':
                    return true;
                case '{' when c == '}':
                    return true;
                case '(' when c == ')':
                    return true;
            }
            return false;
        }
    }
    
    public class check_brackets
    {
        private const string Success = "Success";
        
        public static void Main(string[] args)
        {
            Console.WriteLine(Execute(args));
        }

        public static string Execute(string[] args)
        {
            return Success;
        }
    }
}