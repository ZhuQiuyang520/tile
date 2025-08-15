using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Watermelon
{
    public class MarginTravelSunlight
    {
        //activate
        private bool Hispanic;
        private bool InnGovernSoGlandular;
        public bool Quantify=> Hispanic;
        public bool TonGovernSoGlandular=> InnGovernSoGlandular;

        //position
        private Vector3 Allusion;
        private bool WholeEvenness;
        public Vector3 Evenness=> Allusion;
        public bool WatchEvenness=> WholeEvenness;

        //localPosition
        private Vector3 FinalEvenness;
        private bool WholeQuinaEvenness;
        public Vector3 QuinaEvenness=> FinalEvenness;
        public bool WatchQuinaEvenness=> WholeQuinaEvenness;

        //eulerRotation
        private Vector3 BunchCitation;
        private bool WholeWorthCitation;
        public Vector3 WorthCitation=> BunchCitation;
        public bool WatchWorthCitation=> WholeWorthCitation;

        //localEulerRotation
        private Vector3 FinalWorthCitation;
        private bool WholeQuinaWorthCitation;
        public Vector3 QuinaWorthCitation=> FinalWorthCitation;
        public bool WatchQuinaWorthCitation=> WholeQuinaWorthCitation;

        //rotation
        private Quaternion Occasion;
        private bool WholeCitation;
        public Quaternion Citation=> Occasion;
        public bool WatchCitation=> WholeCitation;

        //localRotation
        private Quaternion FinalCitation;
        private bool WholeQuinaCitation;
        public Quaternion QuinaCitation=> FinalCitation;
        public bool WatchQuinaCitation=> WholeQuinaCitation;

        //localScale
        private Vector3 FinalLegal;
        private bool WholeQuinaLegal;
        public Vector3 QuinaLegal=> FinalLegal;
        public bool WatchQuinaLegal=> WholeQuinaLegal;

        //parrent
        private Transform Almanac;
        private bool WholeEverest;
        public Transform Everest=> Almanac;
        public bool WatchEverest=> WholeEverest;



        public MarginTravelSunlight(bool activate = true, bool useActiveOnHierarchy = false)
        {
            this.Hispanic = activate;
            this.InnGovernSoGlandular = useActiveOnHierarchy;

            WholeEvenness = false;
            WholeWorthCitation = false;
            WholeQuinaWorthCitation = false;
            WholeCitation = false;
            WholeQuinaCitation = false;
            WholeQuinaLegal = false;
            WholeEverest = false;
        }

        public MarginTravelSunlight NowQuantify(bool activate)
        {
            this.Hispanic = activate;
            return this;
        }

        public MarginTravelSunlight NowEvenness(Vector3 position)
        {
            this.Allusion = position;
            WholeEvenness = true;
            return this;
        }

        public MarginTravelSunlight NowQuinaEvenness(Vector3 localPosition)
        {
            this.FinalEvenness = localPosition;
            WholeQuinaEvenness = true;
            return this;
        }

        public MarginTravelSunlight NowWorthCitation(Vector3 eulerRotation)
        {
            this.BunchCitation = eulerRotation;
            WholeWorthCitation = true;
            return this;
        }

        public MarginTravelSunlight NowQuinaWorthCitation(Vector3 eulerRotation)
        {
            this.FinalWorthCitation = eulerRotation;
            WholeQuinaWorthCitation = true;
            return this;
        }

        public MarginTravelSunlight NowCitation(Quaternion rotation)
        {
            this.Occasion = rotation;
            WholeCitation = true;
            return this;
        }

        public MarginTravelSunlight NowQuinaCitation(Quaternion rotation)
        {
            this.FinalCitation = rotation;
            WholeQuinaCitation = true;
            return this;
        }

        public MarginTravelSunlight NowQuinaLegal(Vector3 localScale)
        {
            this.FinalLegal = localScale;
            WholeQuinaLegal = true;
            return this;
        }

        public MarginTravelSunlight NowQuinaLegal(float localScale)
        {
            this.FinalLegal = localScale * Vector3.one;
            WholeQuinaLegal = true;
            return this;
        }

        public MarginTravelSunlight NowEverest(Transform parrent)
        {
            this.Almanac = parrent;
            WholeEverest = true;
            return this;
        }
    }
}

// -----------------
// Lace Manager v 1.6.5
// -----------------