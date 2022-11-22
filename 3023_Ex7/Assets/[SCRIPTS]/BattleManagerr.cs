using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleManagerr : MonoBehaviour
{

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator AIAnimator;
    public Stats playerStats;
    public Stats enemyStats;
    public bool turn = true; //true = player , false = AI
    public TMP_Text turnText;
    private string turnPlayer = "Player turn";
    private string turnAI = "AI turn";

    
    private float timer = 0;
    private float timerPlayerAnim = 0;
    private float timerAIAnim = 0;
    [SerializeField] private float delay = 1.5f;

    public void FireAttack()
    {
        UseSpell(5, "Player FireSkill", 1);
   
    }
    private void UseSpell(int manaCons, string skillName, int animNumber)
    {

        if (turn)
        {
            if (playerStats.mp != 0 && playerStats.mp >= manaCons)
            {
                playerStats.mp -= manaCons;
                playerAnimator.SetInteger("Skill",animNumber);
                Debug.Log(skillName);

                timerPlayerAnim = delay;
            }
            else
            {
                Debug.Log("not enoughMP");
            }


            turn = false;
            turnText.text = turnAI;
        }
    }
    public void WaterAttack()
    {
        UseSpell(7, "Player WaterSkill", 2);

    }
    public void WindAttack()
    {
        UseSpell(2, "Player WindSkill", 3);
    }
    public void EarthAttack()
    {
        UseSpell(15, "Player EarthSkill", 4);
    }

    private void UseSpellAI(int manaCons, string skillName, int animNumber)
    {

            if (enemyStats.mp != 0 && enemyStats.mp >= manaCons)
            {
            Debug.Log(skillName);
            enemyStats.mp -= manaCons;
            AIAnimator.SetInteger("Skill", animNumber);
            timerAIAnim = delay;
            }
            else
            {
                Debug.Log("not enoughMP from AI");
            }

            turn = true;
            turnText.text = turnPlayer;
        
    }
    private void Update()
    {
       
        if (!turn)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                int _random = Random.Range(1, 5);
                switch(_random)
                {
                    case 1:
                        UseSpellAI(5, "Enemy FireSkill", 1);
                        break;
                    case 2:
                        UseSpellAI(7, "Enemy WaterSkill", 2);
                        break;
                    case 3:
                        UseSpellAI(2, "Enemy WindSkill", 3);
                        break;
                    case 4:
                        UseSpellAI(15, "Enemy EarthSkill", 4);
                        break;

                    default:
                        break;
                }
                timer = 0;
            }
        }
        if(timerPlayerAnim > 0)
        {
            timerPlayerAnim -= Time.deltaTime;
            if(timerPlayerAnim <= 0)
            {
                timerPlayerAnim = 0;
                playerAnimator.SetInteger("Skill", 0);
            }
        }
        if (timerAIAnim > 0)
        {
            timerAIAnim -= Time.deltaTime;
            if (timerAIAnim <= 0)
            {
                timerAIAnim = 0;
                AIAnimator.SetInteger("Skill", 0);
            }
        }

    }
}
