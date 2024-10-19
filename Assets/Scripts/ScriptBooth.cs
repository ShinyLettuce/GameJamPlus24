using UnityEngine;

public class ScriptBooth : MonoBehaviour
{
    bool scriptGrabable = false;

    public bool ScriptGrabable() => scriptGrabable;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            scriptGrabable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            scriptGrabable = false;
        }
    }
}
