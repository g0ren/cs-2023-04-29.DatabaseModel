namespace DatabaseModel
{
    class DatabaseModel
    {
        public List<Spell> Spells { get; private set; }
        public List<CharacterClass> CharacterClasses { get; private set; }
        public List<CharacterClassBuild> CharacterClassBuilds { get; private set; }
        public List<Character> Characters { get; private set; }
        public List<Experience> Experiences { get; private set; }
        public List<CharacterExperience> CharacterExperiences { get; private set; }
        public DatabaseModel()
        {
            Spells = new List<Spell>();
            CharacterClasses = new List<CharacterClass>();
            CharacterClassBuilds = new List<CharacterClassBuild>();
            Characters = new List<Character>();
            Experiences = new List<Experience>();
            CharacterExperiences = new List<CharacterExperience>();
        }
        public void addSpell(string name, int level)
        {
            int experienceId = Experiences.First(x => x.CurrentLevel == level).Id;
            Spells.Add(new Spell(name, experienceId));
        }
        public void addClass(string name)
        {
            CharacterClasses.Add(new CharacterClass(name));
        }
        public void addExperienceLevel(int level, int toNextLevel)
        {
            Experiences.Add(new Experience(level, toNextLevel));
        }

        public void addSpellToClass(string spellName, string className)
        {
            Spell spell = Spells.First((x) => x.Name == spellName);
            if (spell == null)
            {
                spell = new Spell(spellName, 
                    Experiences.First(x => x.CurrentLevel == 0).Id);
                Spells.Add(spell);
            }
            CharacterClass characterClass = CharacterClasses.First((x) => x.Name == className);
            if (characterClass == null)
            {
                characterClass = new CharacterClass(className);
                CharacterClasses.Add(characterClass);
            }
            CharacterClassBuilds.Add(new CharacterClassBuild(characterClass.Id, spell.Id));
        }
        public void addCharacter(string name, string className)
        {
            CharacterClass characterClass;
            try
            {
                characterClass = CharacterClasses.First((x) => x.Name == className);
            }
            catch (Exception ex)
            {
                characterClass = new CharacterClass(className);
                CharacterClasses.Add(characterClass);
            }
            Characters.Add(new Character(name, characterClass.Id));
        }

        public void addCharacterExperience(string charName, int currentLevel, int currentExp)
        {
            Character character = Characters.First(x => x.Name == charName);
            if(character == null)
            {
                character = new Character(charName, CharacterClasses[0].Id);
                Characters.Add(character);
            }
            Experience experience = Experiences.First(x => x.CurrentLevel == currentLevel);
            if(experience == null)
            {
                experience = new Experience(currentLevel, currentExp * 10);
                Experiences.Add(experience);
            }
            CharacterExperience characterExperience =
                new CharacterExperience(character.Id, experience.Id, currentExp);
        }
    }
}