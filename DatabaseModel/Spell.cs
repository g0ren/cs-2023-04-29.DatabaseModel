namespace DatabaseModel
{
    class Spell
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int ExperienceId { get; private set; }
        public Spell(string name, int experienceId)
        {
            Id = new Random().Next();
            Name = name;
            ExperienceId = experienceId;
        }
    }
}