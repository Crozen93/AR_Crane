//================================================================================================================================
//
//  Copyright (c) 2015-2021 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
//  EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
//  and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
//
//================================================================================================================================

using System;
using UnityEngine;

namespace easyar
{
    /// <summary>
    /// <para xml:lang="en">EasyAR Sense settings.</para>
    /// <para xml:lang="zh">EasyAR Sense的配置信息。</para>
    /// </summary>
    [CreateAssetMenu(menuName = "EasyAR/Settings")]
    public class EasyARSettings : ScriptableObject
    {
        /// <summary>
        /// <para xml:lang="en">EasyAR Sense License Key。Used for validation of EasyAR Sense functions. Please visit https://www.easyar.com for more details.</para>
        /// <para xml:lang="zh">EasyAR Sense License Key。用于验证EasyAR Sense内部各种功能是否可用。详见 https://www.easyar.cn 。</para>
        /// </summary>
        [HideInInspector, SerializeField]
        [TextArea(1, 10)]
        public string LicenseKey = string.Empty;
        /// <summary>
        /// <para xml:lang="en"><see cref="Gizmos"/> configuration for <see cref="ImageTarget"/> and <see cref="ObjectTarget"/>.</para>
        /// <para xml:lang="zh"><see cref="ImageTarget"/> 和 <see cref="ObjectTarget"/>的<see cref="Gizmos"/>配置。</para>
        /// </summary>
        public TargetGizmoConfig GizmoConfig = new TargetGizmoConfig();
        /// <summary>
        /// <para xml:lang="en">Global spatial map service config.</para>
        /// <para xml:lang="zh">全局稀疏地图服务器配置。</para>
        /// </summary>
        public SparseSpatialMapWorkerFrameFilter.SpatialMapServiceConfig GlobalSpatialMapServiceConfig = new SparseSpatialMapWorkerFrameFilter.SpatialMapServiceConfig();
        /// <summary>
        /// <para xml:lang="en">Global cloud recognizer service config.</para>
        /// <para xml:lang="zh">全局云识别服务器配置。</para>
        /// </summary>
        public CloudRecognizerFrameFilter.CloudRecognizerServiceConfig GlobalCloudRecognizerServiceConfig = new CloudRecognizerFrameFilter.CloudRecognizerServiceConfig();
        /// <summary>
        /// <para xml:lang="en">Include recording support in the build. You need a NSMicrophoneUsageDescription key in the plist according to Apple's policy if this is turned on.</para>
        /// <para xml:lang="zh">在构建中使用录屏支持。根据苹果的相关政策，如果需要使用该功能，你需要在plist中添加NSMicrophoneUsageDescription。</para>
        /// </summary>
        [Tooltip("Microphone permission is required for easyar.VideoRecorder. According to Apple's policy, you need to add NSMicrophoneUsageDescription key in the plist if this is turned on.")]
        public bool IOSRecordingSupport = true;

        /// <summary>
        /// <para xml:lang="en">Configuration for AndroidManifest.</para>
        /// <para xml:lang="zh">AndroidManifest权限配置。</para>
        /// </summary>
        public AndroidManifestPermission AndroidManifestPermissions = new AndroidManifestPermission();

        /// <summary>
        /// <para xml:lang="en">ARCore SDK configuration. If you are using AR Foundation or other ARCore SDK distributions, set it to <see cref="ARCoreType.External"/>.</para>
        /// <para xml:lang="zh">ARCore SDK配置。如果你在使用AR Foundation 或其它ARCore SDK分发，需要设置为<see cref="ARCoreType.External"/>。</para>
        /// </summary>
        [Tooltip("ARCore SDK configuration. If you are using AR Foundation or other ARCore SDK distributions, set it to External.")]
        public ARCoreType ARCoreSDK;

#if !UNITY_2020_1_OR_NEWER
        /// <summary>
        /// <para xml:lang="en">Turn on this option if you are building with Android SDK Platform >= 30 and need ARCore to work. Projects built with Unity 2019.4 must be updated to use Gradle 5.6.4 or later. Please refer to https://developers.google.com/ar/develop/unity/android-11-build#unity_20193_20194_and_20201 for updating your project's Gradle version.</para>
        /// <para xml:lang="zh">如果你在使用Android SDK Platform >= 30构建工程并希望ARCore可以工作，需要打开这个选项。使用Unity 2019.4构建的项目必须使用Gradle 5.6.4或更新版本。可以参考 https://developers.google.com/ar/develop/unity/android-11-build#unity_20193_20194_and_20201 来更新工程使用的Gradle版本。</para>
        /// </summary>
        [Tooltip("Turn on this option if you are building with Android SDK Platform >= 30 and need ARCore to work. Projects built with Unity 2019.4 must be updated to use Gradle 5.6.4 or later. Please refer to https://developers.google.com/ar/develop/unity/android-11-build#unity_20193_20194_and_20201 for updating your project's Gradle version.")]
        public bool ARCoreForAndroid11 = false;
#endif

