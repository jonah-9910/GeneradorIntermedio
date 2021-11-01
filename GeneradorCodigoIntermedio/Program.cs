using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorCodigoIntermedio
{
    class Program
    {
        static void Main(string[] args)
        {
            string text, prev = "", sig = "", agr = "";
            bool flag = false;
            int cont = 0;
            int temp = 1;

            Console.Write("Digite la expresion a codificar : ");
            text = Console.ReadLine();

            if (text.Contains("="))
            {
                string[] parts = text.Split('=');
                agr = parts[0];
                text = parts[1];
                flag = true;
            }

            Console.Write("Codigo intermedio :\n");
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    if (temp == 1)
                    {
                        prev = "";
                        temp += 1;

                        for (int j = i - 1; j >= 0 ; j--)
                        {
                            char c1 = text[j];
                            if (c1 == '+' || c1 == '-' || c1 == '*' || c1 == '/')
                            {
                                break;
                            }
                            prev = c1 + prev;
                        }
                    }
                    else
                    {
                        prev = "t" + (cont - 1);
                    }
                    sig = "";

                    for (int j = i + 1; j < text.Length; j++)
                    {
                        char c2 = text[j];
                        if (c2 == '+' || c2 == '-' || c2 == '*' || c2 == '/')
                        {
                            break;
                        }
                        sig = sig + c2;
                    }
                    Console.Write("t" + cont + " = " + prev + " " + c + " " + sig + "\n");
                    cont++;
                }
            }

            if (flag)
            {
                Console.Write(agr + " = " + "t" + (cont - 1));
            }

            Console.ReadLine();
        }
    }
}
