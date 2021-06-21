//================================================================================================================================
//
//  Copyright (c) 2015-2021 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
//  EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
//  and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
//
//================================================================================================================================

using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
#if UNITY_IOS
using UnityEditor.iOS.Xcode;
#endif

namespace easyar
{
    class BuildProcessor : IPreprocessBuildWithReport, IPostprocessBuildWithReport
    {
        public int callbackOrder => 1;

        public void OnPreprocessBuild(BuildReport report)
        {
            if (AssetDatabase.IsValidFolder("Assets/HiddenEasyAR"))
            {
                AssetDatabase.DeleteAsset("Assets/HiddenEasyAR");
            }

            if (report.summary.platform == BuildTarget.iOS)
            {
                var isNR = false;
                if (EasyARController.Settings)
                {
                    isNR = !EasyARController.Settings.IOSRecordingSupport;
                }
                PrepareOptionalNativePlugin($"Packages/com.easyar.sense/Runtime/Binding{(isNR ? "NR" : "")}/iOS/arm64_fat/easyar.framework", BuildTarget.iOS);
            }
            if (report.summary.platform == BuildTarget.Android)
            {
                var permisssion = new EasyARSettings.AndroidManifestPermission();
                if (EasyARController.Settings)
                {
                    permisssion = EasyARController.Settings.AndroidManifestPermissions;
                }
                if (permisssion.CameraDevice)
                {
                    PrepareOptionalNativePlugin("Packages/com.easyar.sense/Runtime/Android/permission.CAMERA.aar", BuildTarget.Android);
                }
                if (permisssion.Recording)
                {
                    PrepareOptionalNativePlugin("Packages/com.easyar.sense/Runtime/Android/permission.RECORD_AUDIO.aar", BuildTarget.Android);
                }
                var arcore = EasyARSettings.ARCoreType.Optional;
#if !UNITY_2020_1_OR_NEWER
                var arcoreForAndroid11 = false;
#else
                var arcoreForAndroid11 = true;
#endif
                if (EasyARController.Settings)
                {
                    arcore = EasyARController.Settings.ARCoreSDK;
#if !UNITY_2020_1_OR_NEWER
                    arcoreForAndroid11 = EasyARController.Settings.ARCoreForAndroid11;
#endif
                }
#if EASYAR_ENABLE_UNITYARCORE
                if (arcore != EasyARSettings.ARCoreType.External)
                {
                    UnityEngine.Debug.LogWarning("ARCore XR Plugin detected, change <EasyAR -> Sense -> Configuration -> ARCoreSDK> to a different value if there are some conflictions.");
                }
#endif
                switch (arcore)
                {
                    case EasyARSettings.ARCoreType.Optional:
                        PrepareOptionalNativePlugin("Packages/com.easyar.sense/Runtime/Android/com.google.ar.core-1.6.0.aar", BuildTarget.Android);
                        PrepareOptionalNativePlugin("Packages/com.easyar.sense/Runtime/Android/com.google.ar.core-optional.aar", BuildTarget.Android);
                        if (arcoreForAndroid11)
                        {
                            PrepareOptionalNativePlugin("Packages/com.easyar.sense/Runtime/Android/com.google.ar.core-queries.aar", BuildTarget.Android);
                        }
                        break;
                    case EasyARSettings.ARCoreType.Required:
                        PrepareOptionalNativePlugin("Packages/com.easyar.sense/Runtime/Android/com.google.ar.core-1.6.0.aar", BuildTarget.Android);
                        PrepareOptionalNativePlugin("Packages/com.easyar.sense/Runtime/Android/com.google.ar.core-required.aar", BuildTarget.Android);
                        if (arcoreForAndroid11)
                        {
                            PrepareOptionalNativePlugin("Packages/com.easyar.sense/Runtime/Android/com.google.ar.core-queries.aar", BuildTarget.Android);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void OnPostprocessBuild(BuildReport report)
        {
            if (AssetDatabase.IsValidFolder("Assets/HiddenEasyAR"))
            {
                AssetDatabase.DeleteAsset("Assets/HiddenEasyAR");
            }

            if (report.summary.platform == BuildTarget.iOS)
            {
#if UNITY_IOS
                var proj = new PBXProject();
                var projPath = PBXProject.GetPBXProjectPath(report.summary.outputPath);
                proj.ReadFromFile(projPath);
                proj.SetBuildProperty(proj.GetUnityFrameworkTargetGuid(), "ENABLE_BITCODE", "NO");
                proj.SetBuildProperty(proj.GetUnityMainTargetGuid(), "ENABLE_BITCODE", "NO");
                proj.WriteToFile(projPath);
#endif
            }
        }

        private void PrepareOptionalNativePlugin(string asset, BuildTarget target)
        {
            if (!AssetDatabase.IsValidFolder("Assets/HiddenEasyAR"))
            {
                AssetDatabase.CreateFolder("Assets", "HiddenEasyAR");
            }
            var hiddenAsset = "Assets/HiddenEasyAR/" + Path.GetFileName(asset);
            AssetDatabase.CopyAsset(asset, hiddenAsset);
            var plugin = AssetImporter.GetAtPath(hiddenAsset) as PluginImporter;
            plugin.SetCompatibleWithPlatform(target, true);
            plugin.SetExcludeFromAnyPlatform(target, false);
            if (target == BuildTarget.iOS)
            {
                plugin.SetPlatformData(target, "AddToEmbeddedBinaries", "true");
            }
        }
    }
}
