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
		private readonly int _day;
		private readonly DateTime[] _wholeMonth;

		public int AmountOfDays { get { return _amountOfDays; } }
		public DateTime[] WholeMonth { get { return _wholeMonth; } }
		public int Month { get { return _month; } }
		public int Year { get { return _year; } }
		public int Day { get { return _day; } }

		public MonthFinder(DateTime date)
		{
			_month = date.Month;
			_year = date.Year;
			_day = date.Day;
			_amountOfDays = DateTime.DaysInMonth(_year, _month);
			_wholeMonth = GetMonth();
		}

		private int[] ConvertListOfDays2Week(List<DateTime> listOfDays, bool isFirstWeek)
		{
			int offset = 7 - listOfDays.Count;
			var result = new int[7];
			if (!isFirstWeek)
				return listOfDays.Select(date => date.Day).ToArray();
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
			if (currentWeek.Count != 0)
				weeks.Add(new List<DateTime>(currentWeek));
			var page = new int[6][];
			bool isFirstWeek = true;
			for (int i = 0; i < 6; i++)
			{
				if (i == weeks.Count)
				{
					page[i] = new int[7];
					continue;
				}
				page[i] = ConvertListOfDays2Week(weeks[i], isFirstWeek);
				isFirstWeek = false;
			}
			return page;
		}

		private DateTime[] GetMonth()
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
