using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableVariables;

namespace EntityBehaviour {
    public class ThrowAction : MonoBehaviour {
        /// <summary>
        /// reference untuk object yang bisa dilempar (bomb, dkk)
        /// </summary>
        [SerializeField]
        private Throwable throwable;
        /// <summary>
        /// posisi object yang dilempar pertama kali
        /// </summary>
        [SerializeField]
        private Transform throwAnchor;
        /// <summary>
        /// reference untuk scriptable bomb count
        /// </summary>
        [SerializeField]
        private ScriptableInteger bombCount;
        /// <summary>
        /// kekuatan lempar
        /// </summary>
        [SerializeField]
        [Range(1, 16)]
        private int throwPower;

        /// <summary>
        /// attempt untuk melempar object
        /// </summary>
        public void Throw() {
            if (!IsAble()) {
                return;
            }
            GameObject go = Instantiate(throwable.gameObject,
                throwAnchor.position,
                throwAnchor.rotation);

            Throwable _throwable = go.GetComponent<Throwable>();
            Direction _direction = transform.rotation.y != 0 ? Direction.Left : Direction.Right;
            _throwable.AddForce(_direction, 100 * throwPower);
        }

        /// <summary>
        /// function untuk menentukan action throw bisa dilakukan atau tidak
        /// untuk sementara hanya me return true
        /// </summary>
        /// <returns>Boolean yang menentukan aksi throw bisa dilakukan atau tidak</returns>
        private bool IsAble() {
            if (bombCount.value <= 0) {
                return false;
            }
            bombCount.value--;
            return true;
        }
    } 
}
