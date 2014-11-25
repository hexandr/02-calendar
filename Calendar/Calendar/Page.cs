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

		private Dictionary<int, string> dayOfWeek = new Dictionary<int, string>()
		{
			{0, "MON"},
			{1, "TUE"},
			{2, "WED"},
			{3, "THU"},
			{4, "FRI"},
			{5, "SAT"},
			{6, "SUN"}
		};

		public Page(DateTime date)
		{
			data = new MonthFinder(date);
			Height = 260;
			Width = 260;
			BackColor = Color.White;
			Paint += PaintDates;
			Paint += PaintMonthYear;
			Paint += PaintDaysOfWeek;
			InitializeComponent();
		}

		private void PaintDaysOfWeek(object sender, PaintEventArgs e)
		{
			var graphics = e.Graphics;
			var font = new Font(FontFamily.GenericMonospace, 10);
			int offset = 34;
			for (int i = 0; i < dayOfWeek.Count; i++)
			{
				graphics.DrawString(dayOfWeek[i], font, Brushes.Teal, 4 + i * offset, 35);
			}
		}

		private void PaintMonthYear(object sender, PaintEventArgs e)
		{
			var graphics = e.Graphics;
			var f = new Font(FontFamily.GenericSansSerif, 16);
			graphics.DrawString(month[data.Month] + "  " + data.Year.ToString(), f, Brushes.Blue, 4, 4);
		}

		void PaintDates(object sender, PaintEventArgs e)
		{
			var page = data.GetCalendarPage();
			var x = 4;
			var y = 55;
			int offset = 34;
			var graphics = e.Graphics;
			var font = new Font(FontFamily.GenericSerif, 18);
			for (int i = 0; i < page.Length; i++)
			{
				for (int j = 0; j < page[i].Length; j++)
				{
					var brush = Brushes.Black;
					if (data.Day == page[i][j])
						brush = Brushes.Red;
					var toDraw = page[i][j] == 0 ? " " : page[i][j].ToString();
					graphics.DrawString(toDraw, font, brush, x + offset*j, y + offset*i);
				}
			}
		}
	}
}
