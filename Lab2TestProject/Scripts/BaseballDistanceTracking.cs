using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class XRThrowDistanceTracker : MonoBehaviour
{
    public TextMeshProUGUI distanceText;  

    private Vector3 throwPosition;       
    private bool ballThrown = false;   
    private bool calculatingDistance = false; 

    private Rigidbody rb;                 
    private XRGrabInteractable grabInteractable; 
    private float stopVelocityThreshold = 0.1f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectExited.AddListener(OnThrow);     
        distanceText.text = "Distance: 0m";
    }

    void Update()
    {
        if (ballThrown && !calculatingDistance && rb.velocity.magnitude < stopVelocityThreshold)
        {
            Vector3 currentPosition = transform.position;
            float horizontalDistance = Vector2.Distance(
                new Vector2(throwPosition.x, throwPosition.z), 
                new Vector2(currentPosition.x, currentPosition.z)
            );
            
            // Update the UI with the horizontal distance
            distanceText.text = "Final Distance: " + horizontalDistance.ToString("F2") + "m";
            calculatingDistance = true;  // Stop further calculations
        }
    }

    private void OnThrow(SelectExitEventArgs args)
    {
        ballThrown = true;
        throwPosition = transform.position;
        calculatingDistance = false;
    }

    public void ResetBall()
    {
        ballThrown = false;
        calculatingDistance = false;
        distanceText.text = "Distance: 0m";  // Reset UI
    }
}
