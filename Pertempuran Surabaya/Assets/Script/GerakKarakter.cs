using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakKarakter : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    [SerializeField]
    private float kecepatan = 6f;
    [SerializeField]
    private float waktuBerputarHalus = 0.1f;
    private float velocityBerputarHalus;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 arahGerak = new Vector3(horizontal, 0f, vertical).normalized;

        if (arahGerak.magnitude >= 0.1f)
        {
            float targetAngel = Mathf.Atan2(arahGerak.x, arahGerak.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref velocityBerputarHalus, waktuBerputarHalus);
            transform.rotation = Quaternion.Euler(0f, angel, 0f);

            Vector3 arahBergerak = Quaternion.Euler(0f, targetAngel, 0f) * Vector3.forward;
            controller.Move(arahBergerak * kecepatan * Time.deltaTime);
        }
    }
}
