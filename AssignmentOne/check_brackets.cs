using System;

namespace AssignmentOne
{
    internal class Bracket {
        private readonly char _type;
        public int Position { get; }

        public Bracket(char type, int position) {
            _type = type;
            Position = position;
        }

        public bool Match(char c) {
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
            var source = args[0];
            if(string.IsNullOrEmpty(source))
            {
                return Success;
            }
            var stack = new DsStack<Bracket>();
            for (var i = 0; i < source.Length; i++)
            {
                var c = source[i];
                if (IsOpenBracket(c))
                {
                    stack.Push(new Bracket(c, i));
                    continue;
                }
                if (!IsCloseBracket(c))
                {
                    continue;
                }
                if (stack.IsEmpty || !stack.Pop().Match(c))
                {
                    return ResolveErrorPosition(i);
                }
            }
            if (!stack.IsEmpty)
            {
                return ResolveErrorPosition(stack.Top().Position);
            }
            return Success;
        }

        private static string ResolveErrorPosition(int position)
        {
            return (position + 1).ToString();
        }

        private static bool IsOpenBracket(char c)
        {
            return c == '[' || c == '{' || c == '(';
        }
        
        private static bool IsCloseBracket(char c)
        {
            return c == ']' || c == '}' || c == ')';
        }
    }
        
    public class DsStack<T>
    {
        private uint _count = 0;
        private readonly DsLinkedList<T> _state = new DsLinkedList<T>();
        
        public void Push(T key)
        {
            _state.PushFront(key);
            _count += 1;
        }

        public T Top()
        {
            return _state.TopFront();
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                return default(T);
            }
            _count -= 1;
            return _state.PopFront();
        }
        
        public bool IsEmpty => _count == 0;
    }
    
    public class DsLinkedListNode<T>
    {
        public T Key;
        public DsLinkedListNode<T> Next;
        public DsLinkedListNode<T> Prev;
    }

    public class DsLinkedList<T>
    {
        private DsLinkedListNode<T> _head;
        private DsLinkedListNode<T> _tail;

        public void PushFront(T key)
        {
            var node = new DsLinkedListNode<T> {Key = key};
            node.Next = _head;
            _head = node;
            if (_tail == null)
            {
                _tail = _head;
            }
        }

        public T TopFront()
        {
            if (_head == null)
            {
                throw new InvalidOperationException();
            }
            return _head.Key;
        }

        public T PopFront()
        {
            if (_head == null)
            {
                throw new InvalidOperationException();
            }
            var node = _head;
            _head = _head.Next;
            if (_head == null)
            {
                _tail = null;
            }
            else
            {
                _head.Prev = null;
            }
            return node.Key;
        }

        public void PushBack(T key)
        {
            var node = new DsLinkedListNode<T>
            {
                Key = key,
                Prev = _tail
            };
            _tail = node;
            if (_head == null)
            {
                _head = _tail;
            }
        }

        public T TopBack()
        {
            if (_tail == null)
            {
                throw new InvalidOperationException();
            }
            return _tail.Key;
        }

        public T PopBack()
        {
            if (_tail == null)
            {
                throw new InvalidOperationException();
            }
            var node = _tail;
            _tail = _tail.Prev;
            if (_tail == null)
            {
                _head = null;
            }
            else
            {
                _tail.Prev = null;
            }
            return node.Key;
        }
    }
}