using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public float distanceToMove;
    public float speed;
    public Vector3 direction = Vector3.right;

    public Vector3 startingPosition;
    public Vector3 endingPosition;

    public OverlayManager overlayManager;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;

        endingPosition = new Vector3(
            transform.position.x + distanceToMove, 
            transform.position.y, 
            transform.position.z
        );
    }

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime * direction, Space.Self);

        if (transform.position.x > endingPosition.x || transform.position.x < startingPosition.x)
            direction *= -1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        overlayManager.GameOver("You win!");
        Destroy(gameObject);
    }
}
