using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseController : IDisposable
{
    private List<BaseController> _baseControllers;
    private List<GameObject> _gameObjects;
    private bool _isDisposed;

    public void Dispose()
    {
        if (_isDisposed)
        {
            _isDisposed = true;
            ClearList();
            OnDispose();
        }
    }

    private void ClearList()
    {
        if(_baseControllers != null)
        {
            foreach(BaseController baseController in _baseControllers)
            {
                baseController?.Dispose();
            }

            _baseControllers.Clear();
        }

        if(_gameObjects != null)
        {
            foreach(GameObject gm in _gameObjects)
            {
                UnityEngine.Object.Destroy(gm);
            }

            _gameObjects.Clear();
        }
    }

    protected virtual void OnDispose()
    {

    }

    protected void AddControllers(BaseController baseController)
    {
        if (_baseControllers == null) _baseControllers = new List<BaseController>();
        _baseControllers.Add(baseController);
    }
    
    protected void AddGameObject(GameObject gm)
    {
        if (_gameObjects == null) _gameObjects = new List<GameObject>();
        _gameObjects.Add(gm);
    }
}
