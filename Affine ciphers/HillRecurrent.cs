using System;


namespace Affine_ciphers
{
    class HillRecurrent
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

            Console.WriteLine("Введите ключевое слово 1: ");
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

            Console.WriteLine("Введите ключевое слово 2: ");
            string keyWord2 = Console.ReadLine();

            int[] arrKeyWord12 = new int[3];
            int[] arrKeyWord22 = new int[3];
            int[] arrKeyWord32 = new int[3];

            int nub22 = 3;
            int nub32 = 6;
            for (int i = 0; i < 3; i++)
            {
                arrKeyWord12[i] = Alphabet.Keycode(keyWord2[i]);
                arrKeyWord22[i] = Alphabet.Keycode(keyWord2[nub22]);
                arrKeyWord32[i] = Alphabet.Keycode(keyWord2[nub32]);
                nub22++;
                nub32++;
            }


            if (x == 7)
            {
                SwitchEncryption(message,arrKeyWord1, arrKeyWord2, arrKeyWord3, arrKeyWord12, arrKeyWord22, arrKeyWord32);
            }
            if (x == 8)
            {
                SwitchDecryption(message, arrKeyWord1, arrKeyWord2, arrKeyWord3, arrKeyWord12, arrKeyWord22, arrKeyWord32);
            }

