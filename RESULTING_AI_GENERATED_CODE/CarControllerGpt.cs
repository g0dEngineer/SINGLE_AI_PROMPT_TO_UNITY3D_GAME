using UnityEngine;

public class CarControllerGpt : MonoBehaviour
{
    // The cube that will represent the car in the scene
    private GameObject car;

    // The camera that will follow the car
    private GameObject camera;

    // The road that the car will move on
    private GameObject road;

    void Start()
    {
        // Create the car as a cube primitive
        car = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // Set the car's position and scale
        car.transform.position = new Vector3(0, 0.5f, 0);
        car.transform.localScale = new Vector3(1, 2, 3);

        // Set the car's material to red
        car.GetComponent<Renderer>().material.color = Color.red;

        // Create the camera and set its position and rotation
        camera = new GameObject("Camera");
        camera.transform.position = new Vector3(0, 2, -5);
        camera.transform.rotation = Quaternion.Euler(20, 0, 0);

        // Add a Camera component to the camera GameObject
        camera.AddComponent<Camera>();

        // Make the camera follow the car
        camera.transform.parent = car.transform;

        // Create the road as a flat, long, white plane
        road = GameObject.CreatePrimitive(PrimitiveType.Plane);
        road.transform.position = new Vector3(0, 0, 0);
        road.transform.localScale = new Vector3(10, 1, 10);
        road.GetComponent<Renderer>().material.color = Color.white;
    }

    void Update()
    {
        // Move the car forward
        car.transform.position += car.transform.forward * Time.deltaTime * 5;

        // Allow the user to turn the car left and right using the A and D keys
        if (Input.GetKey(KeyCode.A))
        {
            car.transform.Rotate(Vector3.down * Time.deltaTime * 50);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            car.transform.Rotate(Vector3.up * Time.deltaTime * 50);
        }
    }
}
