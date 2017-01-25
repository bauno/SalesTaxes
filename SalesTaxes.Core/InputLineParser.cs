using System;

namespace SalesTaxes.Core
{
	public interface InputLineParser
	{
		InputProductLine Parse(string input);
	}
}

