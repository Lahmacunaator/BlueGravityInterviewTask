using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        private Rigidbody2D _rigidBody;
        private Animator _animator;
        private Vector2 _movement;
        
        private static readonly int Speed = Animator.StringToHash("speed");

        void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");
        
            _animator.SetFloat(Speed, _movement.sqrMagnitude);
        }

        private void FixedUpdate()
        {
            _rigidBody.MovePosition(_rigidBody.position + _movement * (moveSpeed * Time.fixedDeltaTime));
        }
    }
}