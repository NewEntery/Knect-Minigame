using System.Collections.Generic;
using Neurorehab.Scripts.Enums;

namespace Neurorehab.Device_Kinect.Scripts
{
    public class KinectFaceData
    {
        private readonly Dictionary<KinectFace, string> _face;

        private readonly object _faceLock = new object();

        public KinectFaceData()
        {
            _face = new Dictionary<KinectFace, string>
            {
                {KinectFace.happy, ""},
                {KinectFace.engaged, ""},
                {KinectFace.wearingglasses, ""},
                {KinectFace.lefteyeclosed, ""},
                {KinectFace.righteyeclosed, ""},
                {KinectFace.mouthopen, ""},
                {KinectFace.mouthmoved, ""},
                {KinectFace.lookingaway, ""}
            };
        }

        #region face

        public string Happy
        {
            get
            {
                lock (_faceLock)
                {
                    return _face[KinectFace.happy];
                }
            }
            set
            {
                lock (_faceLock)
                {
                    _face[KinectFace.happy] = value;
                }
            }
        }

        public string Engaged
        {
            get
            {
                lock (_faceLock)
                {
                    return _face[KinectFace.engaged];
                }
            }
            set
            {
                lock (_faceLock)
                {
                    _face[KinectFace.engaged] = value;
                }
            }
        }

        public string WearingGlasses
        {
            get
            {
                lock (_faceLock)
                {
                    return _face[KinectFace.wearingglasses];
                }
            }
            set
            {
                lock (_faceLock)
                {
                    _face[KinectFace.wearingglasses] = value;
                }
            }
        }

        public string LeftEyeClosed
        {
            get
            {
                lock (_faceLock)
                {
                    return _face[KinectFace.lefteyeclosed];
                }
            }
            set
            {
                lock (_faceLock)
                {
                    _face[KinectFace.lefteyeclosed] = value;
                }
            }
        }

        public string RightEyeClosed
        {
            get
            {
                lock (_faceLock)
                {
                    return _face[KinectFace.righteyeclosed];
                }
            }
            set
            {
                lock (_faceLock)
                {
                    _face[KinectFace.righteyeclosed] = value;
                }
            }
        }

        public string MouthOpen
        {
            get
            {
                lock (_faceLock)
                {
                    return _face[KinectFace.mouthopen];
                }
            }
            set
            {
                lock (_faceLock)
                {
                    _face[KinectFace.mouthopen] = value;
                }
            }
        }

        public string MouthMoved
        {
            get
            {
                lock (_faceLock)
                {
                    return _face[KinectFace.mouthmoved];
                }
            }
            set
            {
                lock (_faceLock)
                {
                    _face[KinectFace.mouthmoved] = value;
                }
            }
        }

        public string LookingAway
        {
            get
            {
                lock (_faceLock)
                {
                    return _face[KinectFace.lookingaway];
                }
            }
            set
            {
                lock (_faceLock)
                {
                    _face[KinectFace.lookingaway] = value;
                }
            }
        }

        #endregion
    }
}