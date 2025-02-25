using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ChestSystem.Main;

namespace ChestSystem.Currency
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsOwnedText;
        [SerializeField] private TextMeshProUGUI _gemsOwnedText;

        private void Update()
        {
            _coinsOwnedText.text = GameService.Instance.GetCurrencyService().CoinsOwned.ToString();
            _gemsOwnedText.text = GameService.Instance.GetCurrencyService().GemsOwned.ToString();
        }

    }
}
