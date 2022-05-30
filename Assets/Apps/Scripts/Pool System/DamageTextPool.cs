using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace PoolSystem {
    public class DamageTextPool : MonoBehaviour {
        /// <summary>
        /// instance untuk class ini
        /// </summary>
        public static DamageTextPool instance;
        /// <summary>
        /// prefab untuk floating text damage
        /// </summary>
        [SerializeField]
        private GameObject damageText;
        /// <summary>
        /// jumlah pool yang ingin di generate
        /// </summary>
        [SerializeField]
        private int poolSize;
        /// <summary>
        /// penampung text yang sudah di generate
        /// </summary>
        private List<GameObject> pool;

        private void Awake() {
            if (instance != null) {
                Destroy(gameObject);
            } else {
                instance = this;
            }

            pool = new List<GameObject>();
        }
        private void Start() {
            GeneratePool();
        }

        internal void RequestText(Vector3 _position, int _damageValue) {
            foreach(GameObject go in pool) {
                if (go.activeSelf == false) {
                    go.SetActive(true);
                    FloatingDamageUI _fdui = go.GetComponent<FloatingDamageUI>();
                    _fdui.ShowDamage(_position, _damageValue);

                    return;
                }
            }
        }

        /// <summary>
        /// instantiate pool yang dibutuhkan
        /// </summary>
        private void GeneratePool() {
            for (int i=0; i<poolSize; i++) {
                GameObject go = Instantiate(damageText, transform);
                pool.Add(go);
            }
        }
    } 
}
