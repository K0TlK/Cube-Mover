using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeManager : Singleton<CubeManager>
{
    [SerializeField] private Transform cubeSpawnPoint;

    [SerializeField] private float cubeSpeed = 1.0f;
    [SerializeField] private float cubeSpawnrate = 1.0f;
    [SerializeField] private Vector3 cubePos = Vector3.one;

    private float baseSpawnrate;
    private float baseLifetime;
    private Vector3 baseCubePos;

    public float Speed => cubeSpeed;
    public float Spawnrate => cubeSpawnrate;
    public Vector3 CubePos => cubePos;

    [SerializeField] private TMP_InputField inputFieldSpeed;
    [SerializeField] private TMP_InputField inputSpawnrate;
    [SerializeField] private TMP_InputField inputLifePosX;
    [SerializeField] private TMP_InputField inputLifePosY;
    [SerializeField] private TMP_InputField inputLifePosZ;

    [SerializeField] private CubeCotroller cubePrefab;

    private bool isActive = true;

    private void Awake()
    {
        baseSpawnrate = cubeSpeed;
        baseLifetime = cubeSpawnrate;
        baseCubePos = cubePos;
    }

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        while (isActive)
        {
            CubeCotroller tmp = Instantiate(cubePrefab, cubeSpawnPoint);
            tmp.transform.localPosition = Vector3.zero;
            tmp.Init(cubePos, cubeSpeed);
            yield return new WaitForSeconds(cubeSpawnrate);
        }
    }

    public void InputFieldSpeedUpdate()
    {
        string data = inputFieldSpeed.text;
        if (data == "")
        {
            cubeSpeed = baseSpawnrate;
            return;
        }
        cubeSpeed = (float)Convert.ToDouble(data);
        if (cubeSpeed < 0.0f)
        {
            cubeSpeed = baseSpawnrate;
        }
    }

    public void InputFieldSpawnrateUpdate()
    {
        string data = inputSpawnrate.text;
        if (data == "")
        {
            cubeSpawnrate = baseLifetime;
            return;
        }
        cubeSpawnrate = (float)Convert.ToDouble(data);
        if (cubeSpawnrate < 0.0f)
        {
            cubeSpawnrate = baseSpawnrate;
        }
    }

    public void InputFieldXUpdate()
    {
        string data = inputLifePosX.text;
        if (data == "")
        {
            SetPos(new Vector3(baseCubePos.x, cubePos.y, cubePos.z));
            return;
        }
        SetPos(new Vector3((float)Convert.ToDouble(data), cubePos.y, cubePos.z));
    }

    public void InputFieldYUpdate()
    {
        string data = inputLifePosY.text;
        if (data == "")
        {
            SetPos(new Vector3(cubePos.x, baseCubePos.y, cubePos.z));
            return;
        }
        SetPos(new Vector3(cubePos.x, (float)Convert.ToDouble(data), cubePos.z));
    }

    public void InputFieldZUpdate()
    {
        string data = inputLifePosZ.text;
        if (data == "")
        {
            SetPos(new Vector3(cubePos.x, cubePos.y, baseCubePos.z));
            return;
        }
        SetPos(new Vector3(cubePos.x, cubePos.y, (float)Convert.ToDouble(data)));
    }

    private void SetPos(Vector3 newPos)
    {
        cubePos = newPos;
    }

    public void debugData(string additional)
    {
        Debug.Log($"{additional}| speed: {Speed} spawnrate: {Spawnrate} cubePos: {CubePos}");
    }
}
