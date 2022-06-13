using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityBehaviour {
    public class AnimatedAction : MonoBehaviour {
        /// <summary>
        /// reference untuk animator
        /// </summary>
        [SerializeField]
        protected Animator animator;
        private void Awake() {
            animator = GetComponentInChildren<Animator>();
        }
    } 
}
