using UnityEngine;

public class ZoneTimeTracker : MonoBehaviour
{
    private ZoneDetector zoneDetector;

    public float zoneATime = 0f;
    public float zoneBTime = 0f;
    public float zoneCTime = 0f;

    void Start()
    {
        zoneDetector = GetComponent<ZoneDetector>();
    }

    void Update()
    {
        if (zoneDetector == null)
            return;

        switch (zoneDetector.currentZone)
        {
            case "Zone A":
                zoneATime += Time.deltaTime;
                break;

            case "Zone B":
                zoneBTime += Time.deltaTime;
                break;

            case "Zone C":
                zoneCTime += Time.deltaTime;
                break;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 25),
            "Zone A: " + zoneATime.ToString("F1") + " sec");

        GUI.Label(new Rect(10, 35, 200, 25),
            "Zone B: " + zoneBTime.ToString("F1") + " sec");

        GUI.Label(new Rect(10, 60, 200, 25),
            "Zone C: " + zoneCTime.ToString("F1") + " sec");
    }

    void OnDisable()
    {
        Debug.Log(
            "Zone A: " + zoneATime.ToString("F2") +
            " sec | Zone B: " + zoneBTime.ToString("F2") +
            " sec | Zone C: " + zoneCTime.ToString("F2") + " sec"
        );
    }
}