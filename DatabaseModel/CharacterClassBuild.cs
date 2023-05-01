namespace DatabaseModel
{
    class CharacterClassBuild
    {
        public int Id { get; private set; }
        public int CharacterClassId { get; private set; }
        public int SpellId { get; private set; }
        public CharacterClassBuild(int characterClassId, int spellId)
        {
            Id = new Random().Next();
            CharacterClassId = characterClassId;
            SpellId = spellId;
        }
    }
}