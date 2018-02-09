using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chip {
    public class Move : MonoBehaviour {
        private Vector2 bias;
        public delegate void OnMoveHandler();
        private event OnMoveHandler onMoveEvent;

        void OnMouseDown() {
            if (Input.touchCount > 1)
                return;
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
            rigidbody.freezeRotation = true;

            bias = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

            onMoveEvent();
        }

        void OnMouseDrag() {
            if (Input.touchCount > 1)
                return;

            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            Vector2 newPosition = new Vector3(mouse.x, mouse.y, transform.position.z) + new Vector3(bias.x, bias.y, 0);
            rigidbody.MovePosition(newPosition);

            onMoveEvent();
        }

        void OnMouseUp() {
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
            rigidbody.freezeRotation = false;

            onMoveEvent();
        }

        public void Subscribe(OnMoveHandler f){
            onMoveEvent += f;
        }

    }
}
