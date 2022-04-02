using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : BaseController
{
    bool _snowCoroutine, _laserCoroutine;
    bool _strongCoroutine, _fastAttackCoroutine;
    bool _usingSnow, _usingLaser, _usingStrong, _usingFastAttack;
    bool _backStrong, _backFastAttack;
    UI_Skill _skillUI;
    GameObject[] _usingSkill;
    PlayerStat _playerStat;
    IEnumerator[] _areaSkillCoroutine;
    IEnumerator[] _buffSkillCoroutine;

    public override void Init()
    {
        _skillUI = MainManager.UI.Skill.GetComponent<UI_Skill>();
        _usingSkill = new GameObject[MainManager.UI.Skill.transform.GetComponentsInChildren<Image>().Length - 1];
        _areaSkillCoroutine = new IEnumerator[(int)Define.AreaSkill.MaxCount];
        _buffSkillCoroutine = new IEnumerator[(int)Define.BuffSkill.MaxCount];
        _playerStat = MainManager.Game.Player.GetComponent<PlayerStat>();
    }
    
    void Update()
    {
        _usingSnow = false; _usingLaser = false;
        _usingStrong = false; _usingFastAttack = false;
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
            if (skill.name == "Snow")
            {
                _usingSnow = true;
                MainManager.Skill.AreaSkills[(int)Define.AreaSkill.Snow].SetActive(true);
                if (!_snowCoroutine)
                {
                    _areaSkillCoroutine[(int)Define.AreaSkill.Snow] = SnowSkill(skill);
                    StartCoroutine(_areaSkillCoroutine[(int)Define.AreaSkill.Snow]);
                }
            } 
            else if (skill.name == "Laser")
            {
                _usingLaser = true;
                MainManager.Skill.AreaSkills[(int)Define.AreaSkill.Laser].SetActive(true);
                if (!_laserCoroutine)
                {
                    _areaSkillCoroutine[(int)Define.AreaSkill.Laser] = LaserSkill(skill);
                    StartCoroutine (_areaSkillCoroutine[(int)Define.AreaSkill.Laser]);
                }
            }
                
            else if (skill.name == "Strong")
            {
                _usingStrong = true;
                if (!_strongCoroutine)
                {
                    _buffSkillCoroutine[(int)Define.BuffSkill.Strong] = StrongSkill(skill);
                    StartCoroutine(_buffSkillCoroutine[(int)Define.BuffSkill.Strong]);
                }
            }
                
            else if (skill.name == "FastAttack")
            {
                _usingFastAttack = true;
                if (!_fastAttackCoroutine)
                {
                    _buffSkillCoroutine[(int)Define.BuffSkill.FastAttack] = FastAttackSkill(skill);
                    StartCoroutine(_buffSkillCoroutine[(int)Define.BuffSkill.FastAttack]);
                }
            }
        }

        if (_snowCoroutine && !_usingSnow) { MainManager.Skill.AreaSkills[(int)Define.AreaSkill.Snow].SetActive(false); }
        if (_laserCoroutine && !_usingLaser) { MainManager.Skill.AreaSkills[(int)Define.AreaSkill.Laser].SetActive(false); }
        if (_strongCoroutine && !_usingStrong)
        {
            StopCoroutine(_buffSkillCoroutine[(int)Define.BuffSkill.Strong]); _strongCoroutine = false;
            if (!_backStrong)
                _playerStat.AddAttack(-_playerStat.Strong);
        }
        if (_fastAttackCoroutine && !_usingFastAttack)
        {
            StopCoroutine(_buffSkillCoroutine[(int)Define.BuffSkill.FastAttack]); _fastAttackCoroutine = false;
            if (!_backFastAttack)
                _playerStat.AddAttackSpeed(-_playerStat.FastAttack);
        }
    }

    IEnumerator SnowSkill(GameObject skill)
    {
        _snowCoroutine = true;
        GameObject coolTime = skill.transform.GetChild(0).gameObject;
        Animator anim = coolTime.GetComponent<Animator>();
        anim.speed = 1f / _playerStat.SnowCoolTime;
        coolTime.SetActive(true);

        while (true)
        {
            MainManager.Skill.StartSkill(Define.AreaSkill.Snow);
            yield return new WaitForSeconds(_playerStat.SnowCoolTime);
        }
    }

    IEnumerator LaserSkill(GameObject skill)
    {
        _laserCoroutine = true;
        GameObject coolTime = skill.transform.GetChild(0).gameObject;
        Animator anim = coolTime.GetComponent<Animator>();
        anim.speed = 1f / _playerStat.LaserCoolTime;
        coolTime.SetActive(true);

        while (true)
        {
            MainManager.Skill.StartSkill(Define.AreaSkill.Laser);
            MainManager.Audio.Play("Laser", Define.Audio.Effect);
            yield return new WaitForSeconds(_playerStat.LaserCoolTime);
        }
    }

    
    IEnumerator StrongSkill(GameObject skill)
    {
        _strongCoroutine = true;
        GameObject coolTime = skill.transform.GetChild(0).gameObject;
        Animator anim = coolTime.GetComponent<Animator>();
        anim.speed = 1f / _playerStat.StrongCoolTime;
        coolTime.SetActive(true);

        while (true)
        {
            _playerStat.AddAttack(_playerStat.Strong);
            MainManager.Audio.Play("Strong", Define.Audio.Effect);
            _backStrong = false;
            yield return new WaitForSeconds(_playerStat.StrongStay);
            _playerStat.AddAttack(-_playerStat.Strong);
            _backStrong = true;
            yield return new WaitForSeconds(_playerStat.StrongCoolTime - _playerStat.StrongStay);
        }
    }

    IEnumerator FastAttackSkill(GameObject skill)
    {
        _fastAttackCoroutine = true;
        GameObject coolTime = skill.transform.GetChild(0).gameObject;
        Animator anim = coolTime.GetComponent<Animator>();
        anim.speed = 1f / _playerStat.FastAttackCoolTime;
        coolTime.SetActive(true);

        while (true)
        {   
            _playerStat.AddAttackSpeed(_playerStat.FastAttack);
            MainManager.Audio.Play("FastAttack", Define.Audio.Effect);
            _backFastAttack = false;
            yield return new WaitForSeconds(_playerStat.StrongStay);
            _playerStat.AddAttackSpeed(-_playerStat.FastAttack);
            _backFastAttack = true;
            yield return new WaitForSeconds(_playerStat.FastAttackCoolTime - _playerStat.FastAttackStay);
        }
    }
}
