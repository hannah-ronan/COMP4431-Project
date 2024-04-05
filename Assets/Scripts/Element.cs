using System.ComponentModel;
using UnityEngine;

public static class Element
{
    public static readonly Color WaterColour = new Color(68 / 255f, 124 / 255f, 207 / 255f);
    public static readonly Color FireColour = new Color(230 / 255f, 75 / 255f, 75 / 255f);
    public static readonly Color AirColour = new Color(239 / 255f, 241 / 255f, 245 / 255f);
    public static readonly Color EarthColour = new Color(118 / 255f, 187 / 255f, 78 / 255f);

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
            Elements.Water => WaterColour,
            Elements.Fire => FireColour,
            Elements.Air => AirColour,
            Elements.Earth => EarthColour,
            Elements.None => Color.clear,
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