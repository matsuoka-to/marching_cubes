using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Destruction")]
    [SerializeField] private SphereCollider sphere;

    [SerializeField] private Rigidbody rb;
    
    [SerializeField] private float projectileSpeed = 1.0f;
    
    [Header("Lifetime")]
    [SerializeField] private float lifeTime = 5.0f;

    private bool isInitialized= false;
    private bool isEnter= false;
    
    private Vector3 targetPosition;
    private float damageStrength;
    
    private void  Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetParameter(Vector3 target, Vector3 position, float scale)
    {
        targetPosition = target;

        transform.position = position;
        transform.localScale = Vector3.one * scale;
        damageStrength = scale;
        isInitialized = true;

        Vector3 direction =　(targetPosition- transform.position).normalized;
        rb.linearVelocity = direction * projectileSpeed;        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.name != "Root" || isEnter || !isInitialized)
        {
            return;
        }
        
        // 衝突地点を取得
        ContactPoint contact = collision.GetContact(0);
        Vector3 hitPosition = contact.point;

        // Marching Cubes Terrainを探す
        MarchingCubesDamageTerrain terrain = obj.GetComponent<MarchingCubesDamageTerrain>();
        if (terrain != null)
        {
            isEnter = true;
            
            // 地形を破壊
            terrain.DamageTerrain(hitPosition, damageStrength * 2, damageStrength);

            // 弾を削除
            Destroy(gameObject);
        }
    }
}