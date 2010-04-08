using System;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.ComponentModel;

namespace K
{
    public partial class Data
    {
        /// <summary>
        /// XML�V���A���C�Y�\�ȃt�H���g
        /// </summary>
        public class XFont
        {
            /// <summary>
            /// �t�H���g
            /// </summary>
            [XmlIgnore()]
            public Font Value;

            [EditorBrowsable(EditorBrowsableState.Never)]
            [XmlAttribute("Font")]
            public String FontString
            {
                get
                {
                    FontConverter fc = new FontConverter();
                    return fc.ConvertToString(Value);
                }
                set
                {
                    FontConverter fc = new FontConverter();
                    Value = (Font)fc.ConvertFromString(value);
                }
            }

            public XFont() { }
            public XFont(Font f)
            {
                Value = f;
            }
        }
    }
}
