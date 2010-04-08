using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bright
{
    public static class Core
    {
        public static readonly Cores.Config Config = Cores.Config.LoadConfig();

        private static Data.Operation curOp = null;
        public static Data.Operation CurrentOperation
        {
            get { return curOp; }
            set
            {
                curOp = value;
                if (CurrentOperationUpdated != null)
                    CurrentOperationUpdated.Invoke();
            }
        }

        public static volatile bool IsOperationCreated = false;
        public static Data.GroupingElement.DistributionModes DistributionMode = Bright.Data.GroupingElement.DistributionModes.Copy;

        public static event Action CurrentOperationUpdated;

        public static event Action<int> ImagePrefetchCompleted;
        public static void InvokePrefetched(int index)
        {
            if (ImagePrefetchCompleted != null)
                ImagePrefetchCompleted.Invoke(index);
        }

        public static event Action<Keys> Distributed;
        public static void InvokeDistrubited(Keys k)
        {
            if (Distributed != null)
                Distributed.Invoke(k);
        }
    }
}
