using System;

namespace Affine_ciphers
{
    class AffineCipher
    {
        public static void Code (string txt, int x)
        {

            int keyA = 0, invA = 0;

            bool a = true;
            while (a)
            {
                Console.Write("Введите ключ 'a': ");

                keyA = Convert.ToInt32(Console.ReadLine());
                if (keyA < 0 || keyA > Alphabet.ArrAlphabet.Length)
                {
                    keyA = keyA % Alphabet.ArrAlphabet.Length;
                }
                for (int i = 0; i < Alphabet.ArrAlphabet.Length; i++)
                {
                    if (keyA * i % Alphabet.ArrAlphabet.Length == 1)
                    {
                        invA = i;
                        a = false;
                        break;
                    }
                }
                if (a == true) Console.WriteLine("Неверно введен ключ 'a'!");
            }

            Console.Write("Введите ключ 'b': ");
            int keyB = Convert.ToInt32(Console.ReadLine());

            if (keyB < 0)
            {
                keyB = keyB % Alphabet.ArrAlphabet.Length;
            }


            if (x == 1)
                Encode(txt, keyA, keyB);

            if (x == 2)
                Decode(txt, invA, keyB);

        }

        static void Encode(string txt, int keyA, int keyB)
        {
            Console.WriteLine("\nЗашифрованное сообщение:");
            for (int i = 0; i < txt.Length; i++)
            {
                //Console.Write(Alphabet.Keycode(txt[i]));
                //Alphabet.ArrAlphabet[i] = Alphabet.ArrAlphabet[((Alphabet.Keycode(txt[i])) * keyA + keyB) % Alphabet.ArrAlphabet.Length];
                Console.Write(Alphabet.ArrAlphabet[((Alphabet.Keycode(txt[i])) * keyA + keyB) % Alphabet.ArrAlphabet.Length]);
            }
            Console.WriteLine("\n");
        }

        static void Decode(string txt, int invA, int keyB)
        {
            Console.WriteLine("\nРасшифрованное сообщение:");
            for (int i = 0; i < txt.Length; i++)
            {
                Console.Write(Alphabet.ArrAlphabet[((Alphabet.Keycode(txt[i]) - keyB + Alphabet.ArrAlphabet.Length) * invA) % Alphabet.ArrAlphabet.Length]);
            }
            Console.WriteLine("\n");
        }
    }
}
