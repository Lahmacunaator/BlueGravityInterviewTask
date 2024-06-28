using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private Rigidbody2D rigidBody;
        private Animator animator;

        private Vector2 movement;

        void Start()
        {
            animator = GetComponent<Animator>();
            rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        
            animator.SetFloat("speed", movement.sqrMagnitude);
        }

        private void FixedUpdate()
        {
            rigidBody.MovePosition(rigidBody.position + movement * (moveSpeed * Time.fixedDeltaTime));
        }
    }
}