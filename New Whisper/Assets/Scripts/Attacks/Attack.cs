using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    /// <summary>
    /// How many targets the attack will hit
    /// </summary>
    public enum Targeting
    {
        Single,         //Hits single target
        Multiple,       //Hits multiple targets
        Self,           //Targets user
        Ally,           //Targets ally
        AllyMultiple,   //Targets all Allies
        Everyone
    }

    /// <summary>
    /// Whether it's a physical or magical
    /// </summary>
    public enum Style
    {
        Physical,       //Goes off of Attack of Attacker and Defense of Defender
        Multiple        //Goes off of Magic Stats
    }

    //Default Attack Name
    public string attackName = "Attack Name";

    //Default Vanilla Text of Attack
    public string attackDescription = "Attack Description";

    //Default MP cost for the Attack
    public int attackCosst = 0;

    //Default Damage Amount
    public int Damage = 0;

    //Default Typing of Attack
    public Type type = Type.Normas;

    //Default targeting tyle of Attack
    public Targeting target = Targeting.Single;

    //Default Style of Attack
    public Style style = Style.Physical;
}
