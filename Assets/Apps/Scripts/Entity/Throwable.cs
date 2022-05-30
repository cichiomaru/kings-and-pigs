using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityBehaviour {
    public class Throwable : MonoBehaviour {
        /// <summary>
        /// reference untuk rigidbody2d pada throwable objects
        /// </summary>
        private Rigidbody2D rb2d;

        private void Awake() {
            rb2d = GetComponent<Rigidbody2D>();
        }
        /// <summary>
        /// menambahkan force ke object
        /// </summary>
        internal void AddForce(Vector2 _force) {
            rb2d.AddForce(_force);
        }
    }
}
