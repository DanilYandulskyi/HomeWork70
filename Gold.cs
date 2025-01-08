using UnityEngine;

public class Gold : MonoBehaviour
{
    public void StartFollow(Transform target)
    {
        transform.SetParent(target);
    }

    public void StopFollow()
    {
        transform.SetParent(null);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}