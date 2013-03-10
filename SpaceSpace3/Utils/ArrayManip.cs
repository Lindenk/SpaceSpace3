using System;

namespace Utils
{
	public static class ArrayManip
	{
		public static int[] parseCSV(string csv, int size)
		{
			int[] retVec = new int[size];
			for(int i = 0, ri = 0; i < csv.Length; i++, ri++)
			{
				//find the end of the vector before the comma
				int j = i;
				while(j < csv.Length && csv[j] != ',')
				{
					if(csv[j] == '\n')
						break;
					j++;
				}

				//parse the substring between i and j
				retVec[ri] = Convert.ToInt32(csv.Substring(i, j-i));
				i = j;
			}

			return retVec;
		}
	}
}

