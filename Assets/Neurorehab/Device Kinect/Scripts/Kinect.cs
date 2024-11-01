using System.Collections.Generic;
using Neurorehab.Scripts.Devices.Abstracts;
using Neurorehab.Scripts.Devices.Data;
using Neurorehab.Scripts.Enums;
using UnityEngine;

namespace Neurorehab.Device_Kinect.Scripts
{
    /// <summary>
    /// The controller of all the <see cref="KinectData"/>. Responsible for creating, deleting and updating all the <see cref="KinectData"/> according to what is receiving by UDP.
    /// </summary>
    public class Kinect : GenericDeviceController
    {
        [Header("Avatar Info")]
        public List<Material> AvatarMaterials;

        protected override void Awake()
        {
            base.Awake();

            DeviceName = Devices.kinect.ToString();

        }

        //TODO NAO APAGAR ATE ARRANJAR A PARTE DAS GESTURES
        //public void CreateNewUnityObject(GenericDevice genericDevice)
        //{
        //    foreach (var stringValuese in genericDevice.GetNewDetections(DevicesData.Keys.ToList()))
        //    {
        //        var avatarData = new KinectData(stringValuese.Id);
        //        DevicesData.Add(stringValuese.Id, avatarData);

        //        var avatar = Instantiate(AvatarPrefab);

        //        var avatarKinectSkeleton = avatar.GetComponent<KinectUnity>();

        //        avatarKinectSkeleton.Id = avatarData.Id;
        //        avatarData.UnityObject = avatarKinectSkeleton.gameObject;

        //        var mats = new Material[1];
        //        mats[0] = AvatarMaterials[DevicesData.Count - 1];
        //        avatarKinectSkeleton.AvatarMatObj.GetComponent<SkinnedMeshRenderer>().materials = mats;

        //        //var color = mats[0].color;
        //        //var gesturePanel = Instantiate(GesturesPrefab);
        //        //var gestLeft = gesturePanel.transform.FindChild("Left");
        //        //var gestRight = gesturePanel.transform.FindChild("Right");

        //        //gestLeft.GetComponent<Image>().color = gestRight.GetComponent<Image>().color = color;

        //        //avatarKinectSkeleton.GestureLeft = gestLeft.gameObject;
        //        //avatarKinectSkeleton.GestureRight = gestRight.gameObject;

        //        //gesturePanel.transform.SetParent(GesturesParent.transform, false);

        //        avatar.transform.SetParent(AvatarsParent.transform);
        //    }
        //}
    }
}