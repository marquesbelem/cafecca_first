using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject[] Targets;
    private Vector3 _Target;

    public float Distance = 10;
    public float StoppingDistance = 2;
    public float Speed = 5;
    public enum Type
    {
        Follow,
        Random
    }

    public Type Movement;

    private void Start()
    {
        Targets = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update()
    {
        switch (Movement)
        {
            case Type.Follow:
                Follow();
                break;
            case Type.Random:
                break;
        }
    }

    private void Follow()
    {
        for (var idx = 0; idx < Targets.Length; idx++)
        {
            //Inimigo irá seguir o player mais proximo a ele
            if (Vector3.Distance(Targets[idx].transform.position, transform.position) < Distance)
            {
                _Target = new Vector3(Targets[idx].transform.position.x, transform.position.y, Targets[idx].transform.position.z);
            }
        }

        //Inimigo irá parar antes de chegar perto do player
        if (Vector3.Distance(transform.position, _Target) > StoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _Target, Speed * Time.deltaTime);

            Vector3 relativePosition = _Target - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(relativePosition, Vector3.up);
            transform.rotation = targetRotation;
        }
    }
}
