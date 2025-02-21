using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChestSystem.Utilities;

namespace ChestSystem.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            Debug.Log("GameService Setup");
        }

    }

}
