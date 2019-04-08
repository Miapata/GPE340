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
        GameManager.instance.loseCanvas.SetActive(true);


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
