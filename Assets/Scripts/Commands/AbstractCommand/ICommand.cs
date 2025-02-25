using ChestSystem.Chest;

namespace ChestSystem.Commands
{
    public interface ICommand
    {
        void Execute();

        public void Undo();

        public ChestController GetChestController();
    }
}
