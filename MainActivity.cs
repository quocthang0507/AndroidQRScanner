using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using QRScanner.Services;
using ZXing.Mobile;

namespace QRScanner
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
		private Button btnClick;
		private TextView txtBarcode;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.activity_main);

			btnClick = FindViewById<Button>(Resource.Id.btnScan);
			txtBarcode = FindViewById<TextView>(Resource.Id.txtBarcode);

			btnClick.Click += btnScan_Clicked;

			MobileBarcodeScanner.Initialize(Application);
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		private async void btnScan_Clicked(object sender, EventArgs e)
		{
			try
			{
				var scanner = new QRScanningService();
				var result = await scanner.ScanAsync();
				if (result != null)
				{
					txtBarcode.Text = result;
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}
	}
}