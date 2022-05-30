using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI {
    public class FloatingDamageUI : MonoBehaviour {
        /// <summary>
        /// reference untuk text damage
        /// </summary>
        [SerializeField]
        private TMP_Text damageText;

        private void Start() {
            gameObject.SetActive(false);
        }
        /// <summary>
        /// memunculkan damage pada posisi tertentu
        /// </summary>
        /// <param name="_objectPosition">posisi object yang terkena damage</param>
        /// <param name="_damageText">nilai dari damage yang ditampilkan</param>
        public void ShowDamage (Vector3 _objectPosition, int _damageText) {
            Vector3 _uiPosition;
            _uiPosition = Camera.main.WorldToScreenPoint(_objectPosition);

            gameObject.SetActive(true);
            damageText.text = _damageText.ToString();
            damageText.rectTransform.position = _uiPosition;

            StartCoroutine(DamageTimer());
        }

        private IEnumerator DamageTimer() {
            yield return new WaitForSeconds(.8f);
            gameObject.SetActive(false);
        }
    } 
}
