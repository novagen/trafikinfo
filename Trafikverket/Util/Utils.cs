using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Trafikverket.Transfer;

namespace Trafikverket.Util
{
	public static class Utils
	{
		public static string GetCountyName(int id)
		{
			if (Enum.IsDefined(typeof(County), id))
			{
				var county = (County)id;
				return county.GetEnumDescription();
			}

			return null;
		}

		public static List<string> GetCountyNames(int[] ids)
		{
			var result = new List<string>();

			foreach (var i in ids)
			{
				var name = GetCountyName(i);

				if (!string.IsNullOrWhiteSpace(name))
				{
					result.Add(name);
				}
			}

			return result;
		}

		public static Response GetErrorResponse(WebException ex)
		{
			var stream = ex?.Response?.GetResponseStream();

			if (stream == null)
			{
				return null;
			}

			using (var reader = new StreamReader(stream))
			{
				var result = reader.ReadToEnd();

				try
				{
					var data = JsonConvert.DeserializeObject<QueryResponse>(result);
					return data.Response;
				}
				catch (Exception e)
				{
					return new Response { Result = new Result[1] { new Result { Error = new Error { Message = ex != null ? ex.Message : e.Message } } } };
				}
			}
		}

		public static string ToUtcString(this DateTime date)
		{
			return date.ToUniversalTime().ToString("s") + "Z";
		}
	}
}