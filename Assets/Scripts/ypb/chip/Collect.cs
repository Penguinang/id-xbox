using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chip {
    public class Collect : MonoBehaviour {
        public float Velocity = 0.2f;
        public float CollectedSize = 0.5f;
        private bool _collected = false;
        public bool collected {
            get {
                return _collected;
            }
            private set {
                _collected = value;
            }
        }

        // void OnMouseUp() {
        //     if (collected)
        //         return;
        //     CollectionBar.Collect(gameObject);
        //     collected = true;
        //     pack();
        // }


        public void MoveTo(Vector2 position) {
            StartCoroutine(Move(position));
        }

        private void pack() {
            Bounds bounds = gameObject.GetComponent<SpriteRenderer>().sprite.bounds;
            transform.localScale = new Vector3(CollectedSize / bounds.extents.x, CollectedSize / bounds.extents.x, 1);
        }
        public void unpack() {
            transform.localScale = new Vector3(1, 1, 1);
        }
        private IEnumerator Move(Vector2 position) {
            float distance = Vector2.Distance(transform.position, position);
            Vector2 direction = (position - new Vector2(transform.position.x, transform.position.y)).normalized;
            while (distance > 0.1) {
                transform.Translate(direction * Velocity);
                yield return null;
                distance = Vector2.Distance(transform.position, position);
            }
            transform.position = position;
            CollectionBar.CollectComplete();
        }
    }
}