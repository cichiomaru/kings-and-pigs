using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core {
    public class GameManager : MonoBehaviour {
        /// <summary>
        /// gravity physics
        /// </summary>
        [SerializeField]
        private float gravity;

        private void Start() {
            SetGravity(gravity);
        }
        public void SetGravity(float _gravity) {
            Physics2D.gravity = new Vector2(0, _gravity);
        }
    } 
}
