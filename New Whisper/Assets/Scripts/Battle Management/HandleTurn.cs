using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HandleTurn : MonoBehaviour
{
    public string AttackerName;
    public string Type;
    public GameObject Attacker;
    public GameObject Target;

    public Attack choosenAttack;
}
