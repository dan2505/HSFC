namespace SchoolRecords
{
    public abstract class Student : Person
    {
        private Teacher dos;
        private Subjects studies;

        protected Student(string firstName, string lastName, int age, Address address, Teacher dos) : base(firstName,
            lastName, age, address)
        {
            this.dos = dos;
        }

        public void setDos(Teacher dos)
        {
            this.dos = dos;
        }

        public Teacher getDos()
        {
            return dos;
        }

        public void setSubjects(Subjects subjects)
        {
            studies = subjects;
        }

        public Subjects getSubjects()
        {
            return studies;
        }
    }
}