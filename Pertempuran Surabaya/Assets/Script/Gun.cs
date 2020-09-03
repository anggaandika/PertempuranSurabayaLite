using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.5f, 1.5f)]
    private float kecepatanTembakan = 1;
    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;
    public Transform poinTembak;
    public AudioSource gunFireSource;
    private float time;
    private Animator animator;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= kecepatanTembakan)
        {
            if(Input.GetButton("Fire1"))
            {
                time = 0f;
                TembakSenjata();
            } else if(!Input.GetButton("Fire1"))
            {
                animator.SetBool("Fire", false);
            }
        }
    }

    private void TembakSenjata()
    {
        gunFireSource.Play();
        animator.SetBool("Fire", true);
        Debug.DrawRay(poinTembak.position, poinTembak.forward * 100, Color.red, 2f);
        Ray ray = new Ray(poinTembak.position, poinTembak.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100))
        {
            var health = hit.collider.GetComponent<Health>();

            if (health != null)
                health.TakeDamage(damage);
        }
    }
}
