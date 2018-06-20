using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newAlgorithm
{
    class Kit : IComparable
    {
        private readonly List<int> _composition;
        private List<int> _readyComposition;
        private int _time;
        private int _compositionTime;
        private double _criterion;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="composition"></param>
        public Kit(List<int> composition, int compositionTime)
        {
            _composition = composition;
            _compositionTime = compositionTime;
            _readyComposition = new List<int>();
            _criterion = 0;
            var max = 0;
            var min = 100000;
            foreach (var elem in composition)
            {
                _readyComposition.Add(0);
                if (elem > max)
                {
                    max = elem;
                }
                if (elem < min)
                {
                    min = elem;
                }
            }
            _criterion = (max - min) / max;
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
        /// Проверка заполнености комплекта
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
        /// Получение времени формирования комплекта
        /// </summary>
        /// <returns></returns>
        public int GetTime()
        {
            return this._time;
        }

        public int GetCompositionTime()
        {
            return _compositionTime;
        }

        /// <summary>
        /// Получение критерия комплекта
        /// </summary>
        /// <returns></returns>
        public double GetCriterion()
        {
            return _criterion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kit"></param>
        /// <returns></returns>
        public int CompareTo(object kit)
        {
            return _criterion > ((Kit)kit)._criterion ? 1 : _criterion < ((Kit)kit)._criterion ? -1 : 0;
        }
    }
}
