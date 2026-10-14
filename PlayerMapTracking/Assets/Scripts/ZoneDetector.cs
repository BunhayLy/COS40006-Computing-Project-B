using UnityEngine;

public class ZoneDetector : MonoBehaviour
{
    public string currentZone = "None";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zone"))
        {
            currentZone = other.gameObject.name;
            Debug.Log("Entered: " + currentZone);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Zone"))
        {
            currentZone = "None";
            Debug.Log("Left zone");
        }
    }
}