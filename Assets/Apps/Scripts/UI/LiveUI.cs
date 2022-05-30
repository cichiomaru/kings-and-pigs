using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableVariables;

namespace UI {
    public class LiveUI : MonoBehaviour {
        /// <summary>
        /// reference untuk icon live (hati) pada UI
        /// </summary>
        [SerializeField]
        private List<Image> liveIcon;
        /// <summary>
        /// reference untuk scriptable integer
        /// </summary>
        [SerializeField]
        private ScriptableInteger live;

        private void Start() {
        }
        private void Update() {
            UpdateLive();
        }

        /// <summary>
        /// update simbol hati di UI mengikuti variabel yang dituju
        /// </summary>
        private void UpdateLive() {
            for (int i=0; i<3; i++) {
                if (i < live.value) {
                    liveIcon[i].gameObject.SetActive(true);
                } else {
                    liveIcon[i].gameObject.SetActive(false);
                }
            }
        }
    }
}