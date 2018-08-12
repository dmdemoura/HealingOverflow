using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class IANoobsandOrcs : MonoBehaviour
{
    GameObject _target;
    Transform target;

    public float speed = 5f;
    public float timeBetweenAttacks = 0.5f;
    public int damage = 4;
    public bool attackArea;
    float timer;
    
    private Rigidbody2D mRigidbody;
    Health health;

    private Animator mAnim;

    private void Start()
    {
        mAnim = GetComponentInChildren<Animator>();
        health = GetComponent<Health>();

        mRigidbody = GetComponent<Rigidbody2D>();

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

                if (timer >= timeBetweenAttacks)
                {
                    Attack();
                    mAnim.SetBool("Atacking", true);
                }else{
                    mAnim.SetBool("Atacking", false);
                }
            }
            else
            {
                mRigidbody.velocity = Vector3.zero;

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

                if (timer >= timeBetweenAttacks)
                {
                    Attack();
                   
                }

            }
            else
            {
                mRigidbody.velocity = Vector3.zero;
              
            }
        
        }
        mAnim.SetFloat("Horizontal", mRigidbody.velocity.x);

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

    void Chase()
    {

        Vector2 targetDir = target.position - transform.position;

        if (targetDir.magnitude > 1)
        {
            mRigidbody.velocity = targetDir.normalized * speed;
        }
        else
        {
         
            mRigidbody.velocity = Vector3.zero;
        }
    }



    void Attack()
    {
        timer = 0f;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + Vector3.forward, 1f);
        
        foreach (Collider2D collider in colliders)
        {
            if(collider.gameObject != this.gameObject && collider.gameObject.GetComponent<Health>().currentHealth > 0 && health.currentHealth > 0)
            {
                collider.GetComponent<Health>().Damage(damage);
            }

        }
    }

}
