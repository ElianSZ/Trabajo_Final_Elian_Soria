using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // private Vector3 initialPos = new Vector3(0, 100, 0);
     public float speed = 4f;
     public float runSpeed = 7f;
     public float rotSpeed = 40f;
     public float rot = 0f;

    // public float graviy = 0f;
    public Vector3 moveDir = Vector3.zero;
    private CharacterController controller;
    private Animator anim;

    public GameObject projectilePrefab;
    public GameObject shooter1;
    public GameObject shooter2;

    public Transform turretTransform;

    public ParticleSystem explosionParticleSystem;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Se dispara el proyectil 1
            Instantiate(projectilePrefab, shooter1.transform.position, transform.rotation);
            Instantiate(explosionParticleSystem, shooter1.transform.position, transform.rotation);

            // Se dispara el proyectil 2
            Instantiate(projectilePrefab, shooter2.transform.position, transform.rotation);
            Instantiate(explosionParticleSystem, shooter2.transform.position, transform.rotation);

            // Ejecuta una vez el audio de disparo
            // playerAudioSource.PlayOneShot(shotClip, 1f);
        }

        // HandleTurret();
    }

    private void Movement()
    {
        // Caminar
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("Walk", 1);

            moveDir = new Vector3(0, 0, 1);
            moveDir = moveDir * speed;
            moveDir = transform.TransformDirection(moveDir);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("Walk", 0);

            moveDir = new Vector3(0, 0, 0);
        }

        // Correr
        if (Input.GetKey (KeyCode.LeftShift))
        {
            anim.SetInteger("Run", 1);

            moveDir = new Vector3(0, 0, 1);
            moveDir = moveDir * runSpeed;
            moveDir = transform.TransformDirection(moveDir);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetInteger("Run", 0);

            moveDir = new Vector3(0, 0, 0);
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        controller.Move(moveDir * Time.deltaTime);
    }

    /*
    void HandleTurret()
    {
        if (turretTransform)
        {
            Vector3 turretLookDir = mousePosition - turretTransform.position;
        }
    }
    */
}