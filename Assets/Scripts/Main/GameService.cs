using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ChestSystem.Utilities;
using ChestSystem.Chest;
using ChestSystem.ChestSlot;
using ChestSystem.UI;

namespace ChestSystem.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        private ChestService _chestService;
        private ChestSlotService _chestSlotService;
        private UnlockingQueueService _unlockingQueueService;
        private UIService _uiService;

        [SerializeField] private int _chestSlotCount;

        [Header("Views")]
        [SerializeField] private ChestView _chestPrefab;
        [SerializeField] private ChestSlotView _chestSlotPrefab;
        [SerializeField] private UIView _uiPrefab;
        [SerializeField] private AcknowledgementPopUpView _acknowledgementPrefab;
        [SerializeField] private ConfirmationPopUpView _confirmationPrefab;
        [SerializeField] private NotificationPopUpView _notificationPrefab;


        [Header("Scriptable Objects")]
        [SerializeField] private List<ChestScriptableObject> _chestSO_List;

        [Header("Transform")]
        [SerializeField] private Transform _canvasTransform;

        protected override void Awake()
        {
            base.Awake();
        }
   
        private void Start()
        {
            _uiService = new UIService(_uiPrefab, _acknowledgementPrefab, _confirmationPrefab, _notificationPrefab, _canvasTransform);
            _chestService = new ChestService(_chestSO_List,_chestPrefab);
            _chestSlotService = new ChestSlotService(_chestSlotPrefab, _chestSlotCount);
            _unlockingQueueService = new UnlockingQueueService(_chestSlotCount);

            Initialize();
        }

        private void Initialize()
        {
            _uiService.Initialize();
        }

        public Transform GetCanvasTransform { get { return _canvasTransform; } private set { } }

        public Transform GetSlotContentTransform { get { return _canvasTransform; } private set { } }

        public ChestService GetChestService() => _chestService;

        public ChestSlotService GetChestSlotService() => _chestSlotService;

        public UnlockingQueueService GetUnlockingQueueService() => _unlockingQueueService;

        public UIService GetUIService() => _uiService;

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
