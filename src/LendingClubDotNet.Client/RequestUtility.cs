using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace LendingClubDotNet.Client
{
    public static class RequestUtility
	{
		public static TResponse ExecuteGetRequest<TResponse>(string url, string authorizationToken)
		{
			string jsonResponse;

			using(var client = new HttpClient())
			{
				client.DefaultRequestHeaders
					.Accept
					.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", (authorizationToken));


				var response = client.GetAsync(url).Result;

				if(!response.IsSuccessStatusCode)
				{
					throw new InvalidOperationException(response.StatusCode.ToString());					
				}

				var content = response.Content;
				jsonResponse = content.ReadAsStringAsync().Result;
			}

			return JsonConvert.DeserializeObject<TResponse>(jsonResponse);
		}

		public static TResponse ExecutePostRequest<TRequest, TResponse>(TRequest requestValue, string url, string authorizationToken)
		{
            //TODO needs testing

            string jsonResponse;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", (authorizationToken));

                string jsonData = JsonConvert.SerializeObject(requestValue);

                var response = client.PostAsync(url, new StringContent(jsonData)).Result;

                if(!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
				var content = response.Content;
				jsonResponse = content.ReadAsStringAsync().Result;
			}

			return JsonConvert.DeserializeObject<TResponse>(jsonResponse);
		}
	}
}
