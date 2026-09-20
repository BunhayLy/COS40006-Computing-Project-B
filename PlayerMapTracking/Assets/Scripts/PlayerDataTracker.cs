using UnityEngine;
using System.IO;

public class PlayerDataTracker : MonoBehaviour
{
    private string filePath;
    private float timer = 0f;
    public float recordInterval = 0.5f;

    void Start()
    {
        filePath = Application.dataPath + "/PlayerMovement.csv";

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Time,X,Y,Z\n");
        }
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

        string data =
            Time.time.ToString("F2") + "," +
            position.x.ToString("F2") + "," +
            position.y.ToString("F2") + "," +
            position.z.ToString("F2") + "\n";

        File.AppendAllText(filePath, data);
    }
}