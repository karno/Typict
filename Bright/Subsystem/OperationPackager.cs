using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.IO;


namespace Bright.Subsystem
{
    public static class OperationPackager
    {
        public static void Save(Data.Operation oper, string dest)
        {
            var dat = new Operate();
            dat.Index = oper.Index;
            dat.RewindArray = oper.GetRewindStack();
            List<Operate.DestData> dd = new List<Operate.DestData>();
            foreach (var d in oper.Data.GetDestinationsKeys())
            {
                dd.Add(new Operate.DestData() { LinkKey = d, Dest = oper.Data.GetDestination(d).DestPath });
            }
            dat.DestArray = dd.ToArray();
            List<Operate.Element> el = new List<Operate.Element>();
            foreach (var e in oper.Data.GetElementsArray())
            {
                var ds = from ar in e.Destinations
                         select ar.Destination;
                el.Add(new Operate.Element() { Dest = ds.ToArray<string>(), Source = e.ImageSourcePath, DistributionMode = e.DistributionMode });
            }
            dat.ElementArray = el.ToArray();
            var bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(dest, FileMode.Create, FileAccess.ReadWrite))
            {
                bf.Serialize(fs, dat);
            }
        }

        public static Data.Operation Load(string source)
        {
            Operate op = null;
            var bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(source, FileMode.Open, FileAccess.Read))
            {
                op = bf.Deserialize(fs) as Operate;
            }
            var newop = new Data.Operation(op.Index, op.RewindArray);
            foreach (var dest in op.DestArray)
            {
                newop.Data.AddDestination(dest.LinkKey, new Bright.Data.Destination(dest.LinkKey, dest.Dest));
            }
            foreach (var elem in op.ElementArray)
            {
                var ne = new Bright.Data.GroupingElement(elem.Source) { DistributionMode = elem.DistributionMode };
                foreach (var dpath in elem.Dest)
                    ne.Destinations.Add(new Bright.Data.GroupingElement.DestData(dpath));
                newop.Data.AddElement(ne);
            }
            return newop;
        }

        private static bool Backupping = false;
        public static void DoBackup()
        {
            if (Core.CurrentOperation != null && !Backupping)
            {
                Backupping = true;
                Action<Data.Operation, string> saver = new Action<Bright.Data.Operation, string>(Save);
                saver.BeginInvoke(Core.CurrentOperation, Define.AutoBackupFile,
                    (iar) =>
                    {
                        ((Action<Data.Operation, string>)iar.AsyncState).EndInvoke(iar);
                        Backupping = false;
                    }, saver);
            }
        }

        public static void RemoveBackup()
        {
            if (File.Exists(Define.AutoBackupFile))
                File.Delete(Define.AutoBackupFile);
        }

        [Serializable]
        public class Operate
        {
            public int Index { get; set; }
            public int[] RewindArray { get; set; }
            public DestData[] DestArray { get; set; }
            [Serializable]
            public class DestData
            {
                public string Dest { get; set; }
                public Keys LinkKey { get; set; }
            }
            public Element[] ElementArray { get; set; }
            [Serializable]
            public class Element
            {
                public string Source { get; set; }
                public string[] Dest { get; set; }
                public Data.GroupingElement.DistributionModes DistributionMode { get; set; }
            }
        }
    }
}