        /// <summary>
        /// <para xml:lang="en">Generate XML document when script reload to make intelliSense for API document work.</para>
        /// <para xml:lang="zh">在脚本重新加载时生成XML文档，以使API文档的intelliSense可以工作。</para>
        /// </summary>
        public bool GenerateXMLDoc = true;

        /// <summary>
        /// <para xml:lang="en">ARCore SDK configuration.</para>
        /// <para xml:lang="zh">ARCore SDK配置。</para>
        /// </summary>
        public enum ARCoreType
        {
            /// <summary>
            /// <para xml:lang="en">ARCore SDK distributed with EasyAR will be included in the build. ARCore features are activated only on ARCore supported devices that have Google Play Services for AR installed. Please visit https://developers.google.com/ar/develop/java/enable-arcore for more details and configurations required for your app.</para>
            /// <para xml:lang="zh">随EasyAR一起分发的ARCore SDK将会被包含在应用中。ARCore 功能只在支持ARCore并安装了Google Play Services for AR的设备上可以使用。更多细节及应用所需要的配置请访问 https://developers.google.com/ar/develop/java/enable-arcore 。</para>
            /// </summary>
            Optional,
            /// <summary>
            /// <para xml:lang="en">ARCore SDK distributed with EasyAR will be included in the build. Your app will require an ARCore Supported Device that has Google Play Services for AR installed on it. Please visit https://developers.google.com/ar/develop/java/enable-arcore for more details and configurations required for your app.</para>
            /// <para xml:lang="zh">随EasyAR一起分发的ARCore SDK将会被包含在应用中。应用将只能在支持ARCore并安装了Google Play Services for AR的设备上可以运行。更多细节及应用所需要的配置请访问 https://developers.google.com/ar/develop/java/enable-arcore 。</para>
            /// </summary>
            Required,
            /// <summary>
            /// <para xml:lang="en">ARCore SDK distributed with EasyAR will not be used.</para>
            /// <para xml:lang="zh">随EasyAR一起分发的ARCore SDK将不会使用。</para>
            /// </summary>
            External,
        }

        /// <summary>
        /// <para xml:lang="en"><see cref="Gizmos"/> configuration for target.</para>
        /// <para xml:lang="zh">Target的<see cref="Gizmos"/>配置。</para>
        /// </summary>
        [Serializable]
        public class TargetGizmoConfig
        {
            /// <summary>
            /// <para xml:lang="en"><see cref="Gizmos"/> configuration for <see cref="easyar.ImageTarget"/>.</para>
            /// <para xml:lang="zh"><see cref="easyar.ImageTarget"/>的<see cref="Gizmos"/>配置。</para>
            /// </summary>
            public ImageTargetConfig ImageTarget = new ImageTargetConfig();
            /// <summary>
            /// <para xml:lang="en"><see cref="Gizmos"/> configuration for <see cref="easyar.ObjectTarget"/>.</para>
            /// <para xml:lang="zh"><see cref="easyar.ObjectTarget"/>的<see cref="Gizmos"/>配置。</para>
            /// </summary>
            public ObjectTargetConfig ObjectTarget = new ObjectTargetConfig();

