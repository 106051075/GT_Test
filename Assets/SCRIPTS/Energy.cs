using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ParticleSystem))]

public class Energy : MonoBehaviour
{
    int crystal;
    public static bool energyClick1 = false;
    public static bool energyClick2 = false;
    public Animator ani;
    private int hp = 1;
    private bool MC = false;
    bool isOver = false;
    ParticleSystem par;
    ParticleSystem.Particle[] arrPar;
    int arrCount = 0;
    public Transform target;
    public float speed = 0.1f;

    private void Start()
    {
        par = GetComponent<ParticleSystem>();
        arrPar = new ParticleSystem.Particle[par.main.maxParticles];
        crystal = LayerMask.NameToLayer("crystal");
    }
    private void OnMouseOver()
    {
        isOver = true;
    }
    private void OnMouseExit()
    {
        isOver = false;
    }
    private void Update()
    {
        touch();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == crystal)
        {
            MC = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == crystal)
        {
            MC = false;
        }
        if (other.gameObject.layer == crystal && hp == 1 && Input.GetMouseButtonUp(1))
        {
            energyClick2 = false;
            MC = false;
        }
        if (other.gameObject.layer == crystal && hp == 0 && Input.GetMouseButtonUp(0))
        {
            energyClick1 = false;
            MC = false;
        }
    }
    private void touch()
    {
       if(isOver == true)
        {
            if(MC == true)
            {
                if (Input.GetMouseButtonDown(0) && EnergyNumber.a <= 4 && EnergyNumber.a >= 0 && hp == 1)
                {
                    energyClick1 = true;
                    ani.SetBool("Click", true);
                    hp -= 1;
                }
                if (Input.GetMouseButtonDown(1) && EnergyNumber.a >= 1 && EnergyNumber.a <= 5 && hp == 0)
                {
                    energyClick2 = true;
                    ani.SetBool("Click", false);
                    hp += 1;
                }
            }
        }
    }
}
