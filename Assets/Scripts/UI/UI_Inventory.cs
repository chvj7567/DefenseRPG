using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inventory : UI_Base
{
    PlayerStat _playerStat;
    Image[] _skillSpace;
    List<GameObject> _skillIcon;

    public GameObject DragSkill { get; set; }
    public Transform OriginPos { get; set; }
    public bool IsDrop { get; set; }

    bool _isInit;
    enum Images
    {
        SkillSpace1,
        SkillSpace2,
        SkillSpace3,
        SkillSpace4,
        SkillSpace5,
        SkillSpace6,
        SkillSpace7,
        SkillSpace8,
    }

    public override void Init()
    {
        if (!_isInit)
        {
            _isInit = true;
            _playerStat = MainManager.Game.Player.GetComponent<PlayerStat>();
            _skillSpace = new Image[Enum.GetNames(typeof(Images)).Length];
            _skillIcon = new List<GameObject>();

            Bind<Image>(typeof(Images));

            for (int i = 0; i < _skillSpace.Length; i++)
            {
                _skillSpace[i] = GetImage(i);
            }
        }
    }

    void OnEnable()
    {
        if (_playerStat == null)
        {
            Init();
        }

        InputSkill();
    }

    public void InputSkill()
    {
        string path = null;

        if (_playerStat.Snow != 0 && !UsingSkill(Enum.GetName(typeof(Define.AreaSkill), (int)Define.AreaSkill.Snow)))
        {
            path = $"Skill/Icon/{Enum.GetName(typeof(Define.AreaSkill), (int)Define.AreaSkill.Snow)}";
            CreateSkillICon(path);
        }
        if (_playerStat.Laser != 0 && !UsingSkill(Enum.GetName(typeof(Define.AreaSkill), (int)Define.AreaSkill.Laser)))
        {
            path = $"Skill/Icon/{Enum.GetName(typeof(Define.AreaSkill), (int)Define.AreaSkill.Laser)}";
            CreateSkillICon(path);
        }
        if(_playerStat.Strong != 0 && !UsingSkill(Enum.GetName(typeof(Define.BuffSkill), (int)Define.BuffSkill.Strong)))
        {
            path = $"Skill/Icon/{Enum.GetName(typeof(Define.BuffSkill), (int)Define.BuffSkill.Strong)}";
            CreateSkillICon(path);
        }
        if(_playerStat.FastAttack != 0 && !UsingSkill(Enum.GetName(typeof(Define.BuffSkill), (int)Define.BuffSkill.FastAttack)))
        {
            path = $"Skill/Icon/{Enum.GetName(typeof(Define.BuffSkill), (int)Define.BuffSkill.FastAttack)}";
            CreateSkillICon(path);
        }

        
    }

    public void CreateSkillICon(string path)
    {
        if (path != null)
        {
            GameObject go = MainManager.Resource.Instantiate(path, GetLastSpace().transform);
            Image[] images = go.GetComponentsInChildren<Image>();
            foreach (Image image in images)
                image.raycastTarget = false;
            go.transform.GetChild(0).gameObject.SetActive(false);
            _skillIcon.Add(go);
        }
    }

    public void SwapSkill(GameObject startSlot, GameObject destSlot)
    {
        if (destSlot != null)
        {
            if (destSlot.transform.childCount != 0)
            {
                Transform destSkill = destSlot.transform.GetChild(0);
                destSlot.transform.GetChild(0).SetParent(startSlot.transform);
                destSkill.localPosition = Vector3.zero;
            }

            DragSkill.transform.SetParent(destSlot.transform);
            DragSkill.transform.localPosition = Vector3.zero;
        }
    }

    public GameObject GetLastSpace()
    {
        foreach (Image image in _skillSpace)
        {
            if (image.transform.childCount == 0)
            {
                return image.gameObject;
            }
        }

        return null;
    }

    public bool UsingSkill(string skill)
    {
        foreach (GameObject go in _skillIcon)
        {
            if (go.name == skill)
                return true;
        }

        return false;
    }
}
