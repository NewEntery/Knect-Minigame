using System;
using Neurorehab.Scripts.Devices.Abstracts;
using Neurorehab.Scripts.Devices.Data;
using Neurorehab.Scripts.Enums;
using UnityEngine;

namespace Neurorehab.Device_Kinect.Scripts
{
    /// <summary>
    /// Responsible for updating the Unity Kinect data according to its <see cref="KinectData"/>.
    /// </summary>
    public class KinectUnity : GenericDeviceUnity
    {
        /// <summary>
        /// All the avatar joints initial rotations
        /// </summary>
        private Quaternion[] _initialRotations;

        /// <summary>
        /// A reference to the <see cref="KinectData"/> tobe able to use its own override methods
        /// </summary>
        private KinectData _kinectData;

        [Header("Avatar additional information")]
        public GameObject AvatarMatObj;

        [Header("Avatar Joints")] public GameObject Body;

        public GameObject GestureLeft;
        public GameObject GestureRight;
        public GameObject Head;
        public GameObject LeftAnkle;
        public GameObject LeftElbow;
        public GameObject LeftHip;
        public GameObject LeftKnee;
        public GameObject LeftShoulder;
        public GameObject LeftWrist;
        public GameObject Neck;
        public GameObject RightAnkle;
        public GameObject RightElbow;
        public GameObject RightHip;
        public GameObject RightKnee;
        public GameObject RightShoulder;
        public GameObject RightWrist;
        public GameObject Torso;
        public GameObject Waist;

        /// <summary>
        /// Initializes all the transforms and <see cref="_initialRotations"/>
        /// </summary>
        private void Awake()
        {
            var jointCount = Enum.GetNames(typeof(KinectBones)).Length;

            var transforms = new Transform[jointCount];
            _initialRotations = new Quaternion[jointCount];

            transforms[(int) KinectBones.head] = Head != null ? Head.transform : null;
            transforms[(int) KinectBones.neck] = Neck != null ? Neck.transform : null;
            transforms[(int) KinectBones.leftshoulder] = LeftShoulder != null ? LeftShoulder.transform : null;
            transforms[(int) KinectBones.leftelbow] = LeftElbow != null ? LeftElbow.transform : null;
            transforms[(int) KinectBones.leftwrist] = LeftWrist != null ? LeftWrist.transform : null;
            transforms[(int) KinectBones.rightshoulder] = RightShoulder != null ? RightShoulder.transform : null;
            transforms[(int) KinectBones.rightelbow] = RightElbow != null ? RightElbow.transform : null;
            transforms[(int) KinectBones.rightwrist] = RightWrist != null ? RightWrist.transform : null;
            transforms[(int) KinectBones.torso] = Torso != null ? Torso.transform : null;
            transforms[(int) KinectBones.waist] = Waist != null ? Waist.transform : null;
            transforms[(int) KinectBones.lefthip] = LeftHip != null ? LeftHip.transform : null;
            transforms[(int) KinectBones.leftknee] = LeftKnee != null ? LeftKnee.transform : null;
            transforms[(int) KinectBones.leftankle] = LeftAnkle != null ? LeftAnkle.transform : null;
            transforms[(int) KinectBones.righthip] = RightHip != null ? RightHip.transform : null;
            transforms[(int) KinectBones.rightknee] = RightKnee != null ? RightKnee.transform : null;
            transforms[(int) KinectBones.rightankle] = RightAnkle != null ? RightAnkle.transform : null;
            
            if (Body == null) return;

            foreach (KinectBones joint in Enum.GetValues(typeof(KinectBones)))
                if (transforms[(int) joint])
                    _initialRotations[(int) joint] = Quaternion.Inverse(Body.transform.rotation) *
                                                     transforms[(int) joint].rotation;
        }

        private void Update()
        {
            if (GenericDeviceData == null) return;

            UpdateAvatar();
        }

