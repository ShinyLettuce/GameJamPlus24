using System.Linq;
using UnityEngine;

public class Audience : MonoBehaviour
{

    [SerializeField]
    LayerMask layerMask;
    public bool AudienceSeesMistake(Actor actor)
    {
        
         if(actor.state != Actor.ActorState.EXPOSED)
         {
            return false;
         }
         Vector3 direction = transform.position - actor.transform.position;
         if (!Physics.Raycast(actor.transform.position, direction, out RaycastHit hit, Mathf.Infinity, layerMask))
         {
             Debug.Log("I See You!");
             return true;
         }
         Debug.DrawLine(transform.position, hit.point);
        return false;
       
    }
}
