﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar;
using NUnit.Framework;

namespace MonthTest
{
	[TestFixture]
	public class MonthFinderTests
	{
		[Test]
		public void CalculatingAmountOfDays()
		{
			var date = new DateTime(2014, 11, 1);
			var mf = new Calendar.MonthFinder(date);
			Assert.AreEqual(30, mf.AmountOfDays);
		}

		[Test]
		public void GetDaysOfMonth()
		{
			var date = new DateTime(2014, 11, 1);
			var mf = new Calendar.MonthFinder(date);
			Assert.AreEqual(new DateTime(2014, 11, 20), mf.Month[19]);
		}
	}
}