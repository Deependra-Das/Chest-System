namespace ChestSystem.Chest
{
    public interface IChestState
    {
        public void OnStateEnter();
        public void OnChestButtonClick();
        public void OnStateExit();
    }
}