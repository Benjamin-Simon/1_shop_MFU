using System;
using System.IO;
using System.Linq;

namespace MFU
{

    abstract class MFU
    {
        public virtual void Print(string txt)
        {
            Console.WriteLine(txt);
        }

        abstract public string Scan();
    }

    class MFUSamsung : MFU
    {
        private string name;

        public MFUSamsung(string name)
        {
            this.name = name;
        }

        public override void Print(string txt)
        {
            Console.WriteLine("Samsung " + name);
            Console.WriteLine(txt);
        }

        public override string Scan()
        {
            throw new NotImplementedException();
        }
    }

    class MFUHuawei : MFU
    {
        private string name = "Huawei";
        public MFUHuawei(string name)
        {
            this.name += " " + name;
        }

        public override void Print(string txt)
        {
            Console.WriteLine(name);
            Console.WriteLine(txt);
        }

        public override string Scan()
        {
            throw new NotImplementedException();
        }
    }

    class MFUHP : MFU
    {
        private string name;
        public MFUHP(string name)
        {
            this.name = name;
        }

        public override void Print(string txt)
        {
            Console.WriteLine("HP " + name);
            Console.WriteLine(txt);
        }

        public override string Scan()
        {
            throw new NotImplementedException();
        }
    }
    abstract class Printer  //абстрактный принтер
    {
        //string mark = "noname";
        public void Print(string txt)
        {
            Console.WriteLine($"Текст для печати: {txt}");
        }
    }
    abstract class Scaner  // абстрактный сканер
    {
        public void Scan()
        {

        }
    }

    class PrinterHuawei : Printer // конкретный принтер Huawei
    {
        int price = 200;
        //public static string mark = "Huawei";

        public void Print()
        {
            Console.WriteLine($"Марка принтера - Huawei");
        }
    }
    class PrinterSamsung : Printer // конкретный принтер Samsung
    {
        int price = 210;

        public PrinterSamsung(string txt)
        {
            //Console.WriteLine("Ctor was called!");
        }


        public void Print()
        {
            Console.WriteLine($"Марка принтера - Samsung");
        }
    }
    class HP_Printer : Printer // конкретный принтер HP
    {
        int price = 210;
        public void Print()
        {
            Console.WriteLine($"Марка принтера - HP");
        }
    }

    class ScanerHuawei : Scaner  // конкретный сканер Huawei
    {
        public void Scan()
        {
            FileStream file1 = new FileStream("c:\\note.txt", FileMode.Append); //создаем файловый поток
            StreamWriter print = new StreamWriter(file1); // добавить в файл
            print.WriteLine();
            print.Write(" Сканер Huawei \n");
            print.Close();
        }
    }
    class Samsung_Scaner : Scaner  // конкретный сканер Samsung
    {
        public void Scan()
        {
            FileStream file1 = new FileStream("c:\\note.txt", FileMode.Append); //создаем файловый поток
            StreamWriter print = new StreamWriter(file1); // добавить в файл
            print.WriteLine();
            print.Write(" Сканер Samsung \n");
            print.Close();
        }
    }
    class HP_Scaner : Scaner  // конкретный сканер HP
    {
        public void Scan()
        {
            FileStream file1 = new FileStream("c:\\note.txt", FileMode.Append); //создаем файловый поток
            StreamWriter print = new StreamWriter(file1); // добавить в файл
            print.WriteLine();
            print.Write(" Сканер HP \n");
            print.Close();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string[] buyer = new string[] { "Петя", "Вася", "Дима" };

            var flag = true;

            while (flag)
            {
                Console.WriteLine("Кто пришел??");
                string name = Console.ReadLine();

                if(!buyer.ToList().Contains(name)) break;

                Console.Write("Привет, " + name + " выберите МФУ: ");
                string printer = Console.ReadLine();

                switch (printer)
                {
                    case "Samsung":
                        {
                            MFU mfu = new MFUSamsung("X10");         // абстрактное мфу делаем мфу самсунг 
                            mfu.Print("Lorem ipsum dolor");        // создаем абстрактный принтер в который отправляем текст через текущий конкретный мфу
                            //mfu.Scan();                              // создаем абстрактный сканер и присваиваем ему конкретный сканер из текущего конкретного мфу
                        }
                        break;
                    case "Huawei":
                        {
                            MFU mfu = new MFUHuawei("Xuyinyan10");       // абстрактное мфу делаем мфу самсунг 
                            mfu.Print("Lorem ipsum dolor");                       // создаем абстрактный принтер в который отправляем текст через текущий конкретный мфу
                            //mfu.Scan();                          // создаем абстрактный сканер и присваиваем ему конкретный сканер из текущего конкретного мфу
                        }
                        break;
                    case "HP":
                        {
                            MFU mfu = new MFUHP("Hp100");          // абстрактное мфу делаем мфу самсунг 
                            mfu.Print("Lorem ipsum dolor");                       // создаем абстрактный принтер в который отправляем текст через текущий конкретный мфу
                            //mfu.Scan();                          // создаем абстрактный сканер и присваиваем ему конкретный сканер из текущего конкретного мфу
                        }
                        break;

                    default:
                        Console.WriteLine("Ошибка: Неизвестный производитель");
                        break;
                }
            }
        }
    }
}
