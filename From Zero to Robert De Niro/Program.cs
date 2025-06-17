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

            Console.Clear();
            while (true)
            {
                Console.WriteLine("Вітаю! Я бот-помічник! Обери команду! Слава Скайнет!");
                Console.WriteLine("1 - Перевірити число на парність");
                Console.WriteLine("2 - Таблиця множення числа");
                Console.WriteLine("3 - Порахувати суму чисел");
                Console.WriteLine("4 - Вивести моє ім’я задом наперед");
                Console.WriteLine("5 - Виконати бінарний пошук");
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
                    case "5":
                        RunBinarySearch(); 
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
                Console.Clear();
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
                Console.WriteLine("Число парне.");
            else
                Console.WriteLine("Число непарне.");
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
            string reversed = "";

            for (int i = name.Length - 1; i >= 0; i--)
            {
                reversed += name[i];
            }

            Console.WriteLine("Задом наперед: " + reversed);
        }

        
        static void RunBinarySearch()
        {
            int[][] arrays = new int[][]
            {
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { -10, -5, 0, 5, 10, 15 },
                new int[] { 2, 4, 6, 8, 10, 12, 14, 16 },
                new int[] { 50, 100, 150, 200 },
                new int[] { -20, -10, 0, 10, 20, 30, 40, 50, 60 }
            };

            Console.WriteLine("Оберіть масив для пошуку:");
            for (int i = 0; i < arrays.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {string.Join(", ", arrays[i])}");
            }

            int arrayIndex;
            while (!int.TryParse(Console.ReadLine(), out arrayIndex) || arrayIndex < 1 || arrayIndex > arrays.Length)
            {
                Console.Write("Невірний вибір. Введіть число від 1 до 5: ");
            }

            int[] selectedArray = arrays[arrayIndex - 1];

            Console.Write("Введіть число для пошуку: ");
            int target;
            while (!int.TryParse(Console.ReadLine(), out target))
            {
                Console.Write("Це не число. Спробуйте ще раз: ");
            }

            int result = BinarySearchAlgorithm(selectedArray, target);

            if (result != -1)
            {
                Console.WriteLine($"Значення {target} має індекс {result} у масиві.");
            }
            else
            {
                Console.WriteLine($"Значення {target} не знайдено.");
            }
        }

       
        static int BinarySearchAlgorithm(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (array[middle] == target)
                    return middle;
                else if (array[middle] < target)
                    left = middle + 1;
                else
                    right = middle - 1;
            }

            return -1;
        }
    } 
    }
        




