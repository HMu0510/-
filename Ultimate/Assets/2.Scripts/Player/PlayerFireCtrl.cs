﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerSfx
{
    public AudioClip[] fire;
    public AudioClip[] reload;
}
public class PlayerFireCtrl : MonoBehaviour
{
    public enum WeaponType
    {
        RIFLE = 0,
        SHOTGUN
    }
    public WeaponType currWeapon = WeaponType.SHOTGUN;

    [SerializeField] GameObject bullet;
    [SerializeField] ParticleSystem cartridge;
    private ParticleSystem muzzleFlash;
    private AudioSource _audio;

    public Transform firePos;
    public PlayerSfx playerSfx;
    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    private void Fire()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);

        cartridge.Play();

        muzzleFlash.Play();

        FireSfx();
    }
    private void FireSfx()
    {
        var _sfx = playerSfx.fire[(int)currWeapon];

        _audio.PlayOneShot(_sfx, 1.0f);
    }
}
