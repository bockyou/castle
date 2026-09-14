using UnityEngine;
using Oculus.Interaction;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowAnchor;
    private Rigidbody arrowRb;

    public LineRenderer lineRenderer;

    public InteractableUnityEventWrapper bowStringWrapper;

    private bool isPulling = false;

    void Start()
    {
        bowStringWrapper.WhenSelect.AddListener(SelectedEvent);
        bowStringWrapper.WhenUnselect.AddListener(UnselectedEvent);
    }

    void Update()
    {
        if (isPulling)
        {
            lineRenderer.SetPosition(1, bowStringWrapper.transform.localPosition);

            arrowRb.transform.position = bowStringWrapper.transform.position;
            arrowRb.transform.LookAt(arrowAnchor.position);
        }
        else
        {
            lineRenderer.SetPosition(1, new Vector3(0, 0, -0.1106f));

            bowStringWrapper.transform.localPosition = new Vector3(0, 0, -0.1106f);
            bowStringWrapper.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }

    private void SelectedEvent()
    {
        isPulling = true;

        GameObject arrow = Instantiate(arrowPrefab, bowStringWrapper.transform.position, bowStringWrapper.transform.rotation);
        arrowRb = arrow.GetComponent<Rigidbody>();
    }

    private void UnselectedEvent()
    {
        isPulling = false;
        arrowRb.isKinematic = false;
        arrowRb.useGravity = true;
        
        if (lineRenderer.GetPosition(1).z <= -0.2f)
        {
            arrowRb.AddForce(arrowRb.transform.forward * 30f, ForceMode.Impulse);
        }
    }
}
