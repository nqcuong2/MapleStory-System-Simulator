using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StatsConstants
{
	public enum AbilityPointType
	{
		HP,
		MP,
		STR,
		DEX,
		INT,
		LUK
	}

	public readonly static int ABILITY_POINTS_PER_LV = 5;
	public readonly static float ONE_HANDED_SWORD_MULTIPLIER = 1.2f;
}
