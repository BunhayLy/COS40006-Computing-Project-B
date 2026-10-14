using UnityEngine;
using System.IO;

public class PlayerDataTracker : MonoBehaviour
{
    private string filePath;
    private float timer = 0f;

    public float recordInterval = 0.5f;

    private ZoneDetector zoneDetector;

    void Start()
    {
        zoneDetector = GetComponent<ZoneDetector>();

        filePath = Application.dataPath + "/PlayerMovement.csv";

        // Create a new CSV for each test run
        File.WriteAllText(filePath, "Time,X,Y,Z,Zone\n");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= recordInterval)
        {
            RecordPlayerPosition();
            timer = 0f;
        }
    }

    void RecordPlayerPosition()
    {
        Vector3 position = transform.position;

        string zone = "None";

        if (zoneDetector != null)
        {
            zone = zoneDetector.currentZone;
        }

        string data =
            Time.time.ToString("F2") + "," +
            position.x.ToString("F2") + "," +
            position.y.ToString("F2") + "," +
            position.z.ToString("F2") + "," +
            zone + "\n";

        File.AppendAllText(filePath, data);
    }
}