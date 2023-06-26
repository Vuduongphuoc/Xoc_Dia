using UnityEngine;

public abstract class BotBaseState
{
   public abstract void EnterState(BotStateManager bot);

   public abstract void UpdateState(BotStateManager bot);

   public abstract void ExitState(BotStateManager bot);
    
}
