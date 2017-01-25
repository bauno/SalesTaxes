using System;

namespace SalesTaxes.Core
{
	public class InputProductLine
	{
		public int Qty {
			get;
			set;
		}

		public string Description {
			get;
			set;
		}

		public decimal LinePrice {
			get;
			set;
		}

		public bool Imported {
			get;
			set;
		}


	}
}

