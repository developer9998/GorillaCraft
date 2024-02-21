using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GorillaCraft
{
    public class AssetLoader
    {
        private AssetBundle _assetBundle = null;
        private Task _loadingTask = null;
        private bool _bundleLoaded;

        private Dictionary<string, Object> _loadedObjects;

        private async Task LoadBundle()
        {
            Stream _bundleStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(Constants.BundleDirectory);
            var _bundleCreationRequest = AssetBundle.LoadFromStreamAsync(_bundleStream);

            var _completionSource = new TaskCompletionSource<AssetBundle>();
            _bundleCreationRequest.completed += operation =>
            {
                var outRequest = operation as AssetBundleCreateRequest;
                _completionSource.SetResult(outRequest.assetBundle);
            };

            _assetBundle = await _completionSource.Task;
            _bundleLoaded = true;
        }

        public async Task<T> LoadAsset<T>(string name) where T : Object
        {
            if (!_bundleLoaded)
            {
                _loadingTask ??= LoadBundle();
                await _loadingTask;
            }

            if (_loadedObjects != null && _loadedObjects.TryGetValue(name, out var _loadedObject))
                return _loadedObject as T;

            Debug.Log("LOADING: " + name);

            _loadedObjects ??= new Dictionary<string, Object>();

            var _bundleLoadRequest = _assetBundle.LoadAssetAsync<T>(name);
            var _completionSource = new TaskCompletionSource<T>();
            _bundleLoadRequest.completed += operation =>
            {
                var outRequest = operation as AssetBundleRequest;
                if (outRequest.asset == null)
                {
                    _completionSource.SetResult(null);
                    return;
                }

                _completionSource.SetResult(outRequest.asset as T);
            };

            var _finishedTask = await _completionSource.Task;
            _loadedObjects.Add(name, _finishedTask);
            return _finishedTask;
        }
    }
}
