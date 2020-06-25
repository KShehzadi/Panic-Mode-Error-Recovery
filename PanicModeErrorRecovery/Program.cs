using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanicModeErrorRecovery
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                string str=null;
                string strInput;
                Console.WriteLine("\n" + "\n" + "" +
                    "***********************" +
                    " Enter Input " +
                    "***********************" + "\n");
                strInput = Console.ReadLine();
                char[] characters = strInput.ToArray();
                for (int i = 0; i < characters.Length; ++i)
                {
                    //Relational Operaters
                    if (characters[i] == '<')
                    {
                        str = str + characters[i];
                        if (i + 1 != characters.Length)
                        {
                            if (characters[i] == '=')
                            {
                                str = str + characters[i];
                                Console.Write("<"+str+" Less than Equal" +">"+ "\n");
                                str = null;
                                ++i;
                            }
                            else if (characters[i] == '>')
                            {
                                str = str + characters[i];
                                Console.Write("<"+str+ "Not Equal" +">"+ "\n");
                                str = null;
                                ++i;
                            }
                            else
                            {
                                Console.Write("<"+str + " Less than" +">"+ "\n");
                                str = null;
                            }
                        }
                        else
                        {
                            Console.Write("<"+str + " Less than" +">"+ "\n");
                            str = null;
                        }
                    }
                    else if (characters[i] == '=')
                    {
                        str = str+characters[i];
                        Console.Write("<"+str+" Equal" +">"+ "\n");
                        str = null;
                    }
                    else if (characters[i] == '>')
                    {
                        str = str + characters[i];
                        if (i + 1 != characters.Length)
                        {
                            if (characters[i + 1] == '=')
                            {
                                str = str + characters[i+1];
                                Console.Write("<"+str+ " Greater than Equal" +">" +"\n");
                                str = null;
                                ++i;
                            }
                            else
                            {
                                Console.Write("<"+str+" Greater than" +">"+ "\n");
                                str = null;
                            }
                        }
                        else
                        {
                            Console.Write("<"+str+ " Greater than" +">"+ "\n");
                            str = null;
                        }
                    }
                    //Code to check Identifier
                    else if (char.IsLetter(characters[i]))
                    {
                        str = str + characters[i];
                        int j = i + 1;
                        if (characters.Length != j)
                        {
                            for (; j < characters.Length; ++j)
                            {
                                if (char.IsDigit(characters[j]) || char.IsLetter(characters[j]))
                                {
                                    str = str + characters[j];
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        i = j - 1;
                        Console.Write("<"+str+ " Identifier" +">"+ "\n");
                        str = null;
                    }
                    //code to check is a number or not
                    else if (char.IsDigit(characters[i]))
                    {
                        str = str + characters[i];
                        bool flag = true;
                        int j = i + 1;
                        if (j != characters.Length)
                        {
                            for (; j < characters.Length; ++j)
                            {
                                if (char.IsDigit(characters[j]))
                                {
                                    str = str + characters[j];
                                    continue;
                                }
                                else if (characters[j] == '.')
                                {
                                    if (j + 1 != characters.Length)
                                    {
                                        if (char.IsDigit(characters[j + 1]))
                                        {
                                            str = str + characters[j];
                                            continue;
                                        }
                                        else
                                        {
                                            flag = false;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        flag = false;
                                        break;
                                    }
                                }
                                else if (characters[j] == 'E')
                                {
                                    str = str + characters[j];
                                    if (j + 1 != characters.Length)
                                    {
                                        if (characters[j + 1] == '+' || characters[j + 1] == '-')
                                        {
                                            str = str + characters[j+1];
                                            if (char.IsDigit(characters[j + 2]))
                                            {
                                                str = str + characters[j+2];
                                                int k = j + 3;
                                                for (; k < characters.Length; ++k)
                                                {
                                                    if (char.IsDigit(characters[k]))
                                                    {
                                                        str = str + characters[k];
                                                        continue;
                                                    }
                                                    else
                                                        break;
                                                }
                                                j = k - 1;
                                            }
                                            else
                                            {
                                                flag = false;
                                                Console.Write("<"+str+ "Error!" +">"+ "\n");
                                                str = null;
                                            }
                                        }
                                        else if (char.IsDigit(characters[j + 1]))
                                        {
                                            str = str + characters[j+1];
                                            int k = j + 2;
                                            for (; k < characters.Length; ++k)
                                            {
                                                if (char.IsDigit(characters[k]))
                                                {
                                                    str = str + characters[k];
                                                    continue;
                                                }
                                                else
                                                    break;
                                            }
                                            j = k - 1;
                                        }
                                        else
                                        {
                                            flag = false;
                                            Console.Write("<"+str+ " Error!" +">"+ "\n");
                                            str = null;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        flag = false;
                                        Console.Write("<"+str+ " Error!" +">"+ "\n");
                                        str = null;
                                        j++;
                                        break;
                                    }

                                }
                                else
                                {
                                    flag = true;
                                    break;
                                }
                            }
                        }
                        i = j - 1;
                        if (flag)
                        {
                            Console.Write("<"+str + " Number" +">"+ "\n");
                            str = null;
                        }
                    }
                    //code to check for white space
                    else if (char.IsWhiteSpace(characters[i]))
                    {
                        Console.Write("<"+"Space" + ">"+"\n");
                        str = null;
                    }
                    //code to check for assignment opperator
                    else if (characters[i] == ':')
                    {
                        str = str + characters[i];
                        int j = i + 1;
                        if (j != characters.Length)
                        {
                            str = str + characters[j];
                            if (characters[j] == '=')
                            {
                                str = str + characters[j];
                                Console.Write("<"+str+ " Assignment Op" +">"+ "\n");
                                str = null;
                                i = j;
                            }
                            else
                            {
                                Console.Write("<"+str + " Error!" +">"+ "\n");
                                str = null;
                            }
                        }
                        else
                        {
                            Console.Write("<"+str + " Error!" +">"+ "\n");
                            str = null;
                        }
                    }
                    
                    else if (characters[i] == '{')
                    {
                        str = str + characters[i];
                        int j = i + 1;
                        if (j != characters.Length)
                        {
                            if (characters[j] == '}')
                            {
                                str = str + characters[j];
                                Console.Write("<"+str+ " Comment" + ">"+"\n");
                                str = null;
                                i = j;
                            }
                            else
                            {
                                Console.Write("<"+str+ " Error!" +">"+ "\n");
                                str = null;
                            }
                        }
                        else
                        {
                            Console.Write("<"+str + " Error!" +">"+ "\n");
                            str = null;
                        }
                    }
                    //code to check for add opperator
                    else if (characters[i] == '+')
                    {
                        str = str + characters[i];
                        Console.Write("<"+str+ " Add Operator" +">"+ "\n");
                        str = null;
                    }
                    //code to check for subtract opperator
                    else if (characters[i] == '-')
                    {
                        str = str + characters[i];
                        Console.Write("<"+str+ " Subtract Operator" +">"+ "\n");
                        str = null;
                    }
                    //code to check for multiplication opperator
                    else if (characters[i] == '*')
                    {
                        str = str + characters[i];
                        Console.Write("<"+str+ " Multiplication Operator" +">"+ "\n");
                        str = null;
                    }
                    //code to check for division opperator
                    else if (characters[i] == '/')
                    {
                        str = str + characters[i];
                        Console.Write("<"+str+" Divsion Operator" +">"+ "\n");
                        str = null;
                    }
                    //code print error if other than above cases
                    else
                    {
                        str += characters[i];
                        Console.Write("<"+str+ " Error!" +">"+ "\n");
                        str = null;
                    }
                }
            }

        }
    }   
}

