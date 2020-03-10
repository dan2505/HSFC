namespace SchoolRecords
{
    public abstract class Address
    {
        private string houseNumber;
        private string street;
        private string county;
        private string postcode;

        protected Address(string houseNumber, string street, string county, string postcode)
        {
            this.houseNumber = houseNumber;
            this.street = street;
            this.county = county;
            this.postcode = postcode;
        }

        public void setHouseNumber(string houseNumber)
        {
            this.houseNumber = houseNumber;
        }

        public void setStreet(string street)
        {
            this.street = street;
        }

        public void setCounty(string county)
        {
            this.county = county;
        }

        public void setPostCode(string postcode)
        {
            this.postcode = postcode;
        }

        public string getHouseNumber()
        {
            return houseNumber;
        }

        public string getStreet()
        {
            return street;
        }

        public string getCounty()
        {
            return county;
        }

        public string getPostcode()
        {
            return postcode;
        }

        public override string ToString()
        {
            return (houseNumber + ", " + street +
                    ", " + county + ", " + postcode + ".");
        }
    }
}