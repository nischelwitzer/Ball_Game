using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// usage: DMT.StaticStore.myData = ...


namespace DMT
{
    public static class StaticStore
    {
        private static double _myData = 0;
        private static int _myRound = 0;
        private static int _myCollecting = 0;
        private static bool _allowJump = true;


        public static int myRound
        {
            get { return _myRound; }

            set
            {
                int gotData = value;
                if ((gotData >= 0) && (gotData <= 100))
                {
                    _myRound = value;
                }
                else
                {
                    UnityEngine.Debug.LogWarning("setter warning for DMT.StaticStore _myRound");
                }
            }
        }

        public static double myData
        {
            get { return _myData; }

            set
            {
                double gotData = value;
                if ((gotData >= 0.0f) && (gotData <= 360.0f))
                {
                    _myData = value;
                }
                else
                {
                    UnityEngine.Debug.LogWarning("setter warning for DMT.StaticStore");
                }
            }
        }

        public static int myCollecting
        {
            get { return _myCollecting; }
            set
            {
                double gotData = value;
                if (gotData > 0)
                {
                    _myCollecting += value;
                }
                else
                {
                    UnityEngine.Debug.LogWarning("setter _myCollecting warning for DMT.StaticStore");
                }
            }
        }

        public static bool allowJump
        {
            get { return _allowJump; }
            set { _allowJump = value; }
        }

    }
}
