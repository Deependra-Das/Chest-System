namespace ChestSystem.Chest
{
    public class RareChest : ChestController
    {
        public RareChest(ChestScriptableObject chestSO, ChestView chestView) : base(chestSO, chestView) 
        {
            CreateStateMachine();
            _chestStateMachine.ChangeState(ChestStates.LOCKED);
        }

    }
}