using System;

namespace SalesTaxes.Core
{
	public interface ProductRegister
	{
		TaxCategory GetTaxCategory (string productName);		
	}
}

