using UnityEngine;
using System.Collections;

public class worker1Ophelia : MonoBehaviour
{//All the positions which the player will stop at.
    [Header("Positions")]
    public Transform centrePoint;
    public Transform frontPoint;
    public Transform leftPoint;
   
        public Transform rightPoint;
    


    [Header("Speed")]
    public float moveSpeed = 2f;

    private Vector2[] path;

    void Start()
    {
        path = new Vector2[]
        {//worker starts at the centre point
    centrePoint.position,
     frontPoint.position,
     
     
    leftPoint.position,
     
     rightPoint.position,
     
        };

        transform.position = path[0];
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        while (true)
     {
            foreach (Vector2 target in path)
      {
                while (Vector2.Distance(transform.position, target) > 0.01f)
     {
  transform.position = Vector2.MoveTowards(
           transform.position,target,
         moveSpeed*Time.deltaTime );
                    yield return null;
  }

            transform.position = target;
            yield return new WaitForSeconds(3f);
            }     }
   }
}
