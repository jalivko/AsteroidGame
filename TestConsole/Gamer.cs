using System;

namespace TestConsole
{
    class Gamer
    {
        public string Name { get; set; }

        public DateTime DayOfBirth { get; set; }

        public Gamer(string Name, DateTime DayOfBirth)
        {
            this.Name = Name;
            this.DayOfBirth = DayOfBirth;
        }

        public string Introduce()
        {
            return $"Великий {Name} рождён {DayOfBirth:dd.MM.yyyy}!";
        }
    }
}
