using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ChestSystem.Utilities;
using ChestSystem.Chest;
using ChestSystem.ChestSlot;

namespace ChestSystem.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        private ChestService _chestService;
        private ChestSlotService _chestSlotService;
        private UnlockingQueueService _unlockingQueueService;

        [SerializeField] private int _chestSlotCount;

        [Header("Prefabs")]
        [SerializeField] private ChestView _chestPrefab;
        [SerializeField] private ChestSlotView _chestSlotPrefab;

        [Header("Scriptable Objects")]
        [SerializeField] private List<ChestScriptableObject> _chestSO_List;

        [Header("Transform")]
        [SerializeField] private Transform _canvasTransform;
        [SerializeField] private Transform _slotContentTransform;
        [SerializeField] private Button _generateButton;

        protected override void Awake()
        {
            base.Awake();
            SetListeners();
        }
        private void SetListeners()
        {
            _generateButton.onClick.AddListener(GenerateChest);
        }

        private void Start()
        {
            _chestService = new ChestService(_chestSO_List,_chestPrefab);
            _chestSlotService = new ChestSlotService(_chestSlotPrefab, _chestSlotCount);
            _unlockingQueueService = new UnlockingQueueService(_chestSlotCount);
        }

        public Transform GetCanvasTransform { get { return _canvasTransform; } private set { } }

        public Transform GetSlotContentTransform { get { return _slotContentTransform; } private set { } }

        public ChestService GetChestService() => _chestService;

        public ChestSlotService GetChestSlotService() => _chestSlotService;

        public UnlockingQueueService GetUnlockingQueueService() => _unlockingQueueService;

        public void GenerateChest()
        {
            ChestSlotController chestSlot = _chestSlotService.GetVacantSlot();

            if (chestSlot!=null)
            {
                ChestController chest = _chestService.GenerateRandomChest();
                chest.Configure(chestSlot);
                chestSlot.AddChestToSlot(chest);
                chestSlot.SetSlotState(ChestSlotStates.OCCUPIED);
            }

        }

        private void Update()
        {
            _unlockingQueueService?.UpdateUnlockingSlotQueue();
        }
    }

}
