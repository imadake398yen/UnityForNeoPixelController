public static partial class Const
{
	public enum LEDPattern
	{
		RandomChange,
		LerpDark,
		LerpDarkRed
	}

	/// <summary>
	/// enum値をintで返却します.
	/// </summary>
	public static int ToInt(this Const.LEDPattern val)
	{
		return (int)val;
	}
}
