using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] public float _cannonballCounter;
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _reloadGunTime;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && _cannonballCounter >= 1)
        {
            StartCoroutine(ShootTick());
        }
        if (Input.GetKey(KeyCode.R) && _cannonballCounter == 0)
        {
            _cannonballCounter += 5;
        }
    }

    private IEnumerator ShootTick()
    {
        yield return new WaitForSeconds(_shootDelay);
        CreateBall();
        _cannonballCounter -= 1;
    }

    private void CreateBall()
    {
        Ball ballcreated = Instantiate(_ball, _spawnPoint.position, Quaternion.identity).GetComponent<Ball>();
        ballcreated.Fly(_spawnPoint.transform.forward, 50);
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_shootDelay);
    }
}