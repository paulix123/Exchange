namespace Exchange
{
    public class Currency
    {
        public string name;
        public string iso;
        public double rate;

        public Currency(string name, string iso, double rate)
        {
            this.name = name;
            this.iso = iso;
            this.rate = rate;
        }
    }
}
