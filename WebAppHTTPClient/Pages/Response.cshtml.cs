using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppHTTPClient.Pages
{
    public class ResponseModel : PageModel
    {
        public string ResponseBody { get; set; }

        public void OnGet(string result)
        {
            ResponseBody = result;
        }
        
    }
}
