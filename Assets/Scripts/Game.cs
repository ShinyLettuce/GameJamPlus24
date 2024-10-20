using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField]
    Audience audience;

    [SerializeField]
    WaterBooth waterBooth;

    [SerializeField]
    ScriptBooth scriptBooth;

    [SerializeField]
    Player player;

    [SerializeField]
    Actor[] actors;

    [SerializeField]
    TextMeshProUGUI scoreText;

    int score;

    [SerializeField, Min(1)]
    int maxAffectedActors;

    int affectedActors = 0;

    bool playerHasWater = false;

    bool playerHasScript = false;

    bool seesMistake = false;
    
    int mistakeCount = 0;

    void UpdateActors()
    {
        affectedActors = 0;
        foreach (var actor in actors)
        {
            if (actor.state != Actor.ActorState.NORMAL)
            {
                affectedActors++;
            }
        }
        foreach (var actor in actors)
        {
            actor.ActorUpdate(ref affectedActors, ref maxAffectedActors);
            if(actor.PlayerNearActor() && actor.state == Actor.ActorState.WOBBLY && playerHasWater)
            {
                playerHasWater = false;
                actor.SetActorState(Actor.ActorState.NORMAL);
            }
            if (actor.PlayerNearActor() && actor.state == Actor.ActorState.FAILING && playerHasScript)
            {
                playerHasScript = false;
                actor.SetActorState(Actor.ActorState.NORMAL);
            }
        }
    }

    private void Update()
    {
        if (waterBooth.WaterGrabable())
        {
            playerHasWater = true;
            playerHasScript = false;
        }
        if (scriptBooth.ScriptGrabable())
        {
            playerHasWater = false;
            playerHasScript = true;
        }

        player.PlayerUpdate();
        UpdateActors();
        if(mistakeCount > 0)
        {
            score += mistakeCount;
        }

        scoreText.SetText("Score: {0}", score);
    }

    void FixedUpdate()
    {
        player.PlayerPhysicsUpdate();
        mistakeCount = 0;
        foreach (var actor in actors)
        {
            seesMistake = false;
            seesMistake = audience.AudienceSeesMistake(actor);
            if(seesMistake)
            {
                mistakeCount++;
            }
        }
    }
}

