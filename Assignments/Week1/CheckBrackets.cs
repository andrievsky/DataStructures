using System;
using Assignments.Common;

namespace Assignments.Week1
{
    internal class Bracket
    {
        private readonly char _type;
        public int Position { get; }

        public Bracket(char type, int position)
        {
            _type = type;
            Position = position;
        }

        public bool Match(char c)
        {
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

    /// <summary>
    /// Task. Your friend is making a text editor for programmers. He is currently working on a feature that will
    /// find errors in the usage of different types of brackets. Code can contain any brackets from the set
    /// []{}(), where the opening brackets are [,{, and ( and the closing brackets corresponding to them
    /// are ],}, and ).
    /// For convenience, the text editor should not only inform the user that there is an error in the usage
    /// of brackets, but also point to the exact place in the code with the problematic bracket. First priority
    /// is to find the first unmatched closing bracket which either doesn’t have an opening bracket before it,
    /// like ] in ](), or closes the wrong opening bracket, like } in ()[}. If there are no such mistakes, then
    /// it should find the first unmatched opening bracket without the corresponding closing bracket after it,
    /// like ( in {}([]. If there are no mistakes, text editor should inform the user that the usage of brackets
    /// is correct.
    /// Apart from the brackets, code can contain big and small latin letters, digits and punctuation marks.
    /// More formally, all brackets in the code should be divided into pairs of matching brackets, such that in
    /// each pair the opening bracket goes before the closing bracket, and for any two pairs of brackets either
    /// one of them is nested inside another one as in (foo[bar]) or they are separate as in f(a,b)-g[c].
    /// The bracket [ corresponds to the bracket ], { corresponds to }, and ( corresponds to ).
    /// Input Format. Input contains one string 𝑆 which consists of big and small latin letters, digits, punctuation
    /// marks and brackets from the set []{}().
    /// 
    /// Constraints. 
    /// The length of 𝑆 is at least 1 and at most 10^5.
    /// 
    /// Output Format. 
    /// If the code in 𝑆 uses brackets correctly, output “Success" (without the quotes). Otherwise,
    /// output the 1-based index of the first unmatched closing bracket, and if there are no unmatched closing
    /// brackets, output the 1-based index of the first unmatched opening bracket.
    /// </summary>
    public class CheckBrackets : IAssignment
    {
        private const string Success = "Success";

        public string Execute(string[] args)
        {
            var source = args[0];
            if (string.IsNullOrEmpty(source))
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

        private string ResolveErrorPosition(int position)
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