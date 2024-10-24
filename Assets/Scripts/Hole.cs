using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BallLogic>(out var ball)) 
        {
            FindObjectOfType<ScoreManager>().IncrementScore(); 

            Debug.Log("Score incremented");

            //resetam pozitia mingii:
            ball.ResetPosition();
        }
    }
}
