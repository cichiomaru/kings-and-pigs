using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EntityBehaviour;

namespace InputSystem {
    public class InputHandler : MonoBehaviour {
        /// <summary>
        /// reference untuk komponen Moveable
        /// </summary>
        private Moveable moveable;
        /// <summary>
        /// reference untuk komponen Jumpable
        /// </summary>
        private Jumpable jumpable;

        private void Awake() {
            moveable = GetComponent<Moveable>();
            jumpable = GetComponent<Jumpable>();
        }
        private void Update() {
            moveable.SetDirection(Input.GetAxisRaw("Horizontal"), Axis.x);
            if (Input.GetKeyDown(KeyCode.Space)) {
                jumpable.Jump();
            }
        }
    } 
}
