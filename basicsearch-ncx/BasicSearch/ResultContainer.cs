using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCheatX.Core;
using NetCheatX.Core.Interfaces;
using NetCheatX.Core.UI;

namespace BasicSearch
{
    public class ResultContainer<T> : List<T> where T : ISearchResult
    {

        #region Public Types

        public enum ResultEventType
        {
            Created,
            Removed,
            Changed
        }

        public struct ResultEventArgs
        {
            public ResultEventType Type;
            public ISearchResult item;
            public ISearchResult newitem;
        }

        public delegate void ResultEventHandler(IPluginHost host, List<ResultEventArgs> e);
        public delegate void ResultEventHandlerSingle(IPluginHost host, ResultEventArgs e);

        #endregion


        private List<T> _list = new List<T>();


        public event ResultEventHandlerSingle ResultUpdated;

        public IEnumerable<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            return _list.Select(selector);
        }

        public IEnumerable<T> Where(Func<T, bool> predicate)
        {
            return _list.Where(predicate);
        }

        public IEnumerable<T> Where(Func<T, int, bool> predicate)
        {
            return _list.Where(predicate);
        }

        public new List<T>.Enumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public new void Add(T item)
        {
            _list.Add(item);

            if (ResultUpdated != null)
            {
                ResultEventArgs args = new ResultEventArgs();
                args.item = item;
                args.Type = ResultEventType.Created;

                ResultUpdated.Invoke(null, args);
            }
        }

        public new void Clear()
        {
            if (ResultUpdated != null)
            {
                foreach (T item in _list)
                {
                    ResultEventArgs args = new ResultEventArgs();
                    args.item = item;
                    args.Type = ResultEventType.Removed;
                    ResultUpdated.Invoke(null, args);
                }
            }

            _list.Clear();
        }

        public new bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public new void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public new bool Remove(T item)
        {
            bool ret = _list.Remove(item);

            if (ResultUpdated != null && ret)
            {
                ResultEventArgs args = new ResultEventArgs();
                args.item = item;
                args.Type = ResultEventType.Removed;
                ResultUpdated.Invoke(null, args);
            }

            return ret;
        }

        public new int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public new void Insert(int index, T item)
        {
            _list.Insert(index, item);

            if (ResultUpdated != null)
            {
                ResultEventArgs args = new ResultEventArgs();
                args.item = item;
                args.Type = ResultEventType.Created;
                ResultUpdated.Invoke(null, args);
            }
        }

        public new void RemoveAt(int index)
        {
            if (ResultUpdated != null && index < _list.Count && index >= 0)
            {
                ResultEventArgs args = new ResultEventArgs();
                args.item = _list[index];
                args.Type = ResultEventType.Removed;
                ResultUpdated.Invoke(null, args);
            }

            _list.RemoveAt(index);
        }

        public new T this[int index]
        {
            get { return _list[index]; }
            set
            {
                if (ResultUpdated != null)
                {
                    ResultEventArgs args = new ResultEventArgs();
                    args.item = _list[index];
                    args.newitem = value;
                    args.Type = ResultEventType.Changed;
                    ResultUpdated.Invoke(null, args);
                }

                _list[index] = value;
            }
        }

    }
}
