using System;
using System.Collections.Generic;

namespace SalesTaxes.Core
{
	public interface IProductFactory
	{
		IEnumerable<SaleProduct> CreateProducts (IEnumerable<string> inputLines);
	}
}

