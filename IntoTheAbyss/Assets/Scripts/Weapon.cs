using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponData _weaponData;
    public Transform firePoint;

    private string _weaponName;
    private float _damage;
    private float _reloadTime;
    private float _fireRate;
    private int _magazineSize;
    private float _range;
    private float _spread;



    private void Awake()
    {
        _weaponName = _weaponData.weaponName;
        _damage = _weaponData.damage;
        _reloadTime = _weaponData.reloadTime;
        _fireRate = _weaponData.fireRate;
        _magazineSize = _weaponData.magazineSize;
        _range = _weaponData.range;
        _spread = _weaponData.spread;
    }

    public void Shoot()
    {
        float spreadX = Random.Range(-_spread, _spread);
        float spreadY = Random.Range(-_spread, _spread);

        Vector3 direction = firePoint.forward + firePoint.right * spreadX + firePoint.up * spreadY;

        direction.Normalize();

        Ray ray = new Ray(firePoint.position, direction);
        RaycastHit hit;

        Vector3 endPoint;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.Log("Hit" + hit.collider.name);

            //debug vizulizace
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 5f);

            endPoint = hit.point;
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green, 5f);

            endPoint = ray.origin + ray.direction * 100f;
        }
    }

    public void Reload()
    {

    }
}
