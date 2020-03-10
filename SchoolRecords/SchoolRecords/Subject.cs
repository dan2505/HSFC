namespace SchoolRecords
{
    public abstract class Subject
    {
        private readonly string name;
        private readonly string level;

        protected Subject(string name, string level)
        {
            this.name = name;
            this.level = level;
        }

        public string getName()
        {
            return name;
        }

        public string getLevel()
        {
            return level;
        }

        public override string ToString()
        {
            return level + " " + name;
        }
    }
}