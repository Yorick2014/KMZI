using System;
using System.Numerics;

namespace Affine_ciphers
{
    class RSA
    {
        public static void MainRSA()
        {
            Console.WriteLine("Введите 'p'");
            long p = Convert.ToInt64(Console.ReadLine()); //7451

            Console.WriteLine("Введите 'q'");
            long q = Convert.ToInt64(Console.ReadLine()); //2003

            Console.WriteLine("Введите 'e'");
            long e = Convert.ToInt64(Console.ReadLine()); //9973

            Console.WriteLine("Введите сообщение 1 (число)");
            long x1 = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Введите сообщение 2 (число)");
            long x2 = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Введите сообщение 3 (число)");
            long x3 = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine();

            long n = p * q;
            BigInteger fi = BigInteger.Multiply(p - 1, q - 1);
            BigInteger d = Invmod(e, fi);

            Dec(Enc(x1, n, e), n, d);
            Dec(Enc(x2, n, e), n, d);
            Dec(Enc(x3, n, e), n, d);

            Console.ReadKey();
        }

        static long Enc(long x, long n, BigInteger e)
        {
            long E = HugeNumber(x, e, n);
            Console.WriteLine("\nЗашифрованное сообщение " + E);
            return E;
        }

        static long Dec(long y, long n, BigInteger d)
        {
            long D = HugeNumber(y, d, n);
            Console.WriteLine("\nРасшифрованное сообщение " + D);
            return D;
        }

        public static BigInteger Invmod(BigInteger nub, BigInteger fi)
        {
            while (nub < 0)
            {
                nub = nub + fi;
            }

            for (BigInteger i = 0; i < fi; i++)
            {
                if (nub * i % fi == 1)
                {
                    nub = i;
                    break;
                }
            }
            return (nub);
        }

        /// <summary>
        /// (a^b) mod c
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        static long HugeNumber(long a, BigInteger b, long c)
        {
            long flag = 0;

            while (b > 0)
            {
                if (b % 2 == 0)
                {
                    b = b / 2;
                    a = Convert.ToInt64(Math.Pow(a, 2)) % c;
                }
                else
                {
                    if (flag == 0)
                    {
                        b = b - 1;
                        flag = a;
                    }
                    else
                    {
                        b = b - 1;
                        flag = (flag * a) % c;
                    }
                }
            }
            return flag;

        }
    }
}
