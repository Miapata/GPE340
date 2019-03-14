using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
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
        if (!GetComponent<Pawn>().isPlayer)
        {
            GetComponent<RagdollControls>().StartCoroutine("DieEffect");
            return;
        }
        GameManager.instance.loseCanvas.SetActive(true);

        
    }

    public void OnSpawn()
    {
        GetComponent<Pawn>().healthbarImage.fillAmount = 1;
    }
}
