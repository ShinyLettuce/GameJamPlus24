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
        if(audience.seesMistake)
        {
            score++;
        }

        scoreText.SetText("Score: {0}", score);
    }

    void FixedUpdate()
    {
        player.PlayerPhysicsUpdate();
        audience.AudiencePhysicsUpdate(actors);
    }
}

