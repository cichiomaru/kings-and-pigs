using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EntityBehaviour;

namespace AI {
    public class PigAI : MonoBehaviour {
        /// <summary>
        /// state dari AI
        /// </summary>
        [SerializeField]
        private State state;
        /// <summary>
        /// action patroli
        /// </summary>
        [SerializeField]
        private Patrol patrol;

        /// <summary>
        /// reference ke komponen moveable
        /// </summary>
        private MoveAction moveable;

        private void Awake() {
            moveable = GetComponent<MoveAction>();
        }
        private void Start() {
            state = State.Idle;
        }
        private void Update() {
            if (state == State.Patrol) {
                Patrol();
            } else if (state == State.Chase) {
                Chase();
            }
        }

        /// <summary>
        /// kejar musuh jika ada
        /// </summary>
        private void Chase() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// patroli
        /// </summary>
        private void Patrol() {
            if (patrol == null) return;
            if (patrol.GetWaypointsCount() <= 0) return;

            moveable.SetDirection(patrol.GetDirection(transform.position), Axis.x);
        }
    } 
}
