using UnityEngine;

public class Car : MonoBehaviour
{
    public float Speed { get; }

    public Car(float speed)
    {
        Speed = speed;
    }
}
