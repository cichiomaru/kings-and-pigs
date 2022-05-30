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
        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.tag.Equals("Enemy")) {
                DamageTextPool.instance.RequestText(collision.transform.position, 10);
            }
            DestroySelf();
        }
        /// <summary>
        /// menghilangkan object diri sendiri ketika terjadi collision
        /// </summary>
        private void DestroySelf() {
            gameObject.SetActive(false);
        }
    }
}
