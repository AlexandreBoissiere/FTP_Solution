using System;
using System.Drawing;
using System.Windows.Forms;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;
using System.Diagnostics;
using static Total_library.OSProject.Users;
using ByteReflection;
using Microsoft.DirectX.AudioVideoPlayback;
using System.Security.Cryptography;

namespace Total_library
{
    public sealed class ILibrary
    {
        public interface IGetHash
        {
            string GetHash(string str);
            string InverseHash(string str);
        }
        public interface IGetHashBool
        {
            string GetHash(bool bll);
            bool InverseHash(string str);
            bool? TryInverseHash(string str);
        }
    }
    public sealed class Errors
    {
        public static class Maths
        {
            public static Exception ZeroDivisionError = new Exception("Can't divise with 0 !");
        }
        public static class DisplayFunctions
        {
            public static Exception PrintLError = new Exception("Can't display this string ! Please check your code.");
            public static Exception PrintAError = new Exception("Can't display ans append this string ! Please check your code.");
            public static Exception PrintFError = new Exception("Can't display this array ! Please check your code.");
            public static Exception PrintFAError = new Exception("Can't display and append this array ! Please check your code.");
        }
        public static class Parser
        {
            public static Exception ParsingError = new Exception("Can't parse the given text ! Please check it.");
        }
        public static class Types
        {
            public static Exception NullableError = new Exception("Your nullable variable is not null, please check your code or find an alternative.");
            public static Exception UIntError = new Exception("Value of your variable is not an unsigned int !");
            public static Exception UFloatError = new Exception("Value of your variable is not an unsigned float !");
            public static Exception UShortError = new Exception("Value of your variable is not an unsigned short !");
            public static Exception ULongError = new Exception("Value of your variable is not an unsigned long !");
            public static Exception UDoubleError = new Exception("Value of your variable is not an unsigned double !");
        }
        public static class Log
        {
            public static Exception WriteLineValueException = new Exception("The value of the WriteLine arg must be true or false !");
        }
        public static class FilesIO
        {
            public static Exception FileNotFound = new Exception("Referenced file hasn't been found !");
        }
        public static class CodeNode
        {
            public static class AccessChild
            {
                public static Exception UnknownChild = new Exception("This code child don't exists !");
            }
        }
    }
    public sealed class Maths
    {
        public static double Add(double[] Nums)
        {
            double result = 0;
            foreach (double Num in Nums)
            {
                result += Num;
            }
            return result;
        }
        public static double Less(double[] Nums)
        {
            double result = 0;
            foreach (double Num in Nums)
            {
                result -= Num;
            }
            return result;
        }
        public static double Mul(double[] Nums)
        {
            double result = 1;
            foreach (double Num in Nums)
            {
                result *= Num;
            }
            return result;
        }
        public static double Div(double ToDiv, double[] Nums)
        {
            double result = ToDiv;
            foreach (double Num in Nums)
            {
                if (Num == 0) { throw Errors.Maths.ZeroDivisionError; }
                else
                {
                    result /= Num;
                }
            }
            return result;
        }
        public static int PGCD(int a, int b)
        {
            int r, x;
            if (a < b)
            {
                x = a;
                a = b;
                b = x;
            }
            while (b != 0)
            {
                r = a % b;
                a = b;
                b = r;
            }
            return a;
        }
        public static int PPCM(int a, int b)
        {
            int PGCD = Maths.PGCD(a, b);

            int PPCM = (a * b) / PGCD;

            return PPCM;
        }
        public static int Exponent(int a)
        {
            int j = 1;
            for (int i = 1; i < a + 1; i++)
            {
                j *= i;
            }
            return j;
        }
        public static double PythagoreTheorem(double a, double b)
        {
            double result;
            result = Math.Pow(a, 2) + Math.Pow(b, 2);
            result = Math.Sqrt(result);
            return result;
        }
        public static decimal SQRT(decimal squareT)
        {
            decimal sqrt = 0;
            decimal increment = 1;
            while (true)
            {
                if ((increment * increment) == squareT)
                {
                    break;
                }
                else
                {
                    increment++;
                    continue;
                }
            }
            sqrt = increment;
            return sqrt;
        }
        public static double ToSquare(double toSquare)
        {
            return (toSquare * toSquare);
        }
    } 
    public sealed class DisplayFunctions
    {
        public static void PrintL(string str)
        {
            try
            {
                Console.WriteLine(str);
            }
            catch { throw Errors.DisplayFunctions.PrintLError; }
        }
        public static void PrintA(string str)
        {
            try
            {
                Console.Write(str);
            }
            catch { throw Errors.DisplayFunctions.PrintAError; }
        }
        public static void PrintF(string[] Array)
        {
            try
            {
                foreach (string _Element in Array)
                {
                    Console.WriteLine(_Element);
                }
            }
            catch { throw Errors.DisplayFunctions.PrintFError; }
        }
        public static void PrintFA(string[] Array)
        {
            try
            {
                foreach (string _Element in Array)
                {
                    Console.Write(_Element);
                }
            }
            catch { throw Errors.DisplayFunctions.PrintFAError; }
        }
    }
    public sealed class InputsFunctions
    {
        public static string ReadL()
        {
            string input;
            input = Console.ReadLine();
            return input;
        }
        public static ConsoleKeyInfo ReadK(bool display = true)
        {
            ConsoleKeyInfo input = Console.ReadKey(display);
            return input;
        }
        public static void ReadVoid(bool display = true)
        {
            Console.ReadKey(display);
        }
    }
    public sealed class Parser
    {
        public static List<char> rawTextParser(string txt)
        {
            List<char> parsed = new List<char>();

            try
            {
                foreach (char _Sub in txt)
                {
                    parsed.Add(_Sub);
                }
            }
            catch { throw Errors.Parser.ParsingError; }

            return parsed;
        }
        public static List<string> parsing_sorter(List<char> Parsed)
        {
            List<string> sorted_parsing = new List<string>();

            for (int i = 0; i < Parsed.Count; ++i)
            {
                // Imports statements sorting
                if (Parsed[i] == 'i' && Parsed[i + 1] == 'm' && Parsed[i + 2] == 'p' && Parsed[i + 3] == 'o' && Parsed[i + 4] == 'r' && Parsed[i + 5] == 't')
                {
                    if (Parsed[i + 7] == 'm' && Parsed[i + 8] == 'a' && Parsed[i + 9] == 't' && Parsed[i + 10] == 'h')
                    {
                        sorted_parsing.Add("using static Total_library.Maths;");
                    }
                }

                // IFs statements sorting
                if (Parsed[i] == 'e' && Parsed[i + 1] == 'l' && Parsed[i + 2] == 's' && Parsed[i + 3] == 'e' && Parsed[i + 4] == 'i' && Parsed[i + 5] == 'f')
                {
                    sorted_parsing.Add("else if");
                    i += 5;
                    continue;
                }
                else if (Parsed[i] == 'e' && Parsed[i + 1] == 'l' && Parsed[i + 2] == 's' && Parsed[i + 3] == 'e' && Parsed[i + 4] == ' ' && Parsed[i + 5] == 'i' && Parsed[i + 6] == 'f')
                {
                    sorted_parsing.Add("else if");
                    i += 6;
                    continue;
                }
                else if (Parsed[i] == 'e' && Parsed[i + 1] == 'l' && Parsed[i + 2] == 's' && Parsed[i + 3] == 'i' && Parsed[i + 4] == 'f')
                {
                    sorted_parsing.Add("else if");
                    i += 4;
                    continue;
                }
                else if (Parsed[i] == 'i' && Parsed[i + 1] == 'f')
                {
                    sorted_parsing.Add("if");
                    i += 1;
                    continue;
                }
                else if (Parsed[i] == 'e' && Parsed[i + 1] == 'l' && Parsed[i + 2] == 's' && Parsed[i + 3] == 'e')
                {
                    sorted_parsing.Add("else");
                    i += 3;
                    continue;
                }

                // Loops statements sorting
                else if (Parsed[i] == 'w' && Parsed[i + 1] == 'h' && Parsed[i + 2] == 'i' && Parsed[i + 3] == 'l' && Parsed[i + 4] == 'e')
                {
                    sorted_parsing.Add("while");
                    i += 4;
                    continue;
                }
                else if (Parsed[i] == 'f' && Parsed[i + 1] == 'o' && Parsed[i + 2] == 'r')
                {
                    sorted_parsing.Add("for");
                    i += 2;
                    continue;
                }
                else if (Parsed[i] == 'f' && Parsed[i + 1] == 'o' && Parsed[i + 2] == 'r' && Parsed[i + 3] == 'e' && Parsed[i + 4] == 'a' && Parsed[i + 5] == 'c' &&
                    Parsed[i + 6] == 'h')
                {
                    sorted_parsing.Add("foreach");
                    i += 6;
                    continue;
                }

                // Types statements sorting
                //// Int
                else if (Parsed[i] == '_' && Parsed[i + 1] == 'I' && Parsed[i + 2] == 'n' && Parsed[i + 3] == 't' && Parsed[i + 4] == 'e' && Parsed[i + 5] == 'g' &&
                    Parsed[i + 6] == 'e' && Parsed[i + 7] == 'r')
                {
                    sorted_parsing.Add("int");
                    i += 7;
                    continue;
                }
                else if (Parsed[i] == '_' && Parsed[i + 1] == 'I' && Parsed[i + 2] == 'n' && Parsed[i + 3] == 't')
                {
                    sorted_parsing.Add("int");
                    i += 3;
                    continue;
                }
                else if (Parsed[i] == '_' && Parsed[i + 1] == 'I' && Parsed[i + 2] == 't' && Parsed[i + 3] == 'g')
                {
                    sorted_parsing.Add("int");
                    i += 3;
                    continue;
                }
                else if (Parsed[i] == '_' && Parsed[i + 1] == 'I' && Parsed[i + 2] == 'n' && Parsed[i + 3] == 't' && Parsed[i + 4] == 'g')
                {
                    sorted_parsing.Add("int");
                    i += 4;
                    continue;
                }

                //// Boolean
                else if (Parsed[i] == '_' && Parsed[i + 1] == 'B' && Parsed[i + 2] == 'o' && Parsed[i + 3] == 'o' && Parsed[i + 4] == 'l' && Parsed[i + 5] == 'e' &&
                    Parsed[i + 6] == 'a' && Parsed[i + 7] == 'n')
                {
                    sorted_parsing.Add("bool");
                    i += 7;
                    continue;
                }

                //// Built-In Functions
                else if (Parsed[i] == 'p' && Parsed[i + 1] == 'r' && Parsed[i + 2] == 'i' && Parsed[i + 3] == 'n' && Parsed[i + 4] == 't')
                {
                    sorted_parsing.Add("Console.WriteLine(");
                    i += 4;
                    continue;
                }

                // Code separators statements sorting
                else if (Parsed[i] == '(')
                {
                    sorted_parsing.Add("(");
                    continue;
                }
                else if (Parsed[i] == ')')
                {
                    sorted_parsing.Add(")");
                    continue;
                }
                else if (Parsed[i] == '[')
                {
                    sorted_parsing.Add("[");
                    continue;
                }
                else if (Parsed[i] == ']')
                {
                    sorted_parsing.Add("]");
                    continue;
                }
                else if (Parsed[i] == '{')
                {
                    sorted_parsing.Add("{");
                    continue;
                }
                else if (Parsed[i] == '}')
                {
                    sorted_parsing.Add("}");
                    continue;
                }

                // Quotation marks statements sorting
                else if (Parsed[i] == '"')
                {
                    sorted_parsing.Add("\"");
                    continue;
                }
                else if (Parsed[i] == '\'')
                {
                    sorted_parsing.Add("'");
                    continue;
                }

                // separators statement sorting
                else if (Parsed[i] == ',')
                {
                    sorted_parsing.Add(",");
                    continue;
                }
                else if (Parsed[i] == ';')
                {
                    sorted_parsing.Add(";");
                    continue;
                }
                else if (Parsed[i] == '.')
                {
                    sorted_parsing.Add(".");
                    continue;
                }

                // Operators statement sorting
                else if (Parsed[i] == '+')
                {
                    sorted_parsing.Add("+");
                    continue;
                }
                else if (Parsed[i] == '-')
                {
                    sorted_parsing.Add("-");
                    continue;
                }
                else if (Parsed[i] == '*')
                {
                    sorted_parsing.Add("*");
                    continue;
                }
                else if (Parsed[i] == '/')
                {
                    sorted_parsing.Add("/");
                    continue;
                }
                else if (Parsed[i] == '=')
                {
                    sorted_parsing.Add("=");
                    continue;
                }

                // String litterals separators statement sorting
                else if (Parsed[i] == '-')
                {
                    sorted_parsing.Add("-");
                    continue;
                }
                else if (Parsed[i] == '_')
                {
                    sorted_parsing.Add("_");
                    continue;
                }
                else if (Parsed[i] == '|')
                {
                    sorted_parsing.Add("|");
                    continue;
                }
                else if (Parsed[i] == ' ')
                {
                    sorted_parsing.Add(" ");
                }

                // Symbols statement sorting
                else if (Parsed[i] == '#')
                {
                    sorted_parsing.Add("#");
                    continue;
                }
                else if (Parsed[i] == '~')
                {
                    sorted_parsing.Add("~");
                    continue;
                }
                else if (Parsed[i] == '&')
                {
                    sorted_parsing.Add("&");
                    continue;
                }
                else if (Parsed[i] == '^')
                {
                    sorted_parsing.Add("^");
                    continue;
                }
                else if (Parsed[i] == '¨')
                {
                    sorted_parsing.Add("¨");
                    continue;
                }
                else if (Parsed[i] == '$')
                {
                    sorted_parsing.Add("$");
                    continue;
                }
                else if (Parsed[i] == '£')
                {
                    sorted_parsing.Add("£");
                    continue;
                }
                else if (Parsed[i] == '%')
                {
                    sorted_parsing.Add("%");
                    continue;
                }
                else if (Parsed[i] == '!')
                {
                    sorted_parsing.Add("!");
                    continue;
                }
                else if (Parsed[i] == '§')
                {
                    sorted_parsing.Add("§");
                    continue;
                }
                else if (Parsed[i] == ':')
                {
                    sorted_parsing.Add(":");
                    continue;
                }
                else if (Parsed[i] == '?')
                {
                    sorted_parsing.Add("?");
                    continue;
                }
                else if (Parsed[i] == '¤')
                {
                    sorted_parsing.Add("¤");
                    continue;
                }
                else if (Parsed[i] == 'µ')
                {
                    sorted_parsing.Add("µ");
                    continue;
                }
                else if (Parsed[i] == '<')
                {
                    sorted_parsing.Add("<");
                    continue;
                }
                else if (Parsed[i] == '>')
                {
                    sorted_parsing.Add(">");
                    continue;
                }

                // Numbers statement sorting
                else if (Parsed[i] == '0')
                {
                    sorted_parsing.Add("0");
                    continue;
                }
                else if (Parsed[i] == '1')
                {
                    sorted_parsing.Add("1");
                    continue;
                }
                else if (Parsed[i] == '2')
                {
                    sorted_parsing.Add("2");
                    continue;
                }
                else if (Parsed[i] == '3')
                {
                    sorted_parsing.Add("3");
                    continue;
                }
                else if (Parsed[i] == '4')
                {
                    sorted_parsing.Add("4");
                    continue;
                }
                else if (Parsed[i] == '5')
                {
                    sorted_parsing.Add("5");
                    continue;
                }
                else if (Parsed[i] == '6')
                {
                    sorted_parsing.Add("6");
                    continue;
                }
                else if (Parsed[i] == '7')
                {
                    sorted_parsing.Add("7");
                    continue;
                }
                else if (Parsed[i] == '8')
                {
                    sorted_parsing.Add("8");
                    continue;
                }
                else if (Parsed[i] == '9')
                {
                    sorted_parsing.Add("9");
                    continue;
                }

                // Letters statement
                // Lowercases
                else if (Parsed[i] == 'a')
                {
                    sorted_parsing.Add("a");
                    continue;
                }
                else if (Parsed[i] == 'b')
                {
                    sorted_parsing.Add("b");
                    continue;
                }
                else if (Parsed[i] == 'c')
                {
                    sorted_parsing.Add("c");
                    continue;
                }
                else if (Parsed[i] == 'd')
                {
                    sorted_parsing.Add("d");
                }
                else if (Parsed[i] == 'e')
                {
                    sorted_parsing.Add("e");
                }
                else if (Parsed[i] == 'f')
                {
                    sorted_parsing.Add("f");
                }
                else if (Parsed[i] == 'g')
                {
                    sorted_parsing.Add("g");
                }
                else if (Parsed[i] == 'h')
                {
                    sorted_parsing.Add("h");
                }
                else if (Parsed[i] == 'i')
                {
                    sorted_parsing.Add("i");
                }
                else if (Parsed[i] == 'j')
                {
                    sorted_parsing.Add("j");
                }
                else if (Parsed[i] == 'k')
                {
                    sorted_parsing.Add("k");
                }
                else if (Parsed[i] == 'l')
                {
                    sorted_parsing.Add("l");
                }
                else if (Parsed[i] == 'm')
                {
                    sorted_parsing.Add("m");
                }
                else if (Parsed[i] == 'n')
                {
                    sorted_parsing.Add("n");
                }
                else if (Parsed[i] == 'o')
                {
                    sorted_parsing.Add("o");
                }
                else if (Parsed[i] == 'p')
                {
                    sorted_parsing.Add("p");
                }
                else if (Parsed[i] == 'q')
                {
                    sorted_parsing.Add("q");
                }
                else if (Parsed[i] == 'r')
                {
                    sorted_parsing.Add("r");
                }
                else if (Parsed[i] == 's')
                {
                    sorted_parsing.Add("s");
                }
                else if (Parsed[i] == 't')
                {
                    sorted_parsing.Add("t");
                }
                else if (Parsed[i] == 'u')
                {
                    sorted_parsing.Add("u");
                }
                else if (Parsed[i] == 'v')
                {
                    sorted_parsing.Add("v");
                }
                else if (Parsed[i] == 'w')
                {
                    sorted_parsing.Add("w");
                }
                else if (Parsed[i] == 'x')
                {
                    sorted_parsing.Add("x");
                }
                else if (Parsed[i] == 'y')
                {
                    sorted_parsing.Add("y");
                }
                else if (Parsed[i] == 'z')
                {
                    sorted_parsing.Add("z");
                }

                // Uppercases
                else if (Parsed[i] == 'A')
                {
                    sorted_parsing.Add("A");
                }
                else if (Parsed[i] == 'B')
                {
                    sorted_parsing.Add("B");
                }
                else if (Parsed[i] == 'C')
                {
                    sorted_parsing.Add("C");
                }
                else if (Parsed[i] == 'D')
                {
                    sorted_parsing.Add("D");
                }
                else if (Parsed[i] == 'E')
                {
                    sorted_parsing.Add("E");
                }
                else if (Parsed[i] == 'F')
                {
                    sorted_parsing.Add("F");
                }
                else if (Parsed[i] == 'G')
                {
                    sorted_parsing.Add("G");
                }
                else if (Parsed[i] == 'H')
                {
                    sorted_parsing.Add("H");
                }
                else if (Parsed[i] == 'I')
                {
                    sorted_parsing.Add("I");
                }
                else if (Parsed[i] == 'J')
                {
                    sorted_parsing.Add("J");
                }
                else if (Parsed[i] == 'K')
                {
                    sorted_parsing.Add("K");
                }
                else if (Parsed[i] == 'L')
                {
                    sorted_parsing.Add("L");
                }
                else if (Parsed[i] == 'M')
                {
                    sorted_parsing.Add("M");
                }
                else if (Parsed[i] == 'N')
                {
                    sorted_parsing.Add("N");
                }
                else if (Parsed[i] == 'O')
                {
                    sorted_parsing.Add("O");
                }
                else if (Parsed[i] == 'P')
                {
                    sorted_parsing.Add("P");
                }
                else if (Parsed[i] == 'Q')
                {
                    sorted_parsing.Add("Q");
                }
                else if (Parsed[i] == 'R')
                {
                    sorted_parsing.Add("R");
                }
                else if (Parsed[i] == 'S')
                {
                    sorted_parsing.Add("S");
                }
                else if (Parsed[i] == 'T')
                {
                    sorted_parsing.Add("T");
                }
                else if (Parsed[i] == 'U')
                {
                    sorted_parsing.Add("U");
                }
                else if (Parsed[i] == 'V')
                {
                    sorted_parsing.Add("V");
                }
                else if (Parsed[i] == 'W')
                {
                    sorted_parsing.Add("W");
                }
                else if (Parsed[i] == 'X')
                {
                    sorted_parsing.Add("X");
                }
                else if (Parsed[i] == 'Y')
                {
                    sorted_parsing.Add("Y");
                }
                else if (Parsed[i] == 'Z')
                {
                    sorted_parsing.Add("Z");
                }
            }
            return sorted_parsing;
        }
        public static string OverParser(List<string> parsed)
        {
            string overparsed = "";
            for (int i = 0; i < parsed.Count; i++)
            {
                if (parsed[i] == "using static Total_library.Maths;")
                {
                    overparsed += parsed[i];
                    parsed.Remove(parsed[i]);
                }
            }
            overparsed += "using System;\nnamespace compiled\n{\nclass Program\n{\nstatic void Main(string[] args)\n{\n";
            for (int i = 0; i < parsed.Count; i++)
            {
                overparsed += parsed[i];
            }
            overparsed += "\n}\n}\n}";
            return overparsed;
        }

