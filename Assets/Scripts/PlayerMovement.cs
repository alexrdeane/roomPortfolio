using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [RequireComponent(typeof(Rigidbody))]
    [AddComponentMenu("Artificial Intelligence/Player/Movement")]

    public class PlayerMovement : MonoBehaviour
    {
        #region Variables
        [Header("Variables: ")]
        //player's movement speed
        public float movementSpeed = 5f;
        public float movementThreshold;
        //player's private rigidbody
        private Rigidbody rigid;
        public Joystick joystick;
        #endregion

        #region Start
        void Start()
        {
            //gets the rigid body from the player
            rigid = GetComponent<Rigidbody>();
        }
        #endregion

        #region Update
        void Update()
        {
            Move();
        }
        #endregion

        void Move()
        {
            Vector2 input = new Vector2(joystick.Horizontal, joystick.Vertical);
            if (input.x * input.x + input.y * input.y < movementThreshold * movementThreshold)
            {
                input = input.normalized * 0.001f;
            }
            else
            {
                input = input.normalized;
            }

            rigid.velocity = new Vector3(input.x, 0f, input.y) * movementSpeed;
            if (input != Vector2.zero)
            {
                transform.forward = rigid.velocity;
            }
        }
    }
}

