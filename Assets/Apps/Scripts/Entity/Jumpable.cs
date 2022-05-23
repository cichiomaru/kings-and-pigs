using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityBehaviour {
    public class Jumpable : MonoBehaviour {
        /// <summary>
        /// reference ke rigidbody2d
        /// </summary>
        private Rigidbody2D rb2d;
        /// <summary>
        /// kekuatan lompat
        /// </summary>
        [SerializeField]
        private float jumpPower;

        private void Awake() {
            rb2d = GetComponent<Rigidbody2D>();
        }
        /// <summary>
        /// melakukan aksi lompat
        /// </summary>
        public void Jump() {
            rb2d.velocity = jumpPower * Vector3.up;
        }
    } 
}
