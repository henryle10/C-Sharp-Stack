namespace Human
{
    public class Human
    {
        // Fields for Human
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        private int _health { get; set; }

        // add a public "getter" property to access health
        public int Health { get { return _health; } }

        // Add a constructor that takes a value to set Name, and set the remaining fields to default values
        public Human(string name, int strength = 3, int intelligence = 3, int dexterity = 3)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            _health = 100;
        }

        // Add a constructor to assign custom values to all fields
        public Human(string name, int strength, int intelligence, int dexterity, int health)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            _health = health;
        }

        // Build Attack method
        public int Attack(Human target)
        {
            target._health -= this.Strength * 5;
            return _health;
        }
    }
}