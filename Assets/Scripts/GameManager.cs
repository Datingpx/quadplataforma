using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CratePrefab;

    public int maxCratesToSpawn = 4;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCrates());
    }
    private IEnumerator SpawnCrates()
    {
        var hazardsToSpawn = Random.Range(1, maxCratesToSpawn);

        for (int i = 0; i < hazardsToSpawn; i++)
        {
            var x = Random.Range(-7, 7);
            var drag = Random.Range(0f, 2f);
            var hazard = Instantiate(CratePrefab, new Vector3(x, 11, 0), Quaternion.identity);
            hazard.GetComponent<Rigidbody>().drag = drag;
        }

        yield return new WaitForSeconds(1f);

        yield return SpawnCrates();
    }

}
