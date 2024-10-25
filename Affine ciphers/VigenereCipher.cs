using System;

namespace Affine_ciphers
{
    class VigenereCipher
    {
        public static void MainVigenere(string text, int x)
        {
            Console.WriteLine("Введите ключевое слово: ");
            string keyWord = Console.ReadLine();

            int[] arrKeyWord = new int[text.Length];

            for (int i = 0; i < text.Length;)
            {
                for (int j = 0; j < keyWord.Length; j++)
                {
                    if (i < text.Length)
                    {
                        arrKeyWord[i] = Alphabet.Keycode(keyWord[j]);
                        i++;
                    }
                    else
                        break;
                }
            }

            if (x == 9)
            {
                Encryption(text, arrKeyWord);
            }
            if (x == 10)
            {
                Decryption(text, arrKeyWord);
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        static void Encryption(string text, int[] arrKeyWord)
        {
            Console.WriteLine("\nЗашифрованное сообщение:");

            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(Alphabet.ArrAlphabet[(Alphabet.Keycode(text[i]) + arrKeyWord[i]) % Alphabet.ArrAlphabet.Length]);
            }
        }
        static void Decryption(string text, int[] arrKeyWord)
        {
            Console.WriteLine("\nРасшифрованное сообщение:");

            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(Alphabet.ArrAlphabet[(Alphabet.Keycode(text[i]) + Alphabet.ArrAlphabet.Length - arrKeyWord[i]) % Alphabet.ArrAlphabet.Length]);
            }
        }


    }
}
