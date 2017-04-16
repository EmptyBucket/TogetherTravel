using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TogetherTravel
{
    public class DynamicAsset : DynamicObject
    {
        private readonly IDictionary<string, object> _dict;

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            object value;
            result = _dict.TryGetValue(binder.Name, out value) ? value : null;
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _dict[binder.Name] = value;
            return true;
        }

        public DynamicAsset()
        {
            _dict = new Dictionary<string, object>();
        }

        public DynamicAsset(IEnumerable<KeyValuePair<string, object>> keyValuePairs)
        {
            _dict = keyValuePairs.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public DynamicAsset(IDictionary<string, object> dict)
        {
            _dict = dict;
        }
    }

    public class AssetsProvider
    {
        private static AssetsProvider _assetsProvider;

        private static readonly object LockInstance = new object();

        private dynamic _assets;

        public dynamic Assets
        {
            get
            {
                using (var md5 = MD5.Create())
                using (var stream = File.OpenRead(_pathAssetsFile))
                {
                    var tmpHash = md5.ComputeHash(stream);
                    if (_hash != null && _hash.SequenceEqual(tmpHash)) return _assets;
                    _hash = tmpHash;
                    stream.Seek(0, SeekOrigin.Begin);
                    using (var streamReader = new StreamReader(stream))
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        var jObject = JObject.Load(jsonTextReader);
                        var dynamicAsset = new DynamicAsset(jObject);
                        _assets = dynamicAsset;
                    }
                }
                return _assets;
            }
        }

        private byte[] _hash;

        private readonly string _pathAssetsFile;

        private AssetsProvider(string pathAssetsFile)
        {
            _pathAssetsFile = pathAssetsFile;
        }

        public static AssetsProvider Instance()
        {
            if (_assetsProvider == null)
                throw new Exception("Context associated");
            return _assetsProvider;
        }

        public static AssetsProvider Bind(string pathAssets)
        {
            lock(LockInstance)
                _assetsProvider = new AssetsProvider(pathAssets);
            return _assetsProvider;
        }
    }
}