namespace SalesOptimize.OneToManyMapper.Models
{
	public struct Value
    {
		readonly int _value;

		public int Self
			=> _value;

		public Value(int value)
		{
			_value = value;
		}

		public static bool operator ==(Value value, int val)
		{
			return value._value == val;
		}
		
		public static bool operator !=(Value value, int val)
		{
			return value._value != val;
		}

		public static bool operator ==(Value value, Value value2)
		{
			return value == value2._value;
		}

		public static bool operator !=(Value value, Value value2)
		{
			return value != value2._value;
		}

		public override bool Equals(object obj)
		{
			int v;
			if(!int.TryParse(obj.ToString(), out v))
			{
				if (!Value.TryParse(obj, out v))
					return false;
			}

			return this == v;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return _value.ToString();
		}

		static bool TryParse(object obj, out int value)
		{
			try
			{
				value = ((Value)obj).Self;
				return true;
			}
			catch (System.Exception)
			{
				value = 0;
			}

			return false;
		}
	}
}
