using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    const float maxHealth = 100;
    float _currentHealth;
    private Slider Hp;
    bool isDead;
    public GameObject _key01,_key02;
    public bool key01,key02;
    [SerializeField]
    Image _effect;

    void Start()
    {
        _currentHealth = maxHealth;
        Hp =  GameObject.Find("Hp").GetComponent<Slider>();
        _key01 = GameObject.Find("Key01");
        _key02 = GameObject.Find("Key02");
        key01 = false;
        key02 = false;
        _key01.gameObject.SetActive(false);
        _key02.gameObject.SetActive(false);


    }
   
   

    internal void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        Hp.value = _currentHealth;
        DamageEffect();
        if (_currentHealth <= 0&&!isDead)
        {
            Dead();  
        }
    }

    private void DamageEffect()
    {
        StartCoroutine(Damage(0.5f));
    }
    IEnumerator Damage(float des, bool alive=true)//协程，一帧执行一次
    {
        float worktime = 0;
        bool _isGrow = true;
        while (true)
        {

            if (worktime >= des)
            {
                if (alive) 
                {
                    _isGrow = false;
                }
                else
                {
                   
                   SceneManager.LoadScene("LoseGame");//死亡，跳到失败界面                 
                }

            }
            
            if (_isGrow)
            {
                worktime += Time.deltaTime;//deltaTime两帧之间的时间 
            } 
            else
            {
                worktime -= Time.deltaTime;
            }
            _effect.color = Color.Lerp(Color.clear, Color.red,worktime);//遭受到攻击，图片颜色渐变，提示受到攻击
            if (worktime <=0) 
            {
              
                yield break;
            }
            yield return null;
        }
    }
    public void Dead()
    {

        isDead = true;
        Hp.value = 0;
        StartCoroutine(Damage(1,false));
    }
}
