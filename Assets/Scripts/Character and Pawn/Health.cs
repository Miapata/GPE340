using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    private bool dead;
    // Use this for initialization
    public void OnDamage(float damage)
    {
        
        if (health > 0)
        {
            dead = false;
            health -= damage;
        }
        if (health <= 0)
        {
            OnDie();
        }


        GetComponent<Pawn>().healthbarImage.fillAmount = health;


    }

    public void OnDie()
    {

        if (dead == true)
            return;
        dead = true;
        if (tag == "Enemy")
        {

            GameManager.instance.spawner.count++;
            GetComponent<RagdollControls>().StartCoroutine("DieEffect");
          
         
            return;

        }
        //If our lives are greater than zero
        if (GameManager.instance.lives > 0)
        {
            // We subtract the lives by one
            GameManager.instance.lives--;
             // Set the text of the livesText to our lives
            GameManager.instance.livesText.text = GameManager.instance.lives.ToString();
        }
        else
        {
            // Our loss canvas is then set to true
            GameManager.instance.loseCanvas.SetActive(true);
    
        }

        GetComponent<RagdollControls>().StartCoroutine("DieEffect");


    }

    public void Instant()
    {
        OnDie();
    }

    public void OnSpawn()
    {
        GetComponent<Pawn>().healthbarImage.fillAmount = 1;
    }
}
