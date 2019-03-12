using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Object = System.Object;
using Random = UnityEngine.Random;

[CustomPropertyDrawer(typeof(WeightedObject))]
public class DropController : MonoBehaviour
{
    public List<WeightedObject> dropTable;

    [Serializable]
    public class WeightedObject
    {
        public Object value;
        public float weight;
    }

    public void DropItem()
    {
       
    }

    public Object Select()
    {
        List<float> CDFArray = new List<float>();
        int index = 0;
        float total = 0;

        foreach (WeightedObject drop in dropTable)
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


        return dropTable[selectedIndex].value;
    }
}
