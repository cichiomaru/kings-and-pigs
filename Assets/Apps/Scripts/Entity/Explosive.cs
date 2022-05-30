using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolSystem;

namespace EntityBehaviour {
    public class Explosive : MonoBehaviour {

        /// <summary>
        /// memunculkan efek ledakan
        /// </summary>
        public void ShowExplosion() {
            ExplosionEffectPool.instance.Request(transform.position);
        }
    }

}