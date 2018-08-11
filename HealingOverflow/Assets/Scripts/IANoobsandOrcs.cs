using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class IANoobsandOrcs : MonoBehaviour
{

    Transform target;
    GameObject _target;
    public float speed = 5f;
    public float timeBetweenAttacks = 0.5f;
    public int Enemydamage = 4;
    public int Playerdamage = 2;
    public bool attackArea;
    float timer;


    Health health;

    void Update()
    {
        if (this.CompareTag("Player"))
        {
            _target = GameObject.FindGameObjectWithTag("Enemy");
            timer += Time.deltaTime;
            target = _target.transform;
            if(attackArea == false)
            {
                Chase();
            }
        
            if(timer >= timeBetweenAttacks && attackArea && health.currentHealth > 0)
            {
                Attack();
            }

            if(health.currentHealth <= 0)
            {
                Destroy(_target);
                Debug.Log("Enemy is dead");
            }
        }
        else if (this.CompareTag("Enemy"))
        {
            _target = GameObject.FindGameObjectWithTag("Player");
            timer += Time.deltaTime;
            target = _target.transform;
            if(attackArea == false)
            {
                Chase();
            }
        
            if (timer >= timeBetweenAttacks && attackArea && health.currentHealth > 0)
            {
                Attack();
            }
            if(health.currentHealth == 0)
            {
                Destroy(_target);  
                Debug.Log("Player is dead");
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D other)
    {

        if (this.CompareTag("Player") && (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player")))
        {
            attackArea = true;
        }
        else if (this.CompareTag("Enemy") && other.gameObject.CompareTag("Player"))
        {
            attackArea = true;
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (this.CompareTag("Player") && other.gameObject.CompareTag("Enemy"))
        {
            attackArea = false;
        }
        else if (this.CompareTag("Enemy") && other.gameObject.CompareTag("Player"))
        {
            attackArea = false;
        }
    }

    void FindTheClosest()
    {
        //float distTarget = Mathf.Infinity;
        //closesttarget = null;
        //alltarget = GameObject.FindGameObjectsWithTag("");
    }

    void Chase()
    {
        Vector3 targetDir = target.position - transform.position;

        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

   

    void Attack()
    {
        timer = 0f;

        if(this.CompareTag("Player") && health.currentHealth > 0)
        {
            health.Damage(Playerdamage);
            Debug.Log("Enemy health is " + health.currentHealth);
        }
        else if(this.CompareTag("Enemy") && health.currentHealth > 0)
        {
            health.Damage(Enemydamage);
            Debug.Log("Player health is " + health.currentHealth);
        }

    }
}
