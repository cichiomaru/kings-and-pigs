using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ScriptableVariables {
    [CreateAssetMenu(fileName = "New Scriptable Integer", menuName = "Scriptable Objects/Scriptable Variables")]
    public class ScriptableInteger : ScriptableObject {
        /// <summary>
        /// nilai dari integer
        /// </summary>
        public int value;
        /// <summary>
        /// nilai awal dari integer, value akan kembali ke defaultValue jika
        /// isResetEveryPlay bernilai true
        /// </summary>
        public int defaultValue;
        /// <summary>
        /// flag untuk menentukan nilai akan kembali ke awal atau tidak
        /// </summary>
        public bool isResetEveryPlay;

        private void OnEnable() {
            if (isResetEveryPlay) {
                value = defaultValue;
            }
        }
    } 
}
