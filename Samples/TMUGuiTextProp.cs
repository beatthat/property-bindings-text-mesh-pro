using BeatThat.Properties;
using UnityEngine;
using TMPro;

namespace BeatThat.Properties.TMPro
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class TMUGuiTextProp : TextProp
	{
		protected override string GetValue ()
		{
			return this._text.text;
		}

		protected override void _SetValue (string s)
		{
			this._text.text = s; 
		}

		public override bool sendsValueObjChanged { get { return true; } }
				
		public TextMeshProUGUI _text
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

