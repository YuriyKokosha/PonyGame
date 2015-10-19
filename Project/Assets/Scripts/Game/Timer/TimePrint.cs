using UnityEngine;
using System.Collections;

public class TimePrint
{
	// ------------------------------------------------------------------------------------ //

	public enum TimeFormat 
	{
		HMS,
		MS
	}

	// ------------------------------------------------------------------------------------ //
	
	public static string timeToText (float time, TimeFormat type)
	{
		System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(time);
		switch (type) 
		{
			case TimeFormat.HMS: 	return string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
			case TimeFormat.MS: 	return string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
		}

		SLog.logError("TimeBase getTimeText (float time, TimeFormat type): unknown type == " + type.ToString());
		return null;
	}

	public static double getSystemTimeInMilliseconds () {
		System.DateTime epochStart = new System.DateTime(1970, 1, 1, 1, 0, 0, System.DateTimeKind.Utc);
		double millisecond = (System.DateTime.UtcNow - epochStart).TotalMilliseconds;
		return millisecond;
	}

	// ------------------------------------------------------------------------------------ //
}
