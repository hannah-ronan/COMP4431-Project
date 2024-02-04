using System.ComponentModel;
using UnityEngine;

public class Element
{
    public enum Type
    {
        //Lightning,
        //Neutral,
        //None,
        Air,
        Earth,
        Fire,
        Water,
    }
    /// <summary>
    /// Get Element's  associated colour
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    /// <exception cref="InvalidEnumArgumentException"></exception>
    public static Color GetColour(Type element)
    {
        return element switch
        {
            Type.Water => new Color(68, 124, 207),
            //Element.Water => new Color(118, 187, 78),
            Type.Fire => new Color(230, 75, 75),
            Type.Air => new Color(255, 255, 255),
            Type.Earth => new Color(118, 187, 78),
            _ => throw new InvalidEnumArgumentException("Invalid Element"),
        };
    }
}