using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        [SerializeField] private Transform _contentTransform;
        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            _chestService = new ChestService(_chestSO_List,_chestPrefab);
            _chestService.GenerateChest();
        }

        public Transform GetContentTransform { get { return _contentTransform; } private set { } }
    }

}
