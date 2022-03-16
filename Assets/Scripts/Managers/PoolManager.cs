using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PoolManager는 각 Poolable 컴포넌트를 포함하는 오브젝트 종류당
// Pool을 하나씩 가지고 있도록 한다.
public class PoolManager
{
    #region Pool
    class Pool
    {
        public GameObject Original { get; private set; }
        public Transform Root { get; set; }

        Stack<Poolable> _poolStack = new Stack<Poolable>();

        // 원본 대상을 저장하고 복사본을 기본적으로 5개 만들어
        // 오브젝트 종류당 Root폴더를 하나씩 만들어 저장한다.
        public void Init(GameObject original, int count = 5)
        {
            Original = original;
            Root = new GameObject().transform;
            Root.name = $"{original.name}_Root";

            for (int i = 0; i < count; ++i)
                Push(Create());
        }

        // Original에 저장된 원본을 복사하여 새 오브젝트를 생성한다.
        // 생성 후 Poolable을 붙여 오브젝트 풀링이 적용된 오브젝트임을 표시한다.
        Poolable Create()
        {
            GameObject go = Object.Instantiate<GameObject>(Original);
            go.name = Original.name;
            return Util.GetOrAddComponent<Poolable>(go);
        }

        // _poolStack에 생성된 오브젝트의 Poolable 컴포넌트를 저장한다.
        public void Push(Poolable poolable)
        {
            if (poolable == null)
                return;

            poolable.transform.parent = Root;
            poolable.gameObject.SetActive(false);
            poolable.IsUsing = false;

            _poolStack.Push(poolable);
        }

        // _poolStack에 저장된 Poolable 컴포넌트를 꺼내어 반환한다.
        // _poolStack이 비어있다면 생성하여 반환한다.
        public Poolable Pop(Transform parent)
        {
            Poolable poolable;

            if (_poolStack.Count > 0)
                poolable = _poolStack.Pop();
            else
                poolable = Create();

            poolable.gameObject.SetActive(true);

            // DontDestroyOnLoad 해제 용도
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

    // 오브젝트 풀들을 모두 관리하는 _root가 없다면 생성 후
    // 씬이 바뀌어도 파괴되지 않도록 한다.
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

    // 다 쓴 오브젝트를 반환할 때 Push를 진행한다.
    // 딕셔너리에 해당 오브젝트의 이름이 없다면
    // 풀링되지 않은 오브젝트이기에 즉시 파괴한다.
    public void Push(Poolable poolable)
    {
        if (_pool.ContainsKey(poolable.gameObject.name) == false)
        {
            GameObject.Destroy(poolable.gameObject);
            return;
        }

        _pool[poolable.gameObject.name].Push(poolable);
    }

    // 오브젝트 풀에서 꺼내어 쓸 때 해당 키 값이 없다면 생성하여 반환한다.
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
