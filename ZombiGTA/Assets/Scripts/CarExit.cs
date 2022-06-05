using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarExit : MonoBehaviour
{
    private CarUserControl m_User;

    private void Awake()
    {
        m_User = GetComponent<CarUserControl>();
    }

    private void Update()
    {
        if (m_User.enabled)
        {
            if (Input.GetKey("E"))
            {

            }
        }
    }
}
