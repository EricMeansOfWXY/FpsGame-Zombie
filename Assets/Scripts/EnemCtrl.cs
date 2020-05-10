using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemCtrl : MonoBehaviour
{
    enum StateEnum
    {
        看到玩家 = 20,
        接近玩家 = 18,
        追逐玩家 = 10,
        攻击玩家 = 2
    }
    Animator _selfAnim;
    Transform _target;
    NavMeshAgent _selfNavAgent;
    const float maxHealth = 1;
    float _currentHealth = maxHealth;
    bool _isDead;
    public bool _hurt=false;
    private Slider _blood; 
    Collider _attack;
    Collider _attackBody;

    [SerializeField]
    [Range(1, 10)]
    float damage = 5;//僵尸伤害

    float worktime;
    [SerializeField]
    [Range(0.5f, 1)]
    float _attackspeed = 0.5f; 

    void Start()
    {
        _selfAnim = GetComponent<Animator>();
        _target = GameObject.Find("Player").transform;
        _selfNavAgent = GetComponent<NavMeshAgent>();
        _attack = GetComponent<SphereCollider>();
        _attackBody = GetComponent<CapsuleCollider>();
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
            TakeDamage(0.1f);
            _hurt = false;
        }
        float distance = Vector3.Distance(_target.position, transform.position);//僵尸与玩家的距离
        
       
        if (distance < (int)StateEnum.看到玩家)
        {
            _selfNavAgent.SetDestination(_target.position);
            _selfAnim.SetBool("See", true);
            if (distance < (int)StateEnum.接近玩家)
            {
                _selfAnim.SetBool("Close", true);
                if (distance < (int)StateEnum.追逐玩家)
                {
                    _selfAnim.SetBool("Closer", true);
                    if (distance < (int)StateEnum.攻击玩家)
                    {
                        _selfAnim.SetBool("Attack", true);
                    }
                    else
                    {
                        _selfAnim.SetBool("Attack", false);
                    }
                }
                else
                {
                    _selfAnim.SetBool("Closer", false);
                }
            }
            else
            {
                _selfAnim.SetBool("Close", false);
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
        _blood.value = _currentHealth;
        if (_currentHealth <= 0&&!_isDead)//僵尸血量低于0，死亡条件成立，播放死亡动画
        {
            Dead();
            
            
        }
    }
    public void Dead()
    {
        _blood.value = 0;
        _selfAnim.SetTrigger("Dead");
        _isDead = true;
        Destroy(_attack);//删除僵尸
        Destroy(_attackBody);//删除攻击碰撞体
        Destroy(gameObject, 2);
        GameObject.Find("LoadScene").GetComponent<LoadScene>()._pointLoad();
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            worktime += Time.deltaTime;
            if (worktime >= _attackspeed)
            {
                worktime = 0;
                player.TakeDamage(damage); 

            }
        }
    }   
}
