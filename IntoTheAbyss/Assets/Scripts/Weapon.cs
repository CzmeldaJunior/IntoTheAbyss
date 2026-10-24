using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponData _weaponData;
    public Transform firePoint;
    public GameObject bulletHole;
    public TrailRenderer bulletTrail;
    public ParticleSystem ImpactParticle;
    [SerializeField]
    private float bulletSpeed = 150f;

    private string _weaponName;
    private float _damage;
    private float _reloadTime;
    private float _fireRate;
    private int _magazineSize;
    private float _range;
    private float _spread;


    int _currentAmmo;
    bool _isReloading;
    float _fireTime;



    private void Awake()
    {
        _weaponName = _weaponData.weaponName;
        _damage = _weaponData.damage;
        _reloadTime = _weaponData.reloadTime;
        _fireRate = _weaponData.fireRate;
        _magazineSize = _weaponData.magazineSize;
        _range = _weaponData.range;
        _spread = _weaponData.spread;


        _currentAmmo = _magazineSize;
    }

    public void Shoot()
    {
        if (_currentAmmo <= 0 || _isReloading || Time.time < _fireTime) return;

        _fireTime = Time.time + _fireRate;

        ShootingLogic();

        _currentAmmo--;
    }

    public void Reload()
    {
        if (_isReloading || _currentAmmo == _magazineSize) return;

        StartCoroutine(ReloadRoutine());
    }

    private IEnumerator ReloadRoutine()
    {
        //Bude volat ammoManager

        _isReloading = true;

        yield return new WaitForSeconds(_reloadTime);
        
        Debug.Log("Reloaded");

        _currentAmmo = _magazineSize;

        _isReloading = false;
    }

    private void ShootingLogic()
    {
        float spreadX = Random.Range(-_spread, _spread);
        float spreadY = Random.Range(-_spread, _spread);

        Vector3 direction = firePoint.forward + firePoint.right * spreadX + firePoint.up * spreadY;

        direction.Normalize();

        Ray ray = new Ray(firePoint.position, direction);
        RaycastHit hit;

        Vector3 endPoint;

        if (Physics.Raycast(ray, out hit, _range))
        {
            Debug.Log("Hit" + hit.collider.name);

            if(hit.collider.TryGetComponent<IDamageable>(out var damageTarget))
            {
                damageTarget.TakeDamage(_damage);
            }

            //debug vizulizace
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 5f);

            endPoint = hit.point;
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * _range, Color.green, 5f);

            endPoint = ray.origin + ray.direction * 100f;
        }

        TrailRenderer trail = Instantiate(bulletTrail, firePoint.position, Quaternion.identity);
        StartCoroutine(SpawnBulletTrail(trail, endPoint, hit));
    }

    private IEnumerator SpawnBulletTrail(TrailRenderer trail, Vector3 endPoint, RaycastHit hit)
    {
        Vector3 startPosition = trail.transform.position;
        float distance = Vector3.Distance(startPosition, endPoint);
        float traveled = 0f;

        while (traveled < distance)
        {
            float frame = bulletSpeed * Time.deltaTime;
            traveled += frame;

            trail.transform.position = Vector3.Lerp(startPosition, endPoint, traveled / distance);

            yield return null;
        }

        trail.transform.position = endPoint;

        if (hit.collider != null)
        {
            GameObject impactBulletHole = Instantiate(bulletHole, hit.point - new Vector3(0, 0, 0.01f), Quaternion.LookRotation(hit.normal));

            Destroy(impactBulletHole.gameObject, 10f);
        }
            Destroy(trail.gameObject, 2f);
        
    }
}
