using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField]
    private float destroyTime = 2f;

    private void Start()
    {
        // Inicia a contagem regressiva para destruir o objeto
        Invoke("DestroyObject", destroyTime);
    }

    private void DestroyObject()
    {
        // Destroi o objeto
        Destroy(gameObject);
    }
}