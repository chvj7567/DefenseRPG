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

            // Original ������Ʈ�� Ǯ�� ����Ǿ� �ִٸ� ��ȯ
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

        // Ǯ�� ����̸� Pop���� �����ش�.
        // �̹� Ǯ�� �Ǿ��ٸ� �ʱ�ȭ �� ��ȯ
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

        // Ǯ�� ����̸� �ı����� �ʰ� ���ÿ� Push�Ѵ�.
        if (go.GetComponent<Poolable>() != null)
        {
            MainManager.Pool.Push(go.GetComponent<Poolable>());
            return;
        }

        Object.Destroy(go, time);
    }
}
