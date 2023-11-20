using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Target : MonoBehaviour
{

    [SerializeField] private int _count;
    [SerializeField] private int _countTargets;
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private GameObject _spawner;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<Ball>())
        {
            _count++;
            _counter.text = "Score: " + _count.ToString();
            Destroy(collision.gameObject);
        }
        Vector3 _randomSpwnPosition = new Vector3(Random.Range(-20, 20), Random.Range(2, 10), Random.Range(7, 35));
        Instantiate(_spawner, _randomSpwnPosition, Quaternion.identity);
    }
}