using System.ComponentModel;
using UnityEngine;

public class Element
{
    /// <summary>
    /// The types of elements
    /// </summary>
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
            Type.Water => new Color(68/255f, 124/255f, 207/255f),
            //Element.Water => new Color(118, 187, 78),
            Type.Fire => new Color(230/255f, 75/255f, 75/255f),
            Type.Air => new Color(255/255f, 255/255f, 255/255f),
            Type.Earth => new Color(118/255f, 187/255f, 78/255f),
            _ => throw new InvalidEnumArgumentException("Invalid Element"),
        };
    }
}