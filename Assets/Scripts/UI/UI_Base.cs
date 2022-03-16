using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Base : MonoBehaviour
{
	protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();
	public abstract void Init();

	private void Start()
	{
		Init();
	}

	protected void Bind<T>(Type type) where T : UnityEngine.Object
	{
		string[] names = Enum.GetNames(type);
		UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
		_objects.Add(typeof(T), objects);

		for (int i = 0; i < names.Length; i++)
		{
			if (typeof(T) == typeof(GameObject))
				objects[i] = Util.FindChild(gameObject, names[i], true);
			else
				objects[i] = Util.FindChild<T>(gameObject, names[i], true);

			if (objects[i] == null)
				Debug.Log($"Failed To Bind({names[i]})");
		}
	}

	protected T Get<T>(int idx) where T : UnityEngine.Object
	{
		UnityEngine.Object[] objects = null;
		if (_objects.TryGetValue(typeof(T), out objects) == false)
			return null;

		return objects[idx] as T;
	}

	protected GameObject GetObject(int idx) { return Get<GameObject>(idx); }
	protected Text GetText(int idx) { return Get<Text>(idx); }
	protected Image GetImage(int idx) { return Get<Image>(idx); }
	protected Button GetButton(int idx) { return Get<Button>(idx); }

	public static void BindEvent(GameObject go, Action action, Define.UIEvent type = Define.UIEvent.Update)
	{
		UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);

		switch (type)
		{
			case Define.UIEvent.Update:
				evt.OnUpdateHandler -= action;
				evt.OnUpdateHandler += action;
				break;
		}
	}

	public static void BindEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type)
	{
		UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);

		switch (type)
		{
			case Define.UIEvent.Click:
				evt.OnClickHandler -= action;
				evt.OnClickHandler += action;
				break;
			case Define.UIEvent.Down:
				evt.OnDownHandler -= action;
				evt.OnDownHandler += action;
				break;
			case Define.UIEvent.Up:
				evt.OnUpHandler -= action;
				evt.OnUpHandler += action;
				break;
		}
	}

	public static void NoBindEvent(GameObject go, Action action, Define.UIEvent type = Define.UIEvent.Update)
	{
		UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);

		switch (type)
		{
			case Define.UIEvent.Update:
				evt.OnUpdateHandler -= action;
				break;
		}
	}

	public static void NoBindEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type)
	{
		UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);

		switch (type)
		{
			case Define.UIEvent.Click:
				evt.OnClickHandler -= action;
				break;
			case Define.UIEvent.Down:
				evt.OnDownHandler -= action;
				break;
			case Define.UIEvent.Up:
				evt.OnUpHandler -= action;
				break;
		}
	}
}