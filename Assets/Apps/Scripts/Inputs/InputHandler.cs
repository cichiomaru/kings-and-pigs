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
        /// <summary>
        /// reference untuk komponent Throwable
        /// </summary>
        private ThrowAction throwAction;

        private void Awake() {
            moveAction = GetComponent<MoveAction>();
            jumpAction = GetComponent<JumpAction>();
            throwAction = GetComponent<ThrowAction>();
        }
        private void Update() {
            moveAction.SetDirection(Input.GetAxisRaw("Horizontal"), Axis.x);
            if (Input.GetKeyDown(KeyCode.Space)) {
                jumpAction.Jump();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                throwAction.Throw();
            }
        }
    } 
}
