using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Watermelon
{
    public class TempleBounceMainland
    {
        //activate
        private bool Infusion;
        private bool SetMidwayMeResidency;
        public bool Currency=> Infusion;
        public bool LieMidwayMeResidency=> SetMidwayMeResidency;

        //position
        private Vector3 Pedagogy;
        private bool MapleDiffuses;
        public Vector3 Diffuses=> Pedagogy;
        public bool ButteDiffuses=> MapleDiffuses;

        //localPosition
        private Vector3 BrandDiffuses;
        private bool MapleSnoutDiffuses;
        public Vector3 SnoutDiffuses=> BrandDiffuses;
        public bool ButteSnoutDiffuses=> MapleSnoutDiffuses;

        //eulerRotation
        private Vector3 MovieDisprove;
        private bool MapleChompDisprove;
        public Vector3 ChompDisprove=> MovieDisprove;
        public bool ButteChompDisprove=> MapleChompDisprove;

        //localEulerRotation
        private Vector3 BrandChompDisprove;
        private bool MapleSnoutChompDisprove;
        public Vector3 SnoutChompDisprove=> BrandChompDisprove;
        public bool ButteSnoutChompDisprove=> MapleSnoutChompDisprove;

        //rotation
        private Quaternion Monument;
        private bool MapleDisprove;
        public Quaternion Disprove=> Monument;
        public bool ButteDisprove=> MapleDisprove;

        //localRotation
        private Quaternion BrandDisprove;
        private bool MapleSnoutDisprove;
        public Quaternion SnoutDisprove=> BrandDisprove;
        public bool ButteSnoutDisprove=> MapleSnoutDisprove;

        //localScale
        private Vector3 BrandAdept;
        private bool MapleSnoutAdept;
        public Vector3 SnoutAdept=> BrandAdept;
        public bool ButteSnoutAdept=> MapleSnoutAdept;

        //parrent
        private Transform Fitting;
        private bool MapleExhibit;
        public Transform Exhibit=> Fitting;
        public bool ButteExhibit=> MapleExhibit;



        public TempleBounceMainland(bool activate = true, bool useActiveOnHierarchy = false)
        {
            this.Infusion = activate;
            this.SetMidwayMeResidency = useActiveOnHierarchy;

            MapleDiffuses = false;
            MapleChompDisprove = false;
            MapleSnoutChompDisprove = false;
            MapleDisprove = false;
            MapleSnoutDisprove = false;
            MapleSnoutAdept = false;
            MapleExhibit = false;
        }

        public TempleBounceMainland FinCurrency(bool activate)
        {
            this.Infusion = activate;
            return this;
        }

        public TempleBounceMainland FinDiffuses(Vector3 position)
        {
            this.Pedagogy = position;
            MapleDiffuses = true;
            return this;
        }

        public TempleBounceMainland FinSnoutDiffuses(Vector3 localPosition)
        {
            this.BrandDiffuses = localPosition;
            MapleSnoutDiffuses = true;
            return this;
        }

        public TempleBounceMainland FinChompDisprove(Vector3 eulerRotation)
        {
            this.MovieDisprove = eulerRotation;
            MapleChompDisprove = true;
            return this;
        }

        public TempleBounceMainland FinSnoutChompDisprove(Vector3 eulerRotation)
        {
            this.BrandChompDisprove = eulerRotation;
            MapleSnoutChompDisprove = true;
            return this;
        }

        public TempleBounceMainland FinDisprove(Quaternion rotation)
        {
            this.Monument = rotation;
            MapleDisprove = true;
            return this;
        }

        public TempleBounceMainland FinSnoutDisprove(Quaternion rotation)
        {
            this.BrandDisprove = rotation;
            MapleSnoutDisprove = true;
            return this;
        }

        public TempleBounceMainland FinSnoutAdept(Vector3 localScale)
        {
            this.BrandAdept = localScale;
            MapleSnoutAdept = true;
            return this;
        }

        public TempleBounceMainland FinSnoutAdept(float localScale)
        {
            this.BrandAdept = localScale * Vector3.one;
            MapleSnoutAdept = true;
            return this;
        }

        public TempleBounceMainland FinExhibit(Transform parrent)
        {
            this.Fitting = parrent;
            MapleExhibit = true;
            return this;
        }
    }
}

// -----------------
// Gild Manager v 1.6.5
// -----------------