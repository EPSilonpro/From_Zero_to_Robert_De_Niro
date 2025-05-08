using System.Text;
using System.Xml.Linq;

namespace From_Zero_to_Robert_De_Niro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            

            while (true)
            {
                
                Console.WriteLine("Вітаю! Я ботяра є...на! Обери команду! Слава Скайнет! Термінатор ЛОХ! Джон Коннор друг ЛОХА!");
                Console.WriteLine("1 - Перевірити число на парність");
                Console.WriteLine("2 - Таблиця множення числа");
                Console.WriteLine("3 - Порахувати суму чисел");
                Console.WriteLine("4 - Вивести моє ім’я задом наперед");
                Console.WriteLine("0 - Вийти з програми");
                Console.Write("Введіть свій вибір: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CheckEven();
                        break;
                    case "2":
                        ShowMultiplicationTable();
                        break;
                    case "3":
                        SumNumbers();
                        break;
                    case "4":
                        ReverseName();
                        break;
                    case "0":
                        Console.WriteLine("До побачення!");
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }

                Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
            }
        }

        static void CheckEven()
        {
            int num = 0;
            bool valid = false;


            while (!valid)
            {
                Console.Write("Введіть число: ");
                valid = int.TryParse(Console.ReadLine(), out num);

                if (!valid)
                {
                    Console.WriteLine("Це не число. Спробуйте ще раз.");
                }
            }
            if (num % 2 == 0)
            {
                Console.WriteLine("Число парне.");
            }
            else
            {
                Console.WriteLine("Число непарне");
            }
            
        }

        static void ShowMultiplicationTable()
        {
            Console.Write("Введіть число: ");
            string input = Console.ReadLine();
            int num;

            while (!int.TryParse(input, out num))
            {
                Console.Write("Це не число. Спробуйте ще раз: ");
                input = Console.ReadLine();
            }

           
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{num} × {i} = {num * i}");
            }
        }

        static void SumNumbers()
        {
            Console.Write("Скільки чисел ви хочете додати? ");
            string input = Console.ReadLine();
            int count;

            while (!int.TryParse(input, out count) || count <= 0)
            {
                Console.Write("Некоректна кількість. Спробуйте ще раз: ");
                input = Console.ReadLine();
            }

            int[] numbers = new int[count];

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Введіть число {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out numbers[i]))
                {
                    Console.Write("Це не число. Спробуйте ще раз: ");
                }
            }

            int sum = 0;
            
            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"Сума: {sum}");
        }

        static void ReverseName()
            
        {
           
            Console.Write("Введіть ім’я: ");
            string name = Console.ReadLine();
            string reversed = new string(name.Reverse().ToArray());
            Console.WriteLine("Задом наперед: " + reversed);
        }
        }
}
