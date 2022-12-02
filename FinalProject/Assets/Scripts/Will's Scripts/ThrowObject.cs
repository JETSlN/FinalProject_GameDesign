using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public static ThrowObject Instance;
    public GameObject[] items;

    public Transform camera;
    public float throwForce;

    void Awake()
    {
        Instance = this;
    }

    public void throwingObject(string itemName) {
        foreach (GameObject item in items) {
            if (item.name == itemName) {
                GameObject projectile = Instantiate(item, camera.position, camera.rotation);
                Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

                Vector3 force = camera.transform.forward * throwForce;
                projectileRb.AddForce(force, ForceMode.Impulse);
            }
        }
    }
}
