using System;

namespace CoachProject
{
    public class Person
    {
        private String name;
        private int age;

        public Person(String name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public String GetName()
        {
            return name;
        }

        public int GetAge()
        {
            return age;
        }

        public void SetName(String name)
        {
            this.name = name;
        }

        public void SetAge(int age)
        {
            this.age = age;
        }

        public override String ToString()
        {
            return GetName() + " is aged " + GetAge();
        }
    }
}