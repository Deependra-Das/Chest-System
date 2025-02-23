namespace ChestSystem.Chest
{
    public class EpicChest : ChestController
    {
        public EpicChest(ChestScriptableObject chestSO, ChestView chestView) : base(chestSO, chestView) 
        {
            CreateStateMachine();
            _chestStateMachine.ChangeState(ChestStates.LOCKED);
        }

    }
}