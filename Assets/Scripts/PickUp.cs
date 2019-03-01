using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PickUp : MonoBehaviour
{
    //Rotate speed for the object
    public float rotateSpeed;


    public PickupsManager.Items item;
    public void Update()
    {
        Rotate();
    }
    private void OnTriggerEnter(Collider collider)
    {

        if (collider != null)
        {
            print("Player detected");
            OnPickUp(collider.gameObject);
        }
        else
        {
            Debug.Log("No player detected");
        }
    }


    public virtual void OnPickUp(GameObject player)
    {
        GameObject go;
        Pawn pawn = player.GetComponent<Pawn>();
        switch (item)
        {

            case PickupsManager.Items.M4:
                if (player.GetComponent<Pawn>().equppiedItem != null)
                {
                    Destroy(player.GetComponent<Pawn>().equppiedItem);
                }
                go = Instantiate(PickupsManager.instance.m4, player.GetComponent<Pawn>().weaponPlacementPoint);
                pawn.equppiedItem = go.gameObject;
                pawn.LHPoint = go.transform.GetChild(1);
                pawn.RHPoint = go.transform.GetChild(0);

                break;
            case PickupsManager.Items.Sword:
                if (player.GetComponent<Pawn>().equppiedItem != null)
                {
                    Destroy(player.GetComponent<Pawn>().equppiedItem);
                }
                go = Instantiate(PickupsManager.instance.sword, player.GetComponent<Pawn>().weaponPlacementPoint);
                pawn.equppiedItem = go;
                pawn.LHPoint = go.transform.GetChild(1);
                pawn.RHPoint = go.transform.GetChild(0);
                break;

            case PickupsManager.Items.Health:
                Instantiate(PickupsManager.instance.health,player.transform);
               
                break;
        }

        Destroy(gameObject);


    }
    public void Rotate()
    {
        transform.Rotate(transform.up, rotateSpeed * Time.deltaTime);
    }
}
