namespace DatabaseModel
{
    class Character
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int CharacterClassID { get; private set; }
        public Character(string name, int characterClassId)
        {
            Id = new Random().Next();
            Name = name;
            CharacterClassID = characterClassId;
        }
    }
}