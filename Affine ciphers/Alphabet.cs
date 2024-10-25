using System;


namespace Affine_ciphers
{
    class Alphabet
    {                                                 // 0    1    3    4    5    6    7    8    9    10   11   12  13   14    15   16   17   18   19   20   21   22   23   24   25   26    27  28   29   30   31   32   33                                                                                                                                  32   33  34        36
        public static char[] ArrAlphabet = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', '.', ',', ' ', '?' };

        public static int Keycode(char s)
        {
            for (int i = 0; i < ArrAlphabet.Length; i++)
            {
                if (s == ArrAlphabet[i]) return i;
            }
            return 0;
        }
    }
}
