using System.Numerics;

class Program
{
    internal class FibonacciSequence
    {
        //последовательность Фибоначчи
        private List<BigInteger> fibSeq;
        /// конструктор объявляет пустую последовательность
        public FibonacciSequence() { fibSeq = new List<BigInteger>(); }
        /// <summary>
        /// Метод создания последовательности Фибоначчи
        /// </summary>
        /// <param name="n">количество чисел (n+1) в последовательности, 
        /// где n = 0 соответствует единственному числу - единице [ 1 ] </param>
        /// <returns>последовательность Фибоначчи из кол-ва элементов n</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        public List<BigInteger> CreateFibSeq(int n)
        {
            //новая последовательность с единственным значением
            fibSeq = new List<BigInteger>() { 1 };
            //если количество элементов отрицательное
            if (n < 0) throw new ArgumentOutOfRangeException("n must be greater than zero");
            //если в последовательности один элемент
            else if (n == 0) return fibSeq;
            else
            {
                fibSeq.Add(1);                                  //второй элемент последовательности 0 + 1 = 1
                for (var i = 2; i < n + 1; i++)                 //заполнение последовательности
                {
                    fibSeq.Add(fibSeq[i - 1] + fibSeq[i - 2]);
                }
                return fibSeq;
            }
        }
        /// <summary>
        /// Метод расчета суммы всех чисел в последовательности Фибоначчи
        /// </summary>
        /// <returns>сумма числовой последовательности Фибоначчи</returns>
        public BigInteger FibSeqSum()
        {
            BigInteger result = fibSeq.Aggregate(BigInteger.Zero, (acc, num) => acc += num);
            return result;
        }
        /// <summary>
        /// Метод расчета факториала последовательности Фибоначчи
        /// </summary>
        /// <returns>факториал числовой последовательности Фибоначчи</returns>
        public BigInteger FibSeqFact()
        {
            if (!fibSeq.Any()) return BigInteger.Zero;
            BigInteger result = fibSeq.Aggregate(BigInteger.One, (acc, num) => acc * num);
            return result;
        }
        /// <summary>
        /// вывод последовательности, ее суммы и факториала  в консоль
        /// </summary>
        public void PrintFibSeqAndSum()
        {
            Console.Write("Sequence: ");
            foreach (var fib in fibSeq) { Console.Write($"{fib} "); }
            Console.WriteLine($"\nSum: {FibSeqSum()}\nMul: {FibSeqFact()}\n");
        }
    }
    static void Main()
    {
        FibonacciSequence fib = new FibonacciSequence();

        fib.CreateFibSeq(0);
        fib.PrintFibSeqAndSum();

        fib.CreateFibSeq(1);
        fib.PrintFibSeqAndSum();

        fib.CreateFibSeq(2);
        fib.PrintFibSeqAndSum();

        fib.CreateFibSeq(10);
        fib.PrintFibSeqAndSum();

        fib.CreateFibSeq(20);
        fib.PrintFibSeqAndSum();

        fib.CreateFibSeq(100);
        fib.PrintFibSeqAndSum();
    }
}

