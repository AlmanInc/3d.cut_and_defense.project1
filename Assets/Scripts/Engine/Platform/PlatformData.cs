using UnityEngine;
using System.Collections;

namespace Runner.Engine
{
	public class PlatformData 
	{
		public PlatformData () 
		{
			width = new DataItem (true);
			length = new DataItem (true);
			height = new DataItem (true);
			distanceToLength = new DataItem (true);
			distanceToWidth = new DataItem();
			distanceToHeight = new DataItem ();
			distanceNextLength = new DataItem (true);
			distanceNextWidth = new DataItem ();
			distanceNextHeight = new DataItem ();
		}

		private DataItem width;
		public DataItem Width
		{
			get { return width; }
		}

		private DataItem length;
		public DataItem Length
		{
			get { return length; }
		}

		private DataItem height;
		public DataItem Height
		{
			get { return height; }
		}

		private DataItem distanceToLength;
		public DataItem DistanceToLength
		{
			get { return distanceToLength; }
		}

		private DataItem distanceToWidth;
		public DataItem DistanceToWidth
		{
			get { return distanceToWidth; }
		}

		private DataItem distanceToHeight;
		public DataItem DistanceToHeight
		{
			get { return distanceToHeight; }
		}

		private DataItem distanceNextLength;
		public DataItem DistanceNextLength
		{
			get { return distanceNextLength; }
		}
		
		private DataItem distanceNextWidth;
		public DataItem DistanceNextWidth
		{
			get { return distanceNextWidth; }
		}
		
		private DataItem distanceNextHeight;
		public DataItem DistanceNextHeight
		{
			get { return distanceNextHeight; }
		}
	}
}
