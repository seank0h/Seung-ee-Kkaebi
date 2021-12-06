using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class MobilePlayerMovement : MonoBehaviour
    {
        [Header("Player")]
        [Tooltip("Move speed of the character in m/s")]
        public float MoveSpeed = 4.0f;
        [Tooltip("Sprint speed of the character in m/s")]
        public float SprintSpeed = 6.0f;
        [Tooltip("Rotation speed of the character")]
        public float RotationSpeed = 1.0f;
        [Tooltip("Acceleration and deceleration")]
        public float SpeedChangeRate = 10.0f;


        Vector3 forward;
        Vector3 right;

        public GameObject inputManager;
        private CharacterController _controller;
        private StarterAssetsInputs _input;
        // Start is called before the first frame update
        void Start()
        {
            
            _controller = GetComponent<CharacterController>();
            _input = inputManager.GetComponent<StarterAssetsInputs>();
            forward = Camera.current.transform.forward;
            forward.y = 0;
            forward = Vector3.Normalize(forward);
            right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
            

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
