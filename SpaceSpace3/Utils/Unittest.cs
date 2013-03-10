using System;
using NUnit.Framework;

using Utils;

namespace UtilsTesting
{
	[TestFixture()]
	public class Unittest
	{
		[Test()]
		public void TestArrayManip ()
		{
			int[] a = ArrayManip.parseCSV("5,7,4", 3);
			if(a[0] != 5 || a[1] != 7 || a[2] != 4) //i fckn hate c# sometimes
				throw new Exception("Assert Failed");
		}
	}
}

