using UnityEngine;

//Move a gameObject towards a randomly selected target
//Match the targets scale and rotation
//Keep moving the gameObject from target position to target position.

public class LerpExample : MonoBehaviour
{
    //Properties
    public Transform[] targets;
    private Transform start;
    private Transform end;
    public float lerpDuration = 2f;
    private float elapsedTime = 0f;


    //Instantiate random start and end point values.
    void Start()
    {
        start = targets[Random.Range(0, targets.Length -1)];
        end = targets[Random.Range(0, targets.Length - 1)];
    }

    //Move the gameObject towards the new target with matching scale and rotation.
    //Once the gameObject reaches the target, set a new target.
    void Update()
    {
        if(elapsedTime < lerpDuration)
        {
            transform.position = Vector3.Lerp(start.position, end.position, elapsedTime / lerpDuration);
            transform.rotation = Quaternion.Slerp(start.rotation, end.rotation, elapsedTime / lerpDuration);
            transform.localScale = Vector3.Lerp(start.localScale, end.localScale, elapsedTime / lerpDuration);
            elapsedTime += Time.deltaTime;
        }
        else
        {
            elapsedTime = 0f;
            start = end;
            do
            {
                end = targets[Random.Range(0, targets.Length - 1)];
            }
            while (end == start);
        }
    }
}
