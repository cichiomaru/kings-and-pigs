using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolSystem;

namespace EntityBehaviour {
    public enum Direction {
        Left, Right
    }
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
        internal void AddForce(Direction _direction, int _throwPower) {
            Vector2 _directionVector;
            if (_direction == Direction.Left) {
                _directionVector = new Vector2(-.5f, .5f);
            } else {
                _directionVector = new Vector2(.5f, .5f);
            }
            rb2d.AddForce(_directionVector * _throwPower);
        }
        /// <summary>
        /// deaktivasi object
        /// </summary>
        public void Deactivate() {
            gameObject.SetActive(false);
        }
        public void Damage(Collision2D _collision) {
            Damageable _damageable = _collision.gameObject.GetComponent<Damageable>();

            if (_damageable == null) return;

            _damageable.TakeDamage(1);
        }
    }
}
