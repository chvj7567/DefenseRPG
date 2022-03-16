using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    // 해당 컴포넌트가 있으면 추가하여 가져오고, 없으면 그냥 가져온다.
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }

    // 자식 게임오브젝트 중에 T에 해당하는 컴포넌트를 가져온다.
    // 자식들의 그 아래 자식들까지 찾으려면 recursive에 true로 체크하여 재귀적으로 찾는다.
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if (recursive == false)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }

    // 게임 오브젝트를 찾는 경우 제네릭 형식이 아닌 일반 형식으로 호출할 수 있게 오버라이딩한다.
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform == null)
            return null;

        return transform.gameObject;
    }
}
