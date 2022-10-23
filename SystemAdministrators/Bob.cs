using System;
namespace SystemAdministrators
{
    class Bob
    {
        HolidayShift[] shifts;
        int shiftNumber;
        int counter = 0;
        public Bob(int shiftNumber)
        {
            this.shifts = new HolidayShift[shiftNumber];
            this.shiftNumber = shiftNumber;
        }
        public void AddShift(HolidayShift shift)
        {
            if (counter < shiftNumber)
                shifts[counter] = shift;
            else
                Console.WriteLine("Array is full!");
            counter++;
        }
        public HolidayShift[] GetShifts()
        {
            return shifts;
        }
    }
}
