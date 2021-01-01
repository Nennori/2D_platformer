using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private float maxX = 49;
    private float maxY = 15;
    private float minX = -17;
    private float minY = -3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraPosition();
    }
    public void UpdateCameraPosition() {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, minX, maxX), Mathf.Clamp(player.position.y, minY, maxY), transform.position.z);
    }
}
