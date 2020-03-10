using System;

namespace SchoolRecords
{
    public abstract class Teacher : Person
    {
        private readonly Subjects teaches;

        protected Teacher(string firstName, string lastName, int age, Address address) : base(firstName, lastName, age,
            address)
        {
            teaches = new Subjects(6);
        }

        public override string ToString()
        {
            return base.ToString() + "Teaches:" + Environment.NewLine + teaches;
        }
    }
}