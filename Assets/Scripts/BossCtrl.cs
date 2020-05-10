using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossCtrl : MonoBehaviour
{
    int _delay;
    int blend01;
    Animator _selfAnim;
    Transform _target;
    NavMeshAgent _selfNavAgent;
    const float maxHealth = 200;
    float _currentHealth = maxHealth;
    bool _isDead;
    public bool _hurt = false;
    public bool _head = false;
    public bool _recover = false;
    private Slider _blood;

   
   
    void Start()
    {
        blend01 = 0;
        _selfAnim = GetComponent<Animator>();
        _target = GameObject.Find("Player").transform;
        _selfNavAgent = GetComponent<NavMeshAgent>();
        _blood = this.GetComponentInChildren<Slider>();
        _blood.value = maxHealth;
       
    }
    void Update()
    {
        if (_isDead)
        {
            _selfNavAgent.isStopped = true;
            return;
        }
        if (_hurt)//被子弹击中，减少血量
        {
            TakeDamage(1f);
            _hurt = false;
        }
        if (_head)
        {
            TakeDamage(5f);
            _head = false;
        }
        if (_recover == true && _currentHealth < maxHealth)
        {
            TakeDamage(-1f);
            _recover = false;
        }
        float distance = Vector3.Distance(_target.position, transform.position);//僵尸与玩家的距离


        if (distance < 20.0f)
        {
           
            _selfAnim.SetBool("See", true);
            //_selfNavAgent.SetDestination(_target.position);
            if (distance < 10.0f)
            {
                _selfAnim.SetBool("Closer", true);
                if (distance < 1.5f)
                {
                    _selfAnim.SetBool("Attack", true);
                    //_selfNavAgent.SetDestination(transform.position);
                }
                else
                {
                    _selfAnim.SetBool("Attack", false);
                    //_selfNavAgent.SetDestination(_target.position);
                }
            }
            else
            {
                _selfAnim.SetBool("Closer", false);
               // _selfNavAgent.SetDestination(_target.position);
            }
        }
        else
        {
            _selfNavAgent.SetDestination(transform.position);
            _selfAnim.SetBool("See", false);
        }
    }
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        Debug.Log(_currentHealth);
        if (_currentHealth <= 10)
        {
            _selfAnim.SetTrigger("Hurt");

        }
        else
            _selfAnim.SetBool("LowHp", true);
        _blood.value = _currentHealth;
        if (_currentHealth <= 0 && !_isDead)//僵尸血量低于0，死亡条件成立，播放死亡动画
        {
            Dead();


        }
    }
    public void Dead()
    {
        _blood.value = 0;
        _selfAnim.SetTrigger("Dead");
        _isDead = true;
        Destroy(gameObject, 2);
    }
   

}
