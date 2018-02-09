using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chip {
    public class RotateController : MonoBehaviour {

        private Vector2 startDirection;
        private bool rotating = false;
        private Transform operatingChip;
        private Vector3 right;

        // Update is called once per frame
        void Update() {
            // Start rotating
            if (!rotating && Input.touchCount >= 2) {
                operatingChip = GetOperatingChip();
                if (operatingChip != null) {
                    right = operatingChip.right;
                    Unlock(operatingChip.gameObject);
                }
                startDirection = GetTouchDirection();
                rotating = true;
            }
            // End rotating
            else if (rotating && Input.touchCount <= 1) {
                if (operatingChip != null)
                    Lock(operatingChip.gameObject);
                operatingChip = null;
                rotating = false;
            }
            // Rotating
            else if (rotating && operatingChip != null) {
                Vector2 newDirection = GetTouchDirection();
                float angle = Vector2.Angle(startDirection, newDirection);
                if (Vector3.Cross(startDirection, newDirection).z < 0) {
                    angle *= -1;
                }

                operatingChip.right = Quaternion.AngleAxis(angle, operatingChip.forward) * right;
            }
        }

        /// <summary>
        /// 得到当前操作的碎片。判断依据为在两个触摸点为半径的圆内，切距离中点最近的碎片
        /// </summary>
        private Transform GetOperatingChip() {
            Transform result = null;
            float minDistance = 99999;
            Vector2 touch0 = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touch1 = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);
            Vector2 origin = (touch1 + touch0) / 2;
            float radius = Vector2.Distance(touch0, origin);

            // List<Transform> chips = ChipsManager.GetChips();
            List<GameObject> chips = CollectionBar.instance.GetChips();
            foreach (GameObject chip in chips) {
                float distance = Vector2.Distance(chip.transform.position, origin);
                if (distance > radius)
                    continue;
                if (distance < minDistance) {
                    result = chip.transform;
                    minDistance = distance;
                }
            }
            return result;
        }

        private void Lock(GameObject obj) {
            Rigidbody2D rigidbody = obj.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
                rigidbody.bodyType = RigidbodyType2D.Kinematic;
        }
        private void Unlock(GameObject obj) {
            Rigidbody2D rigidbody = obj.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
                rigidbody.bodyType = RigidbodyType2D.Dynamic;
        }

        private static Vector2 GetTouchDirection() {
            if (Input.touchCount < 2)
                return new Vector2();
            return Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position) - Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
    }
}
