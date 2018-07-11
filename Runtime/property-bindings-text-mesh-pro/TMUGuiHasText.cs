using BeatThat.TransformPathExt;
using TMPro;
using UnityEngine;

namespace BeatThat.Properties.TMPro
{
    [RequireComponent(typeof(TextMeshProUGUI))]
	public class TMUGuiHasText : HasText, IDrive<TextMeshProUGUI>
	{
		
		public TextMeshProUGUI driven { get { return this._text; } }

		public override bool sendsValueObjChanged { get { return false; } }

		override public string value
        { 
            get {
                var t = this._text;
                if(t == null) {
#if UNITY_EDITOR || DEBUG_UNSTRIP
                    Debug.LogError("[" + this.Path() + "] missing required component " + typeof(TextMeshProUGUI).Name);
#endif
                    return null;
                }
                return t.text;
            }
            set { 
                var t = this._text;
                if (t == null)
                {
#if UNITY_EDITOR || DEBUG_UNSTRIP
                    Debug.LogError("[" + this.Path() + "] missing required component " + typeof(TextMeshProUGUI).Name);
#endif
                    return;
                }
                t.text = value; 
            } 
        }

		public object GetDrivenObject ()
		{
			return this._text;
		}

		public bool ClearDriven ()
		{
			m_text = null;
			return true;
		}

		private TextMeshProUGUI _text
		{
			get {
				if(m_text == null) {
					m_text = GetComponent<TextMeshProUGUI>();
				}
                return m_text;
			}
		}
	
		private TextMeshProUGUI m_text;
	}
}

