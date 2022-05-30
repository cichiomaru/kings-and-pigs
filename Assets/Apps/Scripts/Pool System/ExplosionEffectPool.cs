using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolSystem {
    public class ExplosionEffectPool : MonoBehaviour {
        /// <summary>
        /// instance dari class ini
        /// </summary>
        public static ExplosionEffectPool instance;
        /// <summary>
        /// container object efek ledakan
        /// </summary>
        [SerializeField]
        private List<GameObject> pool;
        /// <summary>
        /// prefab untuk efek ledakan
        /// </summary>
        [SerializeField]
        private GameObject explosionEffectPrefab;
        /// <summary>
        /// ukuran pool
        /// </summary>
        [SerializeField]
        private int poolSize;

        private void Awake() {
            if (instance == null) {
                instance = this;
            } else {
                Destroy(gameObject);
            }

            pool = new List<GameObject>();
        }
        private void Start() {
            GeneratePool();
        }

        /// <summary>
        /// generate isi pool berupa efek ledakan
        /// </summary>
        private void GeneratePool() {
            for (int i=0; i<poolSize; i++) {
                GameObject go = Instantiate(explosionEffectPrefab, transform);
                
                pool.Add(go);
                go.SetActive(false);
            }
        }
        /// <summary>
        /// mencari efek yang tidak aktif dan mengaktifkannya
        /// </summary>
        /// <param name="_position">posisi ledakan</param>
        public void Request(Vector3 _position) {
            foreach(GameObject go in pool) {
                if (!go.activeSelf) {
                    go.SetActive(true);
                    go.transform.position = _position;

                    return;
                }
            }
        }
    } 
}
