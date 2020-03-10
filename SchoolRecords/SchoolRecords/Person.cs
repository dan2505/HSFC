using System;

namespace SchoolRecords
{
    public class Person
    {
        private string firstName, lastName;
        private int age;
        private Address address;

        protected Person(string firstName, string lastName, int age, Address address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.address = address;
        }

        public void setFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public void setLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string getLastName()
        {
            return lastName;
        }

        public void setAge(int theAge)
        {
            age = theAge;
        }

        public int getAge()
        {
            return age;
        }

        public void setAddress(Address address)
        {
            this.address = address;
        }

        public Address getAddress()
        {
            return address;
        }

        public override string ToString()
        {
            return firstName +
                   lastName +
                   " is aged " +
                   age +
                   Environment.NewLine +
                   address;
        }
    }
}