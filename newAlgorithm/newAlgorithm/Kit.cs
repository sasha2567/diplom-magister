﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newAlgorithm
{
    class Kit
    {
        private readonly List<int> _composition;
        private List<int> _readyComposition;
        private int _time;
        private int _compositionTime;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="composition"></param>
        public Kit(List<int> composition, int compositionTime)
        {
            _composition = composition;
            _compositionTime = compositionTime;
            _readyComposition = new List<int>();
            for (int i = 0; i < composition.Count; i++)
            {
                _readyComposition.Add(0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="type"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public SheduleElement AddBatch(int batch, int type, List<int> time)
        {
            if (_composition[type] == _readyComposition[type]) {
                return new SheduleElement(batch, type, time);
            }
            var difference = 0;
            if (batch >= _composition[type] - _readyComposition[type])
            {
                difference = batch - _composition[type];
                _readyComposition[type] = _composition[type];
                _time = time[time.Count - 1];
            }
            else
            {
                _readyComposition[type] += batch;
                _time = time[time.Count - 1];
            }
            return new SheduleElement(difference, type, time);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsSetAllComposition()
        {
            for(int i = 0; i < _composition.Count; i++)
            {
                if (_readyComposition[i] != _composition[i]) return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetTime()
        {
            return this._time;
        }
    }
}