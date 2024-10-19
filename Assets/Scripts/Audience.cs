using UnityEngine;

public class Audience : MonoBehaviour
{
    [SerializeField]
    GameObject actorRef;

    Transform actorTransform;

    public bool seesMistake = false;

    [SerializeField]
    LayerMask layerMask;

    void Awake()
    {
        actorTransform = actorRef.GetComponent<Transform>();
    }

    public void AudiencePhysicsUpdate()
    {
        seesMistake = false;
        RaycastHit hit;
        Vector3 direction = actorTransform.position - transform.position;
        if (!Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("I See You!");
            seesMistake = true;
        }
        Debug.DrawLine(transform.position, hit.point);
    }
}
