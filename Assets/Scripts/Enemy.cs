using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _lookRadius = 20f;
    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private int _enemyDamage = 2;
    [SerializeField] private float _nextTimeToAttack = 1f;
    [SerializeField] private Animator _animator;
    private float _attackRate = 0f;

    void Start()
    {
        _target = PlayerControllerF.Instance.transform;
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Agent();
    }

    void Agent()
    {
        _attackRate += Time.deltaTime;
        float distance = Vector3.Distance(_target.position, transform.position);
        if (distance <= _lookRadius)
        {
            _agent.SetDestination(_target.position);
            if (distance <= _agent.stoppingDistance)
            {
                if (/*PlayerControllerF.Instance.playerHealth > 0 &&*/ _attackRate > _nextTimeToAttack)
                {
                    FaceTarget();
                    Debug.Log("ATTACK!");
                    Attack();
                    _attackRate = 0f;
                }
            }
        }
    }

    void Attack()
    {
        //ATTACK ANIMASYONU SET EDILECEK VE PLAYER'A DAMAGE VERECEK.
        _animator.SetBool("isAttack", true);
        //PlayerController.playerInstance.TakeDamage(_enemyDamage);
    }

    //AI YÖNÜNÜ KARAKTERE DÖNDÜREN METOT.
    void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    //GetHit animasyonu set edilecek ve can 0 olunca Die fonksiyonu çağırılacak.
    public void TakeDamage(int amount)
    {
        _animator.SetBool("isAttack", false);
        _animator.SetBool("GetHit", true);
        /*enemyHealth -= amount;
        if (enemyHealth <= 0)
        {
            Die();
        }*/
    }

    //Die animasyonu set edilecek ve obje yokedilecek.
    void Die()
    {
        _animator.SetBool("isDead", true);
        Destroy(gameObject, 2.5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _lookRadius);
    }

    //İskeletin collider'ına kılıç çarparsa hasar alacak.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            //TakeDamage(PlayerControllerF.Instance.playerDamage);
        }
    }
}