using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotStateManager : MonoBehaviour
{
    BotBaseState currentState;
    BotIdle IdleState = new BotIdle();
    BotBet BetState = new BotBet();
    BotWin WinState = new BotWin();
    BotLose LoseState = new BotLose();

    void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }
}