        public static int TotalParser(string sourcecode, out string parsedcode)
        {
            try
            {
                List<char> preparsed = rawTextParser(sourcecode);
                List<string> parsed = parsing_sorter(preparsed);
                parsedcode = OverParser(parsed);
                return 0;
            }
            catch
            {
                parsedcode = sourcecode;
                return 1;
            }
        }
    }
    public sealed class Prototypes_Types
    {
        public sealed class _Int
        {
            private int Int;
            public _Int(int value) => Int = value;
            public int INT() => Int;

            public static implicit operator int(_Int n) => n.INT();
            public static explicit operator _Int(int x) => new _Int(x);

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static bool operator ==(_Int left, _Int right) => left.INT() == right.INT();
            public static bool operator !=(_Int left, _Int right) => left.INT() != right.INT();
        }
        public sealed class _Short
        {
            private short shrt;
            public _Short(short value) => shrt = value;
            public short SHORT() => shrt;

            public static implicit operator short(_Short n) => n.SHORT();
            public static explicit operator _Short(short x) => new _Short(x);

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static bool operator ==(_Short left, _Short right) => left.SHORT() == right.SHORT();
            public static bool operator !=(_Short left, _Short right) => left.SHORT() != right.SHORT();
        }
        public sealed class _Long
        {
            private long lng;
            public _Long(long value) => lng = value;
            public long LONG() => lng;

            public static implicit operator long(_Long n) => n.LONG();
            public static explicit operator _Long(long x) => new _Long(x);

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static bool operator ==(_Long left, _Long right) => left.LONG() == right.LONG();
            public static bool operator !=(_Long left, _Long right) => left.LONG() != right.LONG();
        }
        public sealed class _String
        {
            private string str;
            public _String(string value) => str = value;
            public string STRING() => str;

            public static implicit operator string(_String n) => n.STRING();
            public static explicit operator _String(string x) => new _String(x);

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static bool operator ==(_String left, _String right) => left.STRING() == right.STRING();
            public static bool operator !=(_String left, _String right) => left.STRING() != right.STRING();
        }
        public sealed class _Double
        {
            private double dbl;
            public _Double(double value) => dbl = value;
            public double DOUBLE() => dbl;

