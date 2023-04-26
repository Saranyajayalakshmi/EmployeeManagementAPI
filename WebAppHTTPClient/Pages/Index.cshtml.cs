using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace WebAppHTTPClient.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public string RequestMethod { get; set; }

        [BindProperty]
        public string Data { get; set; }
        
        [BindProperty]
        public string BaseUrl { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            string responseContent = "[]";
            try
            {
                Uri baseURL = new Uri(BaseUrl);

                HttpClient client = new HttpClient();

                // Any parameters? Get value, and then add to the client 
                


                if (RequestMethod.Equals("GET")) // GetAllData
                {
                    HttpResponseMessage response = await client.GetAsync(baseURL.ToString());

                    if (response.IsSuccessStatusCode)
                    {
                        responseContent = await response.Content.ReadAsStringAsync();
                    }
                }
                else if (RequestMethod.Equals("GETBYID")) //Get DataByID
                {
                    HttpResponseMessage response = await client.GetAsync(baseURL.ToString());

                    if (response.IsSuccessStatusCode)
                    {
                        responseContent = await response.Content.ReadAsStringAsync();
                    }
                   
                }


                else if (RequestMethod.Equals("POST")) // Add the Data
                {
                    JObject jObject = JObject.Parse(Data);

                    var stringContent = new StringContent(jObject.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(baseURL.ToString(), stringContent);

                    if (response.IsSuccessStatusCode)
                    {
                        responseContent = await response.Content.ReadAsStringAsync();

                    }
                }
                else if (RequestMethod.Equals("PUT")) //update the Data
                {
                    JObject jObject = JObject.Parse(Data);

                    var stringContent = new StringContent(jObject.ToString(), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(baseURL.ToString(), stringContent);

                    if (response.IsSuccessStatusCode)
                    {
                        responseContent = await response.Content.ReadAsStringAsync();
                    }

                }
                else if (RequestMethod.Equals("DELETE")) //Delete the Data
                {

                    HttpResponseMessage response = await client.DeleteAsync(baseURL.ToString());

                    if (response.IsSuccessStatusCode)
                    {
                        responseContent = await response.Content.ReadAsStringAsync();

                    }
                   return RedirectToPage("Error");
                }

                return RedirectToPage("Response", new { result = responseContent });

            }
            catch (ArgumentNullException uex)
            {
                return RedirectToPage("Error", new { msg = uex.Message + " | URL missing or invalid." });
            }
            catch (JsonReaderException jex)
            {
                return RedirectToPage("Error", new { msg = jex.Message + " | Json data could not be read." });
            }
            catch (Exception ex)
            {
                return RedirectToPage("Error", new { msg = ex.Message + " | Are you missing some Json keys and values? Please check your Json data." });
            }
        }
    }
}