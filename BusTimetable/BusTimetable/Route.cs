namespace BusTimetable
{
    internal class Route
    {
        private readonly string _origin;
        private readonly string _destination;
        private readonly int _routeCount;
        private readonly string[] _startTimes;

        public Route(string origin, string destination, string[] startTimes, int routeCount)
        {
            _origin = origin;
            _destination = destination;
            _startTimes = startTimes;
            _routeCount = routeCount;
        }

        public string GetOrigin()
        {
            return _origin;
        }

        public string GetDestination()
        {
            return _destination;
        }

        public string[] GetStartTimes()
        {
            return _startTimes;
        }

        public int GetRouteCount()
        {
            return _routeCount;
        }
    }
}