            public static implicit operator double(_Double n) => n.DOUBLE();
            public static explicit operator _Double(double x) => new _Double(x);

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static bool operator ==(_Double left, _Double right) => left.DOUBLE() == right.DOUBLE();
            public static bool operator !=(_Double left, _Double right) => left.DOUBLE() != right.DOUBLE();
        }
        public sealed class _Float
        {
            private float flt;
            public _Float(float value) => flt = value;
            public float FLOAT() => flt;

            public static implicit operator float(_Float n) => n.FLOAT();
            public static explicit operator _Float(float x) => new _Float(x);

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static bool operator ==(_Float left, _Float right) => left.FLOAT() == right.FLOAT();
            public static bool operator !=(_Float left, _Float right) => left.FLOAT() != right.FLOAT();
        }
        public sealed class _Array<Type>
        {
            private Type[] array;
            public _Array(Type[] value) => array = value;
            public Type[] ARRAY() => array;

            public static implicit operator Type[](_Array<Type> n) => n.ARRAY();
            public static explicit operator _Array<Type>(Type[] x) => new _Array<Type>(x);
        }
        public sealed class _List<Type>
        {
            private List<Type> _list = new List<Type>();
            public _List(List<Type> value) => _list = value;
            public List<Type> LIST() => _list;

            public static implicit operator List<Type>(_List<Type> n) => n.LIST();
            public static explicit operator _List<Type>(List<Type> x) => new _List<Type>(x);
        }
        public sealed class _Byte
        {
            private byte byt;
            public _Byte(byte value) => byt = value;
            public byte BYTE() => byt;

            public static implicit operator byte(_Byte n) => n.BYTE();
            public static explicit operator _Byte(byte x) => new _Byte(x);

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static bool operator ==(_Byte left, _Byte right) => left.BYTE() == right.BYTE();
            public static bool operator !=(_Byte left, _Byte right) => left.BYTE() != right.BYTE();
        }
        public sealed class _Bool
        {
            private bool bll;
            public _Bool(bool value) => bll = value;
            public bool BOOL() => bll;

            public static implicit operator bool(_Bool n) => n.BOOL();
            public static explicit operator _Bool(bool x) => new _Bool(x);

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static bool operator ==(_Bool left, _Bool right) => left.BOOL() == right.BOOL();
            public static bool operator !=(_Bool left, _Bool right) => left.BOOL() != right.BOOL();
        }
        public sealed class _Null
        {
            private bool? nul;
            public _Null(bool? value) { if (value == null) { nul = value; } else { Console.WriteLine(Errors.Types.NullableError); } }
            public bool? NULL() => nul;

            public static implicit operator bool?(_Null n) => n.NULL();
            public static explicit operator _Null(bool? x) => new _Null(x);

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static bool operator ==(_Null left, _Null right) => left.NULL() == right.NULL();
            public static bool operator !=(_Null left, _Null right) => left.NULL() != right.NULL();
        }
        public sealed class _Exception
        {
#pragma warning disable CS0649
            private Exception Except;
#pragma warning restore CS0649
            public _Exception(string except) { Except = new Exception(except); }
            public Exception EXCEPTION() => Except;

            public static implicit operator Exception(_Exception nE) => nE.EXCEPTION();
            public static explicit operator _Exception(string xE) => new _Exception(xE);
        }
        public sealed class _UInt
        {
            private uint value;
            public _UInt(uint val) => value = val;
            public uint UINT() => value;

            public static implicit operator uint(_UInt n) => n.UINT();
            public static explicit operator _UInt(uint x) => new _UInt(x);

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static bool operator ==(_UInt left, _UInt right) => left.UINT() == right.UINT();
            public static bool operator !=(_UInt left, _UInt right) => left.UINT() != right.UINT();
        }
        public sealed class _UFloat
        {
            private float uflt;
            public _UFloat(float value) { if (value > 0) { uflt = value; } else { Console.WriteLine(Errors.Types.UFloatError); } }
            public float UFLOAT() => uflt;

            public static implicit operator float(_UFloat n) => n.UFLOAT();
            public static explicit operator _UFloat(float x) => new _UFloat(x);
        }
        public sealed class _UShort
        {
            private short ushrt;
            public _UShort(short value) { if (value > 0) { ushrt = value; } else { Console.WriteLine(Errors.Types.UShortError); } }
            public short USHORT() => ushrt;

            public static implicit operator short(_UShort n) => n.USHORT();
            public static explicit operator _UShort(short x) => new _UShort(x);
        }
        public sealed class _ULong
        {
            private long ulng;
            public _ULong(long value) { if (value > 0) { ulng = value; } else { Console.WriteLine(Errors.Types.ULongError); } }
            public long ULONG() => ulng;

            public static implicit operator long(_ULong n) => n.ULONG();
            public static explicit operator _ULong(long x) => new _ULong(x);
        }
        public sealed class _UDouble
        {
            private double udbl;
            public _UDouble(double value) { if (value > 0) { udbl = value; } else { Console.WriteLine(Errors.Types.UDoubleError); } }
            public double UDOUBLE() => udbl;

            public static implicit operator double(_UDouble n) => n.UDOUBLE();
            public static explicit operator _UDouble(double x) => new _UDouble(x);
        }
        public sealed class _DynVar<Type>
        {
            private Type var;
            public _DynVar(Type value) { var = value; }
            public Type DYNVAR() => var;
            ~_DynVar() { /*Abstract actions : just suppress memory...*/ }

            public static implicit operator Type(_DynVar<Type> n) => n.DYNVAR();
            public static explicit operator _DynVar<Type>(Type x) => new _DynVar<Type>(x);
        }
        public sealed class _StaticVar<Type>
        {
            private Type var;
            public _StaticVar(Type value) { var = value; }
            public Type STATICVAR() => var;

            public static implicit operator Type(_StaticVar<Type> n) => n.STATICVAR();
            public static explicit operator _StaticVar<Type>(Type x) => new _StaticVar<Type>(x);
        }
        public sealed class _DynArray<Type>
        {
            private _Array<Type> dynArray;
            public _DynArray(_Array<Type> value) => dynArray = value;
            public _Array<Type> DYNARRAY() => dynArray;
            ~_DynArray() { /*just suppress memory, just wait...*/ }

            public static implicit operator _Array<Type>(_DynArray<Type> n) => n.DYNARRAY();
            public static explicit operator _DynArray<Type>(_Array<Type> x) => new _DynArray<Type>(x);

            public static implicit operator Type[](_DynArray<Type> n)
            {
                _Array<Type> subArray = new _Array<Type>(n);
                Type[] finalArray = (Type[])subArray;
                return finalArray;
            }
            public static explicit operator _DynArray<Type>(Type[] x)
            {
                _Array<Type> subArray = new _Array<Type>(x);
                _DynArray<Type> finalArray = new _DynArray<Type>(subArray);
                return finalArray;
            }
        }
        public sealed class _DynList<Type>
        {
            private _List<Type> _list;
            public _DynList(_List<Type> value) => _list = value;
            public _List<Type> DYNLIST() => _list;
            ~_DynList() { /*just suppress memory, just wait...*/ }

            public static implicit operator _List<Type>(_DynList<Type> n) => n.DYNLIST();
            public static explicit operator _DynList<Type>(_List<Type> x) => new _DynList<Type>(x);

            public static implicit operator List<Type>(_DynList<Type> n)
            {
                _List<Type> subList = new _List<Type>(n);
                List<Type> finalList = (List<Type>)subList;
                return finalList;
            }
            public static explicit operator _DynList<Type>(List<Type> x)
            {
                _List<Type> subList = new _List<Type>(x);
                _DynList<Type> finalList = new _DynList<Type>(subList);
                return finalList;
            }
        }
    }

    namespace Types
    {
        // Don't run : generate a StackOverFlowException.
        public struct MInt : IComparable, IEquatable<MInt>, IComparable<MInt>
        {
            public static readonly MInt MaxValue = 2147483647;
            public static readonly MInt MinValue = -2147483647;
            public static readonly MInt NoneValue = 'N';

            private int PVal { get; set; }

            public MInt(int value)
            {
                var v = value;
                this = v;
            }

            public static MInt Parse(string s)
            {
                var intS = int.Parse(s);
                return new MInt(intS);
            }
            public static MInt Parse(int i)
            {
                return new MInt(i);
            }
            public int CompareTo(MInt value)
            {
                if (this < value)
                    return -1;
                else if (this == value)
                    return 0;
                else
                    return 1;
            }
            public int CompareTo(object value)
            {
                if (value is MInt)
                {
                    if (this < (MInt)value)
                        return -1;
                    else if (this == (MInt)value)
                        return 0;
                    else
                        return 1;
                }
                else
                    throw new ArgumentException("value n'est pas Total_library.Types.MInt.");
            }
            public override bool Equals(object obj)
            {
                if (obj is MInt && (MInt)obj == this)
                    return true;
                else
                    return false;

            }
            public bool Equals(MInt obj)
            {
                return this == obj;
            }
            public override int GetHashCode()
            {
                return (int)this;
            }
            public override string ToString()
            {
                return string.Concat(this);
            }
            public static string ToString(MInt obj)
            {
                return string.Concat(obj);
            }
            public bool ToBoolean(MInt obj)
            {
                if (obj == 1)
                    return true;
                else if (obj == 0)
                    return false;
                else
                    throw new ArgumentException("obj n'est pas égal à 0 ou 1");
            }

            public static MInt operator +(MInt i)
            {
                return +i;
            }
            public static MInt operator +(MInt i1, MInt i2)
            {
                return i1 + i2;
            }
            public static MInt operator -(MInt i)
            {
                return -i;
            }
            public static MInt operator -(MInt i1, MInt i2)
            {
                return i1 - i2;
            }
            public static MInt operator ++(MInt i)
            {
                return i++;
            }
            public static MInt operator --(MInt i)
            {
                return i--;
            }
            public static MInt operator *(MInt i1, MInt i2)
            {
                return i1 * i2;
            }
            public static MInt operator /(MInt i1, MInt i2)
            {
                return i1 / i2;
            }
            public static MInt operator %(MInt i1, MInt i2)
            {
                return i1 % i2;
            }
            public static bool operator ==(MInt left, MInt right)
            {
                return left == right;
            }
            public static bool operator !=(MInt left, MInt right)
            {
                return left != right;
            }
            public static bool operator <(MInt left, MInt right)
            {
                return left < right;
            }
            public static bool operator >(MInt left, MInt right)
            {
                return left > right;
            }
            public static bool operator <=(MInt left, MInt right)
            {
                return left <= right;
            }
            public static bool operator >=(MInt left, MInt right)
            {
                return left >= right;
            }

