using System;


namespace Affine_ciphers
{
    class Program
    {
        static void Main()
        {
            while(true)
            {
                Console.WriteLine("\nВведите номер для выбора дальнейшего действия: " +
                "\n'1' зашифровать с помощью Аффинного шифра; " +
                "\n'2' расширофвать с помощью Аффинного шифра;" +
                "\n'3' зашифровать с помощью Аффинно-рекуррентного шифра;" +
                "\n'4' расширофвать с помощью Аффинно-рекуррентного шифра;" +
                "\n'5' заширофвать с помощью шифра Хилла;" +
                "\n'6' расширофвать с помощью шифра Хилла;" +
                "\n'7' заширофвать с помощью рекуррентной модификации шифра Хилла;" +
                "\n'8' расширофвать с помощью рекуррентной модификации шифра Хилла;" +
                "\n'9' заширофвать с помощью шифра Виженера;" +
                "\n'10' расширофвать с помощью шифра Виженера;" +
                "\n'11' зашифровать/расширофвать с помощью шифра RSA");
                int x = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите текст: ");
                string txt = Console.ReadLine();

                switch (x)
                {
                    case 1:
                        AffineCipher.Code(txt, x);
                        break;
                    case 2:
                        AffineCipher.Code(txt, x);
                        break;
                    case 3:
                        AffineRecurrentCipher.Code(txt, x);
                        break;
                    case 4:
                        AffineRecurrentCipher.Code(txt, x);
                        break;
                    case 5:
                        Hills.MainHill(txt, x);
                        break;
                    case 6:
                        Hills.MainHill(txt, x);
                        break;
                    case 7:
                        HillRecurrent.MainHill(txt, x);
                        break;
                    case 8:
                        HillRecurrent.MainHill(txt, x);
                        break;
                    case 9:
                        VigenereCipher.MainVigenere(txt, x);
                        break;
                    case 10:
                        VigenereCipher.MainVigenere(txt, x);
                        break;
                    case 11:
                        RSA.MainRSA();
                        break;

                    default:                        
                        break;

                }
            }
        }
    }
}
