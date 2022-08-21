using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The typing of an attack or character
/// </summary>
public enum Type
{
    Ignis,      //Fire Attacks,     Can cause Attack drops
    Auqas,      //Water Attacks,    Can Cause Defense drops
    Natura,     //Nature Attacks,   Can Cause Magic drops
    Normas,     //Normal Attacks,   Basic Attack Style
    Lumon,      //Light Attacks,    Healing and Buffs
    Morton      //Dark Attacks,     Can cause any drops
}

public class TypeChart
{
    //Not Effective to Defender
    static float not = 0.6f;

    //Super Effective to Defnder
    static float eff = 1.5f;

    //Base Effecitve to Defender
    static float bas = 1f;

    //Chart for Effectiveness
    static float[][] chart =
    {
       //                        Ignis, Aquas, Natura, Normas, Lumon, Morton Defending
       /* Ignis */  new float[] {not,   eff,   bas,    bas,    bas,   not},
       /* Auqas */  new float[] {not,   not,   eff,    bas,    bas,   not},
       /* Natura */ new float[] {eff,   not,   not,    bas,    bas,   not},
       /* Normas */ new float[] {bas,   bas,   bas,    bas,    bas,   bas},
       /* Lumon */  new float[] {bas,   eff,   bas,    bas,    not,   eff},
       /* Morton */ new float[] {bas,   eff,   bas,    bas,    not,   eff}
      // Attacking
    };

    /// <summary>
    /// Returns a multiplier for damage done by a move
    /// </summary>
    /// <param name="attackingType"></param>
    /// <param name="defendingType"></param>
    /// <returns></returns>
    public static float GetEffectiveness(Type attackingType, Type defendingType)
    {
        int row = (int)attackingType - 1;
        int col = (int)defendingType - 1;
        return chart[row][col];
    }
}