            public static implicit operator MInt(int value)
            {
                return new MInt(value);
            }
            public static implicit operator MInt(char value)
            {
                return (MInt)value;
            }
            public static implicit operator MInt(ushort value)
            {
                return (MInt)value;
            }
            public static implicit operator MInt(short value)
            {
                return (MInt)value;
            }
            public static implicit operator MInt(sbyte value)
            {
                return (MInt)value;
            }
            public static implicit operator MInt(byte value)
            {
                return (MInt)value;
            }
            public static explicit operator ulong(MInt value)
            {
                return (ulong)value;
            }
            public static explicit operator long(MInt value)
            {
                return (long)value;
            }
            public static explicit operator uint(MInt value)
            {
                return (uint)value;
            }
            public static explicit operator int(MInt value)
            {
                return value.PVal;
            }
            public static explicit operator char(MInt value)
            {
                return (char)value;
            }
            public static explicit operator ushort(MInt value)
            {
                return (ushort)value;
            }
            public static explicit operator short(MInt value)
            {
                return (short)value;
            }
            public static explicit operator sbyte(MInt value)
            {
                return (sbyte)value;
            }
            public static explicit operator byte(MInt value)
            {
                return (byte)value;
            }
            public static explicit operator string(MInt value)
            {
                return value.ToString();
            }
            public static explicit operator MInt(string s)
            {
                return Parse(s);
            }
            public static explicit operator float(MInt value)
            {
                return (float)value;
            }
            public static explicit operator double(MInt value)
            {
                return (double)value;
            }
        }
    }
    public sealed class Log
    {
        private StreamWriter log;
        public Log(string logname, bool WriteMode = true)
        {
            if (File.Exists(logname) == true)
            {
                this.log = new StreamWriter("./" + logname, WriteMode);
            }
            else
            {
                System.IO.File.Create("./" + logname);
                this.log = new StreamWriter("./" + logname, WriteMode);
            }
        }
        public void Write(string message, bool WriteLine = true)
        {
            if (WriteLine)
            {
                this.log.WriteLine(message);
            }
            else if (WriteLine == false)
            {
                this.log.Write(message);
            }
            else
            {
                Console.WriteLine(Errors.Log.WriteLineValueException);
            }
        }
        public void Close()
        {
            this.log.Close();
        }
        ~Log() { /*abstract actions : suppress memory, just wait...*/ }
    }
    public sealed class FilesIO
    {
        public class Read
        {
            StreamReader fileToRead;
#pragma warning disable CS0649
            bool _exists;
#pragma warning restore CS0649
            public Read(string filepath)
            {
                if (File.Exists(filepath) == true)
                {
                    this.fileToRead = new StreamReader(filepath);
                }
                else
                {
                    System.IO.File.Create("./" + filepath);
                    this.fileToRead = new StreamReader(filepath);
                }
            }
            public string READ(StreamReader file)
            {
                if (this._exists)
                {
                    return file.ReadToEnd();
                }
                else
                {
                    Console.WriteLine(Errors.FilesIO.FileNotFound);
                    return "";
                }
            }
        }
        public class Write
        {
            StreamWriter fileToWrite;
#pragma warning disable CS0649
            bool _exists;
#pragma warning restore CS0649

            public Write(string filepath)
            {
                if (File.Exists(filepath))
                {
                    this.fileToWrite = new StreamWriter(filepath);
                }
                else
                {
                    System.IO.File.Create("./" + filepath);
                    this.fileToWrite = new StreamWriter(filepath);
                }
            }
            public bool WRITE(StreamWriter file, string message)
            {
                bool sucefull;
                if (this._exists)
                {
                    file.Write(message);
                    sucefull = true;
                    return sucefull;
                }
                else
                {
                    Console.WriteLine(Errors.FilesIO.FileNotFound);
                    sucefull = false;
                    return sucefull;
                }
            }
        }
    }

    public sealed class MapPosition
    {
        private struct CoordsCreator
        {
            public int abs { get; set; }
            public int ord { get; set; }
        }

        CoordsCreator Coords;

        /// <summary>
        /// Créer une nouvelle instance de la classe MapPosition avec des coordonnées aléatoires.
        /// </summary>
        /// <param name="map">L'instance de la classe Map à préciser.</param>
        public MapPosition(Map map)
        {
            Random rdm = new Random();
            Coords = new CoordsCreator { abs = rdm.Next(map.PublicCoords[0]), ord = rdm.Next(map.PublicCoords[2]) };
            map.Positions.Add("(" + Coords.abs.ToString() + ";" + Coords.ord.ToString() + ")");
        }
        /// <summary>
        /// Créer une nouvelle instance de la classe MapPosition avec une coordonnée aléatoire comprise entre 1 et 100.
        /// </summary>
        /// <param name="coord">La valeur de la coordonée non aléatoire.</param>
        /// <param name="position">Si "true", alors les ordonnées seront aléatoires | Si "false", alors les abscisses seront aléatoires.</param>
        /// <param name="map">L'instance de la classe Map à préciser.</param>
        public MapPosition(int coord, bool position, Map map)
        {
            Random rdm = new Random();
            if (position == true)
                if (coord <= map.PublicCoords[0])
                    Coords = new CoordsCreator { abs = coord, ord = rdm.Next(map.PublicCoords[2]) };
                else
                    Coords = new CoordsCreator { abs = map.PublicCoords[0], ord = rdm.Next(map.PublicCoords[2]) };
            else
                if (coord <= map.PublicCoords[2])
                Coords = new CoordsCreator { abs = rdm.Next(map.PublicCoords[0]), ord = coord };
            else
                Coords = new CoordsCreator { abs = rdm.Next(map.PublicCoords[0]), ord = map.PublicCoords[2] };

            map.Positions.Add("(" + Coords.abs.ToString() + ";" + Coords.ord.ToString() + ")");
        }
        /// <summary>
        /// Créer une nouvelle instance de la classe MapPosition.
        /// </summary>
        /// <param name="x">Valeur des abscisses.</param>
        /// <param name="y">Valeur des ordonnées.</param>
        /// <param name="map">L'instance de la classe Map à préciser.</param>
        public MapPosition(int x, int y, Map map)
        {
            if (x <= map.PublicCoords[0])
                if (y <= map.PublicCoords[2])
                    Coords = new CoordsCreator { abs = x, ord = y };
                else
                    Coords = new CoordsCreator { abs = x, ord = map.PublicCoords[2] };
            else
                if (y <= map.PublicCoords[2])
                Coords = new CoordsCreator { abs = map.PublicCoords[0], ord = y };
            else
                Coords = new CoordsCreator { abs = map.PublicCoords[0], ord = map.PublicCoords[2] };

            map.Positions.Add("(" + Coords.abs.ToString() + ";" + Coords.ord.ToString() + ")");
        }

        public bool CompareTo(MapPosition x, MapPosition y)
        {
            if ((x.Coords.abs + x.Coords.ord) == (y.Coords.abs + y.Coords.ord))
                return true;
            else
                return false;
        }
        public int CalcDifference(MapPosition x, MapPosition y)
        {
            int difference = (x.Coords.abs + x.Coords.ord) - (y.Coords.abs + y.Coords.ord);
            return difference;
        }
        public int AddCoords(MapPosition x, MapPosition y)
        {
            int add = (x.Coords.abs + x.Coords.ord) + (y.Coords.abs + y.Coords.ord);
            return add;
        }
        public int AddCoords(MapPosition x)
        {
            int add = x.Coords.abs + x.Coords.ord;
            return add;
        }
        public int GetHashCode(MapPosition x)
        {
            return x.Coords.abs * x.Coords.ord;
        }
        public int GetHashCode(MapPosition x, MapPosition y)
        {
            return (x.Coords.abs * x.Coords.ord) * (y.Coords.abs * y.Coords.ord);
        }
        public string ToString(MapPosition x)
        {
            string str = "(";
            str += x.Coords.abs.ToString();
            str += ";";
            str += x.Coords.ord.ToString();
            str += ")";
            return str;
        }
        public string ToString(MapPosition x, MapPosition y)
        {
            string str = "[";
            str += this.ToString(x);
            str += ";";
            str += this.ToString(y);
            return str;
        }
        public int[] ToArray(MapPosition x)
        {
            int[] Array = new int[2];
            Array[0] = x.Coords.abs;
            Array[1] = x.Coords.ord;
            return Array;
        }
        public int[] ToArray(MapPosition x, MapPosition y)
        {
            int[] Array = new int[4];

            Array[0] = x.Coords.abs;
            Array[1] = x.Coords.ord;

            Array[2] = y.Coords.abs;
            Array[3] = y.Coords.ord;

            return Array;
        }
        public MapPosition ChangeCoords(int[] coords, Map map)
        {
            return new MapPosition(coords[0], coords[1], map);
        }
    }
    public sealed class Map
    {
        private struct CoordsCreator
        {
            public int PositiveMaxAbs { get; set; }
            public int NegativeMaxAbs { get; set; }
            public int PositiveMaxOrd { get; set; }
            public int NegativeMaxOrd { get; set; }
        }

        CoordsCreator Coords;

        public int[] PublicCoords = new int[4];

        /// <summary>
        /// Créer une instance de la classe Map.
        /// </summary>
        /// <param name="px">Valeur positive maximale des abscisses.</param>
        /// <param name="nx">Valeur négative maximale des abscisses.</param>
        /// <param name="py">Valeur positive maximale des ordonnées.</param>
        /// <param name="ny">Valeur négative maximale des ordonnées.</param>
        public Map(int px, int nx, int py, int ny)
        {
            Coords = new CoordsCreator { PositiveMaxAbs = px, NegativeMaxAbs = nx, PositiveMaxOrd = py, NegativeMaxOrd = ny };
            PublicCoords[0] = px;
            PublicCoords[1] = nx;
            PublicCoords[2] = py;
            PublicCoords[3] = ny;
        }

        /// <summary>
        /// Liste contenant les points de la carte (instance de la classe Map), les points étants des instances de MapPosition.
        /// </summary>
        public List<string> Positions = new List<string>();

        public int GetHashCode(Map map)
        {
            int hash;
            hash = ((map.PublicCoords[0] * map.PublicCoords[1]) * (map.PublicCoords[2] * map.PublicCoords[3]));
            return hash;
        }
        public bool CompareHash(Map x, Map y)
        {
            if (GetHashCode(x) == GetHashCode(y))
                return true;
            else
                return false;
        }
    }

    public sealed class SpaceMapPosition
    {
        private struct CoordsCreator
        {
            public int abs { get; set; }
            public int ord { get; set; }
            public int alt { get; set; }
        }

        CoordsCreator Coords;

        public int[] PublicCoords = new int[3];

        /// <summary>
        /// Créer une nouvelle instance de la classe SpaceMapPosition avec des coordonnées aléatoires.
        /// </summary>
        /// <param name="map">L'instance de la classe SpaceMap à préciser.</param>
        public SpaceMapPosition(SpaceMap map)
        {
            Random rdm = new Random();
            Coords = new CoordsCreator { abs = rdm.Next(map.PublicCoords[0]), ord = rdm.Next(map.PublicCoords[2]), alt = rdm.Next(map.PublicCoords[4]) };

            PublicCoords[0] = Coords.abs;
            PublicCoords[1] = Coords.ord;
            PublicCoords[2] = Coords.alt;

            map.Positions.Add("(" + Coords.abs.ToString() + ";" + Coords.ord.ToString() + ";" + Coords.alt.ToString() + ")");
        }
        /// <summary>
        /// Créer une nouvelle instance de la classe SpaceMapPosition avec une coordonnée aléatoire comprise entre 1 et 100.
        /// </summary>
        /// <param name="coord1">La valeur de la première coordonnée non aléatoire.</param>
        /// <param name="coord2">La valeur de la deuxième coordonnée non aléatoire.</param>
        /// <param name="position">Si "0", alors les ordonnées seront aléatoires | Si "1", alors les abscisses seront aléatoires. | Si "3", alors les altitudes seront aléatoires.</param>
        /// <param name="map">L'instance de la classe SpaceMap à préciser.</param>
        public SpaceMapPosition(int coord1, int coord2, short position, SpaceMap map)
        {
            Random rdm = new Random();
            if (position == 0)
            {
                if (coord1 <= map.PublicCoords[0] && coord2 <= map.PublicCoords[4])
                    Coords = new CoordsCreator { abs = coord1, ord = rdm.Next(map.PublicCoords[2]), alt = coord2 };
                else
                    Coords = new CoordsCreator { abs = map.PublicCoords[0], ord = rdm.Next(map.PublicCoords[2]), alt = map.PublicCoords[4] };
            }
            else if (position == 1)
            {
                if (coord1 <= map.PublicCoords[2] && coord2 <= map.PublicCoords[4])
                    Coords = new CoordsCreator { abs = rdm.Next(map.PublicCoords[0]), ord = coord1, alt = coord2 };
                else
                    Coords = new CoordsCreator { abs = rdm.Next(map.PublicCoords[0]), ord = map.PublicCoords[2], alt = map.PublicCoords[4] };
            }
            else
            {
                if (coord1 <= map.PublicCoords[0] && coord2 <= map.PublicCoords[2])
                    Coords = new CoordsCreator { abs = coord1, ord = coord2, alt = rdm.Next(map.PublicCoords[4]) };
                else
                    Coords = new CoordsCreator { abs = map.PublicCoords[0], ord = map.PublicCoords[2], alt = map.PublicCoords[4] };
            }

            PublicCoords[0] = Coords.abs;
            PublicCoords[1] = Coords.ord;
            PublicCoords[2] = Coords.alt;

            map.Positions.Add("(" + Coords.abs.ToString() + ";" + Coords.ord.ToString() + ";" + Coords.alt.ToString() + ")");
        }
        /// <summary>
        /// Créer une nouvelle instance de la classe SpaceMapPosition.
        /// </summary>
        /// <param name="x">Valeur des abscisses.</param>
        /// <param name="y">Valeur des ordonnées.</param>
        /// <param name="z">Valeur des altitudes.</param>
        /// <param name="map">L'instance de la classe SpaceMap à préciser.</param>
        public SpaceMapPosition(int x, int y, int z, SpaceMap map)
        {
            if (x <= map.PublicCoords[0])
            {
                if (y <= map.PublicCoords[2])
                {
                    if (z <= map.PublicCoords[4])
                        Coords = new CoordsCreator { abs = x, ord = y, alt = z };
                    else
                        Coords = new CoordsCreator { abs = x, ord = y, alt = map.PublicCoords[4] };
                }
                else
                {
                    if (z <= map.PublicCoords[4])
                        Coords = new CoordsCreator { abs = x, ord = map.PublicCoords[2], alt = z };
                    else
                        Coords = new CoordsCreator { abs = x, ord = map.PublicCoords[2], alt = map.PublicCoords[4] };
                }
            }
            else
            {
                if (y <= map.PublicCoords[2])
                {
                    if (z <= map.PublicCoords[4])
                        Coords = new CoordsCreator { abs = map.PublicCoords[0], ord = y, alt = z };
                    else
                        Coords = new CoordsCreator { abs = map.PublicCoords[0], ord = y, alt = map.PublicCoords[4] };
                }
                else
                {
                    if (z <= map.PublicCoords[4])
                        Coords = new CoordsCreator { abs = map.PublicCoords[0], ord = map.PublicCoords[2], alt = z };
                    else
                        Coords = new CoordsCreator { abs = map.PublicCoords[0], ord = map.PublicCoords[2], alt = map.PublicCoords[4] };
                }
            }

            PublicCoords[0] = Coords.abs;
            PublicCoords[1] = Coords.ord;
            PublicCoords[2] = Coords.alt;

            map.Positions.Add("(" + Coords.abs.ToString() + ";" + Coords.ord.ToString() + ")");
        }

