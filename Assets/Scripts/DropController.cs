using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Random = UnityEngine.Random;

public class DropController : MonoBehaviour
{
    public List<WeightedDrop> dropTable;

    [Serializable]
    public class WeightedDrop
    {
        public GameObject dropObject;
        public float weight;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetRandomItem()
    {
        List<float> CDFArray = new List<float>();
        int index = 0;
        float total = 0;

        foreach (WeightedDrop drop in dropTable)
        {
            total = total + dropTable[index].weight;
            CDFArray.Add(total);
            index++;

        }

        float randomNumber = Random.Range(0.0f, total);

        int selectedIndex = Array.BinarySearch(CDFArray.ToArray(), randomNumber);
        if (selectedIndex < 0)
        {
            selectedIndex = ~selectedIndex;
        }
        

        return dropTable[selectedIndex].dropObject;
    }
}
