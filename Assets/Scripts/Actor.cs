using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField]
    Material normal, failing, exposed;

    public enum ActorState
    {
        NORMAL,
        FAILING,
        EXPOSED
    }

    [SerializeField]
    public ActorState state = ActorState.NORMAL;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ActorUpdate()
    {
        switch(state)
        {
            case ActorState.NORMAL:
                spriteRenderer.material = normal;
                break;
            case ActorState.FAILING:
                spriteRenderer.material = failing;
                break;
            case ActorState.EXPOSED:
                spriteRenderer.material = exposed;
                break;
        }
    }
}
