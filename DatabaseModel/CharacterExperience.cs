namespace DatabaseModel
{
    class CharacterExperience
    {
        public int Id { get; private set; }
        public int CharactersId { get; private set; }
        public int ExpirienceId { get; private set; }
        public int Expirience { get; private set; }
        public CharacterExperience(int charactersId, int expirienceId, int expirience)
        {
            Id = new Random().Next();
            CharactersId = charactersId;
            ExpirienceId = expirienceId;
            Expirience = expirience;
        }
    }
}