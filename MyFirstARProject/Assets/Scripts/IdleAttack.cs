using UnityEngine;

public class IdleAttack : MonoBehaviour
{
    private Animator object1Animator;
    private Animator object2Animator;
    private float distance = 0.25f; // Distanța de declanșare

    void Start()
    {
        GameObject player1 = GameObject.FindWithTag("Monster");
        GameObject player2 = GameObject.FindWithTag("Cactus");

        if (player1 != null && player2 != null)
        {
            object1Animator = player1.GetComponent<Animator>();
            object2Animator = player2.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("There are no objects with the specified tags!");
        }
    }

    void Update()
    {
        if (object1Animator != null && object2Animator != null)
        {
            float currentDistance = Vector3.Distance(object1Animator.transform.position, object2Animator.transform.position);

            if (currentDistance <= distance)
            {
                object1Animator.SetTrigger("TrAttack");
                object2Animator.SetTrigger("TrAttack");
            }
            else
            {
                object1Animator.SetTrigger("TrIdle");
                object2Animator.SetTrigger("TrIdle");
            }
        }
    }
}