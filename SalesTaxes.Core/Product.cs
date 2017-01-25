using System;

namespace SalesTaxes.Core
{
	public interface Product
	{
		int Qty {get;}
		string Description { get; }
		decimal NetLinePrice { get; }
		decimal GrossLinePrice{ get; }
		bool Imported { get; }
		TaxCategory TaxCategory { get; }
		decimal Taxes { get; }

		void CalculateTaxes (TaxCalculator taxCalculator);			
	}
}

