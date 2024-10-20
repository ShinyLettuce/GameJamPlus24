using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField]
    Material normal, wobbly, failing, exposed;

    [SerializeField]
    GameObject waterSign;

    [SerializeField]
    GameObject scriptSign;

    public enum ActorState
    {
        NORMAL,
        WOBBLY,
        FAILING,
        EXPOSED
    }

    public ActorState state = ActorState.NORMAL;

    SpriteRenderer spriteRenderer;

    float failingCounter = 0f, exposedCounter = 0f, normalCounter = 0f;

    [SerializeField, Min(1f)]
    float failingTime = 5f, exposedTime = 5f, normalTime = 4f;

    [SerializeField, Range(0f, 1f)]
    float failingChance = 0.20f;

    bool playerNearActor = false;

    public void SetActorState(Actor.ActorState newState)
    {
        state = newState;
        failingCounter = 0f;
        exposedCounter = 0f;
        normalCounter = 0f;
    }
    public bool PlayerNearActor() => playerNearActor;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerNearActor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerNearActor = false;
        }
    }

    public void ActorUpdate(ref int affectedActors, ref int maxAffectedActors)
    {
        switch(state)
        {
            case ActorState.NORMAL:
                if(affectedActors >= maxAffectedActors)
                {
                    normalCounter = 0;
                    Debug.Log("max reached");
                    return;
                }
                NormalToFailCounter(ref affectedActors);
                break;
            case ActorState.WOBBLY:
                FailToExposedCounter();
                break;
            case ActorState.FAILING:
                FailToExposedCounter();
                break;
            case ActorState.EXPOSED:
                ExposedToNormalCounter();
                break;
        }
    }

    public void ActorRender()
    {
        switch(state)
        {
            case ActorState.NORMAL:
                spriteRenderer.material = normal;
                scriptSign.SetActive(false);
                waterSign.SetActive(false);
                break;

            case ActorState.WOBBLY:
                spriteRenderer.material = wobbly;
                waterSign.SetActive(true);
                scriptSign.SetActive(false);
                break;

            case ActorState.FAILING:
                spriteRenderer.material = failing;
                scriptSign.SetActive(true);
                waterSign.SetActive(false);
                break;

            case ActorState.EXPOSED:
                spriteRenderer.material = exposed;
                scriptSign.SetActive(false);
                waterSign.SetActive(false);
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
        SoundManager.PlaySound(SoundType.HELP);
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
