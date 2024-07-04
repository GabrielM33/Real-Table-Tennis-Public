using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab;
    public float spawnInterval = 3.0f;
    public GameObject spawnPosition;
    public float forceApplied;
    public float elevationAngle;

    public void InvokeHardMode()
    {
        Debug.Log("Invoking Hard Mode");
        // Cancel all other invokes
        CancelInvoke();

        // Start hard mode
        InvokeRepeating("PlayHardMode", 0f, spawnInterval);
    }

    public void PlayHardMode()
    {
        Debug.Log("Playing Hard Mode");
        // Instantiate the ball at the position of the spawnPosition GameObject
        GameObject spawnedBall = Instantiate(ballPrefab, spawnPosition.transform.position, Quaternion.identity);

        // Generate a random angle between -30 and 30 degrees
        var randomAngle = Random.Range(-15f, 15f);

        // Convert the angle to a direction vector
        var direction = Quaternion.Euler(elevationAngle, randomAngle, 0) * Vector3.forward;

        // Apply force to the spawned ball in the calculated direction
        Rigidbody ballRigidbody = spawnedBall.GetComponent<Rigidbody>();
        if (ballRigidbody != null)
        {
            ballRigidbody.AddForce(direction * forceApplied, ForceMode.Impulse);
        }

        // Destroy the spawned ball after 5 seconds
        Destroy(spawnedBall, 5f);
    }

    public void InvokeMediumMode()
    {
        Debug.Log("Invoking Medium Mode");
        // Cancel all other invokes
        CancelInvoke();

        // Start medium mode
        InvokeRepeating("PlayMediumMode", 0f, 4.0f);
    }

    public void PlayMediumMode()
    {
        Debug.Log("Playing Medium Mode");
        // Instantiate the ball at the position of the spawnPosition GameObject
        GameObject spawnedBall = Instantiate(ballPrefab, spawnPosition.transform.position, Quaternion.identity);

        // Generate a random angle between -30 and 30 degrees
        var randomAngle = Random.Range(-15f, 15f);

        // Convert the angle to a direction vector
        var direction = Quaternion.Euler(elevationAngle, randomAngle, 0) * Vector3.forward;

        // Apply force to the spawned ball in the calculated direction
        Rigidbody ballRigidbody = spawnedBall.GetComponent<Rigidbody>();
        if (ballRigidbody != null)
        {
            ballRigidbody.AddForce(direction * forceApplied, ForceMode.Impulse);
        }

        // Destroy the spawned ball after 5 seconds
        Destroy(spawnedBall, 5f);
    }

    public void InvokeEasyMode()
    {
        Debug.Log("Invoking Easy Mode");
        // Cancel all other invokes
        CancelInvoke();

        // Start easy mode
        InvokeRepeating("PlayEasyMode", 0f, 4.0f);
    }

    public void PlayEasyMode()
    {
        Debug.Log("Playing Easy Mode");
        // Instantiate the ball at the position of the spawnPosition GameObject
        GameObject spawnedBall = Instantiate(ballPrefab, spawnPosition.transform.position, Quaternion.identity);

        // Generate a random angle between -30 and 30 degrees
        var randomAngle = Random.Range(0f, 15f);

        // Convert the angle to a direction vector
        var direction = Quaternion.Euler(elevationAngle, randomAngle, 0) * Vector3.forward;

        // Apply force to the spawned ball in the calculated direction
        Rigidbody ballRigidbody = spawnedBall.GetComponent<Rigidbody>();
        if (ballRigidbody != null)
        {
            ballRigidbody.AddForce(direction * forceApplied, ForceMode.Impulse);
        }

        // Destroy the spawned ball after 5 seconds
        Destroy(spawnedBall, 5f);
    }
}