        /// <summary>
        /// Updates the avatar joints values (position and rotation) according to its <see cref="GenericDeviceUnity.GenericDeviceData"/> 
        /// </summary>
        public void UpdateAvatar()
        {
            if (_kinectData == null)
                _kinectData = (KinectData) GenericDeviceData;

            //Body.transform.localPosition = _kinectData.GetPosition(KinectBones.waist.ToString());

            if (Head != null)
                Head.transform.rotation = Body.transform.rotation *  //reference object
                                      GenericDeviceData.GetRotation(KinectBones.head.ToString()) * //rotation that comes from kinect (world rotation)
                                      _initialRotations[(int) KinectBones.head]; //initial rotation of the head inside unity

            if (Neck != null)
                Neck.transform.rotation = Body.transform.rotation * 
                                      GenericDeviceData.GetRotation(KinectBones.neck.ToString()) *
                                      _initialRotations[(int) KinectBones.neck];

            if (Torso != null)
                Torso.transform.rotation = Body.transform.rotation * 
                                       GenericDeviceData.GetRotation(KinectBones.torso.ToString()) *
                                       _initialRotations[(int) KinectBones.torso];

            if (Waist != null)
                Waist.transform.rotation = Body.transform.rotation * 
                                       GenericDeviceData.GetRotation(KinectBones.waist.ToString()) *
                                       _initialRotations[(int) KinectBones.waist];

            if (LeftShoulder != null)
                LeftShoulder.transform.rotation = Body.transform.rotation *
                                              GenericDeviceData.GetRotation(KinectBones.leftshoulder.ToString()) *
                                              _initialRotations[(int) KinectBones.leftshoulder];

            if (LeftElbow != null)
                LeftElbow.transform.rotation = Body.transform.rotation *
                                           GenericDeviceData.GetRotation(KinectBones.leftelbow.ToString()) *
                                           _initialRotations[(int) KinectBones.leftelbow];

            if (LeftWrist != null)
                LeftWrist.transform.rotation = Body.transform.rotation *
                                           GenericDeviceData.GetRotation(KinectBones.leftwrist.ToString()) *
                                           _initialRotations[(int) KinectBones.leftwrist];

            if (RightShoulder != null)
                RightShoulder.transform.rotation = Body.transform.rotation *
                                               GenericDeviceData.GetRotation(KinectBones.rightshoulder.ToString()) *
                                               _initialRotations[(int) KinectBones.rightshoulder];

            if (RightElbow != null)
                RightElbow.transform.rotation = Body.transform.rotation *
                                            GenericDeviceData.GetRotation(KinectBones.rightelbow.ToString()) *
                                            _initialRotations[(int) KinectBones.rightelbow];

            if (RightWrist != null)
                RightWrist.transform.rotation = Body.transform.rotation *
                                            GenericDeviceData.GetRotation(KinectBones.rightwrist.ToString()) *
                                            _initialRotations[(int) KinectBones.rightwrist];

            if (LeftHip != null)
                LeftHip.transform.rotation = Body.transform.rotation *
                                         GenericDeviceData.GetRotation(KinectBones.lefthip.ToString()) *
                                         _initialRotations[(int) KinectBones.lefthip];

            if (LeftKnee != null)
                LeftKnee.transform.rotation = Body.transform.rotation *
                                          GenericDeviceData.GetRotation(KinectBones.leftknee.ToString()) *
                                          _initialRotations[(int) KinectBones.leftknee];

            if (LeftAnkle != null)
                LeftAnkle.transform.rotation = Body.transform.rotation *
                                           GenericDeviceData.GetRotation(KinectBones.leftankle.ToString()) *
                                           _initialRotations[(int) KinectBones.leftankle];

            if (RightHip != null)
                RightHip.transform.rotation = Body.transform.rotation *
                                          GenericDeviceData.GetRotation(KinectBones.righthip.ToString()) *
                                          _initialRotations[(int) KinectBones.righthip];

            if (RightKnee != null)
                RightKnee.transform.rotation = Body.transform.rotation *
                                           GenericDeviceData.GetRotation(KinectBones.rightknee.ToString()) *
                                           _initialRotations[(int) KinectBones.rightknee];

            if (RightAnkle != null)
                RightAnkle.transform.rotation = Body.transform.rotation *
                                            GenericDeviceData.GetRotation(KinectBones.rightankle.ToString()) *
                                            _initialRotations[(int) KinectBones.rightankle];
        }
    }
}