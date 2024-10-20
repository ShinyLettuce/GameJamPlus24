using System.Linq;
using UnityEngine;

public class Audience : MonoBehaviour
{

    public bool seesMistake = false;

    [SerializeField]
    LayerMask layerMask;
    public void AudiencePhysicsUpdate(Actor[] actors)
    {
        seesMistake = false;
        foreach (Actor actor in actors)
        {
            if(actor.state != Actor.ActorState.EXPOSED)
            {
                continue;
            }
            Vector3 direction = transform.position - actor.transform.position;
            if (!Physics.Raycast(actor.transform.position, direction, out RaycastHit hit, Mathf.Infinity, layerMask))
            {
                Debug.Log("I See You!");
                seesMistake = true;
            }
            Debug.DrawLine(transform.position, hit.point);
        }
    }
}
