using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField]
    Material normal, wobbly, failing, exposed;

    public enum ActorState
    {
        NORMAL,
        WOBBLY,
        FAILING,
        EXPOSED
    }

    public ActorState state = ActorState.NORMAL;

    SpriteRenderer spriteRenderer;

    float failingCounter = 0f, exposedCounter = 0f, normalCounter;

    [SerializeField, Min(1f)]
    float failingTime = 5f, exposedTime = 5f, normalTime = 4f;

    [SerializeField, Range(0f, 1f)]
    float failingChance = 0.20f;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ActorUpdate(ref int affectedActors, ref int maxAffectedActors)
    {
        switch(state)
        {
            case ActorState.NORMAL:
                spriteRenderer.material = normal;
                if(affectedActors >= maxAffectedActors)
                {
                    normalCounter = 0;
                    Debug.Log("max reached");
                    return;
                }
                NormalToFailCounter(ref affectedActors);
                break;

            case ActorState.WOBBLY:
                spriteRenderer.material = wobbly;
                FailToExposedCounter();
                break;

            case ActorState.FAILING:
                spriteRenderer.material = failing;
                FailToExposedCounter();
                break;

            case ActorState.EXPOSED:
                spriteRenderer.material = exposed;
                ExposedToNormalCounter();
                break;
        }
    }

    void NormalToFailCounter(ref int affectedActors)
    {
        normalCounter += Time.deltaTime;
        if (normalCounter < normalTime)
        {
            return;
        }
        if(Random.Range(0f, 1f) > failingChance)
        {
            normalCounter = 0;
            return;
        }
        if (Random.Range(0f, 1f) < 0.5f)
        {
            state = ActorState.FAILING;
        }
        else
        {
            state = ActorState.WOBBLY;
        }
        affectedActors++;
        normalCounter = 0f;
    }

    void FailToExposedCounter()
    {
        if (failingCounter > failingTime)
        {
            state = ActorState.EXPOSED;
            failingCounter = 0f;
        }
        failingCounter += Time.deltaTime;
    }

    void ExposedToNormalCounter()
    {
        if (exposedCounter > exposedTime)
        {
            state = ActorState.NORMAL;
            exposedCounter = 0f;
        }
        exposedCounter += Time.deltaTime;
    }

}
