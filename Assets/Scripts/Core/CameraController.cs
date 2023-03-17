using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    public Vector3 minValues, maxValues;

    private void FixedUpdate()
    {
        Follow();
    }

    public void Follow()
    {
        Vector3 targetpos = target.position + offset;

        Vector3 boundpos = new Vector3(
            Mathf.Clamp(targetpos.x, minValues.x, maxValues.x),
            Mathf.Clamp(targetpos.y, minValues.y, maxValues.y),
            Mathf.Clamp(targetpos.z, minValues.z, maxValues.z));

        Vector3 smoothPos = Vector3.Lerp(transform.position, boundpos, smoothFactor * Time.deltaTime);
        transform.position = smoothPos;
    }
}
