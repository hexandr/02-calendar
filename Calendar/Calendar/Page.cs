using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
	public partial class Page : Form
	{
		private MonthFinder data;
		private Dictionary<int, string> month = new Dictionary<int, string>()
		{
			{1, "January"},
			{2, "February"},
			{3, "March"},
			{4, "April"},
			{5, "May"},
			{6, "June"},
			{7, "July"},
			{8, "August"},
			{9, "September"},
			{10, "October"},
			{11, "November"},
			{12, "December"}
		};
		public Page(DateTime date)
		{
			data = new MonthFinder(date);
			Height = 160;
			Width = 160;
			Paint += PaintDates;
			Paint += PaintMonthYear;
			InitializeComponent();
		}

		private void PaintMonthYear(object sender, PaintEventArgs e)
		{
			var graphics = e.Graphics;
			graphics.DrawString(month[data.Month] + " " + data.Year.ToString(), DefaultFont, Brushes.Blue, 30, 4);
		}

		void PaintDates(object sender, PaintEventArgs e)
		{
			var page = data.GetCalendarPage();
			var x = 4;
			var y = 20;
			const int offset = 20;
			var graphics = e.Graphics;
			for (int i = 0; i < page.Length; i++)
			{
				for (int j = 0; j < page[i].Length; j++)
				{
					var toDraw = page[i][j] == 0 ? " " : page[i][j].ToString();
					graphics.DrawString(toDraw, DefaultFont, Brushes.Black, x + offset*j, y + offset*i);
				}
			}
		}
	}
}
