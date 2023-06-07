using UnityEngine;
using System;
using System.Collections.Generic;
using KeyType = System.String;

[Serializable]
public class PoolObjectData
{
    public const int INIT_COUNT = 20;
    public const int MAX_COUNT = 50;

    public KeyType key;
    public GameObject prefab;
    public int initObjectCount = INIT_COUNT;
    public int maxObjectCount = MAX_COUNT;
}

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    /***********************************************************************
    *                             Private Fields
    ***********************************************************************/
    #region .
    [SerializeField]
    private List<PoolObjectData> poolObjectDataList = new List<PoolObjectData>();

    private Dictionary<KeyType, PoolObjectData> dataDic;    //Pool Object Datas
    private Dictionary<KeyType, GameObject> objectDic;      //Pool Objects
    private Dictionary<KeyType, Stack<GameObject>> poolDic; //Pools
    private Dictionary<KeyType, GameObject> parentDic;      //Pool Parents
    #endregion

    /***********************************************************************
    *                             Unity Methods
    ***********************************************************************/
    #region .
    protected override void Awake()
    {
        base.Awake();
        Init();
    }
    #endregion

    /***********************************************************************
    *                             Private Methods
    ***********************************************************************/
    #region .
    /// <summary>
    /// Ǯ���� ������Ʈ ������ŭ Dictionary ���� �� ������Ʈ ���
    /// </summary>
    private void Init()
    {
        int poolObjectCount = poolObjectDataList.Count;

        dataDic = new Dictionary<KeyType, PoolObjectData>(poolObjectCount);
        objectDic = new Dictionary<KeyType, GameObject>(poolObjectCount);
        poolDic = new Dictionary<KeyType, Stack<GameObject>>(poolObjectCount);
        parentDic = new Dictionary<KeyType, GameObject>(poolObjectCount);

        foreach (var poolObject in poolObjectDataList)
        {
            RegisterObject(poolObject);
        }
    }

    /// <summary>
    /// ������Ʈ ��� �Լ�
    /// Pool Object���� �θ� ������Ʈ�� ����� ���ο� initObjectCount��ŭ ����
    /// </summary>
    /// <param name="data">������ Ǯ�� ������</param>
    private void RegisterObject(PoolObjectData data)
    {
        if (objectDic.ContainsKey(data.key))
        {
            Debug.LogWarning($"Data already exists!\nID : {data.key}\nObject : {data.prefab}");
        }

        GameObject parent = new GameObject();
        parent.name = $"{data.prefab.name} INIT [{data.initObjectCount}] MAX [{data.maxObjectCount}]";
        parentDic.Add(data.key, parent);

        Stack<GameObject> pool = new Stack<GameObject>(data.maxObjectCount);

        for (int i = 0; i < data.initObjectCount; i++)
        {
            GameObject clone = Instantiate(data.prefab);
            clone.SetActive(false);
            pool.Push(clone);
            clone.transform.SetParent(parent.transform);
        }

        objectDic.Add(data.key, data.prefab);
        poolDic.Add(data.key, pool);
        dataDic.Add(data.key, data);
    }
    #endregion

    /***********************************************************************
    *                             Public Methods
    ***********************************************************************/
    #region .
    /// <summary>
    /// ������Ʈ ����
    /// </summary>
    /// <param name="key">������ Pool Object�� Key</param>
    /// <returns></returns>
    private GameObject Clone(KeyType key)
    {
        if (!dataDic.TryGetValue(key, out PoolObjectData data)) return null;

        return Instantiate(data.prefab);
    }

    /// <param name="key">������ Pool Object�� Key</param>
    /// <returns></returns>
    public GameObject Spawn(KeyType key)
    {
        if (!poolDic.TryGetValue(key, out var pool))
        {
            Debug.LogError($"Object with id {key} not found!");
            return null;
        }

        if (!dataDic.TryGetValue(key, out var data))
        {
            Debug.LogError($"Pool object is null!");
            return null;
        }

        GameObject obj;

        if (pool.Count > 0)
        {
            obj = pool.Pop();
        }
        else
        {

            if (!parentDic.TryGetValue(key, out var parent))
            {
                parent = new GameObject();
                parent.name = $"{data.prefab.name} INIT [{data.initObjectCount}] MAX [{data.maxObjectCount}]";
            }

            if (parent.transform.childCount > data.maxObjectCount - 1)
            {
                Debug.LogError($"Generation limit exceeded!\nMax Count : {data.maxObjectCount}");
                return null;
            }

            Debug.Log(parent.transform.childCount);

            Debug.Log($"Create a new instance\nID : {key}");
            obj = Clone(key);
            obj.transform.SetParent(parent.transform);
        }

        obj.SetActive(true);

        return obj;
    }

    /// <summary>
    /// ����� ���� Pool Object�� �ٽ� Pool�� ����
    /// </summary>
    /// <param name="key">Pool Object�� Key</param>
    /// <param name="obj">Pooling Object</param>
    public void Despawn(KeyType key, GameObject obj)
    {
        if (obj == null) return;
        if (obj.activeSelf == false) return;

        if (!poolDic.TryGetValue(key, out Stack<GameObject> pool))
        {
            Debug.LogError($"Cannot find pool object with id {key}!\nObject name : {obj.name}");
        }

        pool.Push(obj);
        obj.SetActive(false);
    }
    #endregion
}