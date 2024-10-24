using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    public TMP_Text distanceText;

    public GameObject startPoint;
    public GameObject endPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(startPoint.transform.position, endPoint.transform.position);

        distanceText.text = distance.ToString();
    }
}
