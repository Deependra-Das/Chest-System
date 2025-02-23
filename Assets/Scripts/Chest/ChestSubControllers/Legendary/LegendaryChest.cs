namespace ChestSystem.Chest
{
    public class LegendaryChest : ChestController
    {
        public LegendaryChest(ChestScriptableObject chestSO, ChestView chestView) : base(chestSO, chestView) 
        {
            CreateStateMachine();
            _chestStateMachine.ChangeState(ChestStates.LOCKED);
        }

    }
}