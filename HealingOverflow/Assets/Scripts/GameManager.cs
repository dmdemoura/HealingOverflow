﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public bool debug;
    //==========Declaração do singleton=============
    public static GameManager instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        _entityList = new List<GameObject>();
        _staticEntityPrefabs = EntityPrefabs;
        if (debug)
        {
            Debug.Log("Lista de prefabs na lista normal:");
            foreach (GameObject x in EntityPrefabs)
            {
                Debug.Log("Prefab: " + x.name);
            }
            Debug.Log("Lista de prefabs na lista estatica:");
            foreach (GameObject x in _staticEntityPrefabs)
            {
                Debug.Log("Prefab: " + x.name);
            }
        }
    }
    //=============================================

    private static List<GameObject> _entityList;
    [Header("Lista de prefabs a serem spawnados")]

    //Lista de prefab statica para ser usada nas funções estaticas
    static List<GameObject> _staticEntityPrefabs;
    [SerializeField] List<GameObject> EntityPrefabs;

    /// <summary>
    /// Adiciona uma entidade a lista de entidades
    /// </summary>
    /// <param name="newEntity"></param>
    public static void AddEntity(GameObject newEntity) {
        for (int i = 0; i < _staticEntityPrefabs.Count; i++)
        {
            if (newEntity.CompareTag(_staticEntityPrefabs[i].tag))
            {
                _entityList.Add(newEntity);
                return;
            }
        }
        Debug.Log("ERRO, tentando adicionar uma entidade que não faz aprte da lsita de entidades");
        
    }

    /// <summary>
    /// Spawna uma entidade cujo prefab identificado pela tag passada por parametro
    /// </summary>
    /// <param name="tag">String tag que identifica o prefab a ser spawnado</param>
    /// <param name="spawnPosition">Posição em que a nova entidade sera spawnada</param>
    public static void SpawnAt(string tag, Vector3 spawnPosition)
    {
        foreach (GameObject item in _staticEntityPrefabs)
        {
            if (item.CompareTag(tag))
            {
                GameObject newGameObject = Instantiate(item);
                newGameObject.transform.position = spawnPosition;
                AddEntity(newGameObject);
                return;
            }
        }
        Debug.Log("ERRO! não possuo prefabs com a tag " + tag + " na minha EntityPrefabs");
    }

    /// <summary>
    /// Acha a entidade(identificada pela tag do aprametro) mais proxima a posição do de procura
    /// </summary>
    /// <param name="tag">String com nome da tag da entidade a ser procurada</param>
    /// <param name="searchPosition">Posição a ser procurado</param>
    /// <returns>Retorna referencia do objeto mais proximo ao ponto</returns>
    public static GameObject FindNearAt(string tag, Vector3 searchPosition)
    {
        List<GameObject> subEntityList = _entityList.FindAll(x => x.CompareTag(tag));
        if (subEntityList.Count <= 0)
        {
            Debug.Log("ERRO! Não ha nenhum entity com a tag '" + tag + "' para ser achado");
            return null;
        }
        int nearest = 0;
        float nearestDistance = (subEntityList[0].transform.position - searchPosition).magnitude;
        for (int i = 1; i < subEntityList.Count; i++)
        {
            if ((subEntityList[i].transform.position - searchPosition).magnitude < nearestDistance)
            {
                nearest = i;
                nearestDistance = (subEntityList[i].transform.position - searchPosition).magnitude;
            }
        }
        return subEntityList[nearest];
    }

    /// <summary>
    /// Destroy uma entidade
    /// </summary>
    /// <param name="entity">Referencia para o GameObject da entidade a ser destuida</param>
    public static void DestroyEntity(GameObject entity)
    {
       
        if (_entityList.Contains(entity))
        {
            _entityList.Remove(entity);
        }
        else
        {
            Debug.Log("ERRO! Entidade tentando ser distruidafoi adicionada ao GameManager");
            return;
        }
        Destroy(entity);
    }

    void Update()
    {
    }
}