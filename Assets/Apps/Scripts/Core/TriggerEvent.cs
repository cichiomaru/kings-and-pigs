using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core {
    public class TriggerEvent : MonoBehaviour {
        /// <summary>
        /// daftar tag yang akan dideteksi
        /// </summary>
        [SerializeField]
        private List<string> targetTag;
        /// <summary>
        /// event yang dijalankan ketika bertabrakan dengan object yang memiliki tag pada list
        /// </summary>
        [SerializeField]
        private UnityEvent OnCollide;
        /// <summary>
        /// event yang dijalankan ketika bertabrakan dengan object yang memiliki tag pada list dengan parameter collision
        /// </summary>
        [SerializeField]
        private UnityEvent<Collision2D> OnCollideWithParameter;

        private void OnCollisionEnter2D(Collision2D _collision) {
            if (!targetTag.Contains(_collision.gameObject.tag)) {
                return;
            }

            OnCollide?.Invoke();
            OnCollideWithParameter?.Invoke(_collision);
        }
    } 
}
