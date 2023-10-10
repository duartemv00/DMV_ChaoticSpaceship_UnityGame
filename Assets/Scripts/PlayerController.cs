using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof (Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private float hMov;
    private float vMov;
    private float hRot;
    private float vRot;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float rotSpeed = 180f;

    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletOriginPosition;

    void Update()
    {
        // Almacenar valor del los input axis para Movimiento
        hMov = Input.GetAxis("HorizontalMov");
        vMov = Input.GetAxis("VerticalMov");
        // Almacenar valor del los input axis para Rotacion
        hRot = Input.GetAxis("HorizontalLook");
        vRot = Input.GetAxis("VerticalLook");

        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z += hRot * rotSpeed * Time.deltaTime * -1;
        rot = Quaternion.Euler( 0, 0, z);
        transform.rotation = rot;

        if (Input.GetButtonDown("Fire")) {
            Fire();
        }
    }

    private void FixedUpdate() {
        //MOVIMIENTO con sistema de fisicas
        rb2D.velocity = new Vector2(hMov * speed, vMov * speed);
    }

    private void Fire() {
        //Instantiate(bulletPrefab, bulletOriginPosition.position, Quaternion.identity);

        GameObject bullet = ObjectPool.OPinstance.GetPooledObject();
        if (bullet != null) {
            bullet.transform.position = bulletOriginPosition.position;
            bullet.transform.rotation = gameObject.transform.rotation;
            //bullet.GetComponent<Bullet>().bulletZ = transform.rotation.eulerAngles.z;
            bullet.SetActive(true);
        }
    }

}
