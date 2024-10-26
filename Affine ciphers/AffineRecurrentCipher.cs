using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affine_ciphers
{
    class AffineRecurrentCipher
    {
        public static void Code(string txt, int x)
        {

            int keyA1 = 0, keyA2 = 0;

            bool a = true;
            while (a)
            {
                Console.Write("Введите ключ 'a1': ");

                keyA1 = Convert.ToInt32(Console.ReadLine());
                if (keyA1 < 0 || keyA1 > Alphabet.ArrAlphabet.Length)
                {
                    keyA1 = keyA1 % Alphabet.ArrAlphabet.Length;
                }
                for (int i = 0; i < Alphabet.ArrAlphabet.Length; i++)
                {
                    if (keyA1 * i % Alphabet.ArrAlphabet.Length == 1)
                    {
                        a = false;
                        break;
                    }
                }
                if (a == true) Console.WriteLine("no inversion input, try another key");
            }

            Console.Write("Введите ключ 'b1': ");
            int keyB1 = Convert.ToInt32(Console.ReadLine());

            if (keyB1 < 0)
            {
                keyB1 = keyB1 % Alphabet.ArrAlphabet.Length;
            }

            bool b = true;
            while (b)
            {
                Console.Write("Введите ключ 'a2': ");

                keyA2 = Convert.ToInt32(Console.ReadLine());
                if (keyA2 < 0 || keyA2 > Alphabet.ArrAlphabet.Length)
                {
                    keyA2 = keyA2 % Alphabet.ArrAlphabet.Length;
                }
                for (int i = 0; i < Alphabet.ArrAlphabet.Length; i++)
                {
                    if (keyA2 * i % Alphabet.ArrAlphabet.Length == 1)
                    {
                        b = false;
                        break;
                    }
                }
                if (b == true) Console.WriteLine("no inversion input, try another key");
            }

            Console.Write("Введите ключ 'b2': ");
            int keyB2 = Convert.ToInt32(Console.ReadLine());

            if (keyB2 < 0)
            {
                keyB2 = keyB2 % Alphabet.ArrAlphabet.Length;
            }

            int[] keysA = new int[txt.Length];
            keysA[0] = keyA1;
            keysA[1] = keyA2;

            for (int i = 2; i < txt.Length; i++)
            {
                keysA[i] = (keysA[i-1] * keysA[i-2]) % Alphabet.ArrAlphabet.Length;
            }

            int[] keysB = new int[txt.Length];
            keysB[0] = keyB1;
            keysB[1] = keyB2;

            for (int i = 2; i < txt.Length; i++)
            {
                keysB[i] = (keysB[i - 1] + keysB[i - 2]) % Alphabet.ArrAlphabet.Length;
            }

            int[] keysInvA = new int[txt.Length];
            for (int i = 0; i < txt.Length; i++)
            {
                keysInvA[i] = Invmod(keysA[i]);
            }


            if (x == 3)
                Encode(txt, keysA, keysB);

            if (x == 4)
                Decode(txt, keysInvA, keysB);

        }


        public static int Invmod(int a)
        {
            int invKeyA = 0;

            for (int i = 0; i < Alphabet.ArrAlphabet.Length; i++)
            {
                if (a * i % Alphabet.ArrAlphabet.Length == 1)
                {
                    invKeyA = i;
                    break;
                }
            }
            return (invKeyA);
        }

        static void Encode(string txt, int[] keysA, int[] keysB)
        {
            Console.WriteLine("\nЗашифрованное сообщение:");
            for (int i = 0; i < txt.Length; i++)
            {
                Console.Write(Alphabet.ArrAlphabet[((Alphabet.Keycode(txt[i])) * keysA[i] + keysB[i]) % Alphabet.ArrAlphabet.Length]);
            }
            Console.WriteLine("\n");
        }

        static void Decode(string txt, int[]keysInvA, int[] keysB)
        {
            Console.WriteLine("\nРасшифрованное сообщение:");
            for (int i = 0; i < txt.Length; i++)
            {

                Console.Write(Alphabet.ArrAlphabet[((Alphabet.Keycode(txt[i]) - keysB[i] + Alphabet.ArrAlphabet.Length) * keysInvA[i]) % Alphabet.ArrAlphabet.Length]);
            }
            Console.WriteLine("\n");
        }
    }
}
