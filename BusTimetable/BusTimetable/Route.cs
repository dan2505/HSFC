namespace BusTimetable
{
    class Route
    {
        private string origin, destination;
        private string[] startTimes;

        public Route(string origin, string destination, string[] startTimes)
        {
            this.origin = origin;
            this.destination = destination;
            this.startTimes = startTimes;
        }

        public string getOrigin()
        {
            return origin;
        }

        public string getDestination()
        {
            return destination;
        }

        public string[] getStartTimes()
        {
            return startTimes;
        }
    }
}