namespace DatabaseModel
{
    class CharacterClass
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public CharacterClass(string name)
        {
            Id = new Random().Next();
            Name = name;
        }
    }
}