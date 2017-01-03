using UnityEngine;
using System.Collections;

public class BallEmitter : MonoBehaviour
{

    public GameObject Go;
    [Range(0, 5)]
    public float ForceMultiplier = 1f;

    private Vector3 _emitterLocation;
    
    // Use this for initialization
    void Start()
    {
        _emitterLocation = gameObject.transform.position;
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            float size = Random.Range(0.4f, 1f);
            var go = Instantiate(Go, _emitterLocation, Quaternion.identity);
            go.GetComponent<Transform>().localScale = new Vector3(size, size, size);
            go.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(LaunchBall(0.5f, go));
            yield return new WaitForSeconds(Random.Range(0.7f, 2f));
        }
    }

    private IEnumerator LaunchBall(float waitTime, GameObject go)
    {
        yield return new WaitForSeconds(waitTime);
        go.GetComponent<Rigidbody>().isKinematic = false;
        go.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1f, 1f) * ForceMultiplier, 0, Random.Range(0f, 1f) * ForceMultiplier), ForceMode.Impulse);

    }
}
