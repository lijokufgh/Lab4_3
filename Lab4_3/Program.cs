namespace Program
{
    public abstract class Program1
    {
        protected abstract void ZapolRnd();
        protected abstract double Max(double[,] mas);
        protected abstract double Max(double[] mas);
        protected abstract double Min(double[,] mas);
        protected abstract double Min(double[] mas);
        protected abstract double Matem(double chi);
        protected abstract void SredStr();
        protected abstract void File(double Max1, double Min1);
    }
    public class Program2 : Program1
    {
        protected Random Rnd = new Random(); // Генератор псевдослучайных чисел.
        private double[,] mas = new double[5, 10]; // Массив на 5 строк и 10 столбцов.
        protected HashSet<int> set = new HashSet<int>(); // Создания хеш сет для хранения уникальных значений.                                                         // 
        protected double[] Sred = new double[5] { 0, 0, 0, 0, 0 };
        protected override void ZapolRnd() // Заполнение массива рандомными, не повторяющимеся значениями.
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int rnd = Rnd.Next(-100, 100); // Инициализация переменной с рандомным значением от -100 до 100.
                    while (set.Contains(rnd)) // Если значение переменной rnd уже есть в хеш сет, генерируем её заново до тех пор пока её значение не станет уникальным.
                    {
                        rnd = Rnd.Next(-100, 100);
                    }
                    set.Add(rnd); // Добавляем в хеш сет переменную.
                    mas[i, j] = rnd; // добавляем переменную в массив.
                    if (j % 10 == 0) Console.WriteLine("");
                    Console.Write($"{mas[i, j]} ");
                }
            }
            Console.WriteLine("");
        }
        protected override double Max(double[,] mas) // Поиск максимального значения.
        {
            double max = -101;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (max < mas[i, j])
                    {
                        max = mas[i, j];
                    }
                }
            }
            Console.WriteLine("");
            return max;
        }
        protected override double Max(double[] mas) // Поиск максимального значения.
        {
            double max = -101;
            for (int i = 0; i < 5; i++)
            {
                if (max < mas[i])
                {
                    max = mas[i];
                }
            }
            Console.WriteLine("");
            return max;
        }
        protected override double Min(double[,] mas) // Поиск минимального значения.
        {
            double min = 101;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (min > mas[i, j])
                    {
                        min = mas[i, j];
                    }
                }
            }
            Console.WriteLine("");
            return min;
        }
        protected override double Min(double[] mas) // Поиск минимального значения.
        {
            double min = 101;
            for (int i = 0; i < 5; i++)
            {
                if (min > mas[i])
                {
                    min = mas[i];
                }

            }
            Console.WriteLine("");
            return min;
        }
        protected override double Matem(double chi)
        {
            for (int i = -10; i < 11; i++)
            {
                Console.Write($"При {i} | sin: {Math.Round(Math.Sin(i * chi), 2)} | "); // Находим синус и округляем до двух знаков после запятой.
                Console.Write($"cos: {Math.Round(Math.Cos(i * chi), 2)} | "); // Находим косинус и округляем до двух знаков после запятой.
                Console.Write($"tan: {Math.Round(Math.Tan(i * chi), 2)}\n"); // Находим тангенс и округляем до двух знаков после запятой.
            }
            return chi;
        }
        protected override void SredStr() // Поиск и вывод среднего значения для каждой строки.
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Sred[i] += Math.Abs(mas[i, j]);

                }
                Sred[i] = (Math.Round(Sred[i], 2) / 10);
                Console.WriteLine(Sred[i]);
            }
        }
        protected override void File(double Max1, double Min1) // Метод дял записи результатов в блокнот.
        {
            string Path = @"C:\Users\lijokufgh\Desktop\222.txt"; //Прописываем путь до текстового файлика
            using (StreamWriter wr = new StreamWriter(Path, false)) // Подключаем возможность взаимодействовать с файлом
            {
                wr.WriteLine("sin cos tan");
                for (int i = -10; i < 11; i++) // Записываем значения в текстовый файл
                {
                    wr.Write($"{Math.Round(Math.Sin(i * Max1), 2)} ");
                    wr.Write($"{Math.Round(Math.Cos(i * Max1), 2)} ");
                    wr.Write($"{Math.Round(Math.Tan(i * Max1), 2)}\n");
                }
                wr.WriteLine("0 0 0");
                wr.WriteLine("0 0 0");
                wr.WriteLine("0 0 0");
                wr.WriteLine("sin cos tan");
                for (int i = -10; i < 11; i++) // Записываем значения в текстовый файл
                {
                    wr.Write($"{Math.Round(Math.Sin(i * Min1), 2)} ");
                    wr.Write($"{Math.Round(Math.Cos(i * Min1), 2)} ");
                    wr.Write($"{Math.Round(Math.Tan(i * Min1), 2)}\n");
                }
            }
        }
        public Program2()
        {
            ZapolRnd();
            Console.Write($"Наибольшее число: {Matem(Max(mas))}\n");
            Console.Write($"Наименьшее число: {Matem(Min(mas))}\n");
            Console.WriteLine("\nСреднее арифметическое для каждой строки:");
            SredStr();
            Console.Write($"Наибольшее число: {Matem(Max(Sred))}\n");
            Console.Write($"Наименьшее число: {Matem(Min(Sred))}\n");
            File(Max(Sred), Min(Sred));
        }
    }
    public class ProgramMain
    {
        static void Main()
        {
            Program2 program1 = new Program2();
        }
    }
}