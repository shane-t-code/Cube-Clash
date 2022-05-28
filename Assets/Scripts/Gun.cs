using UnityEngine;
using System.Collections;
using System.Threading;
using System.Linq;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform frontOfWeapon;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public float Energy;
    public float EnergyPerEnemy;
    public EnergyBar energyBar;
    public float EnergyTakenTime;
    public float EnergyTakenTime2;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public Recoil recoil;
    RaycastHit hit;
    public LineRenderer bulletTrail;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    //public AmmoBar ammobar;

    private float nextTimeToFire = 0f;

    public Animator animator;

    private void Start()
    {
        currentAmmo = maxAmmo;
        //ammobar.SetMaxAmmo(maxAmmo);
        Energy = 0f;

        InvokeRepeating("UpdateEnergy", EnergyTakenTime, EnergyTakenTime2);
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
        //animator.SetBool("IsShooting", false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.L))
        //{
        //    CameraShaker.Instance.ShakeOnce(10f, 10f, 0.01f, 0.01f);
        //}

        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            SpawnBulletTrail(hit.point);
        }

        if (Energy <= -25f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void UpdateEnergy()
    {
        Energy -= 0.5f * TimedSpawn.enemies.Count(c => c != null);
        energyBar.SetEnergy(Energy);
    }

    IEnumerator Reload()
    {
        isReloading = true;

        animator.SetBool("ShouldBobble", false);
        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        //ammobar.SetAmmo(maxAmmo);
        isReloading = false;
    }

    public void Shoot()
    {

        //animator.SetBool("IsShooting", true);

        recoil.Fire();

        muzzleFlash.Play();


        currentAmmo--;
        //ammobar.SetAmmo(currentAmmo);

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
                Energy += EnergyPerEnemy;

                energyBar.SetEnergy(Energy);
            }
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
       //animator.SetBool("IsShooting", false);
    }

    public void SpawnBulletTrail(Vector3 hitPoint)
    {
        GameObject bulletTrailEffect = Instantiate(bulletTrail.gameObject, frontOfWeapon.transform.position, Quaternion.identity);

        LineRenderer LineR = bulletTrailEffect.GetComponent<LineRenderer>();

        LineR.SetPosition(0, frontOfWeapon.transform.position);
        LineR.SetPosition(1, hitPoint);

        Destroy(bulletTrailEffect, 0.05f);

    }
}
