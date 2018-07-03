using BeatThat.Properties;
using UnityEngine;
using TMPro;


namespace BeatThat.Properties.TMPro
{
	[RequireComponent(typeof(TMP_InputField))]
	public class TMUGuiHasTextInput : HasTextInput 
	{
		public override void ActivateInput ()
		{
//			this.inputField.Ac();
		}
			
		public TMP_InputField m_inputField;

		override protected string GetValue() { return this.inputField.text; }
		override protected void _SetValue(string s) { this.inputField.text = s; }

		override protected void Start()
		{
			base.Start ();
			this.inputField.onValueChanged.AddListener(v => SendValueChanged(this.inputField.text));
			this.inputField.onSubmit.AddListener (v => this.onSubmit.Invoke (this.inputField.text));
		}

		public TMP_InputField inputField
		{
			get {
				if(m_inputField == null) {
					m_inputField = GetComponent<TMP_InputField>();
				}
				return m_inputField;
			}
		}

	}
}

