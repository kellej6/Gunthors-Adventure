using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransfer : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cameraMovement;

    // Start is called before the first frame update
    void Start()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraMovement.minPosition += cameraChange;
            cameraMovement.maxPosition += cameraChange;
            collision.transform.position += playerChange;
        }
    }
}
