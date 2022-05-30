using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolSystem;

namespace EntityBehaviour {
    public class Damageable : MonoBehaviour {

        /// <summary>
        /// fungsi untuk menerima damage
        /// </summary>
        /// <param name="_damage">damage yang diterima</param>
        public void TakeDamage(int _damage) {

            DamageTextPool.instance.RequestText(transform.position, _damage);
        }
    } 
}
