using BeatThat.TransformPathExt;
using BeatThat.Bindings;
using UnityEngine;
using UnityEngine.Events;


namespace BeatThat.Properties.TMPro
{
    public class ResizeToPreferredWidthOfText : BindingBehaviour
	{
		public TMUGuiHasText m_hasText;

		private TMUGuiHasText hasText { get { return m_hasText != null? m_hasText: (m_hasText = GetComponentInChildren<TMUGuiHasText>()); } }

		override protected void BindAll()
		{
			var ht = this.hasText;
			if(ht == null) {
				Debug.LogWarning("[" + Time.frameCount + "][" + this.Path() + "] cannot find required component of type " + typeof(TMUGuiHasText));
				return;
			}

			Bind(ht.onValueObjChanged, this.textChangedAction);
		}

		private bool didStart { get; set; }
		void Start()
		{
			this.didStart = true;
			UpdateWidth();
		}

		void OnEnable()
		{
			UpdateWidth();
		}

		private void UpdateWidth()
		{
			if(string.IsNullOrEmpty(hasText.value)) {
				return;
			}

			var rt = GetComponent<RectTransform>();
			rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, hasText.driven.GetPreferredValues().x);
		}

		private void OnTextChanged()
		{
			UpdateWidth();
		}
		private UnityAction textChangedAction { get { return m_textChangedAction?? (m_textChangedAction = this.OnTextChanged); } }
		private UnityAction m_textChangedAction;
	}
}



