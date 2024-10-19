using System.Collections;
using System.Collections.Generic;
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

    void UpdateActors()
    {
        foreach (var actor in actors)
        {
            actor.ActorUpdate();
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

