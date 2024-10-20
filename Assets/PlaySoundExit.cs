using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundExit : StateMachineBehaviour
{
    [SerializeField] private SoundType sound;
    [SerializeField] private float volume = 1f;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SoundManager.PlaySound(sound, volume);
    }
}