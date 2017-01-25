using System;

namespace SalesTaxes.Core
{
	public class ConsoleDisplay : Display
	{
		#region Display implementation

		public void PrintLine (string line)
		{
			Console.WriteLine (line);
		}

		#endregion


	}
}

