using BeatThat.Properties;
using UnityEngine;
using TMPro;

namespace BeatThat.Properties.TMPro
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class TMUGuiHasColor : HasColor
	{
		public TextMeshProUGUI m_text;


		override public Color value
		{
			get {
				return this._text.color;
			}
			set {
				this._text.color = value;
			}
		}

		public override bool sendsValueObjChanged { get { return false; } }
		public override object valueObj { get { return this.value; } }

//		#region implemented abstract members of HasColor
//		override protected Color GetColor() 
//		{
//			return this._text.color;
//		}
//
//		override protected void _SetColor(Color c)
//		{
//			this._text.color = c;
//		}
//		#endregion

		void Reset()
		{
			if(m_text == null) {
				m_text = GetComponent<TextMeshProUGUI>();
			}
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

	}
}

