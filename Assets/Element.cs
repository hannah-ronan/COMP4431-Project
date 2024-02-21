using System.ComponentModel;
using UnityEngine;

public static class Element
{
	/// <summary>
	/// Get Element's  associated colour
	/// </summary>
	/// <param name="element"></param>
	/// <returns></returns>
	/// <exception cref="InvalidEnumArgumentException"></exception>
	public static Color GetColour(Elements element)
	{
		return element switch
		{
			Elements.Water => new Color(68 / 255f, 124 / 255f, 207 / 255f),
			Elements.Fire => new Color(230 / 255f, 75 / 255f, 75 / 255f),
			Elements.Air => new Color(255 / 255f, 255 / 255f, 255 / 255f),
			Elements.Earth => new Color(118 / 255f, 187 / 255f, 78 / 255f),
			Elements.None => Color.white,
			_ => throw new InvalidEnumArgumentException("Invalid Element"),
		};
	}
}

/// <summary>
/// The types of elements
/// </summary>
public enum Elements
{
	//Lightning,
	//Neutral,
	None, // = 1 << 0,
	Air, // = 1 << 1,
	Earth, // = 1 << 2,
	Fire, // = 1 << 3,
	Water, // = 1 <<  4
}