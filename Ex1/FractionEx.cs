using System;
using System.ComponentModel;

namespace Ex1
{
    internal class FractionEx
    {
        public class Fraction
        {
            public int Nu;
            public int De;


            public Fraction(int Nu, int De)
            {
                this.Nu = Nu;
                this.De = De;
            }
            public int gcd(int a, int b)
            {
                if (a == 0 || b == 0)
                {
                    return a + b;
                }
                while (a != b)
                {
                    if (a > b)
                    {
                        a -= b; 
                    }
                    else
                    {
                        b -= a;
                    }
                }
                return a; 
            }
            public Fraction Reduce()
            {
                return new Fraction(this.Nu / gcd(this.Nu,this.De), this.De / gcd(this.Nu,this.De));
            }
            public void GetInput(string args)
            {
                this.Nu = Int32.Parse(args.Split('/')[0]);
                this.De = Int32.Parse(args.Split('/')[1]);
            }

            public string add(Fraction other)
            {
                Fraction temp = new Fraction(this.Nu * other.De + this.De * other.Nu, this.De * other.De);
                temp = temp.Reduce();
                return temp.Nu.ToString() + "/" + temp.De.ToString();
            }

            public string sub(Fraction other)
            {
                Fraction temp = new Fraction(this.Nu * other.De - this.De * other.Nu, this.De * other.De);
                temp = temp.Reduce();
                return temp.Nu.ToString() + "/" + temp.De.ToString();
            }

            public string mul(Fraction other)
            {
                Fraction temp = new Fraction(this.Nu * other.Nu, this.De * other.De);
                temp = temp.Reduce();
                return temp.Nu.ToString() + "/" + temp.De.ToString();
            }

            public string div(Fraction other)
            {
                Fraction temp = new Fraction(this.Nu*other.De, this.De * other.Nu);
                temp = temp.Reduce();
                return temp.Nu.ToString() + "/" + temp.De.ToString();
            }
        }


        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(1,1);
            Fraction f2 = new Fraction(1,1);
            f1.GetInput(args[1]);
            f2.GetInput(args[2]);
            switch (args[0])
            {
                case "add":
                    Console.WriteLine(f1.add(f2));
                    break;
                case "sub":
                    Console.WriteLine(f1.sub(f2));
                    break;
                case "mul":
                    Console.WriteLine(f1.mul(f2));
                    break;
                case "div":
                    Console.WriteLine(f1.div(f2));
                    break;
            }

        }
    }
}