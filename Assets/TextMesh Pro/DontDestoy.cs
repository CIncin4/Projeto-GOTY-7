using UnityEngine;

public class DontDestoy : MonoBehaviour
{
    private static GameObject[] persistentObject = new GameObject[3];
    public int objectIndex;
    void Awake()
    {
        if (persistentObject[objectIndex] == null)
        {
            persistentObject[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (persistentObject[objectIndex] != gameObject)
            Destroy(gameObject);
    }
}
