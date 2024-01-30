using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Helper.Const
{
	/// <summary>
	/// 班别状态
	/// </summary>
	public struct ShiftType
	{
		/// <summary>
		/// 早班清积
		/// </summary>
		public const string DayClean = "Day;Clean";
		/// <summary>
		/// 晚班清积
		/// </summary>
		public const string NightClean = "Night;Clean";
		/// <summary>
		/// 早班
		/// </summary>
		public const string Day = "Day";
		/// <summary>
		/// 晚班
		/// </summary>
		public const string Night = "Night";
		/// <summary>
		/// 中班
		/// </summary>
		public const string Middle = "Middle";
	}
	/// <summary>
	/// 班别编码
	/// </summary>
	public struct ShiftCode
	{
		public const string Night_TGP = "Night_TGP";

		public const string Day = "Day";

		public const string Night = "Night";

		public const string Middle = "Middle";

		public const string Day_TGP = "Day(08:00~16:00)";
	}
}