            /// <summary>
            /// <para xml:lang="en"><see cref="Gizmos"/> configuration for <see cref="easyar.ImageTarget"/>.</para>
            /// <para xml:lang="zh"><see cref="easyar.ImageTarget"/>的<see cref="Gizmos"/>配置。</para>
            /// </summary>
            [Serializable]
            public class ImageTargetConfig
            {
                /// <summary>
                /// <para xml:lang="en">Enable <see cref="Gizmos"/> of target which <see cref="ImageTargetController.SourceType"/> equals to <see cref="ImageTargetController.DataSource.ImageFile"/>. Enable this option will load image file and display gizmo in Unity Editor, the startup performance of the Editor will be affected if there are too much target of this kind in the scene, but the Unity runtime will not be affected when running on devices.</para>
                /// <para xml:lang="zh">开启<see cref="ImageTargetController.SourceType"/>类型为<see cref="ImageTargetController.DataSource.ImageFile"/>的target的<see cref="Gizmos"/>。打开这个将会在Unity Editor中加载图像文件并显示对应gizmo，如果场景中该类target过多，可能会影响编辑器中的启动性能。在设备上运行时，Unity运行时的性能不会受到影响。</para>
                /// </summary>
                public bool EnableImageFile = true;
                /// <summary>
                /// <para xml:lang="en">Enable <see cref="Gizmos"/> of target which <see cref="ImageTargetController.SourceType"/> equals to <see cref="ImageTargetController.DataSource.TargetDataFile"/>. Enable this option will target data file and display gizmo in Unity Editor, the startup performance of the Editor will be affected if there are too much target of this kind in the scene, but the Unity runtime will not be affected when running on devices.</para>
                /// <para xml:lang="zh">开启<see cref="ImageTargetController.SourceType"/>类型为<see cref="ImageTargetController.DataSource.TargetDataFile"/>的target的<see cref="Gizmos"/>。打开这个将会在Unity Editor中加载target数据文件并显示显示对应gizmo，如果场景中该类target过多，可能会影响编辑器中的启动性能。在设备上运行时，Unity运行时的性能不会受到影响。</para>
                /// </summary>
                public bool EnableTargetDataFile = true;
                /// <summary>
                /// <para xml:lang="en">Enable <see cref="Gizmos"/> of target which <see cref="ImageTargetController.SourceType"/> equals to <see cref="ImageTargetController.DataSource.Target"/>. Enable this option will display gizmo in Unity Editor, the startup performance of the Editor will be affected if there are too much target of this kind in the scene, but the Unity runtime will not be affected when running on devices.</para>
                /// <para xml:lang="zh">开启<see cref="ImageTargetController.SourceType"/>类型为<see cref="ImageTargetController.DataSource.Target"/>的target的<see cref="Gizmos"/>。打开这个将会在Unity Editor中显示对应gizmo，如果场景中该类target过多，可能会影响编辑器中的启动性能。在设备上运行时，Unity运行时的性能不会受到影响。</para>
                /// </summary>
                public bool EnableTarget = true;
            }

            /// <summary>
            /// <para xml:lang="en"><see cref="Gizmos"/> configuration for <see cref="easyar.ObjectTarget"/>.</para>
            /// <para xml:lang="zh"><see cref="easyar.ObjectTarget"/>的<see cref="Gizmos"/>配置。</para>
            /// </summary>
            [Serializable]
            public class ObjectTargetConfig
            {
                /// <summary>
                /// <para xml:lang="en">Enable <see cref="Gizmos"/>.</para>
                /// <para xml:lang="zh">开启<see cref="Gizmos"/>。</para>
                /// </summary>
                public bool Enable = true;
            }
        }

        /// <summary>
        /// <para xml:lang="en">Configuration for AndroidManifest.</para>
        /// <para xml:lang="zh">AndroidManifest权限配置。</para>
        /// </summary>
        [Serializable]
        public class AndroidManifestPermission
        {
            /// <summary>
            /// <para xml:lang="en">Permission required for <see cref="easyar.CameraDevice"/>.</para>
            /// <para xml:lang="zh">使用<see cref="easyar.CameraDevice"/>需要的权限。</para>
            /// </summary>
            [Tooltip("Permission required for easyar.CameraDevice")]
            public bool CameraDevice = true;
            /// <summary>
            /// <para xml:lang="en">Permission required for <see cref="easyar.VideoRecorder"/>.</para>
            /// <para xml:lang="zh">使用<see cref="easyar.VideoRecorder"/>需要的权限。</para>
            /// </summary>
            [Tooltip("Permission required for easyar.VideoRecorder")]
            public bool Recording = true;
        }
    }
}
