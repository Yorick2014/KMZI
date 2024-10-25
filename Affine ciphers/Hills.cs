using System;


namespace Affine_ciphers
{
    class Hills
    {
        public static void MainHill(string text, int x)
        {

            text = text.ToLower();

            int m = text.Length;
            m = m % 3;
            if (m == 1)
            {
                text = text + " " + " ";
            }
            else if (m == 2)
            {
                text = text + " ";
            }

            int[] message = new int[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                message[i] = Alphabet.Keycode(text[i]);
            }

            Console.WriteLine("Введите ключевое слово: ");
            string keyWord = Console.ReadLine();

            int[] arrKeyWord1 = new int[3];
            int[] arrKeyWord2 = new int[3];
            int[] arrKeyWord3 = new int[3];

            int nub2 = 3;
            int nub3 = 6;
            for (int i = 0; i < 3; i++)
            {
                arrKeyWord1[i] = Alphabet.Keycode(keyWord[i]);
                arrKeyWord2[i] = Alphabet.Keycode(keyWord[nub2]);
                arrKeyWord3[i] = Alphabet.Keycode(keyWord[nub3]);
                nub2++;
                nub3++;
            }

/*            Console.WriteLine(arrKeyWord1[0] + "\t" + arrKeyWord1[1] + "\t" + arrKeyWord1[2]);
            Console.WriteLine(arrKeyWord2[0] + "\t" + arrKeyWord2[1] + "\t" + arrKeyWord2[2]);
            Console.WriteLine(arrKeyWord3[0] + "\t" + arrKeyWord3[1] + "\t" + arrKeyWord3[2]);*/

            if (x == 5)
            {
                Encryption(message, arrKeyWord1, arrKeyWord2, arrKeyWord3);
            }
            if (x == 6)
            {
                Decryption(message, arrKeyWord1, arrKeyWord2, arrKeyWord3);
            }
            Console.WriteLine();
        }

        static void Encryption(int[] text, int[] arrKeyWord1, int[] arrKeyWord2, int[] arrKeyWord3)
        {
            Console.WriteLine("\nЗашифрованное сообщение:");

            for (int i = 0; i < text.Length; i += 3)
            {
                Console.Write(Alphabet.ArrAlphabet[((text[i] * arrKeyWord1[0]) + (text[i + 1] * arrKeyWord2[0]) + (text[i + 2] * arrKeyWord3[0])) % Alphabet.ArrAlphabet.Length]);
                Console.Write(Alphabet.ArrAlphabet[((text[i] * arrKeyWord1[1]) + (text[i + 1] * arrKeyWord2[1]) + (text[i + 2] * arrKeyWord3[1])) % Alphabet.ArrAlphabet.Length]);
                Console.Write(Alphabet.ArrAlphabet[((text[i] * arrKeyWord1[2]) + (text[i + 1] * arrKeyWord2[2]) + (text[i + 2] * arrKeyWord3[2])) % Alphabet.ArrAlphabet.Length]);
/*
                Console.WriteLine((text[i] * arrKeyWord1[0]) + (text[i + 1] * arrKeyWord2[0]) + (text[i + 2] * arrKeyWord3[0]));
                Console.WriteLine((text[i] * arrKeyWord1[1]) + (text[i + 1] * arrKeyWord2[1]) + (text[i + 2] * arrKeyWord3[1]));
                Console.WriteLine((text[i] * arrKeyWord1[2]) + (text[i + 2] * arrKeyWord2[2]) + (text[i + 2] * arrKeyWord3[2]));
*/
            }

        }

