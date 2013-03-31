//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using MonoTouch.Foundation;
//using MonoTouch.UIKit;
//using Xamarin.Geolocation;

//namespace QuickWeather.Core.iOS
//{
//    public class GeoLocator
//    {
//        private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
//        private readonly Geolocator _geolocator;
//        private CancellationTokenSource _cancelSource;

//        public GeoLocator(int desiredAccuracy)
//        {
//            _geolocator = new Geolocator {DesiredAccuracy = desiredAccuracy};
//            _geolocator.PositionError += OnListeningError;
//            _geolocator.PositionChanged += OnPositionChanged;
//        }

//        public void GetPosition()
//        {
//            _cancelSource = new CancellationTokenSource();

//            _geolocator.GetPositionAsync(timeout: 10000, cancelToken: _cancelSource.Token, includeHeading: true)
//                .ContinueWith(t =>
//                    {
//                        if (t.IsFaulted)
//                            PositionStatus.Text = ((GeolocationException) t.Exception.InnerException).Error.ToString();
//                        else if (t.IsCanceled)
//                            PositionStatus.Text = "Canceled";
//                        else
//                        {
//                            PositionStatus.Text = t.Result.Timestamp.ToString("G");
//                            PositionLatitude.Text = "La: " + t.Result.Latitude.ToString("N4");
//                            PositionLongitude.Text = "Lo: " + t.Result.Longitude.ToString("N4");
//                        }

//                    }, _scheduler);
//        }

//        partial void CancelPosition(NSObject sender)
//        {
//            var cancel = _cancelSource;
//            if (cancel != null)
//                cancel.Cancel();
//        }

//        partial void ToggleListening(NSObject sender)
//        {
//            Setup();

//            if (!_geolocator.IsListening)
//            {
//                ToggleListeningButton.SetTitle("Stop listening", UIControlState.Normal);

//                _geolocator.StartListening(minTime: 30000, minDistance: 0, includeHeading: true);
//            }
//            else
//            {
//                ToggleListeningButton.SetTitle("Start listening", UIControlState.Normal);
//                _geolocator.StopListening();
//            }
//        }

//        private void OnListeningError(object sender, PositionErrorEventArgs e)
//        {
//            BeginInvokeOnMainThread(() =>
//                {
//                    ListenStatus.Text = e.Error.ToString();
//                });
//        }

//        private void OnPositionChanged(object sender, PositionEventArgs e)
//        {
//            BeginInvokeOnMainThread(() =>
//                {
//                    ListenStatus.Text = e.Position.Timestamp.ToString("G");
//                    ListenLatitude.Text = "La: " + e.Position.Latitude.ToString("N4");
//                    ListenLongitude.Text = "Lo: " + e.Position.Longitude.ToString("N4");
//                });
//        }
//    }
//}
