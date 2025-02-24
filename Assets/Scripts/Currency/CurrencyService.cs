using ChestSystem.Chest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Currency
{
    public class CurrencyService
    {
        private CurrencyView _currencyView;
        private int _coinsOwned;
        private int _gemsOwned;

        public CurrencyService(CurrencyView currencyPrefab, Transform canvasTransform)
        {
            _coinsOwned = 0;
            _gemsOwned = 0;
            _currencyView = GameObject.Instantiate(currencyPrefab, canvasTransform);
        }

        public int GemsOwned { get { return _gemsOwned; } private set { } }
        public int CoinsOwned { get { return _coinsOwned; } private set { } }

        public void AddCoins(int amount)
        {
            _coinsOwned += amount;
            VerifyMinCurrency();
        }

        public void SubtractCoin(int amount)
        {
            _coinsOwned -= amount;
            VerifyMinCurrency();
        }

        public void AddGems(int amount)
        {
            _gemsOwned += amount;
            VerifyMinCurrency();
        }

        public void SubtractGems(int amount)
        {
            _gemsOwned -= amount;
            VerifyMinCurrency();
        }

        private void VerifyMinCurrency()
        {
            if (_coinsOwned < 0)
            {
                _coinsOwned = 0;
            }
            if (_gemsOwned < 0)
            {
                _gemsOwned = 0;
            }
        }

    }
}

