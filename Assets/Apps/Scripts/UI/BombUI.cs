using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ScriptableVariables;
using System;

namespace UI {
    public class BombUI : MonoBehaviour {
        /// <summary>
        /// reference untuk text jumlah bomb
        /// </summary>
        [SerializeField]
        private TMP_Text bombCountText;
        /// <summary>
        /// reference untuk scriptable penampung jumlah bomb
        /// </summary>
        [SerializeField]
        private ScriptableInteger bombCount;

        private void Update() {
            UpdateBombCount();
        }

        /// <summary>
        /// update text jumlah bomb pada UI
        /// </summary>
        private void UpdateBombCount() {
            bombCountText.text = bombCount.value.ToString();
        }
    } 
}
