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
    GameObject actor;

    [SerializeField]
    TextMeshProUGUI scoreText;

    int score;

    private void Update()
    {
        player.PlayerUpdate();
        if(audience.seesMistake)
        {
            score++;
        }

        scoreText.SetText("Score: {0}", score);
    }

    void FixedUpdate()
    {
        player.PlayerPhysicsUpdate();
        audience.AudiencePhysicsUpdate();
    }
}

