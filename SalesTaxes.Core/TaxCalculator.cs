using System;

namespace SalesTaxes.Core
{
	public interface TaxCalculator
	{
		decimal GetImportTaxAmount(decimal price);
		decimal GetSaleTaxAmount(decimal price);
	}
}

