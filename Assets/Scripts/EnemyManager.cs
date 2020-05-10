using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    GameObject _originZombie;
    Transform[] _bornPlace;
    private int enemyCounter;
    public int enemySum = 10;
    // Start is called before the first frame update
    void Start()
    {
        _originZombie = Resources.Load<GameObject>("Zombie");
        _bornPlace = new Transform[transform.childCount];
        enemyCounter = 0;
        for (int i = 0; i < _bornPlace.Length; i++)
        {
            _bornPlace[i] = transform.GetChild(i);
        }
        InvokeRepeating("CreatZombie", 2, 2);//传入方法名，等待多少时间后执行第一次，每隔多少时间重复执行
    }
    void CreatZombie()
    {
        
        int random = Random.Range(0, _bornPlace.Length);
        GameObject cloneZombie = Instantiate(_originZombie, _bornPlace[random].position, _bornPlace[random].rotation);
        enemyCounter++;
        if (enemyCounter == enemySum)
        {
            CancelInvoke();//停止产生僵尸
        }
    }

   
   
}
