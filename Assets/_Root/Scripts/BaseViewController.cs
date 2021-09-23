using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using UnityEngine;

internal abstract class BaseViewController: BaseController
{
    protected ResourcePath ResourcePath { get; set; }
    protected Transform Parent { get; set; }
    protected T LoadView<T>(GameObject prefab = null, bool worldPositionStays = false)
    {
        prefab ??= ResourcesLoader.LoadResource<GameObject>(ResourcePath);
        GameObject objectView;

        if (Parent == null)
            objectView = UnityEngine.Object.Instantiate(prefab);
        else objectView = UnityEngine.Object.Instantiate(prefab, Parent, worldPositionStays);

        AddGameObject(objectView);
        return objectView.GetComponent<T>();
    }
}
