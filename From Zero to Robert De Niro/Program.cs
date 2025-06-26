using System.Text;
using System.Xml.Linq;

namespace From_Zero_to_Robert_De_Niro
{
    internal class Program
    {
        static Dictionary<string, string> contacts = new Dictionary<string, string>();

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
                Console.WriteLine("6 - Бінарний пошук у введеному масиві");
                Console.WriteLine("7 - Контакти (додавання, пошук, перегляд, видалення)");
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
                    case "6":
                        CustomBinarySearch();
                        break;
                    case "7":
                        ManageContacts();
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
            int[][] testArrays = new int[][]
            {
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { -10, -5, 0, 5, 10, 15 },
                new int[] { 2, 4, 6, 8, 10, 12, 14, 16 },
                new int[] { 50, 100, 150, 200 },
                new int[] { -20, -10, 0, 10, 20, 30, 40, 50, 60 }
            };

            Console.WriteLine("Оберіть масив:");
            for (int i = 0; i < testArrays.Length; i++)
                Console.WriteLine($"{i + 1}: [{string.Join(", ", testArrays[i])}]");

            int index;
            while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > testArrays.Length)
                Console.Write("Некоректний вибір. Спробуйте ще раз: ");

            int[] array = testArrays[index - 1];
            Console.Write("Введіть число для пошуку: ");
            int target;
            while (!int.TryParse(Console.ReadLine(), out target))
                Console.Write("Це не число. Спробуйте ще раз: ");

            int result = BinarySearchAlgorithm(array, target);
            Console.WriteLine(result != -1 ? $"Знайдено на позиції {result}." : "Елемент не знайдено.");
        }

        static void CustomBinarySearch()
        {
            Console.Write("Введіть числа через пробіл: ");
            string[] input = Console.ReadLine().Split();
            int[] array = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                while (!int.TryParse(input[i], out array[i]))
                {
                    Console.Write($"'{input[i]}' не є числом. Введіть ще раз: ");
                    input[i] = Console.ReadLine();
                }
            }
             

            Array.Sort(array);
            Console.Write("Введіть число для пошуку: ");
            int target;
            while (!int.TryParse(Console.ReadLine(), out target))
            {
                Console.Write("Це не число. Спробуйте ще раз: ");

                int result = BinarySearchAlgorithm(array, target);
                Console.WriteLine(result != -1 ? $"Знайдено на позиції {result}." : "Елемент не знайдено.");
            }
        }

        static int BinarySearchAlgorithm(int[] array, int target)
        {
            int left = 0, right = array.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] == target) return mid;
                else if (array[mid] < target) left = mid + 1;
                else right = mid - 1;
            }
            return -1;
        }

        static void ManageContacts()
        {
            while (true)
            {
                Console.WriteLine("\n--- Контактна книга ---");
                Console.WriteLine("1 - Додати контакт");
                Console.WriteLine("2 - Пошук контакту");
                Console.WriteLine("3 - Показати всі контакти");
                Console.WriteLine("4 - Видалити контакт");
                Console.WriteLine("0 - Назад до головного меню");
                Console.Write("Вибір: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Введіть ім’я: ");
                        string name = Console.ReadLine();
                        Console.Write("Введіть номер телефону: ");
                        string phone = Console.ReadLine();
                        contacts[name] = phone;
                        Console.WriteLine("Контакт додано.");
                        break;

                    case "2":
                        Console.Write("Введіть ім’я: ");
                        string search = Console.ReadLine();
                        if (contacts.ContainsKey(search))
                            Console.WriteLine($"{search}: {contacts[search]}");
                        else
                            Console.WriteLine("Контакт не знайдено.");
                        break;

                    case "3":
                        if (contacts.Count == 0)
                            Console.WriteLine("Список порожній.");
                        else
                            foreach (var pair in contacts)
                                Console.WriteLine($"{pair.Key}: {pair.Value}");
                        break;

                    case "4":
                        Console.Write("Введіть ім’я: ");
                        string del = Console.ReadLine();
                        if (contacts.Remove(del))
                            Console.WriteLine("Контакт видалено.");
                        else
                            Console.WriteLine("Контакт не знайдено.");
                        break;

                    case "0": return;

                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }
    }
}
        




