using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EntityBehaviour;

namespace InputSystem {
    public class InputHandler : MonoBehaviour {
        /// <summary>
        /// reference untuk komponen Moveable
        /// </summary>
        private MoveAction moveAction;
        /// <summary>
        /// reference untuk komponen Jumpable
        /// </summary>
        private JumpAction jumpAction;

        private void Awake() {
            moveAction = GetComponent<MoveAction>();
            jumpAction = GetComponent<JumpAction>();
        }
        private void Update() {
            moveAction.SetDirection(Input.GetAxisRaw("Horizontal"), Axis.x);
            if (Input.GetKeyDown(KeyCode.Space)) {
                jumpAction.Jump();
            }
        }
    } 
}
