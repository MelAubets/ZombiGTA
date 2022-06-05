using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private GameObject Player;
        private Cinemachine.CinemachineVirtualCamera PlayerFollowerCamera;
        private Cinemachine.CinemachineVirtualCamera CarFollowerCamera;

        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            Player = GameObject.Find("Player");
            PlayerFollowerCamera = GameObject.Find("PlayerFollowCamera").GetComponent<Cinemachine.CinemachineVirtualCamera>();
            CarFollowerCamera = GameObject.Find("CarFollowCamera").GetComponent<Cinemachine.CinemachineVirtualCamera>();

            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
            if (Input.GetKey(KeyCode.E))
            {
                PlayerFollowerCamera.enabled = true;
                CarFollowerCamera.enabled = false;
                Player.transform.parent = null;
                Destroy(this.gameObject);
                Player.SetActive(true);

            }
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
