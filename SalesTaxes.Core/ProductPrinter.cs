using System;
using System.Collections.Generic;

namespace SalesTaxes.Core
{
	public interface ProductPrinter
	{
		void Print (IEnumerable<Product> products);
	}
}

