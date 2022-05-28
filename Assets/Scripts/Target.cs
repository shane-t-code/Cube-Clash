using UnityEngine;
using EZCameraShake;
using TMPro;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject FloatingText;
    public float health;
    public ParticleSystem destroyParticles;
    //[SerializeField] private float magnitude;
    //[SerializeField] private float roughness;

    public void TakeDamage(float amount)
    {
        ShowFloatingText();
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        CameraShaker.Instance.ShakeOnce(10f, 10f, 0.01f, 0.01f);
        Instantiate(destroyParticles, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Die();
        }

    }

    private void ShowFloatingText()
    {
        var go = Instantiate(FloatingText, transform.position, transform.rotation);
        go.GetComponent<TextMeshPro>().text = health.ToString();
    }
}
