using UnityEngine;

public class VoxelGridGizmos : MonoBehaviour
{
    public int size = 4;
    public float spacing = 1f;

    private void OnDrawGizmos()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                for (int z = 0; z < size; z++)
                {
                    Vector3 p = new Vector3(x, y, z) * spacing;

                    Gizmos.DrawSphere(p, 0.05f);
                }
            }
        }
    }
}