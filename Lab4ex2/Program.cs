using System;
using System.Collections;
using System.IO;
namespace Lab4ex2
{
    class Program
    {
        public static ArrayList ReadFromFile(string path)
        {
            ArrayList list = new ArrayList();
            string line;
            StreamReader reader = File.OpenText(path);

            while ((line = reader.ReadLine()) != null)
            {
                string[] s = line.Split(new string[]
                {
                    "Назва программи: ", ", Операційна система: ", ", Розмір программи: ", ", Дата запису: "
                }, 4, StringSplitOptions.RemoveEmptyEntries);
                list.Add(new Po(s[0],int.Parse(s[1]), s[2], s[3]));
            }
            reader.Close();
            return list;
        }

        //метод для редагування запису

        public static Po Edit(Po po)
        {
            Console.WriteLine("\nЯке поле ви хочете редагувати?\n\n" +
                                               "Назва программи - 1\n" +
                                               "Операційна система - 2\n" +
                                               "Розмір программи - 3\n" +
                                               "Дата запису - 4\n" +                                            
                                               "Вийти - 5");
            Console.Write("\nВаш вибiр: ");
            int localNum = int.Parse(Console.ReadLine());
            Console.Write("\n");
            Console.Write("Введiть нове значення: ");
            switch (localNum)
            {
                case 1:
                    po.Nameprogram = Console.ReadLine(); break;
                case 2:
                    int occhange = int.Parse(Console.ReadLine());
                    if (occhange < 7 | occhange > 11)
                    {
                        Console.WriteLine("Введіть Windows від 7-11"); break;
                    }
                    else
                    {
                        po.Oc = occhange; break;                     
                    }
                       
                                     
                case 3:
                    string programsizechange = Console.ReadLine();                   
                     break;
                    
                case 4:
                    string datachange = Console.ReadLine();
                    break;
                
                case 5: break;
            }
            return po;
        }
        public static void Write(string path, ArrayList pos)
        {
            StreamWriter streamWriter;
            streamWriter = File.CreateText(path);
            foreach (Po n in pos)
            {
                streamWriter.WriteLine(n);
            }
            streamWriter.Close();
        }

        static void Main(string[] args)
        {
          
            string path = "D:\\database.txt";
        

            ArrayList pos = new ArrayList(new Po[] { });
            while (true)
            {
                
                Console.WriteLine("\n\tМеню\n\n" +
                                  "Додати запис - 1\n" +
                                  "Редагувати запис - 2\n" +
                                  "Видалити запис - 3\n" +
                                  "Вивести усi записи - 4\n" +
                                  "Пошук за операційною системою - 5\n" +
                                  "Вийти - 6");
                try
                {
                    bool breakFlag = false;
                    int a;
                    Console.Write("\nВаш вибiр: ");
                    int choice = int.Parse(Console.ReadLine());
                    Console.Write("\n");
                    switch (choice)
                    {
                        //код для додавання запису

                        case 1:
                            Console.Write("Назва программи: ");
                            string nameprogram = Console.ReadLine();
                            Console.Write("Операційна система: ");
                            int oc =int.Parse (Console.ReadLine());
                            if (oc < 7 || oc > 11)
                            {
                                Console.Write("\nWindows від 7-11\n"); break;
                            }

                            Console.Write("Розмір программи: ");
                            string programsize = Console.ReadLine();
                            
                            Console.Write("Дата запису: ");
                            string data = Console.ReadLine();
                            
                            
                            pos = ReadFromFile(path);
                            Po po = new Po(nameprogram, oc, programsize, data);
                            pos.Add(po);
                            Write(path, pos);
                            break;

                        //код для вибору запису для редагування 

                        case 2:
                           pos = ReadFromFile(path);
                            Console.WriteLine("Який запис хочете редагувати?\n");
                            a = 1;
                            pos.Sort();
                            for (int i = 0; i < pos.Count; i++)
                            {
                                a++;
                                Po n = (Po)pos[i];
                                Console.WriteLine($"{i + 1} - Назва программи: {n.Nameprogram}, Операційна система: {n.Oc}, Розмір программи: {n.Programsize}, Дата запису: {n.Data}");
                            }
                            Console.WriteLine($"{a} - Вийти");
                            Console.Write("\nВаш вибiр: ");
                            int editChoice = int.Parse(Console.ReadLine());
                            if (editChoice == a)
                                break;
                            pos[editChoice - 1] = Edit((Po)pos[editChoice - 1]);
                            Write(path, pos);
                            break;

                        //код для видалення запису

                        case 3:
                            Console.WriteLine("Виберiть запис який хочете видалити\n");
                            a = 1;
                            pos = ReadFromFile(path);
                            pos.Sort();
                            for (int i = 0; i < pos.Count; i++)
                            {
                                a++;
                                Po n = (Po)pos[i];
                                Console.WriteLine($"{i + 1} - Назва программи: {n.Nameprogram}, Операційна система: {n.Oc}, Розмір программи: {n.Programsize}, Дата запису: {n.Data}");

                            }
                            Console.WriteLine($"{a} - Вийти");
                            Console.Write("\nВаш вибiр: ");
                            int deleteChoice = int.Parse(Console.ReadLine());
                            Console.Write("\n");
                            if (deleteChoice == a)
                                break;
                            pos.Remove(pos[deleteChoice - 1]);
                            Write(path, pos);
                            break;

                        //код виведення усіх записів

                        case 4:
                            pos = ReadFromFile(path);
                            pos.Sort();
                            foreach (Po n in pos)
                            {
                                Console.WriteLine($"Назва программи: {n.Nameprogram}, Операційна система: {n.Oc}, Розмір программи: {n.Programsize}, Дата запису: {n.Data}");
                            }
                            Console.WriteLine("\n");
                            break;

                        //код для знаходження за номером групи

                        case 5:
                            int count = 0;
                            pos = ReadFromFile(path);
                            Console.Write("Введiть операційну систему: ");
                            int weekdaynum = int.Parse(Console.ReadLine());
                                Console.Write("\n");
                                
                            foreach (Po n in pos)
                            {
                                if (n.Oc.Equals(weekdaynum))
                                {
                                    Console.WriteLine(n);
                                    count++;
                                    
                                }
                               
                            }
                            if (count == 0)
                            {
                                    Console.Write("Данi про операційну систему не існують \n");
                                  
                                }
                            
                            break;
                        case 6:
                            breakFlag = true;
                            break;
                        default:
                            continue;
                    }
                    if (breakFlag)
                        break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nВводити можна тiльки числа!\n");
                }
            }
        }
    }
}