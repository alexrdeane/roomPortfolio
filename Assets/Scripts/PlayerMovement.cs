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
        public float movementSpeed = 20f;
        public float sphereCollide = 4.5f;
        //player's private rigidbody
        private Rigidbody rigid;
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
            //META only refrenced in update because it is only needed in update (doesnt need to be constantly checked)
            //get input axis as float for x and y
            float inputX = Input.GetAxis("Horizontal");
            float inputZ = Input.GetAxis("Vertical");
            //create input vector
            Vector3 input = new Vector3(inputX, 0, inputZ);
            //apply velocity
            rigid.velocity = input * movementSpeed;

        }
        #endregion

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, sphereCollide);
        }
    }
}

