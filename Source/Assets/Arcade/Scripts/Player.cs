using System;
using UnityEngine;
using Unity.Mathematics;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Arcade
{
    public class Player : MonoBehaviour
    {
        public static bool canMove = true, canRot = true;

        public bool IsGrounded => Physics.Raycast(transform.position, Vector3.down, groundLimit);

        public float fallStrength;
        public float groundLimit;
        public float jumpHeight;
        public float moveSpeed;
        public float2 rotClamp;
        public float rotSmoothFPS;
        public float rotSpeed;

        internal Camera cam;

        private CapsuleCollider col;
        private Rigidbody rb;
        private float2 rot;
        private float2 rotDes;

        private void Awake()
        {
            cam = transform.Find("Camera").GetComponent<Camera>();
            col = GetComponent<CapsuleCollider>();
            rb = GetComponent<Rigidbody>();

            rot = new float2(transform.eulerAngles.y, cam.transform.localEulerAngles.x);
            rotDes = rot;

            col.material = new PhysicMaterial("Player Physics Material")
            {
                bounceCombine = PhysicMaterialCombine.Maximum,
                bounciness = 0,
                dynamicFriction = 0,
                frictionCombine = PhysicMaterialCombine.Average,
                staticFriction = 0,
            };
        }

        private void Update()
        {
            Cursor.lockState = (CursorLockMode)Convert.ToInt32(canRot);
            if (canRot) Rotation();
            if (canMove) Movement();

            if (rb.velocity.y < -0.5f) rb.velocity += Vector3.down * (fallStrength - 1);
        }

        private void Movement()
        {
            float2 dirs = new float2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Quaternion rot = Quaternion.Euler(new float3 { y = transform.eulerAngles.y });

            rb.AddForce(rot * (moveSpeed * Time.deltaTime * (Vector3.forward * dirs.y + Vector3.right * dirs.x).normalized), ForceMode.Impulse);

            if (Input.GetButtonDown("Jump") && IsGrounded) rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        private void Rotation()
        {
            float2 dirs = new float2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            rotDes += dirs;
            rotDes.y = Mathf.Clamp(rotDes.y, rotClamp.y, rotClamp.x);
            if (Time.deltaTime >= 1 / rotSmoothFPS) rot = rotDes;
            else rot += (rotDes - rot) * Time.deltaTime * rotSpeed;

            transform.eulerAngles = new float3 { y = rot.x };
            cam.transform.localEulerAngles = new float3 { x = -rot.y };
        }
    }
}