            Console.WriteLine();
        }

        static void SwitchEncryption(int[] text, int[] arrKeyWord1, int[] arrKeyWord2, int[] arrKeyWord3, int[] arrKeyWord12, int[] arrKeyWord22, int[] arrKeyWord32)
        {
            int[] arrKeyWordC1 = new int[3];
            int[] arrKeyWordC2 = new int[3];
            int[] arrKeyWordC3 = new int[3];

            Console.WriteLine("\nЗашифрованное сообщение:");

            for (int i = 0; i < text.Length; i += 3)
            {
                if (i == 0)
                {
                    Encryption(text, arrKeyWord1, arrKeyWord2, arrKeyWord3, i);
                    //Console.Write(Alphabet.ArrAlphabet[((text[i] * arrKeyWord1[0]) + (text[i + 1] * arrKeyWord2[0]) + (text[i + 2] * arrKeyWord3[0])) % Alphabet.ArrAlphabet.Length]);
                    //Console.Write(Alphabet.ArrAlphabet[((text[i] * arrKeyWord1[1]) + (text[i + 1] * arrKeyWord2[1]) + (text[i + 2] * arrKeyWord3[1])) % Alphabet.ArrAlphabet.Length]);
                    //Console.Write(Alphabet.ArrAlphabet[((text[i] * arrKeyWord1[2]) + (text[i + 1] * arrKeyWord2[2]) + (text[i + 2] * arrKeyWord3[2])) % Alphabet.ArrAlphabet.Length]);
                }

                if (i == 3)
                {
                    Encryption(text, arrKeyWord12, arrKeyWord22, arrKeyWord32, i);
/*
                    Console.Write(Alphabet.ArrAlphabet[((text[i] * arrKeyWord12[0]) + (text[i + 1] * arrKeyWord22[0]) + (text[i + 2] * arrKeyWord32[0])) % Alphabet.ArrAlphabet.Length]);
                    Console.Write(Alphabet.ArrAlphabet[((text[i] * arrKeyWord12[1]) + (text[i + 1] * arrKeyWord22[1]) + (text[i + 2] * arrKeyWord32[1])) % Alphabet.ArrAlphabet.Length]);
                    Console.Write(Alphabet.ArrAlphabet[((text[i] * arrKeyWord12[2]) + (text[i + 1] * arrKeyWord22[2]) + (text[i + 2] * arrKeyWord32[2])) % Alphabet.ArrAlphabet.Length]);
*/
                }

                if (i >= 6)
                {

                    for (int k = 0; k < 3; k++)
                    {
                        arrKeyWordC1[k] = (arrKeyWord1[0] * arrKeyWord12[k] + arrKeyWord1[1] * arrKeyWord22[k] + arrKeyWord1[2] * arrKeyWord32[k]) % Alphabet.ArrAlphabet.Length;
                        arrKeyWordC2[k] = (arrKeyWord2[0] * arrKeyWord12[k] + arrKeyWord2[1] * arrKeyWord22[k] + arrKeyWord2[2] * arrKeyWord32[k]) % Alphabet.ArrAlphabet.Length;
                        arrKeyWordC3[k] = (arrKeyWord3[0] * arrKeyWord12[k] + arrKeyWord3[1] * arrKeyWord22[k] + arrKeyWord3[2] * arrKeyWord32[k]) % Alphabet.ArrAlphabet.Length;
                    }

                    Encryption(text, arrKeyWordC1, arrKeyWordC2, arrKeyWordC3, i);

                    /*
                                        Console.Write(Alphabet.ArrAlphabet[((text[i] * arrKeyWordC1[0]) + (text[i + 1] * arrKeyWordC2[0]) + (text[i + 2] * arrKeyWordC3[0])) % Alphabet.ArrAlphabet.Length]);
                                        Console.Write(Alphabet.ArrAlphabet[((text[i] * arrKeyWordC1[1]) + (text[i + 1] * arrKeyWordC2[1]) + (text[i + 2] * arrKeyWordC3[1])) % Alphabet.ArrAlphabet.Length]);
                                        Console.Write(Alphabet.ArrAlphabet[((text[i] * arrKeyWordC1[2]) + (text[i + 1] * arrKeyWordC2[2]) + (text[i + 2] * arrKeyWordC3[2])) % Alphabet.ArrAlphabet.Length]);
                    */

                    arrKeyWord1 = arrKeyWord12;
                    arrKeyWord2 = arrKeyWord22;
                    arrKeyWord3 = arrKeyWord32;

                    arrKeyWord12 = arrKeyWordC1;
                    arrKeyWord22 = arrKeyWordC2;
                    arrKeyWord32 = arrKeyWordC3;

                }
            }
        }
        static void Encryption(int[] text, int[] arrKeyWord1, int[] arrKeyWord2, int[] arrKeyWord3, int i)
        {
            Console.Write(Alphabet.ArrAlphabet[((text[i] * arrKeyWord1[0]) + (text[i + 1] * arrKeyWord2[0]) + (text[i + 2] * arrKeyWord3[0])) % Alphabet.ArrAlphabet.Length]);
            Console.Write(Alphabet.ArrAlphabet[((text[i] * arrKeyWord1[1]) + (text[i + 1] * arrKeyWord2[1]) + (text[i + 2] * arrKeyWord3[1])) % Alphabet.ArrAlphabet.Length]);
            Console.Write(Alphabet.ArrAlphabet[((text[i] * arrKeyWord1[2]) + (text[i + 1] * arrKeyWord2[2]) + (text[i + 2] * arrKeyWord3[2])) % Alphabet.ArrAlphabet.Length]);
        }

        static void SwitchDecryption(int[] text, int[] arrKeyWord1, int[] arrKeyWord2, int[] arrKeyWord3, int[] arrKeyWord12, int[] arrKeyWord22, int[] arrKeyWord32)
        {
            int[] arrKeyWordC1 = new int[3];
            int[] arrKeyWordC2 = new int[3];
            int[] arrKeyWordC3 = new int[3];

            Console.WriteLine("\nРасшифрованное сообщение:");

            for (int i = 0; i < text.Length; i += 3)
            {
                if (i == 0)
                {
                    Decryption(text, arrKeyWord1, arrKeyWord2, arrKeyWord3, i);
                }

                if (i == 3)
                {
                    Decryption(text, arrKeyWord12, arrKeyWord22, arrKeyWord32, i);
                }

                if (i >= 6)
                {

                    for (int k = 0; k < 3; k++)
                    {
                        arrKeyWordC1[k] = (arrKeyWord1[0] * arrKeyWord12[k] + arrKeyWord1[1] * arrKeyWord22[k] + arrKeyWord1[2] * arrKeyWord32[k]) % Alphabet.ArrAlphabet.Length;
                        arrKeyWordC2[k] = (arrKeyWord2[0] * arrKeyWord12[k] + arrKeyWord2[1] * arrKeyWord22[k] + arrKeyWord2[2] * arrKeyWord32[k]) % Alphabet.ArrAlphabet.Length;
                        arrKeyWordC3[k] = (arrKeyWord3[0] * arrKeyWord12[k] + arrKeyWord3[1] * arrKeyWord22[k] + arrKeyWord3[2] * arrKeyWord32[k]) % Alphabet.ArrAlphabet.Length;
                    }

                    Decryption(text, arrKeyWordC1, arrKeyWordC2, arrKeyWordC3, i);

                    arrKeyWord1 = arrKeyWord12;
                    arrKeyWord2 = arrKeyWord22;
                    arrKeyWord3 = arrKeyWord32;

                    arrKeyWord12 = arrKeyWordC1;
                    arrKeyWord22 = arrKeyWordC2;
                    arrKeyWord32 = arrKeyWordC3;

                }
            }
        }

        static void Decryption(int[] text, int[] arrKeyWord1, int[] arrKeyWord2, int[] arrKeyWord3, int i)
        {
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


            Console.Write(Alphabet.ArrAlphabet[((text[i] * inverseMatrix1[0]) + (text[i + 1] * inverseMatrix2[0]) + (text[i + 2] * inverseMatrix3[0])) % Alphabet.ArrAlphabet.Length]);
            Console.Write(Alphabet.ArrAlphabet[((text[i] * inverseMatrix1[1]) + (text[i + 1] * inverseMatrix2[1]) + (text[i + 2] * inverseMatrix3[1])) % Alphabet.ArrAlphabet.Length]);
            Console.Write(Alphabet.ArrAlphabet[((text[i] * inverseMatrix1[2]) + (text[i + 1] * inverseMatrix2[2]) + (text[i + 2] * inverseMatrix3[2])) % Alphabet.ArrAlphabet.Length]);
        }

        static int AlgebraicAdditions(int detKey, int a1, int b1, int KW11, int KW12, int KW21, int KW22)
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

/*        static void Multip(int[] arrKeyWord1, int[] arrKeyWord2, int[] arrKeyWord3, int[] arrKeyWord12, int[] arrKeyWord22, int[] arrKeyWord32)
        {
            int[] arrKeyWordC1 = new int[3];
            int[] arrKeyWordC2 = new int[3];
            int[] arrKeyWordC3 = new int[3];

            for (int i = 0; i < 3; i++)
            {
                arrKeyWordC1[i] = (arrKeyWord1[0] * arrKeyWord12[i] + arrKeyWord1[1] * arrKeyWord22[i] + arrKeyWord1[2] * arrKeyWord32[i]) % Alphabet.ArrAlphabet.Length;
                arrKeyWordC2[i] = (arrKeyWord2[0] * arrKeyWord12[i] + arrKeyWord2[1] * arrKeyWord22[i] + arrKeyWord2[2] * arrKeyWord32[i]) % Alphabet.ArrAlphabet.Length;
                arrKeyWordC3[i] = (arrKeyWord3[0] * arrKeyWord12[i] + arrKeyWord3[1] * arrKeyWord22[i] + arrKeyWord3[2] * arrKeyWord32[i]) % Alphabet.ArrAlphabet.Length;
            }
        }*/

    }
}
