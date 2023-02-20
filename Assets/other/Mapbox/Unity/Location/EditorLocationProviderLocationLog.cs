namespace Mapbox.Unity.Location
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.IO;
	using Mapbox.Unity.Utilities;
	using Mapbox.Utils;
	using UnityEngine;

	/// <summary>
	/// <para>
	/// The EditorLocationProvider is responsible for providing mock location data via log file collected with the 'LocationProvider' scene
	/// </para>
	/// </summary>
	public class EditorLocationProviderLocationLog : AbstractEditorLocationProvider
	{


		/// <summary>
		/// The mock "latitude, longitude" location, respresented with a string.
		/// You can search for a place using the embedded "Search" button in the inspector.
		/// This value can be changed at runtime in the inspector.
		/// </summary>
		[SerializeField]
		private TextAsset _locationLogFile;


		private LocationLogReader _logReader;
		private IEnumerator<Location> _locationEnumerator;


#if UNITY_EDITOR
		protected override void Awake()
		{
			base.Awake();
			_logReader = new LocationLogReader(_locationLogFile.bytes);
			_locationEnumerator = _logReader.GetLocations();
		}
#endif


		private void OnDestroy()
		{
			if (null != _locationEnumerator)
			{
				_locationEnumerator.Dispose();
				_locationEnumerator = null;
			}
			if (null != _logReader)
			{
				_logReader.Dispose();
				_logReader = null;
			}
		}

// public double movemement_speed;
		public static Vector2d current_player_latlong = new Vector2d(42.27956272028746, -83.7482328924759);
		public double movement_speed = 0.000004;
		public void Update()
        {
			if (Input.GetKey(KeyCode.UpArrow))
				current_player_latlong += new Vector2d(movement_speed, 0.0);
			if (Input.GetKey(KeyCode.DownArrow))
				current_player_latlong += new Vector2d(-movement_speed, 0.0);
			if (Input.GetKey(KeyCode.RightArrow))
				current_player_latlong += new Vector2d(0.0, movement_speed);
			if (Input.GetKey(KeyCode.LeftArrow))
				current_player_latlong += new Vector2d(0.0, -movement_speed);

			_currentLocation.LatitudeLongitude = current_player_latlong;
		}


        protected override void SetLocation()
		{
			/*if (null == _locationEnumerator) { return; }

			// no need to check if 'MoveNext()' returns false as LocationLogReader loops through log file
			_locationEnumerator.MoveNext();
			_currentLocation = _locationEnumerator.Current;*/
		}
	}
}