        public bool CompareTo(SpaceMapPosition x, SpaceMapPosition y)
        {
            if (GetHashCode(x) == GetHashCode(y))
                return true;
            else
                return false;
        }
        public int CalcDiffernce(SpaceMapPosition x, SpaceMapPosition y)
        {
            return (x.Coords.abs + x.Coords.ord + x.Coords.alt) - (y.Coords.abs + y.Coords.ord + y.Coords.alt);
        }
        public int AddCoords(SpaceMapPosition x, SpaceMapPosition y)
        {
            return (x.Coords.abs + x.Coords.ord + x.Coords.alt) + (y.Coords.abs + y.Coords.ord + y.Coords.alt);
        }
        public int AddCoords(SpaceMapPosition x)
        {
            return x.Coords.abs + x.Coords.ord + x.Coords.alt;
        }
        public int GetHashCode(SpaceMapPosition x)
        {
            return x.Coords.abs * x.Coords.ord * x.Coords.alt;
        }
        public int GetHashCode(SpaceMapPosition x, SpaceMapPosition y)
        {
            return GetHashCode(x) * GetHashCode(y);
        }
        public string ToString(SpaceMapPosition x)
        {
            string str = "(";
            str += x.Coords.abs.ToString();
            str += ";";
            str += x.Coords.ord.ToString();
            str += ";";
            str += x.Coords.alt.ToString();
            str += ")";
            return str;
        }
        public string ToString(SpaceMapPosition x, SpaceMapPosition y)
        {
            string str = "[";
            str += this.ToString(x);
            str += ";";
            str += this.ToString(y);
            return str;
        }
        public int[] ToArray(SpaceMapPosition x)
        {
            return new int[3] { x.Coords.abs, x.Coords.ord, x.Coords.alt };
        }
        public int[] ToArray(SpaceMapPosition x, SpaceMapPosition y)
        {
            return new int[6] { x.Coords.abs, x.Coords.ord, x.Coords.alt, y.Coords.abs, y.Coords.ord, y.Coords.alt };
        }
        public SpaceMapPosition ChangeCoords(int[] coords, SpaceMap map)
        {
            return new SpaceMapPosition(coords[0], coords[1], coords[2], map);
        }
    }
    public sealed class SpaceMap
    {
        private struct CoordsCreator
        {
            public int PositiveMaxAbs { get; set; }
            public int NegativeMaxAbs { get; set; }
            public int PositiveMaxOrd { get; set; }
            public int NegativeMaxOrd { get; set; }
            public int PositiveMaxAlt { get; set; }
            public int NegativeMaxAlt { get; set; }
        }

        CoordsCreator Coords;

        public int[] PublicCoords = new int[4];

        /// <summary>
        /// Créer une instance de la classe SpaceMap.
        /// </summary>
        /// <param name="px">Valeur positive maximale des abscisses.</param>
        /// <param name="nx">Valeur négative maximale des abscisses.</param>
        /// <param name="py">Valeur positive maximale des ordonnées.</param>
        /// <param name="ny">Valeur négative maximale des ordonnées.</param>
        /// <param name="pz">Valeur positive maximale des altitudes.</param>
        /// <param name="nz">Valeur négative maximale des altitudes.</param>
        public SpaceMap(int px, int nx, int py, int ny, int pz, int nz)
        {
            Coords = new CoordsCreator { PositiveMaxAbs = px, NegativeMaxAbs = nx, PositiveMaxOrd = py, NegativeMaxOrd = ny, PositiveMaxAlt = pz, NegativeMaxAlt = nz };
            PublicCoords[0] = px;
            PublicCoords[1] = nx;
            PublicCoords[2] = py;
            PublicCoords[3] = ny;
            PublicCoords[4] = pz;
            PublicCoords[5] = nz;
        }

        /// <summary>
        /// Liste contenant les points de la carte en volume (instance de la classe SpaceMap), les points étants des instances de SpaceMapPosition.
        /// </summary>
        public List<string> Positions = new List<string>();

        public int GetHashCode(SpaceMap map)
        {
            int hash;
            hash = ((map.PublicCoords[0] * map.PublicCoords[1]) * (map.PublicCoords[2] * map.PublicCoords[3]) * (map.PublicCoords[4] * map.PublicCoords[5]));
            return hash;
        }
        public bool CompareHash(SpaceMap x, SpaceMap y)
        {
            if (GetHashCode(x) == GetHashCode(y))
                return true;
            else
                return false;
        }
    }

    public sealed class MemoryManagement
    {
        public void malloc(out IntPtr MemoryVar, int MemorySize)
        {
            MemoryVar = Marshal.AllocHGlobal(MemorySize);
        }
        public bool TryMalloc(out IntPtr MemoryVar, int MemorySize)
        {
            try
            {
                MemoryVar = Marshal.AllocHGlobal(MemorySize);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("=> Allocation of 0 bit of memory.");
                MemoryVar = Marshal.AllocHGlobal(0);
                return false;
            }
        }

        public void free(IntPtr MemoryVar)
        {
            Marshal.FreeHGlobal(MemoryVar);
        }
        public bool TryFree(IntPtr MemoryVar)
        {
            try
            {
                Marshal.FreeHGlobal(MemoryVar);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Unable to free this memory bloc.");
                return false;
            }
        }
    }

    public sealed class GetHash
    {
        public sealed class FromChar : ILibrary.IGetHash
        {
            private Dictionary<char, string> ToHash = new Dictionary<char, string>();
            private Dictionary<string, char> FromHash = new Dictionary<string, char>();

            public FromChar()
            {
                // ToHash dictionnary declarations.
                ToHash.Add(' ', "0x000");
                ToHash.Add('!', "0x001");
                ToHash.Add('"', "0x003");
                ToHash.Add('#', "0x004");
                ToHash.Add('$', "0x005");
                ToHash.Add('%', "0x006");
                ToHash.Add('&', "0x007");
                ToHash.Add('\'', "0x008");
                ToHash.Add('(', "0x009");
                ToHash.Add(')', "0x01");
                ToHash.Add('*', "0x02");
                ToHash.Add('+', "0x03");
                ToHash.Add(',', "0x04");
                ToHash.Add('-', "0x05");
                ToHash.Add('.', "0x06");
                ToHash.Add('/', "0x07");
                ToHash.Add(':', "0x08");
                ToHash.Add(';', "0x09");
                ToHash.Add('<', "0x1");
                ToHash.Add('=', "0x2");
                ToHash.Add('>', "0x3");
                ToHash.Add('?', "0x4");
                ToHash.Add('@', "0x5");
                ToHash.Add('[', "0x6");
                ToHash.Add('\\', "0x7");
                ToHash.Add(']', "0x8");
                ToHash.Add('^', "0x9");
                ToHash.Add('_', "1E");
                ToHash.Add('`', "2E");
                ToHash.Add('{', "3E");
                ToHash.Add('|', "4E");
                ToHash.Add('}', "5E");
                ToHash.Add('~', "6E");
                ToHash.Add('²', "7E");
                ToHash.Add('\n', "8E");
                ToHash.Add('\0', "9E");
                ToHash.Add('\a', "1%1E");
                ToHash.Add('\b', "1%2E");
                ToHash.Add('\r', "1%3E");
                ToHash.Add('\f', "1%4E");
                ToHash.Add('\t', "1%5E");
                ToHash.Add('\v', "1%6E");
                ToHash.Add('0', "0%0!000");
                ToHash.Add('1', "0%1!010");
                ToHash.Add('2', "0%2!200");
                ToHash.Add('3', "0%3!003");
                ToHash.Add('4', "1%0!000");
                ToHash.Add('5', "1%1!010");
                ToHash.Add('6', "1%2!200");
                ToHash.Add('7', "1%3!003");
                ToHash.Add('8', "2E%H!0f2");
                ToHash.Add('9', "3E%H!f2x");
                ToHash.Add('A', "%1#[0%0!000]=000");
                ToHash.Add('B', "%1#[0%1!010]=001");
                ToHash.Add('C', "%1#[0%2!200]=002");
                ToHash.Add('D', "%1#[0%3!003]=003");
                ToHash.Add('E', "%1#[1%0!000]=004");
                ToHash.Add('F', "%1#[1%1!010]=005");
                ToHash.Add('G', "%1#[1%2!200]=006");
                ToHash.Add('H', "%1#[1%3!003]=007");
                ToHash.Add('I', "%1#[2E%H!0f2]=008");
                ToHash.Add('J', "%1#[3E%H!f2x]=009");
                ToHash.Add('K', "%2#[0%0!000]=01");
                ToHash.Add('L', "%2#[0%1!010]=02");
                ToHash.Add('M', "%2#[0%2!200]=03");
                ToHash.Add('N', "%2#[0%3!003]=04");
                ToHash.Add('O', "%2#[1%0!000]=05");
                ToHash.Add('P', "%2#[1%1!010]=06");
                ToHash.Add('Q', "%2#[1%2!200]=07");
                ToHash.Add('R', "%2#[1%3!003]=08");
                ToHash.Add('S', "%2#[2E%H!0f2]=09");
                ToHash.Add('T', "%2#[3E%h!f2x]=1");
                ToHash.Add('U', "3E%S3#[0%0!000]=2");
                ToHash.Add('V', "4E%S3#[0%1!010}=3");
                ToHash.Add('W', "5E%S3#[0%2!200]=4");
                ToHash.Add('X', "6E%S3#[0%3!003]=5");
                ToHash.Add('Y', "7E%S3#[1%0!000]=6");
                ToHash.Add('Z', "8E%S3#[1%1!010]=7");
                ToHash.Add('a', "%1&{0%0!000}=000");
                ToHash.Add('b', "%1&{0%1!010}=001");
                ToHash.Add('c', "%1&{0%2!200}=002");
                ToHash.Add('d', "%1&{0%3!003}=003");
                ToHash.Add('e', "%1&{1%0!000}=004");
                ToHash.Add('f', "%1&{1%1!010}=005");
                ToHash.Add('g', "%1&{1%2!200}=006");
                ToHash.Add('h', "%1&{1%3!003})007");
                ToHash.Add('i', "%1&{2E%H!0f2}=008");
                ToHash.Add('j', "%1&{3E%H!f2x}=009");
                ToHash.Add('k', "%2&{0%0!000}=01");
                ToHash.Add('l', "%2&{0%1!010}=02");
                ToHash.Add('m', "%2&{0%2!200}=03");
                ToHash.Add('n', "%2&{0%3!003}=04");
                ToHash.Add('o', "%2&{1%0!000}=05");
                ToHash.Add('p', "%2&{1%1!010}=06");
                ToHash.Add('q', "%2&{1%2!200}=07");
                ToHash.Add('r', "%2&{1%3!003}=08");
                ToHash.Add('s', "%2&{2E%H!0f2}=09");
                ToHash.Add('t', "%2&{3E%H!f2x}=1");
                ToHash.Add('u', "3E%S3&{0%0!000}=2");
                ToHash.Add('v', "4E%S3&{0%1!010}=3");
                ToHash.Add('w', "5E%S3&{0%2!200}=4");
                ToHash.Add('x', "6E%S3&{0%3!003}=5");
                ToHash.Add('y', "7E%S3&{1%0!000}=6");
                ToHash.Add('z', "8E%S3&{1%1!010}=7");
                ToHash.Add('µ', "1%E%Ex%0");
                ToHash.Add('é', "1%E%Ex%1");
                ToHash.Add('è', "1%E%Ex%2");
                ToHash.Add('à', "1%E%Ex%3");
                ToHash.Add('¤', "1%E%Ex%4");
                ToHash.Add('£', "1%E%Ex%5");
                ToHash.Add('§', "1%E%Ex%6");
                ToHash.Add('¨', "1%E%Ex%7");
                ToHash.Add('ç', "1%E%Ex%8");
                ToHash.Add('ù', "1%E%Ex%9");

                FromHash = Utility.UDictionary<char, string>.Inverse(ToHash);
            }

