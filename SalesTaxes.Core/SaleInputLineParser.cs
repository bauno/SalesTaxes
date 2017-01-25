using System;
using System.Text.RegularExpressions;

namespace SalesTaxes.Core
{
	public class SaleInputLineParser : InputLineParser
	{
		
		private Regex _regEx;
		private string _assignmentPattern = @"^(\d+) (.*) at (.*)$";


		public SaleInputLineParser ()
		{
			_regEx = new Regex (_assignmentPattern);
		}

		#region InputLineParser implementation
		public InputProductLine Parse (string input)
		{
			var imported = false;
			if (input.Contains("imported")) {
				input = input.Replace("imported ", "");
				imported = true;
			}
				

			if (_regEx.IsMatch (input)) {

				var matches = Regex.Matches (input, _assignmentPattern, RegexOptions.IgnoreCase);
				var qty = matches [0].Groups [1].Value;
				var desc = matches [0].Groups [2].Value;
				var price = matches [0].Groups [3].Value;
				return new InputProductLine {
					Description = desc.Trim(),
					Imported = imported,
					LinePrice = Convert.ToDecimal (price),
					Qty = Convert.ToInt32 (qty)

				};
			}
			throw new ArgumentException ($"The line {input} is not valid");
				
		}
		#endregion
		
	}
}

