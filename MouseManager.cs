using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    [Header("Mouse Info")]
    public Vector3 mouseStartPosition;

    [Header("Physics")]
    public float launchForce;
    public Vector3 launchVector;

    [Header("Slime Info")]
    public Transform slimeTransform;
    public Rigidbody slimeRigidbody;
    public Vector3 originalSlimePosition;
    public Quaternion originalSlimeRotation;
    public bool inFlight;

    public OverlayManager overlayManager;

    // Start is called before the first frame update
    void Start()
    {
        originalSlimePosition = slimeTransform.position;
        originalSlimeRotation = slimeRigidbody.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (overlayManager.isGameOver) return;

        if (!inFlight)
        {
            if (Input.GetKeyDown(KeyCode.L)) overlayManager.AddLife();

            if (Input.GetMouseButtonDown(0)) mouseStartPosition = Input.mousePosition;

            if (Input.GetMouseButton(0))
            {
                Vector3 mouseDifference = mouseStartPosition - Input.mousePosition;

                print(slimeTransform);

                launchVector = new Vector3(
                    mouseDifference.x * 1f,
                    mouseDifference.y * 1.2f,
                    mouseDifference.y * 1.5f
                );

                slimeTransform.position = originalSlimePosition - launchVector / 400;

                launchVector.Normalize();
            }

            if (Input.GetMouseButtonUp(0)) LaunchSlime();
        }
    }

    public void LaunchSlime()
    {
        slimeRigidbody.isKinematic = false;
        slimeRigidbody.AddForce(launchVector * launchForce, ForceMode.Impulse);
        inFlight = true;
    }

    public void ResetSlime()
    {
        slimeTransform.position = originalSlimePosition;
        slimeRigidbody.rotation = originalSlimeRotation;

        slimeRigidbody.velocity = Vector3.zero;
        slimeRigidbody.isKinematic = true;
        inFlight = false;
    }
}
