using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bright.Data
{
    public class Operation
    {
        public Operation()
        {
            this.Data = new OperationData();
            this.Index = 0;
            this.steppedIndexes = new Stack<int>();
        }

        public Operation(int index, int[] prevStack)
            : this()
        {
            Array.Reverse(prevStack);
            foreach (var i in prevStack)
            {
                steppedIndexes.Push(i);
            }
            this.Index = index;
        }

        public OperationData Data;

        public void SetIndex(int index)
        {
            if (this.Index == index) return;
            this.steppedIndexes.Push(this.Index);
            this.Index = index;
            if (IndexUpdated != null)
                this.IndexUpdated.Invoke();
        }

        Stack<int> steppedIndexes;
        public event Action IndexUpdated;

        public int RewindStackCount
        {
            get { return steppedIndexes.Count; }
        }

        public int[] GetRewindStack()
        {
            return steppedIndexes.ToArray();
        }

        public bool CanSetPrev()
        {
            return steppedIndexes.Count > 0;
        }

        public void SetRewind(int rew)
        {
            if (this.steppedIndexes.Count > 0)
            {
                for (int i = 1; i < rew; i++)
                {
                    this.steppedIndexes.Pop();
                }
                this.Index = this.steppedIndexes.Pop();
                if (IndexUpdated != null)
                    this.IndexUpdated.Invoke();
            }
        }

        public void SetPrev()
        {
            if (this.steppedIndexes.Count > 0)
            {
                this.Index = this.steppedIndexes.Pop();
                if (Core.Config.BehaviorConfig.ClearDestOnBack)
                    this.Data.GetElement(this.Index).Destinations.Clear();
                if (IndexUpdated != null)
                    this.IndexUpdated.Invoke();
            }
        }

        public void SetNext()
        {
            this.steppedIndexes.Push(this.Index);
            this.Index = GetNextValue();
            if (IndexUpdated != null)
                this.IndexUpdated.Invoke();
        }

        public void Reload()
        {
            if (IndexUpdated != null)
                this.IndexUpdated.Invoke();
        }

        private int GetNextValue()
        {
            int cidx = this.Index;
            do
            {
                cidx++;
                if (this.Index == this.Data.ElementsLength)
                    return this.Data.ElementsLength;
                if (this.Data.ElementsLength <= cidx)
                    cidx = 0;
                if (cidx == this.Index)
                {
                    if (this.Data.GetElement(cidx).IsGrouped)
                        return this.Data.ElementsLength;
                    else
                        return this.Index;
                }
            } while (this.Data.GetElement(cidx).IsGrouped);
            return cidx;
        }

        public GroupingElement GetCurrentElement()
        {
            if (this.Index < this.Data.ElementsLength)
                return this.Data.GetElement(this.Index);
            else
                return null;
        }

        public GroupingElement GetNextElement()
        {
            int idx = GetNextValue();
            if (idx < this.Data.ElementsLength)
                return this.Data.GetElement(idx);
            else
                return null;
        }

        public int Index { get; private set; }
    }

    public class OperationData
    {
        Dictionary<Keys, Destination> destinations;
        List<GroupingElement> elements;

        public event Action DestinationsUpdated;
        public event Action ElementsUpdated;

        private void DestUpdateInvoke()
        {
            if (DestinationsUpdated != null)
                DestinationsUpdated.Invoke();
        }
        private void ElemUpdateInvoke()
        {
            if (ElementsUpdated != null)
                ElementsUpdated.Invoke();
        }

        public OperationData()
        {
            destinations = new Dictionary<Keys, Destination>();
            elements = new List<GroupingElement>();
        }

        public bool IsDestinationExists(Keys key)
        {
            return destinations.ContainsKey(key);
        }

        public int IndexOfElement(GroupingElement elem)
        {
            return elements.IndexOf(elem);
        }

        public IEnumerable<Keys> GetDestinationsKeys()
        {
            return destinations.Keys;
        }

        public Destination GetDestination(Keys key)
        {
            return destinations[key];
        }

        public void AddDestination(Keys key, Destination dest)
        {
            if (this.destinations.ContainsKey(key))
                throw new InvalidOperationException();
            else
                this.destinations.Add(key, dest);
            DestUpdateInvoke();
        }

        public void SetDestinations(Dictionary<Keys, string> pair, bool overwrite)
        {
            foreach (var k in pair.Keys)
            {
                if (IsDestinationExists(k))
                    this.GetDestination(k).SetDestPath(pair[k], overwrite);
                else
                    this.AddDestination(k, new Destination(k, pair[k]));
            }
        }

        public void RemoveDestination(Keys key)
        {
            destinations.Remove(key);
            DestUpdateInvoke();
        }

        public void ClearDestinations()
        {
            destinations.Clear();
            DestUpdateInvoke();
        }

        public GroupingElement[] GetElementsArray()
        {
            return elements.ToArray();
        }

        public GroupingElement GetElement(int idx)
        {
            return elements[idx];
        }

        public void SetElement(int idx, GroupingElement elem)
        {
            elements[idx] = elem;
            ElemUpdateInvoke();
        }

        public void RemoveElement(int idx)
        {
            elements.RemoveAt(idx);
            ElemUpdateInvoke();
        }

        public int ElementsLength
        {
            get { return elements.Count; }
        }

        public void AddElement(GroupingElement elem)
        {
            this.elements.Add(elem);
        }

        public bool AddElement(string path)
        {
            return this.AddElement(path, false);
        }

        public bool AddElement(string path, bool silent)
        {
            if (String.IsNullOrEmpty(path))
                throw new ArgumentException("無効なパスが追加されました。", path);

            foreach (var e in this.elements)
            {
                if (e.ImageSourcePath == path)
                    return false;
            }
            this.elements.Add(new GroupingElement(path));
            if (!silent)
                ElemUpdateInvoke();
            return true;
        }

        public void AddElements(string[] paths)
        {
            foreach (var p in paths)
                AddElement(p, true);
            ElemUpdateInvoke();
        }

        public void ClearElements()
        {
            elements.Clear();
            ElemUpdateInvoke();
        }
    }
}
