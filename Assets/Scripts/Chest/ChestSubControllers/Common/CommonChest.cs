namespace ChestSystem.Chest
{
    public class CommonChest : ChestController
    {
        public CommonChest(ChestScriptableObject chestSO, ChestView chestView) : base(chestSO, chestView) 
        {
            CreateStateMachine();
            _chestStateMachine.ChangeState(ChestStates.LOCKED);
        }

    }
}