using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    /// <summary>
    /// The Character's State
    /// </summary>
    public enum TurnState
    {
        CHARGING,       //Charging to attack
        ADDTOLIST,      //Getting added to the attack queue
        WAITING,        //Waiting to attack
        SELECTING,      //Choosing their attack
        ACTION,         //Completing their action
        DEAD            //Character is Dead
    }
    //The current state of the character
    public TurnState currentState;

    #region Stats
    //HP Stat for the Character
    [SerializeField] float maxHP = 0;
    [SerializeField] float currentHP = 0;

    //Attack Stat for the Character
    [SerializeField] float Attack = 0;
    [SerializeField] float currentAttack = 0;

    //Defense Stat for the Character
    [SerializeField] float Defense = 0;
    [SerializeField] float currentDefense = 0;

    //Magic Stat for the Character
    [SerializeField] float Magic = 0;
    [SerializeField] float currentMagic = 0;

    //Magic Points Stat for the Character
    [SerializeField] float maxMP = 0;
    [SerializeField] float currMP = 0;

    //How much Charge the character needs to attack
    [SerializeField] float maxCharge = 5f;

    //Character's current Charge
    [SerializeField] float currentCharge = 0f;

    //Character's charge rate
    [SerializeField] float chargeRate = 1f;
    #endregion

    //Visual Indicator for being able to attack
    [SerializeField] Image progressBar;

    //Damage Indicator
    [SerializeField] GameObject damageIndicator;

    //Whether the character is blocking
    public bool isBlocking = false;

    #region Attack
    //The Attacks characters have
    public List<Attack> Attacks = new List<Attack>();

    //The Spells characters have
    public List<Attack> magicAttacks = new List<Attack>();
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Sets the stats correctly at the start of the fight (in case I don't fix something)
        currentAttack = Attack;
        currentDefense = Defense;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateProgressBar()
    {
        currentCharge += Time.deltaTime;
        float calcCharge = currentCharge / maxCharge;
        progressBar.transform.localScale = new Vector3(Mathf.Clamp(calcCharge, 0f, 1f), progressBar.transform.localScale.y, progressBar.transform.localScale.z);

        if(currentCharge >= maxCharge)
        {
            
        }
    }

    /// <summary>
    /// Handles the Character taking Damage
    /// </summary>
    /// <param name="damageAmount"></param>
    void TakeDamage(int damageAmount)
    {
        currentHP -= damageAmount;

        GameObject damage = Instantiate(damageIndicator, transform.position, Quaternion.identity);
        damage.GetComponentInChildren<TextMesh>().text = damageAmount.ToString();
    }

    /// <summary>
    /// Handles the Character doing Damage
    /// </summary>
    void DoDamage()
    {

    }    
}
