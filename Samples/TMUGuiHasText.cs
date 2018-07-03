using BeatThat.Properties;
using UnityEngine;
using TMPro;

namespace BeatThat.Properties.TMPro
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class TMUGuiHasText : HasText, IDrive<TextMeshProUGUI>
	{
		
		public TextMeshProUGUI driven { get { return this._text; } }

		public override bool sendsValueObjChanged { get { return false; } }

		override public string value { get { return this._text.text; } set { this._text.text = value; } }

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

