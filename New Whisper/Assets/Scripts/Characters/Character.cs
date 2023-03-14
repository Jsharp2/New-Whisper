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

    BattleManager battleManager;

    #region Stats
    //HP Stat for the Character
    public float maxHP = 0;
    public float currentHP = 0;

    //Attack Stat for the Character
    public float Attack = 0;
    public float currentAttack = 0;

    //Defense Stat for the Character
    [SerializeField] float Defense = 0;
    public float currentDefense = 0;

    //Magic Stat for the Character
    public float Magic = 0;
    public float currentMagic = 0;

    //Magic Points Stat for the Character
    public float maxMP = 0;
    public float currMP = 0;

    //How much Charge the character needs to attack
    public float maxCharge = 5f;

    //Character's current Charge
    public float currentCharge = 0f;

    //Character's charge rate
    public float chargeRate = 1f;

    public Type Type = Type.Normas;

    public float multihitMultiplier = .8f;
    #endregion

    //Visual Indicator for being able to attack
    [SerializeField] Image progressBar;

    //Damage Indicator
    [SerializeField] GameObject damageIndicator;

    public GameObject Choosen;

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

        currentCharge = Random.Range(0, 3 * maxCharge / 5);

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
    /// Helps moves being done.
    /// </summary>
    void Target()
    {
        Attack attack = battleManager.PerformList[0].choosenAttack;
        
        if(attack.target == global::Attack.Targeting.Single)
        {
            DealDamage(Choosen, attack);
        }

        if (attack.target == global::Attack.Targeting.Multiple)
        {
            if (attack.GetComponentsInParent<Enemy>() != null)
            {
                DealDamage(battleManager.Allies, attack);
            }
            else
            {
                DealDamage(battleManager.Enemies, attack);
            }
        }
        battleManager.CheckAlive();
    }   
    
    /// <summary>
    /// Damages single character
    /// </summary>
    /// <param name="Target"></param>
    /// <param name="attack"></param>
    void DealDamage(GameObject Target, Attack attack)
    {
        int calcDamage;
        float block = 1f;
        Character targeted = Target.GetComponent<Character>();
        Type type = targeted.Type;

        float typeModifier = TypeChart.GetEffectiveness(attack.type, type);

        if (targeted.isBlocking)
        {
            block = .5f;
        }
        else
        {
            block = 1f;
        }

        if (attack.style == global::Attack.Style.Physical)
        {
            calcDamage = Mathf.Clamp((int)((attack.GetComponentInParent<Character>().currentAttack + attack.Damage - targeted.currentDefense) * typeModifier * block), 1, 99999);
        }
        else
        {
            calcDamage = Mathf.Clamp((int)((attack.GetComponentInParent<Character>().currentMagic + attack.Damage - targeted.currentMagic) * typeModifier * block), 1, 99999);
        }
    }

    /// <summary>
    /// Multihit attacks
    /// </summary>
    /// <param name="Targets"></param>
    /// <param name="attack"></param>
    void DealDamage(List<GameObject> Targets, Attack attack)
    {
        int calcDamage;
        float block = 1f;
        foreach(GameObject target in Targets)
        {
            Character targeted = target.GetComponent<Character>();
            Type type = targeted.Type;

            float typeModifier = TypeChart.GetEffectiveness(attack.type, type);

            if(targeted.isBlocking)
            {
                block = .5f;
            }
            else
            {
                block = 1f;
            }

            if(attack.style == global::Attack.Style.Physical)
            {
                calcDamage = Mathf.Clamp((int)((attack.GetComponentInParent<Character>().currentAttack + attack.Damage - targeted.currentDefense) * multihitMultiplier * typeModifier * block), 1, 99999);
            }
            else
            {
                calcDamage = Mathf.Clamp((int)((attack.GetComponentInParent<Character>().currentMagic + attack.Damage - targeted.currentMagic) * multihitMultiplier * typeModifier * block), 1, 99999);
            }

            targeted.TakeDamage(calcDamage);
        }
    }
}
