using System;
using System.Collections.Generic;
using UnityEngine;


namespace AI {
    [Serializable]
    internal class Patrol : AIAction {
        /// <summary>
        /// reference untuk waypoint patroli
        /// </summary>
        [SerializeField]
        private List<Transform> waypoints;
        /// <summary>
        /// index waypoint saat ini
        /// </summary>
        private int currentWaypoint;

        public Patrol() {
            currentWaypoint = 0;
        }
        /// <summary>
        /// mendapatkan jumlah waypoints yang ada
        /// </summary>
        /// <returns>Jumlah waypoints yang ada</returns>
        public int GetWaypointsCount() {
            if (waypoints == null) return 0;
            return waypoints.Count;
        }
        /// <summary>
        /// mendapatkan arah pergerakan berdasarkan posisi waypoint saat ini dengan posisi entity
        /// </summary>
        /// <param name="_position">Posisi entity saat ini</param>
        /// <returns>Arah pergerakan</returns>
        internal float GetDirection(Vector3 _position) {
            ArrivalCheck(_position);

            if (GetCurrentWaypointPosition().x < _position.x) {
                return -1;
            } else if (GetCurrentWaypointPosition().x > _position.x) {
                return 1;
            }
            return 0;
        }
        /// <summary>
        /// ckeck jika entity sudah mencapai waypoint saat ini
        /// </summary>
        /// <param name="_position">posisi entity</param>
        private void ArrivalCheck(Vector3 _position) {
            if (IsApproximatelyArrived(_position, 0.02f)) {
                currentWaypoint++;
                if (currentWaypoint > GetWaypointsCount()-1) {
                    currentWaypoint = 0;
                }
            }
        }
        /// <summary>
        /// Cek jika entity sudah mencapai waypoint saat ini
        /// </summary>
        /// <param name="_position">posisi entity</param>
        /// <param name="_approx">batas toleransi value dianggap sampai</param>
        /// <returns>bool value untuk status sampai pada waypoint</returns>
        private bool IsApproximatelyArrived(Vector3 _position, float _approx) {
            return Vector3.Distance(GetCurrentWaypointPosition(), _position) <= _approx;
        }

        /// <summary>
        /// mendapatkan posisi waypoint berdasarkan index waypoint saat ini
        /// </summary>
        /// <returns>Posisi waypoint yang sedang ditunjuk sekarang</returns>
        private Vector3 GetCurrentWaypointPosition() {
            return waypoints[currentWaypoint].position;
        }
    }
}