            public string GetHash(string str)
            {
                string final = "";
                foreach (char _Sub in str)
                {
                    try
                    {
                        Console.WriteLine(_Sub + " -> " + ToHash[_Sub]);
                        if (final == "")
                            final += ToHash[_Sub];
                        else
                            final += " " + ToHash[_Sub];
                    }
                    catch (KeyNotFoundException e)
                    {
                        Console.WriteLine("Key not found : " + _Sub);
                        Console.WriteLine(e.Message);
                    }
                }
                return final;
            }
            public string GetHashBackground(string str)
            {
                string final = "";
                foreach (char _Sub in str)
                {
                    try
                    {
                        if (final == "")
                            final += ToHash[_Sub];
                        else
                            final += " " + ToHash[_Sub];
                    }
                    catch (KeyNotFoundException e)
                    {
                        Console.WriteLine("Key not found : " + _Sub);
                        Console.WriteLine(e.Message);
                    }
                }
                return final;
            }
            private List<string> Parser(string str)
            {
                string calcStr = str;

                string[] calcStrSplit;
                calcStrSplit = calcStr.Split(new char[] { ' ' });
                List<string> calcStrTrim = calcStrSplit.ToList<string>();

                foreach (string sub in calcStrTrim)
                {
                    if (sub == " ")
                        calcStrTrim.Remove(sub);
                }

                List<string> final = calcStrTrim;

                return final;
            }
            public string InverseHash(string str)
            {
                string final = "";
                List<string> parsedStr = Parser(str);

                foreach (string sub in parsedStr)
                {
                    final += FromHash[sub];
                }

                return final;
            }
        }
        public sealed class FromBool : ILibrary.IGetHashBool
        {
            private Dictionary<bool, string> ToHash = new Dictionary<bool, string>();
            private Dictionary<string, bool> FromHash = new Dictionary<string, bool>();

            public FromBool()
            {
                ToHash.Add(true, "B1%{@VE}%"); // B1 = Binary 1 (true) ; VE = Value Entry.
                ToHash.Add(false, "B0%{@VO}%"); // B0 = Binary 0 (false) ; VO = Value Out.

                FromHash = Utility.UDictionary<bool, string>.Inverse(ToHash);
            }

            public string GetHash(bool bll)
            {
                string final = "";
                final = ToHash[bll];
                return final;
            }
            public bool InverseHash(string str)
            {
                bool final;
                final = FromHash[str];
                return final;
            }
            public bool? TryInverseHash(string str)
            {
                bool? final;
                try
                {
                    final = FromHash[str];
                    return final;
                }
                catch
                {
                    Console.WriteLine(new Exception("Can't convert this string to a boolean from the encoding structure."));
                    return null;
                }
            }
        }
        public sealed class CreateEncoding<TKey, TValue>
        {
            public Dictionary<TKey, TValue> ToHash = new Dictionary<TKey, TValue>();
            public Dictionary<TValue, TKey> FromHash = new Dictionary<TValue, TKey>();

            public CreateEncoding(Dictionary<TKey, TValue> encodingStructure)
            {
                ToHash = encodingStructure;
                FromHash = Utility.UDictionary<TKey, TValue>.Inverse(ToHash);
            }
        }
    }
    public sealed class GetBytes
    {
        private Dictionary<char, string> ToBytes = new Dictionary<char, string>();
        private Dictionary<string, char> FromBytes = new Dictionary<string, char>();

