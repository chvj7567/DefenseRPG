using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        if (typeof(T) == typeof(GameObject))
        {
            string name = path;
            int index = name.LastIndexOf('/');

            if (index != -1)
            {
                name = name.Substring(index + 1);
            }

            // Original 오브젝트가 풀에 저장되어 있다면 반환
            GameObject go = MainManager.Pool.GetOriginal(name);

            if (go != null)
                return go as T;
        }
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null)
        {
            Debug.Log($"Failed To Load Prefab : {path}");
            return null;
        }

        if (path == "Monster" || path == "Bullet")
        {
            Util.GetOrAddComponent<Poolable>(original);
        }

        // 풀링 대상이면 Pop으로 꺼내준다.
        // 이미 풀링 되었다면 초기화 후 반환
        if (original.GetComponent<Poolable>() != null)
        {
            return MainManager.Pool.Pop(original, parent).gameObject;
        }

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;

        return go;
    }

    public void Destroy(GameObject go, float time = 0)
    {
        if (go == null)
            return;

        // 풀링 대상이면 파괴하지 않고 스택에 Push한다.
        if (go.GetComponent<Poolable>() != null)
        {
            MainManager.Pool.Push(go.GetComponent<Poolable>());
            return;
        }

        Object.Destroy(go, time);
    }
}
