using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Nunit.Framework.TestCaseStorage;

namespace CezarShifr
{
    public class CeasarCipher
    {
        private int offset;

        private char[] enLe =
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
            's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        };

        private char[] ENle =
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R',
            'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        private char[] simv =
        {
            '~', '!'
        };

        public CeasarCipher(int offset)
        {
            this.offset = offset;
        }

        public string Encrypt(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
               var shifr = "";
               for (int i = 0; i < word.Length; i++)
                {
                        var cod = Convert.ToInt32(word[i]);
                        if (cod > 96 && cod < 123)
                        {
                            for (int j = 0; j < enLe.Length; j++)
                            {
                                if (word[i] == enLe[j])
                                {
                                    int temp = j + offset;
                                    while (temp >= enLe.Length)
                                    {
                                        temp -= enLe.Length;
                                    }
                                    shifr += enLe[temp];
                                }
                            }
                        }
                        else if (cod > 64 && cod < 123)
                        {
                            for (int k = 0; k < enLe.Length; k++)
                            {
                                if (word[i] == ENle[k])
                                {
                                    int temp = k + offset;
                                    while (temp >= ENle.Length)
                                    {
                                        temp -= ENle.Length;
                                    }
                                    shifr += ENle[temp];
                                }
                            }
                        }
                        else if (cod == 33 || cod == 126)
                        {
                            for (int h = 0; h < simv.Length; h++)
                            {
                                if (word[i] == simv[h])
                                {
                                    int temp = h + 1;
                                    while (temp >= simv.Length)
                                    {
                                        temp -= simv.Length;
                                    }
                                    shifr += simv[temp];
                                }
                            }
                        }else if (cod == 32)
                        {
                            shifr += " ";
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                }
                return shifr;
            }
        }



        public string Decrypt(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                var unshifr = "";
                for (int i = 0; i < word.Length; i++)
                {
                        var cod = Convert.ToInt32(word[i]);
                        if (cod > 96 && cod < 123)
                        {
                            for (int k = 0; k < enLe.Length; k++)
                            {
                                if (word[i] == enLe[k])
                                {
                                    int temp = k - offset;
                                    while (temp >= enLe.Length)
                                    {
                                        temp += enLe.Length;
                                    }
                                    while (temp < 0)
                                    {
                                        temp += enLe.Length;
                                    }
                                    unshifr += enLe[temp];
                                }
                            }
                        }
                        else if (cod > 64 && cod < 123)
                        {
                            for (int k = 0; k < enLe.Length; k++)
                            {
                                if (word[i] == ENle[k])
                                {
                                    int temp = k - offset;
                                    while (temp >= ENle.Length)
                                    {
                                        temp += ENle.Length;
                                    }
                                    while (temp < 0)
                                    {
                                        temp += ENle.Length;
                                    }
                                unshifr += ENle[temp];
                                }
                            }
                        }
                        else if (cod == 33 || cod == 126)
                        {
                            for (int h = 0; h < simv.Length; h++)
                            {
                                if (word[i] == simv[h])
                                {
                                    int temp = h - 1;
                                    while (temp >= simv.Length)
                                    {
                                        temp += simv.Length;
                                    }
                                    while (temp < 0)
                                    {
                                        temp += simv.Length;
                                    }
                                    unshifr += simv[temp];
                                }
                            }
                        }
                        else if (cod == 32)
                        {
                            unshifr += " ";
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }                  
                return unshifr;
            }
        }
    }
}


