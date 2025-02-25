using System;
using UnityEngine;

namespace ChestSystem.Sound
{
    [CreateAssetMenu(fileName = "Sound_SO", menuName = "ScriptableObjects/Sound_SO")]
    public class SoundScriptableObject : ScriptableObject
    {
        public Sounds[] audioList;
    }

    [Serializable]
    public struct Sounds
    {
        public SoundType soundType;
        public AudioClip audio;
    }
}