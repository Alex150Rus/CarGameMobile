using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using UnityEngine;

internal abstract class BaseViewController: BaseController
{
    protected T LoadView<T>(Transform placeForUi, ResourcePath resourcePath, bool worldPositionStays = false)
    {
        GameObject prefab = ResourcesLoader.LoadResource<GameObject>(resourcePath);
        GameObject objectView = UnityEngine.Object.Instantiate(prefab, placeForUi, worldPositionStays);
        AddGameObject(objectView);

        return objectView.GetComponent<T>();
    }
}
