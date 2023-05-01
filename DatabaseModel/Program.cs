namespace DatabaseModel
{
    class Program
    {
        static DatabaseModel MakeTestDatabase()
        {
            DatabaseModel db = new DatabaseModel();
            foreach (var val in new string[]{
                "Воин", "Маг", "Убивец"
            })
            {
                db.addClass(val);
            }

            foreach(var tup in new (int, int)[]
            {
                (0, 100), 
                (1, 200), 
                (2, 300), 
                (3, 500), 
                (4, 1000), 
                (5, 1500), 
                (6, 2500), 
                (7, 5000), 
                (8, 10000), 
                (9, 21500), 
                (10, 44444)
            })
            {
                db.addExperienceLevel(tup.Item1, tup.Item2);
            }

            foreach(var tup in new (string, int)[]
            {
                ("Удар", 0),
                ("Пинок", 1),
                ("Волшебный пендель", 1),
                ("Прыжок", 5),
                ("Подлый прыжок", 5),
                ("Сделать врагу больно", 9),
                ("Хрясь-хрясь", 10)
            })
            {
                db.addSpell(tup.Item1, tup.Item2);
            }

            db.addCharacter("Убивака", "Воин");
            db.addCharacter("Старый", "Маг");
            db.addCharacter("Хитрый", "Убивец");

            foreach(var val in new string[]
            {
                "Удар",
                "Пинок", 
                "Сделать врагу больно",
                "Хрясь-хрясь"
            })
            {
                db.addSpellToClass(val, "Воин");
            }

            foreach (var val in new string[]
            {
                "Удар",
                "Волшебный пендель",
                "Сделать врагу больно",
                "Прыжок"
            })
            {
                db.addSpellToClass(val, "Маг");
            }

            foreach (var val in new string[]
            {
                "Удар",
                "Пинок",
                "Сделать врагу больно",
                "Подлый прыжок"
            })
            {
                db.addSpellToClass(val, "Убивец");
            }

            foreach(var character in db.Characters)
            {
                db.addCharacterExperience(character.Name, 0, 0);
            }
            return db;
        }

        static void ListCharacters(DatabaseModel db)
        {
            foreach(var c in db.Characters)
            {
                Console.WriteLine(c.Name);
            }
        }

        static void ListCharactersWithClasses(DatabaseModel db)
        {
            foreach(var c in db.Characters)
            {
                Console.WriteLine($"{c.Name}\t" +
                    $"{db.CharacterClasses.First(x => x.Id == c.CharacterClassID).Name}");
            }
        }

        static void ListClassesWithSpells(DatabaseModel db)
        {
            foreach(var cc in db.CharacterClasses)
            {
                Console.WriteLine($"{cc.Name}:");
                foreach(var spell in 
                    db.Spells.Where(s => 
                    db.CharacterClassBuilds
                    .Where(b => b.CharacterClassId == cc.Id)
                    .Select(b => b.SpellId)
                    .Contains(s.Id)
                    ))
                {
                    Console.WriteLine($"\t{spell.Name}");
                }
            }
        }

        static void ListCharactersWithSpells(DatabaseModel db)
        {
            foreach (var c in db.Characters)
            {
                Console.WriteLine($"{c.Name}:");
                foreach(var spell in
                    db.Spells.Where(s =>
                    db.CharacterClassBuilds
                    .Where(b => b.CharacterClassId == c.CharacterClassID)
                    .Select(b => b.SpellId)
                    .Contains(s.Id)
                    ))
                {
                    Console.WriteLine($"\t{spell.Name}");
                }
            }
        }

        static void AddCharacter(DatabaseModel db)
        {
            Console.WriteLine("Enter character name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter class name");
            string className = Console.ReadLine();
            db.addCharacter(name, className);
        }

        public static void Main()
        {
            DatabaseModel db = MakeTestDatabase();
            int command;

            while (true)
            {
                Console.WriteLine("Select command");
                Console.WriteLine("1. List characters in database");
                Console.WriteLine("2. List characters and their classes");
                Console.WriteLine("3. List classes and their spells");
                Console.WriteLine("4. List characters and their spells");
                Console.WriteLine("5. Add a new character");
                Console.WriteLine("0. Exit");
                command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 0:
                        return;
                    case 1:
                        ListCharacters(db);
                        break;
                    case 2:
                        ListCharactersWithClasses(db);
                        break;
                    case 3:
                        ListClassesWithSpells(db);
                        break;
                    case 4:
                        ListCharactersWithSpells(db);
                        break;
                    case 5:
                        AddCharacter(db);
                        break;
                    default:
                        Console.WriteLine("Wrong command!");
                        break;
                }
            }
            

            
            
            
            
        }
    }
}