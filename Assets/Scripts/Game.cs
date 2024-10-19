using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField]
    Audience audience;

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
        }
    }

    private void Update()
    {
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

