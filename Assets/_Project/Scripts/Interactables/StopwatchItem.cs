using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopwatchItem : MonoBehaviour
{
    [SerializeField]
    private int seconds = 3;

    void OnTriggerEnter()
    {
        GameManager.GetGameState<GamePlayingState>().gameTimer.AddTime(seconds);

        Destroy(this.gameObject);
    }
}