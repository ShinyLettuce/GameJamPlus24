using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBehaviour : MonoBehaviour
{
    [SerializeField]
    Material normal, failing, exposed;

    enum ActorState
    {
        NORMAL,
        FAILING,
        EXPOSED
    }

    [SerializeField]
    ActorState state = ActorState.NORMAL;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
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
