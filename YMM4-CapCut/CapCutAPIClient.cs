using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

class CapCutAPIClient {
    public static async Task<byte[]> TalkAsync(string inputtext, string inputtype, int inputpitch, int inputspeed, int inputvolume)
    {
        using (HttpClient client = new HttpClient())
        {
            string baseUrl = "http://localhost:8080/v1/";
            string url = BuildUrl(baseUrl, "synthesize", new
            {
                text = inputtext,
                type = inputtype,
                pitch = inputpitch,
                speed = inputspeed,
                volume = inputvolume,
                method = "buffer"
            });

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    // 成功した場合、レスポンスボディをバイト配列として返す
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    // エラーの場合、ステータスコードとエラーメッセージを含む例外をスロー
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error: {response.StatusCode}\n{errorResponse}");
                }
            }
            catch (HttpRequestException e)
            {
                throw new Exception($"Request error: {e.Message}");
            }
        }
    }

    private static string BuildUrl(string baseUrl, string endpoint, object queryParams)
    {
        var queryString = string.Join("&", queryParams.GetType().GetProperties()
            .Select(p => $"{p.Name}={Uri.EscapeDataString(p.GetValue(queryParams)?.ToString() ?? "")}"));
        return $"{baseUrl}{endpoint}?{queryString}";
    }
}
