using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Mobile;

namespace QRScanner.Services
{
	public class QRScanningService : IQRScanningService
	{
		public async Task<string> ScanAsync()
		{
			var optionsDefault = new MobileBarcodeScanningOptions();
			var optionsCustom = new MobileBarcodeScanningOptions();
			var scanner = new MobileBarcodeScanner()
			{
				TopText = "Scan the QR Code",
				BottomText = "Please wait...",
				CancelButtonText = "Cancel"
			};
			var scanResult = await scanner.Scan(optionsCustom);
			return scanResult.Text;
		}
	}
}