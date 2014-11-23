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
		private readonly int _month;
		private readonly int _year;
		private readonly DateTime[] _wholeMonth;

		public MonthFinder(DateTime date)
		{
			_month = date.Month;
			_year = date.Year;
			_amountOfDays = GetAmountOfDays();
			_wholeMonth = GetMonth(date);
		}

		private int[] ConvertListOfDays2Week(List<DateTime> listOfDays)
		{
			int offset = 7 - listOfDays.Count;
			var result = new int[7];
			for (int i = 0; i < 7; i++)
			{
				int day = i < offset ? 0 : listOfDays[i - offset].Day;
				result[i] = day;
			}
			return result;
		}
		public int[][] GetCalendarPage()
		{
			var currentWeek = new List<DateTime>();
			var weeks = new List<List<DateTime>>();
			foreach (var day in _wholeMonth)
			{
				currentWeek.Add(day);
				if (day.DayOfWeek != DayOfWeek.Sunday) continue;
				weeks.Add(new List<DateTime>(currentWeek));
				currentWeek.Clear();
			}
			return weeks.Select(ConvertListOfDays2Week).ToArray();
		}

		public int AmountOfDays { get { return _amountOfDays; } }
		public DateTime[] Month { get { return _wholeMonth; } }

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

		private int GetAmountOfDays()
		{
			int numOfDays;
			if (IsLeap(_year) && _month == 2)
				numOfDays = 29;
			else if (_month == 2)
				numOfDays = 28;
			else if (_month == 4 || _month == 6 || _month == 9 || _month == 11)
				numOfDays = 30;
			else
				numOfDays = 31;
			return numOfDays;
		}

		private DateTime[] GetMonth(DateTime date)
		{
			var thisMonth = new DateTime[_amountOfDays];
			for (int i = 1; i <= _amountOfDays; i++)
			{
				thisMonth[i-1] = new DateTime(_year, _month, i);
			}
			return thisMonth;
		}
	}
}
