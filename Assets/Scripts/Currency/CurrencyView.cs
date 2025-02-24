using ChestSystem.Chest;
using ChestSystem.Main;
using ChestSystem.UI;
using ChestSystem.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyView : GenericMonoSingleton<CurrencyView>
{    
    [SerializeField] private TextMeshProUGUI _coinsOwnedText;
    [SerializeField] private TextMeshProUGUI _gemsOwnedText;

    private void Start()
    {
       
    }

    private void Update()
    {
        _coinsOwnedText.text = GameService.Instance.GetCurrencyService().CoinsOwned.ToString();
        _gemsOwnedText.text = GameService.Instance.GetCurrencyService().GemsOwned.ToString();
    }

}
