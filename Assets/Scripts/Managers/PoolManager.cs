using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PoolManager�� �� Poolable ������Ʈ�� �����ϴ� ������Ʈ ������
// Pool�� �ϳ��� ������ �ֵ��� �Ѵ�.
public class PoolManager
{
    #region Pool
    class Pool
    {
        public GameObject Original { get; private set; }
        public Transform Root { get; set; }

        Stack<Poolable> _poolStack = new Stack<Poolable>();

        // ���� ����� �����ϰ� ���纻�� �⺻������ 5�� �����
        // ������Ʈ ������ Root������ �ϳ��� ����� �����Ѵ�.
        public void Init(GameObject original, int count = 5)
        {
            Original = original;
            Root = new GameObject().transform;
            Root.name = $"{original.name}_Root";

            for (int i = 0; i < count; ++i)
                Push(Create());
        }

        // Original�� ����� ������ �����Ͽ� �� ������Ʈ�� �����Ѵ�.
        // ���� �� Poolable�� �ٿ� ������Ʈ Ǯ���� ����� ������Ʈ���� ǥ���Ѵ�.
        Poolable Create()
        {
            GameObject go = Object.Instantiate<GameObject>(Original);
            go.name = Original.name;
            return Util.GetOrAddComponent<Poolable>(go);
        }

        // _poolStack�� ������ ������Ʈ�� Poolable ������Ʈ�� �����Ѵ�.
        public void Push(Poolable poolable)
        {
            if (poolable == null)
                return;

            poolable.transform.parent = Root;
            poolable.gameObject.SetActive(false);
            poolable.IsUsing = false;

            _poolStack.Push(poolable);
        }

        // _poolStack�� ����� Poolable ������Ʈ�� ������ ��ȯ�Ѵ�.
        // _poolStack�� ����ִٸ� �����Ͽ� ��ȯ�Ѵ�.
        public Poolable Pop(Transform parent)
        {
            Poolable poolable;

            if (_poolStack.Count > 0)
                poolable = _poolStack.Pop();
            else
                poolable = Create();

            poolable.gameObject.SetActive(true);

            // DontDestroyOnLoad ���� �뵵
            if (parent == null)
                poolable.transform.parent = GameObject.Find("@Scene").transform;

            poolable.transform.parent = parent;
            poolable.IsUsing = true;

            return poolable;
        }
    }
    #endregion

    Dictionary<string, Pool> _pool = new Dictionary<string, Pool>();
    Transform _root;

    // ������Ʈ Ǯ���� ��� �����ϴ� _root�� ���ٸ� ���� ��
    // ���� �ٲ� �ı����� �ʵ��� �Ѵ�.
    public void Init()
    {
        if (_root == null)
        {
            _root = new GameObject { name = "@Pool_Root" }.transform;
            Object.DontDestroyOnLoad(_root);
        }
    }

    public void CreatePool(GameObject original, int count = 10)
    {
        Pool pool = new Pool();
        pool.Init(original, count);
        pool.Root.parent = _root;

        _pool.Add(original.name, pool);
    }

    // �� �� ������Ʈ�� ��ȯ�� �� Push�� �����Ѵ�.
    // ��ųʸ��� �ش� ������Ʈ�� �̸��� ���ٸ�
    // Ǯ������ ���� ������Ʈ�̱⿡ ��� �ı��Ѵ�.
    public void Push(Poolable poolable)
    {
        if (_pool.ContainsKey(poolable.gameObject.name) == false)
        {
            GameObject.Destroy(poolable.gameObject);
            return;
        }

        _pool[poolable.gameObject.name].Push(poolable);
    }

    // ������Ʈ Ǯ���� ������ �� �� �ش� Ű ���� ���ٸ� �����Ͽ� ��ȯ�Ѵ�.
    public Poolable Pop(GameObject original, Transform parent = null)
    {
        if (_pool.ContainsKey(original.name) == false)
            CreatePool(original);

        return _pool[original.name].Pop(parent);
    }

    public GameObject GetOriginal(string name)
    {
        if (_pool.ContainsKey(name) == false)
            return null;
        return _pool[name].Original;
    }

    public void Clear()
    {
        foreach (Transform child in _root)
            GameObject.Destroy(child.gameObject);

        _pool.Clear();
    }
}
