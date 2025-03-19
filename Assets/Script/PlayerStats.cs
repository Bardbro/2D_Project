using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public bool canTakeDamage = true;

    private Animator anim;
    private PlayerMoveControl playerMove;
    private Image heathUI;
    private PlayerAttackControls pAC;
    void Start()
    {   
        // health = maxHealth; 
        health = PlayerPrefs.GetFloat("HealthKey", maxHealth);
        heathUI = GameObject.FindGameObjectWithTag("HealthUI").GetComponent<Image>();
        playerMove = GetComponentInParent<PlayerMoveControl>();
        anim = GetComponentInParent<Animator>();

        pAC = GetComponentInParent<PlayerAttackControls>();
         UpdateHeathUI();
        
    }

    public void IncreaseHealth(float heal)
    {
        health += heal;
        if (health > maxHealth)
        health = maxHealth;

        UpdateHeathUI();
        pAC.ResetAttack();
    }
    public void TakeDamage (float damage)
    {
        if (canTakeDamage)
    {
        health -= damage;
        anim.SetBool("Damage", true);
        playerMove.hasControl = false;

        UpdateHeathUI();
        if(health <= 0)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponentInParent<GatherInput>().DisableControls();
            Debug.Log("Player is dead");
            GameManager.ManagerRestartLevel();
        }
        StartCoroutine(DamagePrevention());
    }
    }
    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);
        if (health > 0 )
        {
            canTakeDamage = true;
            playerMove.hasControl = true;
            anim.SetBool("Damage", false);
        }
        else 
        {   
           anim.SetBool("Death", true);
        }
    }
    public void UpdateHeathUI()
    {
        heathUI.fillAmount = health /maxHealth;
    }

   
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("HealthKey");
    }
}
