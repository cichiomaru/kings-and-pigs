using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effect {
    public class ExplosionEffect : MonoBehaviour {
        private void OnEnable() {
            StartCoroutine(Timer());
        }
        /// <summary>
        /// timer untuk menghilangkan efek explosion
        /// </summary>
        /// <returns></returns>
        private IEnumerator Timer () {
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
        }
    } 
}
