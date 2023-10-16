using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    private NavMeshAgent navAgent;

    private bool canMove = true;

    private float currentLerpTime;
    private float lerpTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyCanMove(canMove) && transform.GetComponent<NavMeshAgent>().enabled == true)
        {
            navAgent.destination = FindObjectOfType<Movement>().gameObject.transform.position;
        }

        if (!EnemyCanMove(canMove))
        {
            if (currentLerpTime != lerpTime)
            {
                PushbackEnemy();
            }
        }
    }

    //
    private void PushbackEnemy()
    {
        Vector3 a = transform.position;
        Vector3 b = transform.position - transform.forward;

        currentLerpTime += Time.deltaTime;

        transform.GetComponent<NavMeshAgent>().enabled = false;

        if (currentLerpTime > lerpTime)
        {
            this.GetComponent<AIController>().DestroyThisEnemy();
            EnemyCanMove(true);
            currentLerpTime = 0f;
        }

        float t = currentLerpTime / lerpTime;

        transform.position = Vector3.Lerp(a, b, t);
    }

    //
    public bool EnemyCanMove(bool _canMove)
    {
        if (_canMove)
        {
            canMove = true;
        }
        else if (!_canMove)
        {
            canMove = false;
        }

        return canMove;
    }
}