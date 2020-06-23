using System;
using System.Diagnostics;
using System.Linq;

namespace AulaPLINQ
{
    class Program
    {
        private static void ReverseStringwithLinq()
        {
            string sentence = "the quick brown fox jumped over the lazy dog ";

            var words = sentence.Split()
                                .Select(word => new string(word.Reverse().ToArray()));

            System.Console.WriteLine(string.Join(" ", words));
        }
        private static void ReverseStringwithPLinq()
        {
            string sentence = "the quick brown fox jumped over the lazy dog ";
            Stopwatch st = new Stopwatch();
            st.Start();
            var words = sentence.Split()
                                .AsParallel() //PLINQ DECIDE QUANDO RODAR PARALELAMETE - ISSO É O PADRÃO.
                                .AsOrdered() //PLINQ NÃO ORDENA POR PADRÃO POR QUESTOES DE PERFORMANCE
                                .WithExecutionMode(ParallelExecutionMode.ForceParallelism) // FORÇANDO RODAR DE FORMA PARALELA
                                .Select(word => new string(word.Reverse().ToArray()));

            System.Console.WriteLine(string.Join(" ", words));
            st.Stop();
            Console.WriteLine($"Tempo decorrido {st.Elapsed}");

        }
        static void Main(string[] args)
        {
            ReverseStringwithPLinq();
        }
    }
}
