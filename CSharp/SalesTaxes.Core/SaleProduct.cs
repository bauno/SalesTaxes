using System;

namespace SalesTaxes.Core
{
	public class SaleProduct : Product
	{
		private decimal? _taxes;

		public SaleProduct (InputProductLine productLine, TaxCategory taxCategory)
		{
			Qty = productLine.Qty;
			Description = productLine.Description;
			NetLinePrice = productLine.LinePrice;
			Imported = productLine.Imported;
			TaxCategory = taxCategory;
		}

		public decimal Taxes {
			get {
				if (_taxes.HasValue)
					return _taxes.Value;
				throw new InvalidOperationException ("Taxes for product not yet calculated");
			}
		}


		public decimal GrossLinePrice {
			get {
				if (_taxes.HasValue)
					return NetLinePrice + _taxes.Value;
				throw new InvalidOperationException ("Taxes for product not yet calculated");
			}				
				
		}

		public int Qty {
			get;
			private set;
		}

		public string Description {
			get;
			private set;
		}

		public decimal NetLinePrice {
			get;
			private set;
		}

		public bool Imported {
			get;
			private set;
		}

		public TaxCategory TaxCategory {
			get;
			private set;
		}


		public void CalculateTaxes (TaxCalculator taxCalculator)
		{
			_taxes = 0.0m;
			if (TaxCategory == TaxCategory.Other)
				_taxes += taxCalculator.GetSaleTaxAmount (NetLinePrice);
			if (Imported)
				_taxes += taxCalculator.GetImportTaxAmount (NetLinePrice);
		}
	}
}

