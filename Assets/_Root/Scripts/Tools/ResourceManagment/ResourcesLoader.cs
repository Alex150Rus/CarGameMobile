using UnityEngine;

namespace Tools
{
    internal static class ResourcesLoader
    {
        public static T LoadResource<T>(ResourcePath path) where T : Object =>
            Resources.Load<T>(path.PathResource);
    }
}