        static void Decryption(int[]text, int[] arrKeyWord1, int[] arrKeyWord2, int[] arrKeyWord3)
        {
            Console.WriteLine("\nРасшифрованное сообщение:");

            int detKey = arrKeyWord1[0] * arrKeyWord2[1] * arrKeyWord3[2] + arrKeyWord1[2] * arrKeyWord2[0] * arrKeyWord3[1] + arrKeyWord1[1] * arrKeyWord2[2] * arrKeyWord3[0] 
                - arrKeyWord1[2] * arrKeyWord2[1] * arrKeyWord3[0] - arrKeyWord1[1] * arrKeyWord2[0] * arrKeyWord3[2] - arrKeyWord1[0] * arrKeyWord2[2] * arrKeyWord3[1];

            detKey = Invmod(detKey);

            //Console.WriteLine("Определитель " + detKey);

            int[] inverseMatrix1 = new int[3];
            int[] inverseMatrix2 = new int[3];
            int[] inverseMatrix3 = new int[3];

            inverseMatrix1[0] = AlgebraicAdditions(detKey, 1, 1, arrKeyWord2[1], arrKeyWord2[2], arrKeyWord3[1], arrKeyWord3[2]);
            inverseMatrix2[0] = AlgebraicAdditions(detKey, 1, 2, arrKeyWord2[0], arrKeyWord2[2], arrKeyWord3[0], arrKeyWord3[2]);
            inverseMatrix3[0] = AlgebraicAdditions(detKey, 1, 3, arrKeyWord2[0], arrKeyWord2[1], arrKeyWord3[0], arrKeyWord3[1]);

            inverseMatrix1[1] = AlgebraicAdditions(detKey, 2, 1, arrKeyWord1[1], arrKeyWord1[2], arrKeyWord3[1], arrKeyWord3[2]);
            inverseMatrix2[1] = AlgebraicAdditions(detKey, 2, 2, arrKeyWord1[0], arrKeyWord1[2], arrKeyWord3[0], arrKeyWord3[2]);
            inverseMatrix3[1] = AlgebraicAdditions(detKey, 2, 3, arrKeyWord1[0], arrKeyWord1[1], arrKeyWord3[0], arrKeyWord3[1]);

            inverseMatrix1[2] = AlgebraicAdditions(detKey, 3, 1, arrKeyWord1[1], arrKeyWord1[2], arrKeyWord2[1], arrKeyWord2[2]);
            inverseMatrix2[2] = AlgebraicAdditions(detKey, 3, 2, arrKeyWord1[0], arrKeyWord1[2], arrKeyWord2[0], arrKeyWord2[2]);
            inverseMatrix3[2] = AlgebraicAdditions(detKey, 3, 3, arrKeyWord1[0], arrKeyWord1[1], arrKeyWord2[0], arrKeyWord2[1]);

            for (int i = 0; i < text.Length; i += 3)
            {

                Console.Write(Alphabet.ArrAlphabet[((text[i] * inverseMatrix1[0]) + (text[i + 1] * inverseMatrix2[0]) + (text[i + 2] * inverseMatrix3[0])) % Alphabet.ArrAlphabet.Length]);
                Console.Write(Alphabet.ArrAlphabet[((text[i] * inverseMatrix1[1]) + (text[i + 1] * inverseMatrix2[1]) + (text[i + 2] * inverseMatrix3[1])) % Alphabet.ArrAlphabet.Length]);
                Console.Write(Alphabet.ArrAlphabet[((text[i] * inverseMatrix1[2]) + (text[i + 1] * inverseMatrix2[2]) + (text[i + 2] * inverseMatrix3[2])) % Alphabet.ArrAlphabet.Length]);

                //Console.WriteLine(((text[i] * inverseMatrix1[0]) + (text[i + 1] * inverseMatrix2[0]) + (text[i + 2] * inverseMatrix3[0])) % Alphabet.ArrAlphabet.Length);
                //Console.WriteLine(((text[i] * inverseMatrix1[1]) + (text[i + 1] * inverseMatrix2[1]) + (text[i + 2] * inverseMatrix3[1])) % Alphabet.ArrAlphabet.Length);
                //Console.WriteLine(((text[i] * inverseMatrix1[2]) + (text[i + 2] * inverseMatrix2[2]) + (text[i + 2] * inverseMatrix3[2])) % Alphabet.ArrAlphabet.Length);
            }


        }

        static int AlgebraicAdditions (int detKey, int a1, int b1, int KW11, int KW12, int KW21, int KW22)
        {
            //Console.WriteLine(IntPow(-1, a1 + b1));
            int a = IntPow(-1, a1 + b1) * ((KW11 * KW22) - (KW12 * KW21));

            int b = (a * detKey) % Alphabet.ArrAlphabet.Length;

            while (b < 0)
            {
                b = b + Alphabet.ArrAlphabet.Length;
            }

            return (b);
        }

        static int IntPow(int x, int pow)
        {
            int ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }


        public static int Invmod(int nub)
        {
            while (nub < 0)
            {
                nub = nub + Alphabet.ArrAlphabet.Length;
            }

            for (int i = 0; i < Alphabet.ArrAlphabet.Length; i++)
            {
                if (nub * i % Alphabet.ArrAlphabet.Length == 1)
                {
                    nub = i;
                    break;
                }
            }
            return (nub);
        }

    }
}
