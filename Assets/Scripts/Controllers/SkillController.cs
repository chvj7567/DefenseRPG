using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    bool _snowCoroutine, _laserCoroutine;
    bool _strongCoroutine, _fastAttackCoroutine;
    UI_Skill _skillUI;
    GameObject[] _usingSkill;
    PlayerStat _playerStat;

    void Start()
    {
        _skillUI = MainManager.UI.Skill.GetComponent<UI_Skill>();
        _usingSkill = new GameObject[MainManager.UI.Skill.transform.GetComponentsInChildren<Image>().Length - 1];
        _playerStat = MainManager.Game.Player.GetComponent<PlayerStat>();
    }
    
    void Update()
    {
        for (int i = 0; i < _usingSkill.Length; i++)
        {
            if (_skillUI.SkillSlot[i].transform.childCount == 0)
                _usingSkill[i] = null;
            else
                _usingSkill[i] = _skillUI.SkillSlot[i].transform.GetChild(0).gameObject;
        }

        foreach (GameObject skill in _usingSkill)
        {
            if (skill == null)
                continue;
            if (skill.name == "Snow" && !_snowCoroutine)
                StartCoroutine(SnowSkill(skill));
            else if (skill.name == "Laser" && !_laserCoroutine)
                StartCoroutine(LaserSkill(skill));
            else if (skill.name == "Strong" && !_strongCoroutine)
                StartCoroutine(StrongSkill(skill));
            else if (skill.name == "FastAttack" && !_fastAttackCoroutine)
                StartCoroutine(FastAttackSkill(skill));
        }
    }

    IEnumerator SnowSkill(GameObject skill)
    {
        _snowCoroutine = true;
        while (true)
        {
            MainManager.Skill.StartSkill(Skill.Area.Snow);
            GameObject coolTime = skill.transform.GetChild(0).gameObject;
            Animator anim = coolTime.GetComponent<Animator>();
            anim.speed = 1f / _playerStat.SnowCoolTime;
            coolTime.SetActive(true);

            yield return new WaitForSeconds(_playerStat.SnowCoolTime);
        }
    }

    IEnumerator LaserSkill(GameObject skill)
    {
        _laserCoroutine = true;
        while (true)
        {
            MainManager.Skill.StartSkill(Skill.Area.Laser);
            GameObject coolTime = skill.transform.GetChild(0).gameObject;
            Animator anim = coolTime.GetComponent<Animator>();
            anim.speed = 1f / _playerStat.LaserCoolTime;
            coolTime.SetActive(true);

            yield return new WaitForSeconds(_playerStat.LaserCoolTime);
        }
    }

    IEnumerator StrongSkill(GameObject skill)
    {
        _strongCoroutine = true;
        
        while (true)
        {
            GameObject coolTime = skill.transform.GetChild(0).gameObject;
            Animator anim = coolTime.GetComponent<Animator>();
            anim.speed = 1f / _playerStat.StrongCoolTime;
            coolTime.SetActive(true);

            _playerStat.AddAttack(_playerStat.Strong);
            yield return new WaitForSeconds(_playerStat.StrongStay);
            _playerStat.AddAttack(-_playerStat.Strong);
            yield return new WaitForSeconds(_playerStat.StrongCoolTime - _playerStat.StrongStay);
        }
    }

    IEnumerator FastAttackSkill(GameObject skill)
    {
        _fastAttackCoroutine = true;
        while (true)
        {
            GameObject coolTime = skill.transform.GetChild(0).gameObject;
            Animator anim = coolTime.GetComponent<Animator>();
            anim.speed = 1f / _playerStat.FastAttackCoolTime;
            coolTime.SetActive(true);

            _playerStat.AddAttackSpeed(_playerStat.FastAttack);
            yield return new WaitForSeconds(_playerStat.StrongStay);
            _playerStat.AddAttackSpeed(-_playerStat.FastAttack);
            yield return new WaitForSeconds(_playerStat.FastAttackCoolTime - _playerStat.FastAttackStay);
        }
    }
}
