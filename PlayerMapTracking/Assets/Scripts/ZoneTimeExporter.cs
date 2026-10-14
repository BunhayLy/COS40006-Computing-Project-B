using UnityEngine;
using System.IO;

public class ZoneTimeExporter : MonoBehaviour
{
    private ZoneTimeTracker zoneTimeTracker;
    private string filePath;

    void Start()
    {
        zoneTimeTracker = GetComponent<ZoneTimeTracker>();

        filePath = Application.dataPath + "/ZoneTimeSummary.csv";
    }

    void OnDisable()
    {
        if (zoneTimeTracker == null)
            return;

        string data =
            "Zone,TimeSpent\n" +
            "Zone A," + zoneTimeTracker.zoneATime.ToString("F2") + "\n" +
            "Zone B," + zoneTimeTracker.zoneBTime.ToString("F2") + "\n" +
            "Zone C," + zoneTimeTracker.zoneCTime.ToString("F2") + "\n";

        File.WriteAllText(filePath, data);

        Debug.Log("Zone time summary saved.");
    }
}