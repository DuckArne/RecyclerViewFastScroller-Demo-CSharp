using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using RecyclerViewFastScroller;
using Android.Graphics;

namespace RecyclerDemo{
	[Activity(Label = "RecyclerDemo", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity{

		RecyclerView recyclerView;
		RecyclerView.Adapter adapter;



		protected override void OnCreate(Bundle bundle){
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			recyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view);
		

		

			recyclerView.HasFixedSize = true;



			// specify an adapter
			adapter = new MyAdapter(new [] {
					"Brasil",
					"Mexico",
					"United States",
					"Canada",
					"Katrineholm",
					"Julle",
					"Kalle",
					"Drissen",
					"Backen",
					"Krumpen",
					"Björnen",
					"Fågeln",
					"Struten",
					"Apan Ola",
					"Mr Fantastic",
					"Roboto", "Kloss", "Fred", "Klaus", "Mr Herman", "Brownie", "Grimm", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle", "Julle"
				});



			VerticalRecyclerViewFastScroller fastScroller = (VerticalRecyclerViewFastScroller)FindViewById(Resource.Id.fast_scroller);
			SectionTitleIndicator sectionTitleIndicator =
				(SectionTitleIndicator)FindViewById(Resource.Id.fast_scroller_section_title_indicator);
			// Connect the recycler to the scroller (to let the scroller scroll the list)
			fastScroller.SetRecyclerView(recyclerView);

			// Connect the scroller to the recycler (to let the recycler scroll the scroller's handle)
			recyclerView.AddOnScrollListener(fastScroller.GetOnScrollListener());

			SetRecyclerViewLayoutManager(recyclerView);
			recyclerView.SetAdapter(adapter);
			fastScroller.SetSectionIndicator(sectionTitleIndicator);
		}

		/**
     * Set RecyclerView's LayoutManager
     */
		public void SetRecyclerViewLayoutManager(RecyclerView recyclerView){
			int scrollPosition = 0;

			// If a layout manager has already been set, get current scroll position.
			if(recyclerView.GetLayoutManager() != null)
			{
				scrollPosition =
					((LinearLayoutManager)recyclerView.GetLayoutManager()).FindFirstCompletelyVisibleItemPosition();
			}

			LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this);

			recyclerView.SetLayoutManager(linearLayoutManager);
			recyclerView.ScrollToPosition(scrollPosition);
		}
	}

	public class MyAdapter : RecyclerView.Adapter,ISectionIndexer{
		string[] items;

		public MyAdapter(string[] data){
			items = data;
		}

		// Create new views (invoked by the layout manager)
		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType){	
			// set the view's size, margins, paddings and layout parameters
			var tv = new TextView(parent.Context);
			tv.SetHeight(200);
			tv.Text = "";

			var vh = new MyViewHolder(tv);
			return vh;
		}

		// Replace the contents of a view (invoked by the layout manager)
		public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position){
			var item = items[position];

			// Replace the contents of the view with that element
			var holder = viewHolder as MyViewHolder;
			holder.TextView.Text = item;
		}

		public override int ItemCount { get { return items.Length; } }

		public int GetPositionForSection(int sectionIndex){
			return 0;
		}

		public int GetSectionForPosition(int position){
			if(position >= items.Length)
			{
				position = items.Length - 1;
			}
	
			return position;
		}

		public Java.Lang.Object[] GetSections(){
			return new Java.Util.ArrayList(items).ToArray();
		}
	}

	public class MyViewHolder : RecyclerView.ViewHolder{
		public TextView TextView { get; set; }

		public MyViewHolder(TextView v) : base(v){
			TextView = v;
		}
	}
}



