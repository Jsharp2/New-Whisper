using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    /// <summary>
    /// Enum handling actions at given time
    /// </summary>
    public enum PerformAction
    {
        WAIT,
        TAKEACTION,
        CHECKALIVE,
        WIN,
        LOSE,
        ESCAPE
    }

    /// <summary>
    /// Enum controls what appears when
    /// </summary>
    public enum HEROGUI
    {
        ACTIVATE,
        WAITING,
        DONE
    }

    public PerformAction battleStates;
    public HEROGUI heroInput;

    public List<HandleTurn> PerformList = new List<HandleTurn>();
    public List<GameObject> Allies = new List<GameObject>();
    public List<GameObject> Enemies = new List<GameObject>();
    public List<GameObject> Characters = new List<GameObject>();

    public List<GameObject> alliesToManage = new List<GameObject>();
    HandleTurn playerChoice;

    public GameObject enemyButton;
    public Transform spacer;

    public GameObject heroPanel;
    public Transform heroSpacer;

    public GameObject attackPanel;
    public GameObject enemySelectPanel;
    public GameObject magicPanel;
    public GameObject Inventory;

    public Transform actionSpacer;
    public Transform magicSpacer;

    public GameObject actionButton;
    public GameObject baseMagicButton;

    public Type attackType;

    public GameObject spellPanel;
    private List<GameObject> atkBtns = new List<GameObject>();

    private List<GameObject> enemyButtons = new List<GameObject>();

    public List<Transform> spawnPoints = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Checks that every character is still supposed to be alive.
    /// </summary>
    public void CheckAlive()
    {
        foreach(GameObject character in Characters)
        {
            if(character.GetComponent<Character>().currentHP <= 0)
            {
                character.GetComponent<Character>().currentState = Character.TurnState.DEAD;
            }
        }
    }


}
