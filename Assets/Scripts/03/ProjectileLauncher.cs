using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float firePointY = 20.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var pos = hit.point;
                var target = pos;
                pos.y = firePointY;
                Fire(target, pos);
            }
        }
    }

    private void Fire(Vector3 target,  Vector3 position)
    {
        if (projectilePrefab == null)
        {
            Debug.LogWarning("Projectile Prefab is not assigned.");
            return;
        }

        var scale = Random.Range(5f, 10f);
        Projectile projectile = Instantiate(projectilePrefab, transform, false);
        projectile.SetParameter(target, position, scale);
    }
}