        public GetBytes()
        {
            ToBytes.Add(' ', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001");
            ToBytes.Add('!', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010");
            ToBytes.Add('"', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100");
            ToBytes.Add('#', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000");
            ToBytes.Add('$', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000");
            ToBytes.Add('%', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100000");
            ToBytes.Add('&', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000");
            ToBytes.Add('\'',"10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000000");
            ToBytes.Add('(', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100000000");
            ToBytes.Add(')', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000011");
            ToBytes.Add('*', "10111100011010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000101");
            ToBytes.Add('+', "10111100011010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001001");
            ToBytes.Add(',', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010001");
            ToBytes.Add('-', "10111100011010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100001");
            ToBytes.Add('.', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000001");
            ToBytes.Add('/', "10111100011010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000001");
            ToBytes.Add(':', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100000001");
            ToBytes.Add(';', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000111");
            ToBytes.Add('<', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001011");
            ToBytes.Add('=', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010011");
            ToBytes.Add('>', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100011");
            ToBytes.Add('?', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000011");
            ToBytes.Add('@', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000011");
            ToBytes.Add('[', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100000011");
            ToBytes.Add(']', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001111");
            ToBytes.Add('\\',"10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010111");
            ToBytes.Add('^', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100111");
            ToBytes.Add('_', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000111");
            ToBytes.Add('`', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000111");
            ToBytes.Add('{', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100000111");
            ToBytes.Add('|', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000011111");
            ToBytes.Add('}', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000101111");
            ToBytes.Add('~', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001001111");
            ToBytes.Add('²', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010001111");
            ToBytes.Add('µ', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100001111");
            ToBytes.Add('é', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000111111");
            ToBytes.Add('è', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001011111");
            ToBytes.Add('à', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010011111");
            ToBytes.Add('§', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100011111");
            ToBytes.Add('¨', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001111111");
            ToBytes.Add('ç', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010111111");
            ToBytes.Add('ù', "10100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100111111");
            ToBytes.Add('0', "11110011110111111111111111001001000001010001001010001001001000110010100000000000000000000000000000000000000000000000000000000001");
            ToBytes.Add('1', "11110011110111111111111111001001000001010001001010001001001000110010100000000000000000000000000000000000000000000000000000000010");
            ToBytes.Add('2', "11110011110111111111111111001001000001010001001010001001001000110010100000000000000000000000000000000000000000000000000000000100");
            ToBytes.Add('3', "11110011110111111111111111001001000001010001001010001001001000110010100000000000000000000000000000000000000000000000000000001000");
            ToBytes.Add('4', "11110011110111111111111111001001000001010001001010001001001000110010100000000000000000000000000000000000000000000000000000010000");
            ToBytes.Add('5', "11110011110111111111111111001001000001010001001010001001001000110010100000000000000000000000000000000000000000000000000000100000");
            ToBytes.Add('6', "11110011110111111111111111001001000001010001001010001001001000110010100000000000000000000000000000000000000000000000000001000000");
            ToBytes.Add('7', "11110011110111111111111111001001000001010001001010001001001000110010100000000000000000000000000000000000000000000000000010000000");
            ToBytes.Add('8', "11110011110111111111111111001001000001010001001010001001001000110010100000000000000000000000000000000000000000000000000100000000");
            ToBytes.Add('9', "11110011110111111111111111001001000001010001001010001001001000110010100000000000000000000000000000000000000000000000001000000000");
            ToBytes.Add('a', "10000000000000000000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('b', "01000000000000000000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('c', "00100000000000000000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('d', "00010000000000000000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('e', "00001000000000000000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('f', "00000100000000000000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('g', "00000010000000000000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('h', "00000001000000000000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('i', "00000000100000000000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('j', "00000000010000000000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('k', "00000000001000000000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('l', "00000000000100000000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('m', "00000000000010000000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('n', "00000000000001000000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('o', "00000000000000100000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('p', "00000000000000010000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('q', "00000000000000001000000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('r', "00000000000000000100000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('s', "00000000000000000010000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('t', "00000000000000000001000000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('u', "00000000000000000000100000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('v', "00000000000000000000010000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('w', "00000000000000000000001000000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('x', "00000000000000000000000100000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('y', "00000000000000000000000010000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('z', "00000000000000000000000001000000000000000000000000000000000000000000011111111110011111100110111011111111111111110001000001101000");
            ToBytes.Add('A', "100000000000000000000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('B', "010000000000000000000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('C', "001000000000000000000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('D', "000100000000000000000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('E', "000010000000000000000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('F', "000001000000000000000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('G', "000000100000000000000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('H', "000000010000000000000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('I', "000000001000000000000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('J', "000000000100000000000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('K', "000000000010000000000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('L', "000000000001000000000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('M', "000000000000100000000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('N', "000000000000010000000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('O', "000000000000001000000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('P', "000000000000000100000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('Q', "000000000000000010000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('R', "000000000000000001000000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('S', "000000000000000000100000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('T', "000000000000000000010000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('U', "000000000000000000001000000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('V', "000000000000000000000100000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('W', "000000000000000000000010000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('X', "000000000000000000000001000011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('Y', "000000000000000000000000100011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('Z', "000000000000000000000000010011011000111111111100000001111110001010110000000000000001010111111111111101111100000000001111111111111");
            ToBytes.Add('¤', "011111111111111110000000000001100000000000000100000000000000101011111111111111010111111111111111010000000000000000000011110100000");
            ToBytes.Add('£', "100000000000000001111111111110011111111111111011111111111111010100000000000000101000000000000000101111111111111111111100001011111");
            ToBytes.Add('\n', "100000000000000000000000000000000000000000000000000000000000111111111100000000000000000000000000000000000000000000000000000000001");
            ToBytes.Add('\0', "010000000000000000000000000000000000000000000000000000000000111111111100000000000000000000000000000000000000000000000000000000010");
            ToBytes.Add('\a', "110000000000000000000000000000000000000000000000000000000000111111111100000000000000000000000000000000000000000000000000000000011");
            ToBytes.Add('\b', "001000000000000000000000000000000000000000000000000000000000111111111100000000000000000000000000000000000000000000000000000000100");
            ToBytes.Add('\r', "101000000000000000000000000000000000000000000000000000000000111111111100000000000000000000000000000000000000000000000000000000101");
            ToBytes.Add('\f', "011000000000000000000000000000000000000000000000000000000000111111111100000000000000000000000000000000000000000000000000000000110");
            ToBytes.Add('\t', "111000000000000000000000000000000000000000000000000000000000111111111100000000000000000000000000000000000000000000000000000000111");
            ToBytes.Add('\v', "000100000000000000000000000000000000000000000000000000000000111111111100000000000000000000000000000000000000000000000000000001000");
            FromBytes = Utility.UDictionary<char, string>.Inverse(ToBytes);
        }

        public string GetHBytes(string str)
        {
            string final = "";
            foreach (char _Sub in str)
            {
                try
                {
                    Console.WriteLine(_Sub + " -> " + ToBytes[_Sub]);
                    if (final == "")
                        final += ToBytes[_Sub];
                    else
                        final += " " + ToBytes[_Sub];
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine("Key not found : " + _Sub);
                    Console.WriteLine(e.Message);
                }
            }
            return final;
        }
        public string GetBytesBackground(string str)
        {
            string final = "";
            foreach (char _Sub in str)
            {
                try
                {
                    if (final == "")
                        final += ToBytes[_Sub];
                    else
                        final += " " + ToBytes[_Sub];
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine("Key not found : " + _Sub);
                    Console.WriteLine(e.Message);
                }
            }
            return final;
        }
        private List<string> Parser(string str)
        {
            string calcStr = str;

            string[] calcStrSplit;
            calcStrSplit = calcStr.Split(new char[] { ' ' });
            List<string> calcStrTrim = calcStrSplit.ToList<string>();

            foreach (string sub in calcStrTrim)
            {
                if (sub == " ")
                    calcStrTrim.Remove(sub);
            }

            List<string> final = calcStrTrim;

            return final;
        }
        public string InverseBytes(string str)
        {
            string final = "";
            List<string> parsedStr = Parser(str);

            foreach (string sub in parsedStr)
            {
                final += FromBytes[sub];
            }

            return final;
        }
    }
    public sealed class Utility
    {
        public sealed class UDictionary<TKey, TValue>
        {
            public static Dictionary<TValue, TKey> Inverse(Dictionary<TKey, TValue> inputDico)
            {

                Dictionary<TKey, TValue> calcDico = inputDico;
                Dictionary<TValue, TKey> finalDico = new Dictionary<TValue, TKey>();
                List<TKey> keys = new List<TKey>();
                List<TValue> values = new List<TValue>();

                keys = calcDico.Keys.ToList();

                foreach (TKey key in keys)
                {
                    values.Add(calcDico[key]);
                }

                for (int i = 0; i < keys.Count; i++)
                {
                    finalDico.Add(values[i], keys[i]);
                }

                return finalDico;
            }
        }
        public sealed class UStringAndNumbers
        {
            public static bool IsNumber(char str)
            {
                if (str == '1' || str == '2' || str == '3' || str == '4' || str == '5' || str == '6' || str == '7' || str == '8' || str == '9')
                    return true;
                else
                    return false;
            }
            public static bool IsOperand(char str)
            {
                if (str == '+' || str == '-' || str == '/' || str == '*' || str == '%')
                    return true;
                else
                    return false;
            }
            public static double ComputeMathFormula(string formula)
            {
                double result = double.NaN;
                CodeCompileUnit unit = prepareCompileUnit(formula);
                Assembly dynamicAssembly = compileCode(unit, "CSharp");
                if (dynamicAssembly != null)
                {
                    object formulaComputer = dynamicAssembly.CreateInstance("DynGen.Compute.formulaComputing", true);
                    MethodInfo computeFormula = formulaComputer.GetType().GetMethod("computeFormula");
                    result = (double)computeFormula.Invoke(formulaComputer, null);
                }
                return result;
            }
            private static Assembly compileCode(CodeCompileUnit compileunit, string language)
            {
                CompilerParameters compilerParameters = new CompilerParameters();
                compilerParameters.ReferencedAssemblies.Add("System.dll");
                compilerParameters.GenerateExecutable = false;
                compilerParameters.GenerateInMemory = true;
                compilerParameters.IncludeDebugInformation = false;
                compilerParameters.WarningLevel = 1;
                // compile.
                CodeDomProvider provider = CodeDomProvider.CreateProvider(language);
                CompilerResults compilerResults = provider.CompileAssemblyFromDom(compilerParameters, compileunit);

                // Return assembly if compilation OK - otherwise return null
                return (compilerResults.Errors.Count == 0) ? compilerResults.CompiledAssembly : null;
            }
            private static CodeCompileUnit prepareCompileUnit(string formulaString)
            {
                CodeNamespace compute = new CodeNamespace("DynGen.Compute");
                compute.Imports.Add(new CodeNamespaceImport("System"));
                CodeCompileUnit compileUnit = new CodeCompileUnit();
                compileUnit.Namespaces.Add(compute);
                CodeTypeDeclaration formulaComputing = new CodeTypeDeclaration("formulaComputing");
                compute.Types.Add(formulaComputing);
                CodeMemberMethod computeFormulaCode = new CodeMemberMethod();
                computeFormulaCode.Attributes = MemberAttributes.Public;
                computeFormulaCode.Name = "computeFormula";
                computeFormulaCode.ReturnType = new CodeTypeReference(typeof(double));
                CodeSnippetExpression formula = new CodeSnippetExpression(formulaString);
                CodeMethodReturnStatement computeFormulaReturnStatement = new CodeMethodReturnStatement(formula);
                computeFormulaCode.Statements.Add(computeFormulaReturnStatement);

                formulaComputing.Members.Add(computeFormulaCode);
                return compileUnit;
            }
        }
        public sealed class UCryptography
        {
            public static string EncryptString(string str, string password)
            {
                byte[] bStr = Encoding.UTF8.GetBytes(str);
                byte[] key = GenerateAlgotihmInputs(password)[0];
                byte[] Iv = GenerateAlgotihmInputs(password)[1];

                RijndaelManaged rijndael = new RijndaelManaged();

                rijndael.Mode = CipherMode.CBC;

                ICryptoTransform aesEncrypter = rijndael.CreateEncryptor(key, Iv);

                MemoryStream ms = new MemoryStream();

                CryptoStream cs = new CryptoStream(ms, aesEncrypter, CryptoStreamMode.Write);
                cs.Write(bStr, 0, bStr.Length);
                cs.FlushFinalBlock();

                byte[] CipherBytes = ms.ToArray();

                ms.Close();
                cs.Close();

                return Convert.ToBase64String(CipherBytes);
            }
            public static string DecryptString(string crypted, string password)
            {
                byte[] cipheredData = Convert.FromBase64String(crypted);
                byte[] key = GenerateAlgotihmInputs(password)[0];
                byte[] Iv = GenerateAlgotihmInputs(password)[1];

                RijndaelManaged rijndael = new RijndaelManaged();
                rijndael.Mode = CipherMode.CBC;


                ICryptoTransform decryptor = rijndael.CreateDecryptor(key, Iv);
                MemoryStream ms = new MemoryStream(cipheredData);
                CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);

                byte[] bStr = new byte[cipheredData.Length];

                int decryptedByteCount = cs.Read(bStr, 0, bStr.Length);

                ms.Close();
                cs.Close();

                return Encoding.UTF8.GetString(bStr, 0, decryptedByteCount);
            }
            public static List<byte[]> GenerateAlgotihmInputs(string password)
            {

                byte[] key;
                byte[] iv;

                List<byte[]> result = new List<byte[]>();

                Rfc2898DeriveBytes rfcDb = new Rfc2898DeriveBytes(password, System.Text.Encoding.UTF8.GetBytes(password));

                key = rfcDb.GetBytes(16);
                iv = rfcDb.GetBytes(16);

                result.Add(key);
                result.Add(iv);

                return result;

            }
        }
    }

    namespace Binary
    {
#pragma warning disable CS0660, CS0661
        public sealed class Operations
        {
            private short Entry1;
            private short Entry2;

            public Operations(Bit bit1, Bit bit2)
            {
                this.Entry1 = bit1.status;
                this.Entry2 = bit2.status;
            }

            public bool AND()
            {
                if (Entry1 == 1 && Entry2 == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool NOT()
            {
                if (Entry1 == 0 && Entry2 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool OR()
            {
                if (Entry1 == 1 || Entry2 == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool XOR()
            {
                if (Entry1 == 1 && Entry2 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public static bool operator ==(Operations a, Operations b)
            {
                if (a.Entry1 == b.Entry1 && a.Entry2 == b.Entry2)
                    return true;
                else
                    return false;
            }
            public static bool operator !=(Operations a, Operations b)
            {
                if (a == b)
                    return false;
                else
                    return true;
            }
        }
        public sealed class Bit
        {
            public short status;
            public Bit(BinaryValues bitVal)
            {
                this.status = bitVal.status;
            }

            public static bool operator ==(Bit a, Bit b)
            {
                if (a.status == b.status)
                    return true;
                else
                    return false;
            }
            public static bool operator !=(Bit a, Bit b)
            {
                if (a == b)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public struct BinaryValues
        {
            public const short active = 1;
            public const short inactive = 0;
            public const short @default = 0;
            public short status
            {
                get { return status; }
                set
                {
                    if (value <= active && value >= inactive)
                    {
                        status = value;
                    }
                    else
                    {
                        throw new Exception("The given value isn't a binary value (0|1) !");
                    }
                }
            }
            public BinaryValues(short status)
            {
                try
                {
                    this.status = status;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    this.status = @default;
                }
            }

            public static bool operator ==(BinaryValues a, BinaryValues b)
            {
                if (a.status == b.status)
                    return true;
                else
                    return false;
            }
            public static bool operator !=(BinaryValues a, BinaryValues b)
            {
                if (a == b)
                    return false;
                else
                    return true;
            }
#pragma warning restore CS0660, CS0661
        }
    }

    namespace OSProject
    {
        public static class FileSystem
        {
            public static readonly string ExecutableAppExt = ".app";
            public static readonly string StaticLibraryExt = ".slib";
            public static readonly string DynamicLibraryExt = ".dlib";

            public static readonly string RootFolder = "./root";
            public static readonly string UsersFolder = "./users";

            public static string GetFileExtension(string path)
            {
                return Path.GetExtension(path);
            }
            public static void InitializeOSFileSystem()
            {
                if (!Directory.Exists(RootFolder))
                {
                    Directory.CreateDirectory(RootFolder);
                }
                if (!Directory.Exists(UsersFolder))
                {
                    Directory.CreateDirectory(UsersFolder);
                }
            }
        }
        public static class Users
        {
            public static class root
            {
                private static readonly string folder = FileSystem.RootFolder;
                public static readonly string docs = folder + "/docs";

                public static readonly string text = docs + "/text";
                public static readonly string music = docs + "/music";
                public static readonly string video = docs + "/video";

                public static readonly string code = folder + "/code";

                public static readonly string raw = code + "/raw";
                public static readonly string obj = code + "/obj";
                public static readonly string bin = code + "/bin";

                public static void InitializeRoot()
                {
                    string[] paths = new string[] { folder, docs, text, music, video, code, raw, obj, bin };
                    foreach (string path in paths)
                    {
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                            Console.WriteLine(path);
                        }
                    }
                }
            }
            public sealed class User
            {
                public static List<User> users = new List<User>();
                public string username { get; set; }
                public string password { get; set; }
                public User(string username, string password)
                {
                    foreach (User user in users)
                    {
                        if (user.username == username)
                            throw new Exception("This username is already used by another user !");
                    }
                    this.username = username;
                    this.password = password;
                    users.Add(this);
                }
                public void InitializeUser()
                {
                    string folder = FileSystem.UsersFolder + "/" + username;
                    string docs = folder + "/docs";

                    string text = docs + "/text";
                    string music = docs + "/music";
                    string video = docs + "/video";

                    string code = folder + "/code";

                    string raw = code + "/raw";
                    string obj = code + "/obj";
                    string bin = code + "/bin";

                    string[] paths = new string[] { FileSystem.UsersFolder, folder, docs, text, music, video, code, raw, obj, bin };
                    foreach (string path in paths)
                    {
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                            Console.WriteLine(path);
                        }
                    }
                }

                public User AddUser(string username, string password)
                {
                    return new User(username, password);
                }
            }
        }
        public static class InitOS
        {
            public static void Init()
            {
                FileSystem.InitializeOSFileSystem();
                root.InitializeRoot();
                Configuration.InitConf();
                Console.Title = Configuration.OSName + " environment";
            }
        }
        public static class Configuration
        {
            private static GetHash.FromChar hasher = new GetHash.FromChar();
            public static readonly string OSName = "DynOS";
            public static readonly string OSFolder = "./DynOS";
            public static readonly string UsersInformations = OSFolder + "/" + hasher.GetHashBackground("users");
            public static Thread autoVerifyUsersConf = new Thread(new ThreadStart(InitUsersConfThreading));

            public static void InitConf()
            {
                string[] paths = new string[] { OSFolder, UsersInformations };
                foreach (string path in paths)
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                        Console.WriteLine(path);
                    }
                }
                autoVerifyUsersConf.Start();
            }
            public static void InitUsersConf()
            {
                if (User.users.Count != 0)
                {
                    foreach (User user in User.users)
                    {
                        if (!Directory.Exists(UsersInformations + "/" + hasher.GetHashBackground(user.username)))
                        {
                            Directory.CreateDirectory(UsersInformations + "/" + hasher.GetHashBackground(user.username));
                        }
                        if (!File.Exists(UsersInformations + "/" + hasher.GetHashBackground(user.username) + "/password.inf"))
                        {
                            StreamWriter sw = new StreamWriter(UsersInformations + "/" + hasher.GetHashBackground(user.username) + "/password.inf");
                            sw.WriteLine(user.password);
                            sw.Close();
                        }
                        else
                        {
                            StreamReader rd = new StreamReader(UsersInformations + "/" + hasher.GetHashBackground(user.username) + "/password.inf");
                            if (rd.ReadLine() != user.password)
                            {
                                rd.Close();
                                StreamWriter sw = new StreamWriter(UsersInformations + "/" + hasher.GetHashBackground(user.username) + "/password.inf");
                                sw.WriteLine(user.password);
                                sw.Close();
                            }
                        }
                    }
                }
                if (!Directory.Exists(UsersInformations + "/" + hasher.GetHashBackground("conf")))
                {
                    Directory.CreateDirectory(UsersInformations + "/" + hasher.GetHashBackground("conf"));
                }
                if (!File.Exists(UsersInformations + "/" + hasher.GetHashBackground("conf") + "/users.inf"))
                {
                    StreamWriter sw = new StreamWriter(UsersInformations + "/" + hasher.GetHashBackground("conf") + "/users.inf");
                    foreach (User user in User.users)
                    {
                        sw.WriteLine(user.username);
                    }
                    sw.Close();
                }
            }
            public static void InitUsersConfThreading()
            {
                while (true)
                {
                    InitUsersConf();
                }
            }
            public static void StopThreads()
            {
                autoVerifyUsersConf.Abort();
            }
            public static string AccessUserPassword(string username)
            {
                string path = UsersInformations + "/" + hasher.GetHashBackground(username) + "/" + hasher.GetHashBackground("password.inf");
                string password = "";
                try
                {
                    password = new StreamReader(path).ReadLine();
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                return password;
            }
            public static List<User> AcessUsers()
            {
                string path = UsersInformations + "/" + hasher.GetHashBackground("conf") + "/" + hasher.GetHashBackground("users.inf");
                string[] usernames = File.ReadAllLines(path);
                List<User> users = new List<User>();
                foreach (string username in usernames)
                {
                    users.Add(new User(username, AccessUserPassword(username)));
                }
                return users;
            }
        }
        public static class AppInterpreter
        {
            public static void LaunchExecutable(string path)
            {
                Process.Start(path);
            }
        }
        public static class ConsoleManagement
        {
            public static void Interpreter(string command)
            {
                if (command == "edit -f" || command == "edit --file")
                {
                    DisplayFunctions.PrintL("path of the file : ");
                    string path = Console.ReadLine();
                    FileInterpreter(path);
                }
                else if (command == "compile -f" || command == "edit --file")
                {
                    DisplayFunctions.PrintL("path of the file : ");
                    string path = Console.ReadLine();
                    Console.WriteLine("Wait the update to be able to use this command. ;)");
                }
                else if (command == "help")
                {
                    foreach (string sub in Help.help())
                    {
                        DisplayFunctions.PrintL("\t" + sub);
                    }
                }
            }
            private static class Help
            {
                public static string[] help()
                {
                    return new string[] { "help", "edit -f | edit --file" };
                }
            }
            private static void FileInterpreter(string path)
            {
                try
                {
                    Process.Start("OSPorjectApp.FileEditor.exe", path);
                }
                catch
                {
                    Console.WriteLine("unable to locate the specified file.");
                }
            }
            private static void CodeCompiler(string path)
            {
                string contents = File.ReadAllText(path);
            }
            public static string InputCommand()
            {
                return Console.ReadLine();
            }
            public static void Core()
            {
                while (true)
                {
                    Console.WriteLine("DynOS{user}~$");
                    Interpreter(InputCommand());
                }
            }
        }
        public static class BinaryCompiler
        {
            public static void PreCompile(string path)
            {
                var precompiler = new GetBytes();
                var fileContents = File.ReadAllText(path);
                var precompiled = precompiler.GetBytesBackground(fileContents);
                if (!Directory.Exists("./obj/"))
                {
                    Directory.CreateDirectory("./obj/");
                }
                File.WriteAllText("./obj/output.obj", precompiled);
            }
            public static void Compile(string path)
            {

            }
        }
        public static class GraphicsManager
        {
            public static void ImageSetPixels(string sourcefilepath, string outimage)
            {
                var src = sourcefilepath;
                string[] code = File.ReadAllLines(src);
                List<string[]> parsedLines = new List<string[]>();
                foreach (string line in code)
                {
                    List<string> splitedStr = line.Split(',').ToList();
                    foreach (string sub in splitedStr)
                    {
                        if (sub == " " || sub == ",")
                        {
                            splitedStr.Remove(sub);
                        }
                    }
                    parsedLines.Add(new string[] { splitedStr[0], splitedStr[1], splitedStr[2] });
                }

                Bitmap bitmap = new Bitmap(outimage);
                /*if (!File.Exists(outimage))
                {
                    Bitmap bitmapTemp = new Bitmap(256, 256, System.Drawing.Imaging.PixelFormat.Format64bppArgb);
                    
                }*/
                Color color = new Color();

                foreach (string[] sub in parsedLines)
                {
                    if (sub[2] == "red")
                    {
                        color = Color.Red;
                    }
                    else if (sub[2] == "blue")
                    {
                        color = Color.Blue;
                    }
                    else if (sub[2] == "yellow")
                    {
                        color = Color.Yellow;
                    }
                    bitmap.SetPixel(int.Parse(sub[0]), int.Parse(sub[1]), color);
                }
            }
        }
    }

    namespace AudioManagement
    {
        public class AudioPlayer
        {
            private Audio audio;
            public AudioPlayer(string path)
            {
                audio = new Audio(path);
            }
            private void AudioPlayThread()
            {
                audio.Play();
            }
            public void AudioPlay()
            {
                Thread thread = new Thread(AudioPlayThread);
                thread.Start();
            }
        }
    }

    namespace Network
    {
        public static class Sockets
        {
            public static Socket CreateSocket(string server, int port)
            {
                Socket s = null;
                IPHostEntry hostentry = null;

                hostentry = Dns.GetHostEntry(server);

                foreach (IPAddress address in hostentry.AddressList)
                {
                    IPEndPoint ipe = new IPEndPoint(address, port);
                    Socket temp = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                    temp.Connect(ipe);

                    if (temp.Connected)
                    {
                        s = temp;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                return s;
            }
            public static void CloseSocket(ref Socket s)
            {
                s.Close();
            }
        }
        public class Com
        {
            public class ComData
            {
                public IPEndPoint Client;
                public byte[] Data = new byte[256];

                public ComData(IPEndPoint client, byte[] data)
                {
                    Client = client;
                    Data = data;
                }
            }
            public class Server
            {
                UdpClient server = null;
                Thread Tstart;
                public List<ComData> got = new List<ComData>();

                public Server()
                {
                    Tstart = new Thread(new ThreadStart(StartThread));
                    Tstart.Start();
                }

                private void StartThread()
                {
                    bool error = false;
                    int attempts = 0;

                    do
                    {
                        try
                        {
                            server = new UdpClient(5015);
                        }
                        catch
                        {
                            error = true;
                            attempts++;
                            Thread.Sleep(500);
                        }
                    }
                    while (error && attempts < 4);

                    if (server == null)
                    {
                        throw new Exception("Unable to link connection at the port 5015 ! Please verify your network configuartion !");
                    }

                    while (true)
                    {
                        try
                        {
                            IPEndPoint ipe = null;
                            byte[] predata = server.Receive(ref ipe);

                            string sPreData = Encoding.ASCII.GetString(predata);
                            string sDecrypted = Utility.UCryptography.DecryptString(sPreData, "2020_FTP_SOLUTION_PASS_SENTENCE");
                            byte[] data = Encoding.ASCII.GetBytes(sDecrypted);

                            ComData cd = new ComData(ipe, data);

                            new Thread(delegate () { Response(cd); }).Start();
                        }
                        catch
                        {
                            break;
                        }
                    }

                    server.Close();
                    throw new Exception("SERVER CLOSED !");
                }
                private void Response(ComData cd)
                {
                    got.Add(cd);
                }
                public void Send(string data, string clientIP)
                {
                    string crypted = Utility.UCryptography.EncryptString(data, "2020_FTP_SOLUTION_PASS_SENTENCE");
                    byte[] bData = Encoding.ASCII.GetBytes(crypted);

                    server.Send(bData, bData.Length, clientIP, 5030);
                }
                public void Stop()
                {
                    Tstart.Abort();
                }
            }
            public class Client
            {
                UdpClient client = null;
                Thread Tstart;
                public List<ComData> got = new List<ComData>();

                public Client()
                {
                    Tstart = new Thread(new ThreadStart(StartThread));
                    Tstart.Start();
                }
                private void StartThread()
                {
                    bool error = false;
                    int attempts = 0;

                    do
                    {
                        try
                        {
                            client = new UdpClient(5030);
                        }
                        catch
                        {
                            error = true;
                            attempts++;
                            Thread.Sleep(500);
                        }
                    } while (error && attempts < 4);

                    if (client == null)
                    {
                        throw new Exception("Unable to link connection at the port 5015 ! Please verify your network configuartion !");
                    }

                    while (true)
                    {
                        try
                        {
                            IPEndPoint ipe = null;
                            byte[] predata = client.Receive(ref ipe);

                            string sPreData = Encoding.ASCII.GetString(predata);
                            string sDecrypted = Utility.UCryptography.DecryptString(sPreData, "2020_FTP_SOLUTION_PASS_SENTENCE");
                            byte[] data = Encoding.ASCII.GetBytes(sDecrypted);

                            ComData cd = new ComData(ipe, data);

                            new Thread(delegate () { Response(cd); }).Start();
                        }
                        catch
                        {
                            break;
                        }
                    }

                    client.Close();
                    throw new Exception("CLIENT CLOSED !");
                }
                private void Response(ComData cd)
                {
                    got.Add(cd);
                }
                public void Send(string data, string serverIP)
                {
                    string crypted = Utility.UCryptography.EncryptString(data, "2020_FTP_SOLUTION_PASS_SENTENCE");
                    byte[] bData = Encoding.ASCII.GetBytes(crypted);

                    client.Send(bData, bData.Length, serverIP, 5015);
                }
                public void Stop()
                {
                    Tstart.Abort();
                }
            }
        }
    }
}