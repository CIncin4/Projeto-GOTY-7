using Unity.Cinemachine;
using UnityEngine;

public class FindBounds : MonoBehaviour
{
    public void Find()
    {
        GetComponent<CinemachineConfiner2D>().BoundingShape2D = GameObject.FindWithTag("Bounds").GetComponent<BoxCollider2D>();
    }
}
