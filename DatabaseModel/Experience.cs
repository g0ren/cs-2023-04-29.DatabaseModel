namespace DatabaseModel
{
    class Experience
    {
        public int Id { get; private set; }
        public int CurrentLevel { get; private set; }
        public int NextLevelExperience { get; private set; }
        public Experience(int currentLevel, int nextLevelExperience)
        {
            Id = new Random().Next();
            CurrentLevel = currentLevel;
            NextLevelExperience = nextLevelExperience;
        }
    }
}