using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace EntityBehaviour {
    public enum Axis {
        x, y, z
    }
    public class MoveAction : AnimatedAction {
        /// <summary>
        /// kecepatan pergerakan entity
        /// </summary>
        [SerializeField]
        private float speed;
        /// <summary>
        /// arah pergerakan
        /// </summary>
        private Vector3 direction;
        /// <summary>
        /// update arah object tergantung arah pergerakan
        /// </summary>
        [SerializeField]
        private bool updateFaceDirection;
        /// <summary>
        /// event yang akan dijalankan ketika object bergerak
        /// </summary>
        [SerializeField]
        private UnityEvent<Vector3> OnMove;
        /// <summary>
        /// event yang akan dijalankan ketika object berhenti
        /// </summary>
        [SerializeField]
        private UnityEvent OnStop;

        /// <summary>
        /// set arah pergerakan
        /// </summary>
        /// <param name="_direction">Arah pergerakan x, y, dan z entity</param>
        public void SetDirection(Vector3 _direction) {
            direction = _direction;
        }
        /// <summary>
        /// set arah pergerakan hanya 1 sumbu
        /// </summary>
        /// <param name="_value">nilai arah pada sumbu</param>
        /// <param name="_axis">sumbu pergerakan</param>
        public void SetDirection (float _value, Axis _axis) {
            switch(_axis) {
                case Axis.x:
                    direction.x = _value;
                    break;
                case Axis.y:
                    direction.y = _value;
                    break;
                case Axis.z:
                    direction.z = _value;
                    break;
            }
        }
        /// <summary>
        /// set kecepatan pergerakan
        /// </summary>
        /// <param name="_speed">kecepatan pergerakan entity</param>
        public void SetSpeed(float _speed) {
            speed = _speed;
        }
        /// <summary>
        /// update frame
        /// </summary>
        private void Update() {
            PositionUpdate();
            RotationUpdate();
            AnimationUpdate();

            if (direction.magnitude > 0) {
                OnMove?.Invoke(direction);
            } else {
                OnStop?.Invoke();
            }
        }

        /// <summary>
        /// update parameter yang ada di animator
        /// </summary>
        private void AnimationUpdate() {
            if (animator != null)
                animator.SetFloat("speed", direction.magnitude);
        }

        /// <summary>
        /// update arah object
        /// </summary>
        private void RotationUpdate() {
            if (!updateFaceDirection)
                return;

            if (direction.x > 0) {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            } else if (direction.x < 0) {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        /// <summary>
        /// update posisi entity
        /// </summary>
        private void PositionUpdate() {
            transform.position += PositionOffset();
        }
        /// <summary>
        /// perubahan posisi object berdasarkan speed dan direction
        /// </summary>
        /// <returns>jarak perpindahan object dalam Vector3</returns>
        public Vector3 PositionOffset () {
            return speed * Time.deltaTime * direction;
        }
    }
}