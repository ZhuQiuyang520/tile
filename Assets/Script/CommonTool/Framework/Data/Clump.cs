using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zeta_framework
{
    public class Clump
    {
        public Clump()
        {
            _Hike = new LevelData();
        }

        public class LevelData
        {
            public int Swear;     // 过关得分
            public int StealVisit;  // 关卡开始次数
            public int ImagistVisit;   // 过关成功次数
        }

        private LevelData _Hike;
        public LevelData Hike        {
            get
            {
                return _Hike;
            }
        }

        public int Early        {
            get
            {
                return _Hike.Swear;
            }
        }


        public void LayHave(JsonData _data)
        {
            if (_data != null)
            {
                this._Hike = JsonMapper.ToObject<LevelData>(_data.ToJson());
            }
            else
            {
                this._Hike = new();
            }
        }

        public void BurEarly(int num)
        {
            _Hike.Swear += num;
            HaveMimetic.Instance.LuckHave();
        }

        public void BurCrampVisit()
        {
            _Hike.StealVisit++;
            HaveMimetic.Instance.LuckHave();
        }

        public void BurIncludeVisit()
        {
            _Hike.ImagistVisit++;
            HaveMimetic.Instance.LuckHave();
        }
    }
}