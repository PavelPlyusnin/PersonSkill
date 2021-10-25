using System;
using System.Collections.Generic;

namespace PersonSkill.DataModels
{
    public static class ConsoleInterface
    {
        public static void UserInterface()
        {
            ShowNavigationHelper();

            int firstExam = int.Parse(Console.ReadLine()); 
            Conext conext = new Conext(); 
            
            switch (firstExam) {
                case 1: 
                {
                    GetPersonList(conext);
                    UserInterface();
                    break;
                }
                case 2: {
                    GetPersonById(conext);
                    break;
                }
                case 3: 
                {
                    AddPerson(conext);
                    UserInterface();
                    break;
                }
                case 4: 
                {
                    DetectChangeSkill(conext);
                    UserInterface();
                    break;
                }
                case 5: 
                {
                    int idPerson = int.Parse(Console.ReadLine());
                    Repository.DeletePerson(conext, idPerson);
                    UserInterface();
                    break;
                }
                case 6:
                    break;
            }

        }

        private static void GetPersonList(Conext conext)
        {
            IEnumerable<Person> persons = Repository.GetPersons(conext);
            foreach (Person Person in persons)
            {
                Console.WriteLine($"{Person.PersonId} {Person.Name}");
            }
        }
        private static void GetPersonById(Conext conext)
        {
            Console.WriteLine("Введите personId");
            int idPerson = int.Parse(Console.ReadLine());
            Person fperson = Repository.GetPersonById(conext, idPerson);
            string res = $"{fperson.Name}";
            foreach (var skill in fperson.Skills)
            {
                res += $" {skill.Name} {skill.Level} ";
            }

            Console.WriteLine(res);
        }

        private static void DetectChangeSkill(Conext conext) 
        {
            string namePers = Console.ReadLine();
            string nameSkil = Console.ReadLine();
            byte newLevel = byte.Parse(Console.ReadLine());
            Repository.DetectChangeSkill(conext, namePers, nameSkil, newLevel);
        }

        private static void AddPerson(Conext conext) 
        {
            Console.WriteLine("Введите Name");
            string newName = Console.ReadLine();
            Console.WriteLine("Введите DisplayName");
            string displayName = Console.ReadLine();
            Console.WriteLine("Введите количество Skill");
            int countSkills = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите SkillName");
            string nameSkill = Console.ReadLine();
            Console.WriteLine("Введите SkillLevel");
            byte levelSkill = byte.Parse(Console.ReadLine());

            var skills = new List<Skill>();
            var newPerson = new Person()
            {
                Name = newName,
                DisplayName = displayName,
                Skills = skills
            };
            for (int count = 1; countSkills >= count; count++)
            {
                skills.Add(new Skill() { Name = nameSkill, Level = levelSkill });
                Console.WriteLine("Введите SkillName");
                nameSkill = Console.ReadLine();
                Console.WriteLine("Введите SkillLevel");
                levelSkill = byte.Parse(Console.ReadLine());
            }
            Repository.AddPerson(conext, newPerson);
        }
        
        private static void ShowNavigationHelper() 
        {
            Console.WriteLine("Для просмотра всех людей введите 1");
            Console.WriteLine("Для просмотра определенного человека введите 2");
            Console.WriteLine("Для внесенеия нового человека в БД введите 3");
            Console.WriteLine("Для изменения человека введите 4");
            Console.WriteLine("Для удаления удаления человека введите 5");
            Console.WriteLine("Для выхода нажмите 6");
        }

    }
}
