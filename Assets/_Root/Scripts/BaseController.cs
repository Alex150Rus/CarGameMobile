using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

internal abstract class BaseController : IDisposable
{
    protected List<BaseController> _baseControllers;
    private List<GameObject> _gameObjects;
    private List<IRepository> _repositories;

    private bool _isDisposed;

    protected void AddController(BaseController baseController)
    {
        _baseControllers ??= new List<BaseController>();
        _baseControllers.Add(baseController);
    }

    protected void AddGameObject(GameObject gameObject)
    {
        _gameObjects ??= new List<GameObject>();
        _gameObjects.Add(gameObject);
    }

    protected void AddRepository(IRepository repository)
    {
        _repositories ??= new List<IRepository>();
        _repositories.Add(repository);
    }

    public void Dispose()
    {
        if (_isDisposed)
            return;

        DisposeBaseControllers();
        DisposeGameObjects();
        DisposeRepositories();

        OnDisposed();
    }

    protected virtual void OnDisposed(){}

    private void DisposeGameObjects()
    {
        if (_gameObjects == null)
            return;

        foreach (GameObject gameObject in _gameObjects)
            Object.Destroy(gameObject);
        _gameObjects.Clear();
    }

    private void DisposeBaseControllers()
    {
        if (_baseControllers == null)
            return;
        
        foreach (BaseController baseController in _baseControllers)
            baseController.Dispose();
        _baseControllers.Clear();
    }

    private void DisposeRepositories()
    {
        if (_repositories == null)
            return;

        foreach (IRepository _repository in _repositories)
            _repository.Dispose();
        _repositories.Clear();
    }
}