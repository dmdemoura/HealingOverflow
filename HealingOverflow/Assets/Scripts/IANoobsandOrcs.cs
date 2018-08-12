using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class IANoobsandOrcs : MonoBehaviour
{
    public GameObject _target;
    Transform target;
    public float speed = 5f;
    public float timeBetweenAttacks = 0.5f;
    public int Enemydamage = 4;
    public int Playerdamage = 2;
    public bool attackArea;
    public bool playerattack;
    float timer;
    Health health;

    private void Start()
    {
        health = GetComponent<Health>();
        GameManager.AddEntity(gameObject);
    }
    void Update()
    {
        if (this.CompareTag("Player"))
        {  
         _target = GameManager.FindNearAt("Enemy", transform.position);

            if (_target != null)
            {
                timer += Time.deltaTime;
                target = _target.transform;
                if (attackArea == false)
                {
                    Chase();
                }

                if (timer >= timeBetweenAttacks && attackArea && health.currentHealth > 0 && _target.GetComponent<Health>().currentHealth > 0)
                {
                    Attack();
                }
                else if(timer >= timeBetweenAttacks && playerattack && health.currentHealth > 0)
                {
                    Attack();
                }
                

            }
            
        }

        else if (this.CompareTag("Enemy"))
        {
         
           _target = GameManager.FindNearAt("Player", transform.position);

            if (_target != null)
            {
                timer += Time.deltaTime;
                target = _target.transform;

                if (attackArea == false)
                {
                    Chase();
                }

                if (timer >= timeBetweenAttacks && attackArea && health.currentHealth > 0 && _target.GetComponent<Health>().currentHealth > 0)
                {
                    Attack();
                }
             
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D other)
    {

        if (this.CompareTag("Player") && other.gameObject.CompareTag("Enemy"))
        {
            attackArea = true;
        }
        else if (this.CompareTag("Enemy") && other.gameObject.CompareTag("Player"))
        {
            attackArea = true;
        }
        else if(this.CompareTag("Player") && other.gameObject.CompareTag("Player"))
        {
            playerattack = true;
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
        else if (this.CompareTag("Player") && other.gameObject.CompareTag("Player"))
        {
            playerattack = true;
        }

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

        if(this.CompareTag("Player"))
        {
            if(attackArea)
            {
                health.Damage(Playerdamage);

                Debug.Log("Enemy health is " + _target.GetComponent<Health>().currentHealth);
            }
           else if(playerattack)
            {
                health.Damage(Playerdamage);
                Debug.Log("Player attacking player, the current health is " + health.currentHealth);
            }
        }
        
      
        else if(this.CompareTag("Enemy"))
        {
            health.Damage(Enemydamage);
            Debug.Log("Player health is " + _target.GetComponent<Health>().currentHealth);
        }

    }
}
