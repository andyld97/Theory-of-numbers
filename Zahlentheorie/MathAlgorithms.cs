using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahlentheorie
{
    public static class MathAlgorithms
    {
        public static bool IsPrimeNumber(int number)
        {
            if (number >= 2)
            {
                int a = 0;
                for (int i = 1; i <= number; i++)
                {
                    if (number % i == 0)
                        a++;
                }

                return (a == 2);
            }
            return false;
        }

        public static int GGT(int a, int b)
        {
            int a1 = a;
            int b1 = b;

            while (true)
            {
                if (a1 == b1)
                    return a1;
                else if (a1 == 0)
                    return b1;
                else if (b1 == 0)
                    return a1;

                if (a1 < b1)
                    b1 -= a1;
                else
                    a1 -= b1;
            }
        }

        public static int KGV(int a, int b)
        {
            int a1 = a;
            int b1 = b;
            int counter = 1;

            while (counter % a1 != 0 || counter % b1 != 0)
                counter++;

            return counter;
        }

        public static Result CalculateExtendedAlgo(int a, int b)
        {
            List<int> xLst = new List<int>();
            List<int> yLst = new List<int>();
            List<int> qLst = new List<int>();
            List<int> rLst = new List<int>();

            int a1 = a, b1 = b;
            int r = -1, q = 0;

            int swap = 0;
            if (b1 > a1)
            {
                swap = b1;
                b1 = a1;
                a1 = swap;
            }

            while (r != 0)
            {
                r = a1 % b1;
                q = a1 / b1;

                xLst.Add(a1); yLst.Add(b1); qLst.Add(q); rLst.Add(r);

                a1 = b1;
                b1 = r;
            }

            int[] aNum = new int[xLst.Count()];
            int[] bNum = new int[yLst.Count()];

            for (int i = xLst.Count - 1; i >= 0; i--)
            {
                if (i == xLst.Count - 1)
                {
                    aNum[i] = 0;
                    bNum[i] = 1;
                }
                else
                    bNum[i] = aNum[i + 1] - qLst[i] * bNum[i + 1];

                if (i != 0)
                    aNum[i - 1] = bNum[i];
            }
            return new Result(b > a ? b : a, b < a ? b : a, aNum[0], bNum[0], xLst, yLst, qLst, rLst, aNum.ToList<int>(), bNum.ToList<int>());
        }

        public static int CalculatePhi(int p)
        {
            if (p == 1)
                return 1;

            if (IsPrimeNumber(p)) // If p is a prime number, phi(p) = p - 1
                return p - 1;

            List<Prime> pfz = CalculatePrimeFactorization(p);

            int r = pfz.Count();

            double e = p;
            for (int i = 0; i <= r - 1; i++)
                e *= (1.0 - 1.0 / pfz[i].Number);

            return int.Parse(e.ToString());
        }

        public static List<Prime> CalculatePrimeFactorization(int number)
        {
            if (number == 0)
                return new List<Prime>();
            if (number == 1)
                return new List<Prime>() { new Prime(1, 1) };

            List<Prime> resultLst = new List<Prime>();

            // Divide number through first prime number till it's isn't possible
            // If number is finally a prime number, we can exit
            Prime currentPrime = new Prime();
            int currentNumber = number;
            int currentP = 2;
            bool isAdded = false;
            bool addedFirst = false;
            bool noLoop = true;

            while (!IsPrimeNumber(currentNumber))
            {
                noLoop = false;
                if (currentNumber % currentP == 0)
                {
                    currentNumber /= currentP;
                    currentPrime.Virility++;
                    isAdded = false;
                    addedFirst = true;
                }
                else
                {
                    if (addedFirst)
                    {
                        isAdded = true;
                        addedFirst = false;
                        currentPrime.Number = currentP;
                        resultLst.Add(currentPrime);
                        currentPrime = new Prime();
                    }
                    currentP = calculateNextPrimeNumber(currentP);
                }
            }

            if (noLoop) // Primenumber
            {
                currentP = currentNumber;
                currentPrime.Virility = 1;
            }
            if (!isAdded)
            {
                currentPrime.Number = currentP;
                resultLst.Add(currentPrime);
            }

            if (resultLst.Count() == 0)
                resultLst.Add(new Prime(number, 1));
            else if (currentNumber > 0 && !noLoop)
            {
                bool found = false;
                for (int i = 0; i <= resultLst.Count - 1; i++)
                {
                    if (resultLst[i].Number == currentNumber)
                    {
                        resultLst[i].Virility++;
                        found = true;
                        break;
                    }
                }
                if (!found)
                    resultLst.Add(new Prime(currentNumber, 1));
            }
            return resultLst;
        }

        private static int calculateNextPrimeNumber(int number)
        {
            int temp = ++number;

            while (!IsPrimeNumber(temp))
                temp++;

            return temp;
        }

        public static List<int> CalculateDivisors(int number)
        {
            List<int> result = new List<int>();
            result.Add(1);
            result.Add(number);

            if (IsPrimeNumber(number))
                return result;

            for (int i = 2; i <= number - 1; i++)
            {
                if (number % i == 0)
                    result.Add(number);
            }

            return result;
        }
    }
}
