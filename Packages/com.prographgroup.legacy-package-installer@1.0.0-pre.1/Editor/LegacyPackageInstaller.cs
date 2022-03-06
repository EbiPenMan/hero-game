using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;

namespace ProGraphGroup.Packages.LegacyPackageInstaller
{
    public class LegacyPackageInstaller
    {
        [InitializeOnLoadMethod]
        static void SubscribeToEvent()
        {
            Events.registeringPackages += RegisteringPackagesEventHandler;
            Events.registeredPackages += RegisteredPackagesEventHandler;
        }

        static void RegisteredPackagesEventHandler(PackageRegistrationEventArgs packageRegistrationEventArgs)
        {
            foreach (var addedPackage in packageRegistrationEventArgs.added)
            {
                Debug.Log($"Adding {addedPackage.displayName}");

                try
                {
                    TextAsset textAssetJson = (TextAsset) AssetDatabase.LoadAssetAtPath(
                        addedPackage.assetPath + "/install-remove-package.json",
                        typeof(TextAsset));

                    if (textAssetJson != null)
                    {
                        InstallRemovePackage installRemovePackage = JsonConvert.DeserializeObject<InstallRemovePackage>(
                            textAssetJson.text,
                            new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

                        if (installRemovePackage != null)
                            foreach (var installPackagePath in installRemovePackage.InstallPackagesPath)
                            {
                                AssetDatabase.ImportPackage(addedPackage.assetPath + installPackagePath, false);
                                Debug.Log(
                                    $"The import of the Legacy package was successful. PackageName:  {addedPackage.displayName} , LegacyFile:{installPackagePath}");
                            }
                    }
                }
                catch (Exception e)
                {
                    Debug.Log($"Error on adding legacy package progress {addedPackage.displayName} error: {e.Message}");
                }
            }
        }

        static void RegisteringPackagesEventHandler(PackageRegistrationEventArgs packageRegistrationEventArgs)
        {
            foreach (var removedPackage in packageRegistrationEventArgs.removed)
            {
                try
                {
                    TextAsset textAssetJson = (TextAsset) AssetDatabase.LoadAssetAtPath(
                        removedPackage.assetPath + "/install-remove-package.json",
                        typeof(TextAsset));

                    if (textAssetJson != null)
                    {
                        InstallRemovePackage installRemovePackage = JsonConvert.DeserializeObject<InstallRemovePackage>(
                            textAssetJson.text,
                            new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});

                        if (installRemovePackage != null)
                            foreach (var removeAssetPath in installRemovePackage.RemoveAssetsPath)
                            {
                                AssetDatabase.DeleteAsset(removeAssetPath);
                                Debug.Log(
                                    $"The remove asset of the Legacy package was successful. PackageName:  {removedPackage.displayName} , AssetPath:{removeAssetPath}");
                            }
                    }
                }
                catch (Exception e)
                {
                    Debug.Log($"Error on removing package progress {removedPackage.displayName} error: {e.Message}");
                }
            }
        }


        [Serializable]
        private class InstallRemovePackage
        {
            [JsonProperty("installPackagesPath")] public List<string> InstallPackagesPath;
            [JsonProperty("removeAssetsPath")] public List<string> RemoveAssetsPath;


            public InstallRemovePackage(List<string> installPackagesPath, List<string> removeAssetsPath)
            {
                InstallPackagesPath = installPackagesPath;
                RemoveAssetsPath = removeAssetsPath;
            }
        }
    }
}