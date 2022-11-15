using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleManagerr : MonoBehaviour
{

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator AIAnimator;

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
        if(turn)
        {
            Debug.Log("Player fireAttack");
            playerAnimator.SetInteger("Skill", 1);
            timerPlayerAnim = delay;
            turn = false;
            turnText.text = turnAI;
        }
    }
    public void WaterAttack()
    {
        if (turn)
        {
            Debug.Log("Player waterAttack");
            playerAnimator.SetInteger("Skill", 2);
            timerPlayerAnim = delay;
            turn = false;
            turnText.text = turnAI;
        }
  
    }
    public void WindAttack()
    {
        if (turn)
        {
            Debug.Log("Player windAttack");
            playerAnimator.SetInteger("Skill", 3);
            timerPlayerAnim = delay;
            turn = false;
            turnText.text = turnAI;
        }
   
    }
    public void EarthAttack()
    {
        if (turn)
        {
            Debug.Log("Player earthAttack");
            playerAnimator.SetInteger("Skill", 4);
            timerPlayerAnim = delay;
            turn = false;
            turnText.text = turnAI;
        }
      
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
                        Debug.Log("AI fireAttack");
                        AIAnimator.SetInteger("Skill", 1);
                        timerAIAnim = delay;
                        turn = true;
                        turnText.text = turnPlayer;
                        break;
                    case 2:
                        Debug.Log("AI waterAttack");
                        AIAnimator.SetInteger("Skill", 2);
                        timerAIAnim = delay;
                        turn = true;
                        turnText.text = turnPlayer;
                        break;
                    case 3:
                        Debug.Log("AI windAttack");
                        AIAnimator.SetInteger("Skill", 3);
                        timerAIAnim = delay;
                        turn = true;
                        turnText.text = turnPlayer;
                        break;
                    case 4:
                        Debug.Log("AI earthAttack");
                        AIAnimator.SetInteger("Skill", 4);
                        timerAIAnim = delay;
                        turn = true;
                        turnText.text = turnPlayer;
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
