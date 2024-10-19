using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceVision : MonoBehaviour
{
    [SerializeField]
    GameObject actorRef;

    Transform actorTransform;

    [SerializeField]
    LayerMask obstructionMask;
    void Start()
    {
        actorTransform = actorRef.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = actorTransform.position - transform.position;
        if (Physics.Raycast(transform.position, direction, obstructionMask))
        {
            Debug.Log("I See You!");
        }
    }
}
