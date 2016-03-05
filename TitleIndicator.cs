
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using RecyclerViewFastScroller;
using Android.Graphics;

namespace RecyclerDemo{
	public class TitleIndicator : SectionTitleIndicator{
		public TitleIndicator(Context context) :
			this(context, null, 0){
			
		}

		public TitleIndicator(Context context, IAttributeSet attrs) :
			this(context, attrs, 0){
			
		}

		public TitleIndicator(Context context, IAttributeSet attrs, int defStyle) :
			base(context, attrs, defStyle){
			
		}

		public override void SetSection(object obj){
			var str = (Java.Lang.String)obj;
			// Example of using a single character
			SetTitleText(str.ToString());

			// Example of using a longer string
			// setTitleText(colorGroup.getName());

			//SetIndicatorTextColor(Color.Aqua);
		}

	}
}

