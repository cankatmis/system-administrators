namespace SystemAdministrators
{
    class HolidayShift
    {
        private int start;
        private int end;
        public HolidayShift(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
        public int GetStart()
        {
            return start;
        }
        public int GetEnd()
        {
            return end;
        }
    }
}
