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
        public Animator anim;
        public GameObject swordWoosh;
        public float whooshTimer = 0f, whooshTimerMax = 0.75f;
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
            whooshTimer += Time.deltaTime;
            Move();
        }
        #endregion

        void Move()
        {
            Vector2 input = new Vector2(joystick.Horizontal, joystick.Vertical);
            if (input.x * input.x + input.y * input.y < movementThreshold * movementThreshold)
            {
                anim.SetBool("isWalking", false);
                input = input.normalized * 0.001f;
            }
            else
            {
                anim.SetBool("isWalking", true);
                input = input.normalized;
            }

            rigid.velocity = new Vector3(input.x, 0f, input.y) * movementSpeed;
            if (input != Vector2.zero)
            {
                transform.forward = rigid.velocity;
                swordWoosh.SetActive(false);
            }
        }

        public void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("melee"))
            {
                anim.Play("attack");
                swordWoosh.SetActive(false);
            }
        }
    }
}

