using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
	public class MonthFinder
	{
		private readonly int _amountOfDays;
		private readonly DateTime[] _thisMonth;

		public MonthFinder(DateTime date)
		{
			_amountOfDays = GetAmountOfDays(date.Month, date.Year);
			_thisMonth = GetMonth(date);
		}

		public int AmountOfDays { get { return _amountOfDays; } }
		public DateTime[] Month { get { return _thisMonth; } }

		private bool IsLeap(int year)
		{
			if (year%400 == 0)
				return true;
			if (year%100 == 0)
				return false;
			if (year%4 == 0)
				return true;
			return false;
		}

		private int GetAmountOfDays(int month, int year)
		{
			int numOfDays;
			if (IsLeap(year) && month == 2)
				numOfDays = 29;
			else if (month == 2)
				numOfDays = 28;
			else if (month == 4 ||
					 month == 6 ||
					 month == 9 ||
					 month == 11)
				numOfDays = 30;
			else
				numOfDays = 31;
			return numOfDays;
		}

		private DateTime[] GetMonth(DateTime date)
		{
			var month = date.Month;
			var year = date.Year;
			var thisMonth = new DateTime[_amountOfDays];
			for (int i = 1; i <= _amountOfDays; i++)
			{
				thisMonth[i-1] = new DateTime(year, month, i);
			}
			return thisMonth;
		}
	}
}
