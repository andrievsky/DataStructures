namespace Assignments.Exercises
{
    public class StringPermutation
    {
        public void Permutation(string source, string prefix)
        {
            if (source.Length == 0)
            {
                //Console.WriteLine(prefix);
                return;
            }
            for (int i = 0; i < source.Length; i++)
            {
                string rem = source.Substring(0, i) + source.Substring(i + 1);
                Permutation(rem, prefix + source[i]);
            }
        }
    }
}