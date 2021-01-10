using UnityEngine;
using UnityEngine.AI;
    
public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 50)]
    public float speed = 3;
    [Header("停止距離"), Range(0, 50)]
    public float stopDistence = 2.5f;
    [Header("攻擊冷卻時間"), Range(0, 50)]
    public float cd = 2f;

    private Transform player;
    private NavMeshAgent nav;
    private Animator ani;
    private float timer;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        player = GameObject.Find("老公公").transform;

        nav.speed = speed;
        nav.stoppingDistance = stopDistence;
    }
    private void Update()
    {
        Track();
        Attack();
    }
    private void Attack()
    {
        if (nav.remainingDistance < stopDistence)
        {
            Vector3 pos = player.position;
            pos.y = transform.position.y;
            transform.LookAt(pos);
            if (timer >= cd)
            {
                ani.SetTrigger("攻擊觸發");
                timer = 0;
            }
            
        }
    }
    private void Track()
    {
        nav.SetDestination(player.position);
        ani.SetBool("跑步開關", nav.remainingDistance > stopDistence);
    }
}
