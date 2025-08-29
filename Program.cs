    using System;
    using System.Collections.Generic;
using System.ComponentModel;
using System.Formats.Asn1;
    using System.Globalization;
    using System.IO.Compression;
    using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Xml;
class MyApp
{
    class Program
    {
        static void Main()
        {
            Random rand = new Random();
            Dictionary<string, int> items = new Dictionary<string, int>();
            int Key = 5;
            string Input;
            int chanches;
            int Input_key;
            string sword = "🔘 Обычный: Меч 🔘"; 
            string poison = "🟡 Редкий: Зелье 🟡"; 
            string armor = "🟣Легендарная броня🟣"; 

            

            while (true)
            {
                Console.WriteLine("[1]-Открыть кейс🔐 [2]-Посмотреть в склад📦 [3]-Играть в найди ключ🔑 [4]-Сразиться с врагом ⚔️ [5]- Выйти ❌");
                chanches = rand.Next(0, 100);
                int random_key = rand.Next(1, 3);
                Input = Console.ReadLine()!;


                if (Input == "1" && Key > 0)
                {
                    Key--; Console.WriteLine($"У вас осталось: {Key}-ключей ");
                    switch (chanches)
                    {
                        case <= 60:
                            items[sword] = 1;
                            Console.WriteLine($"Поздравляю, вы получили: 🔘 Обычный: Меч 🔘 🔪");
                            break;
                        case <= 90:
                            items[poison] = 2;
                            Console.WriteLine($"Поздравляю, вы получили: 🟡 Редкий: Зелье 🟡 🥤");
                            break;
                        default:
                            items[armor] = 3;
                            Console.WriteLine($"Поздравляю, вы получили: 🟣Легендарная броня🟣 🛡");
                            break;

                    }
                }

                if (Input == "2")
                {
                    foreach (var kvp in items)
                        Console.WriteLine($"{kvp.Key} x{kvp.Value}");
                }
                if (Input == "3")
                {
                    Console.WriteLine("Найди ключ🔑[1][2][3]:");
                    Input_key = Convert.ToInt32(Console.ReadLine());
                    if (Input_key == random_key)
                    {
                        Key++; System.Console.WriteLine($"Поздравляю вы получили ключ🔑, теперь у вас {Key}-ключей");
                    }
                    else
                    {
                        System.Console.WriteLine("В следуший раз повезет😥");
                    }
                }
                if (Input == "4")
                {


                    System.Console.WriteLine("Добро пожаловать в схватку🃏");
                    int PlayerHp = 100;
                    int BotHp = 100;
                    bool InBattle = true;
                    while (InBattle)
                    {
                        int PlayerDmg = rand.Next(10, 20);
                        int PlayerHeal = rand.Next(6, 20);
                        int BotDmg = rand.Next(20, 30);
                        int BotHeal = rand.Next(6, 20);


                        Console.WriteLine($"Ваш HP: {PlayerHp}, HP Бота: {BotHp}");
                        Console.WriteLine("Выберите действие [A]-Атака💥 [H]-Востановление🩹 [BA]-Мега-Удар💪");
                        string action = Console.ReadLine()!;

                        switch (action)
                        {
                            case "A":
                                BotHp -= PlayerDmg;
                                Console.WriteLine($"Вы нанесли {PlayerDmg}-урона 👊, у бота осталось {BotHp}-hp ♥");
                                break;
                            case "H":
                                if (PlayerHp < 100)
                                {
                                    PlayerHp += PlayerHeal;
                                    Console.WriteLine($"Вы вылечились на {PlayerHeal}-hp, теперь у вас {PlayerHp}-hp ♥");
                                    if (PlayerHp > 100) PlayerHp = 100;
                                }
                                break;
                            case "BA":
                                if (items.ContainsKey(poison) && items[poison] > 0 )
                                {
                                    BotHp -= PlayerDmg * 2;
                                    items[poison]--;
                                    Console.WriteLine($"Вы нанесли {PlayerDmg * 2}-урона 💥 (мега-удар), у бота осталось {BotHp}-hp");
                                    Console.WriteLine("Вы потратили 🟡 Редкий: Зелье 🟡");
                                }
                                else Console.WriteLine("❌ У вас нет редкого зелья 🥤"); break;
                        }

                        if (BotHp > 0)
                        {
                            int bot_action = rand.Next(0, 2);

                            if (bot_action == 0)
                            {
                                PlayerHp -= BotDmg;
                                Console.WriteLine($"🤖 Бот атаковал и нанес {BotDmg}-урона, у вас осталось {PlayerHp}-hp ♥");
                            }
                            else
                            {
                                BotHp += BotHeal;
                                if (BotHp > 100) BotHp = 100;
                                Console.WriteLine($"🤖 Бот вылечился на {BotHeal}-hp, теперь у него {BotHp}-hp ♥");
                            }
                        }
                        if (BotHp <= 0)
                        {
                            System.Console.WriteLine("Вы победили🎉");

                            Console.WriteLine("Нажмите [0] чтобы вернуться");
                            Input = Console.ReadLine()!;
                            if (Input == "0") InBattle = false;
                        }

                        if (BotHp <= 0 && PlayerHp <= 0)
                        {
                            System.Console.WriteLine("Ничья😶");
                            Console.WriteLine("Нажмите [0] чтобы вернуться");
                            Input = Console.ReadLine()!;
                            if (Input == "0") InBattle = false;
                        }
                        if (PlayerHp <= 0)
                        {
                            System.Console.WriteLine("Вы проиграли💀");
                            Console.WriteLine("Нажмите [0] чтобы вернуться");
                            Input = Console.ReadLine()!;
                            if (Input == "0") InBattle = false;
                        }


                    }
                }
                if (Input == "5")
                {
                    System.Console.WriteLine("!!!Досвидание!!!");
                    break;
                }

            }
        }
    }
}