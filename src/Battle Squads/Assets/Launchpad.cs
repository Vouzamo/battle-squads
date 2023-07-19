using UnityEngine;

public class Launchpad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var controller = other.GetComponent<ILocomotionController>();

        // Call me a bitch one more time...
        controller.ApplyVelocity(Vector3.up * 50f);
    }
}
