namespace Halloween
{
    class Adult : Human
    {
        public Adult(string name) : base(name)
        {
            Life = 0.5f;
            Blood = 0.5f;
            Candies = 1;
        }

    }
}
