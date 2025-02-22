using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ChestSystem.Utilities;
using ChestSystem.Chest;

namespace ChestSystem.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        private ChestService _chestService;

        [Header("Prefabs")]
        [SerializeField] private ChestView _chestPrefab;

        [Header("Scriptable Objects")]
        [SerializeField] private List<ChestScriptableObject> _chestSO_List;

        [Header("Transform")]
        [SerializeField] private Transform _canvasTransform;
        [SerializeField] private Transform _slotTransform;
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
        }

        public Transform GetCanvasTransform { get { return _canvasTransform; } private set { } }

        public ChestService GetChestService() => _chestService;

        public void GenerateChest()
        {
            _chestService.GenerateChest(_slotTransform);
        }
    }

}
