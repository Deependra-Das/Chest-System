using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChestSystem.Utilities;
using ChestSystem.Chest;
using ChestSystem.ChestSlot;
using ChestSystem.UI;
using ChestSystem.Currency;
using ChestSystem.Commands;
using ChestSystem.RefundGem;
using ChestSystem.Sound;

namespace ChestSystem.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        private ChestService _chestService;
        private ChestSlotService _chestSlotService;
        private UnlockingQueueService _unlockingQueueService;
        private UIService _uiService;
        private CurrencyService _currencyService;
        private CommandInvoker _commandInvoker;
        private RefundGemService _refundGemService;
        private SoundService _soundService;

        [SerializeField] private int _chestSlotCount;

        [Header("Views/Prefabs")]
        [SerializeField] private ChestView _chestPrefab;
        [SerializeField] private ChestSlotView _chestSlotPrefab;
        [SerializeField] private UIView _uiPrefab;
        [SerializeField] private AcknowledgementPopUpView _acknowledgementPrefab;
        [SerializeField] private ConfirmationPopUpView _confirmationPrefab;
        [SerializeField] private NotificationPopUpView _notificationPrefab;
        [SerializeField] private ActionPopUpView _actionPrefab;
        [SerializeField] private UndoGemUnlockView _undoGemUnlockPrefab;
        [SerializeField] private UndoOptionView _undoOptionView;
        [SerializeField] private CurrencyView _currencyPrefab;

        [Header("Scriptable Objects")]
        [SerializeField] private List<ChestScriptableObject> _chestSO_List;

        [Header("Transform")]
        [SerializeField] private Transform _canvasTransform;

        [Header("Audio")]
        [SerializeField] private SoundScriptableObject _audioList;
        [SerializeField] private AudioSource _audioSource_SFX;
        [SerializeField] private AudioSource _audioSource_BGM;

        protected override void Awake()
        {
            base.Awake();
        }
   
        private void Start()
        {
            _commandInvoker = new CommandInvoker();
            _currencyService = new CurrencyService(_currencyPrefab, _canvasTransform);
            _uiService = new UIService(_uiPrefab, _acknowledgementPrefab, _confirmationPrefab, _notificationPrefab, _actionPrefab, _canvasTransform);
            _chestService = new ChestService(_chestSO_List,_chestPrefab);
            _chestSlotService = new ChestSlotService(_chestSlotPrefab, _chestSlotCount);
            _unlockingQueueService = new UnlockingQueueService(_chestSlotCount);
            _refundGemService = new RefundGemService(_undoGemUnlockPrefab, _undoOptionView, _canvasTransform);
            _soundService = new SoundService(_audioList, _audioSource_SFX, _audioSource_BGM);

            Initialize();
        }

        private void Initialize()
        {
            _uiService.Initialize();
        }

        public void GenerateChest()
        {
            ChestSlotController chestSlot = _chestSlotService.GetVacantSlot();

            if (chestSlot != null)
            {
                ChestController chest = _chestService.GenerateRandomChest();
                chest.Configure(chestSlot);
                chestSlot.AddChestToSlot(chest);
                chestSlot.SetSlotState(ChestSlotStates.OCCUPIED);
            }
            else
            {
                _uiService.ShowNotificationPopUp(NotificationType.SlotNotAvailable);
            }
        }

        public Transform GetCanvasTransform { get { return _canvasTransform; } private set { } }

        public ChestService GetChestService() => _chestService;

        public ChestSlotService GetChestSlotService() => _chestSlotService;

        public UnlockingQueueService GetUnlockingQueueService() => _unlockingQueueService;

        public UIService GetUIService() => _uiService;

        public CurrencyService GetCurrencyService() => _currencyService;

        public CommandInvoker GetCommandInvoker() => _commandInvoker;

        public RefundGemService GetRefundGemService() => _refundGemService;

        public SoundService GetSoundService() => _soundService;

        public string FormatTime(int minutes)
        {
            int hours = minutes / 60;
            int remainingMinutes = minutes % 60;
            string formattedTime = string.Format("{0:D2}h {1:D2}m", hours, remainingMinutes);

            return formattedTime;
        }
    }
}
