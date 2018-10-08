using Newtonsoft.Json.Linq;
using System;

namespace SeldatMRMS.Model
{
    public class CheckOutPoint
	{
		public struct Properties
		{
			public double X, Y;
			public double X_model, Y_model;
			public double LengthValue, CostValue;
			public double Width, Height;
			public String label;
			public String key;
			public int idnum;
		}
		public Properties properties;
		public CheckOutPoint(String key)
		{
			properties.key = key;
		}
		public JObject createJsonstring()
		{
			dynamic product = new JObject();
			product.Name = properties.key;
			product.Label = properties.label;
			product.Width = properties.Width;
			product.Height = properties.Height;
			product.posX = properties.X;
			product.posY = properties.Y;
			return product;
		}
	}
}
