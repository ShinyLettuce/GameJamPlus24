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
            RaycastHit hit;
            Vector3 direction = actor.transform.position - transform.position;
            if (!Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log("I See You!");
                seesMistake = true;
            }
            Debug.DrawLine(transform.position, hit.point);
        }
    }
}
