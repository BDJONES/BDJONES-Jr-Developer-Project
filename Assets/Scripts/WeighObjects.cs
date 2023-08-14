using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeighObjects : MonoBehaviour
{
    private List<GameObject> allWeightedObjects;
    public float calculatedWeight;
    // Start is called before the first frame update
    void Start()
    {
        allWeightedObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        calculatedWeight = GetTotalObjectWeight();
        Debug.Log("allWeightedObjects.Count = " + allWeightedObjects.Count.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.CompareTag("WeightedObject") && gameObject.CompareTag("Scale"))
        {
            Debug.Log("There was a collision detected");
            allWeightedObjects.Add(otherObject);
        }

        
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.CompareTag("WeightedObject") && gameObject.CompareTag("Scale"))
        {
            Debug.Log("There was a collision detected");
            allWeightedObjects.Remove(otherObject);
            calculatedWeight -= otherObject.GetComponent<Rigidbody>().mass;
        }
    }
    private float GetTotalObjectWeight()
    {
        float totalWeight = 0;
        for (int i = 0; i < allWeightedObjects.Count; i++)
        {
            totalWeight += allWeightedObjects[i].GetComponent<Rigidbody>().mass;
        }
        Debug.Log("totalWeight = " + totalWeight.ToString());
        return totalWeight;
    }
}
