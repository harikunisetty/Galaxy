using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManger : MonoBehaviour
{
    

    [Header("Pools")]
    [SerializeField] int numOfPools = 10;
    [SerializeField] GameObject ammoPrefab;
    [SerializeField] GameObject[] ammoArray;

    [Header("Queue")]
    public Queue<Transform> ammoQueue = new Queue<Transform>();

    public static AmmoManger ammoInstance;

    private void Awake()
    {

        if (ammoInstance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        ammoInstance = this;
    }
    void Start()
    {
        ammoArray = new GameObject[numOfPools];

        for (int i = 0; i < ammoArray.Length; i++)
        {
            ammoArray[i] = Instantiate(ammoPrefab, transform.position, Quaternion.identity);

            Transform objTransfrom = ammoArray[i].GetComponent<Transform>();
            objTransfrom.SetParent(transform);

            ammoQueue.Enqueue(objTransfrom);

            ammoArray[i].SetActive(false);
        }
    }

    public static Transform SpawnAmmo(Vector3 Position, Quaternion Rotation)
    {
        Transform spawnedAmmo = ammoInstance.ammoQueue.Dequeue();

        spawnedAmmo.gameObject.SetActive(true);
        spawnedAmmo.position = Position;
        spawnedAmmo.rotation = Rotation;

        ammoInstance.ammoQueue.Enqueue(spawnedAmmo);

        return spawnedAmmo;
    }
}
