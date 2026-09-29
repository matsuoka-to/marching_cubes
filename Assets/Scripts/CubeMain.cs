using UnityEngine;
using Cysharp.Threading.Tasks;

public class CubeMain : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cubePrefabs;

    private int cnt;
    
    void Start()
    {
        cnt = 0;
        SpawnCubes().Forget();
    }
    
    private async UniTask SpawnCubes()
    {
        cubePrefabs[cnt].SetActive(true);
        cubePrefabs[cnt].GetComponent<MarchingCubesDemo>().SetColor(Color.yellow);
        
        await UniTask.Delay(500);
        
        cubePrefabs[cnt].GetComponent<MarchingCubesDemo>().SetColor(Color.white);
        cnt++;

        if(cnt < cubePrefabs.Length)
        {
            await SpawnCubes();
        }
    }
    
}
