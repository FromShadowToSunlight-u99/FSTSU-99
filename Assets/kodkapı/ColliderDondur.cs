using UnityEngine;
using UnityEngine.InputSystem;

public class ColliderDondur : MonoBehaviour
{
    private bool colliderDonduruldu = false;

    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame && !colliderDonduruldu)
        {
            StartCoroutine(DondurCollider());
        }
    }

    private System.Collections.IEnumerator DondurCollider()
    {
        colliderDonduruldu = true;

        Quaternion baslangicRotasyon = transform.rotation;
        Quaternion hedefRotasyon = Quaternion.Euler(0f, 90f, 0f);

        float donmeZamani = 0.5f; // Dönme süresi (saniye)

        float gecenSure = 0f;

        while (gecenSure < donmeZamani)
        {
            float yuzdeTamamlanan = gecenSure / donmeZamani;
            transform.rotation = Quaternion.Lerp(baslangicRotasyon, hedefRotasyon, yuzdeTamamlanan);

            gecenSure += Time.deltaTime;

            yield return null;
        }

        transform.rotation = hedefRotasyon;

        colliderDonduruldu = false;
    }
}


