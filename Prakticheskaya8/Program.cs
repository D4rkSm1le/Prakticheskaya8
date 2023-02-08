using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prakticheskaya8
{
    class Program : telo
    {
        static void Main()
        {
            ConsoleKeyInfo start;

            while (true)
            {
                nachalo();
                start = Console.ReadKey();
                if (start.Key == ConsoleKey.Tab)
                    perehod();
            }
        }
    }
    public class recordi
    {
        public string name;
        public int minute;
        public float seconds;
    }
    internal class telo
    {
        private static int sec;
        private static int id = 1;
        private static string Name;
        private static List<recordi> result_tables = new List<recordi>();
        public static void nachalo()
        {
            Console.Clear();
            Console.WriteLine("Результаты: ");
            result_tables.Sort((x, y) =>
            {
                int ret = String.Compare($"{y.minute}", $"{x.minute}");
                return ret != 0 ? ret :
                x.minute.CompareTo(y.minute);
            });
            foreach (recordi a in result_tables)
            {
                Console.WriteLine($"Имя: {a.name}\nРезультат в минуту: {a.minute}\nРезультат в секунду: {a.seconds}\n");
                
            }
            Console.WriteLine($"\nДобавь результат на ТАБ");
        }
        protected static void perehod()
        {
            Console.Clear();
            Console.WriteLine("Введите имя\n");
            Name = Console.ReadLine();
            Console.Clear();
            pechatanie();
            id = 1;
        }
        protected static void pechatanie()
        {

            string txt = "Я прикупил огромный байк. Я прикупил огромный байк. На меня все смотрят и они кричат останься, но теперь прощай, прости, но нам пора расстаться. М-м-м-м-мой байк, я проверил каждый гайк. Всё пиздец трещит, пищит, но это даже как-то в кайф. Я проверил тормоза, не сработали — не беда. Всё равно у меня по плану нажимать только по газам. Садись-ка на сидушку, какая же ты душка. Справа видно палево, значит рулим налево. nЛезь-ка под сидушку, достань оттуда пушку. Снова сраный федерал, па-па-па по нём попал";
            char[] text = txt.ToCharArray();
            int i = 0;
            int position = 0;
            int sop = 0;
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine(txt);
                Console.WriteLine("\nХОЧЕШЬ СТАРТАНУТЬ ну тогда Enter");
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Enter);
            Console.Clear();
            Console.WriteLine(txt);
            Thread po = new Thread(potok);
            po.Start();
            do
            {
                Console.SetCursorPosition(sop, position);
                key = Console.ReadKey(true);
                if (key.KeyChar == text[i])
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.SetCursorPosition(sop, position);
                    Console.WriteLine(text[i]);
                    i++;
                    sop++;
                    if (sop == 120)
                    {
                        sop = 0;
                        position++;
                    }
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(sop, position);
                    Console.WriteLine(text[i]);
                    Console.ResetColor();
                }
            } while (id != 0 && i != text.Length);
            id = 0;
            recordi h = new recordi();
            h.name = Name;
            h.minute = i * 60 / sec;
            h.seconds = (float)i / sec;
            result_tables.Add(h);
        }
        private static void potok()
        {
            sec = -1;
            int i = 60;

            while (i != 0)
            {
                if (id != 0)
                {
                    Console.SetCursorPosition(5, 10);
                    if (i == 60)
                    {
                        Console.WriteLine("1:00");
                    }
                    if (i < 60)
                    {
                        Console.WriteLine($"0:{i}");
                    }
                    i = i - 1;
                    sec++;
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(5, 10);
                    Console.WriteLine(" ");
                }
            }
            id = 0;
            Console.SetCursorPosition(5, 10);
            Console.WriteLine("0:0");
            Thread.Sleep(400);
            Console.SetCursorPosition(5, 10);
            Console.WriteLine("Если ты хочешь ещё раз проверить свои силы, нажми любую кнопку Х_Х");
        }
        
    }
}
