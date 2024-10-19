using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBooth : MonoBehaviour
{
    bool waterGrabable = false;

    public bool WaterGrabable() => waterGrabable;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            waterGrabable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            waterGrabable = false;
        }
    }
}
