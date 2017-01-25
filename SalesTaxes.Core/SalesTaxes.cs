using System;
using System.Collections.Generic;

namespace SalesTaxes.Core
{
	public interface SalesTaxes
	{
		void PrintSalesTaxes (IEnumerable<string> productLines);
	}
}

