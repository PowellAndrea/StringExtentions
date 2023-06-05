using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;


namespace TestChat1
{
    //[Route("api/[controller]")]
    [ApiController]
    public class GPT_control : ControllerBase
    {
        [HttpGet]
        [Route("UseChatGPT")]

        public async Task<IActionResult> UseChatGPT(string query)
        {
            var openai = new OpenAIAPI("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");
            CompletionRequest completionRequest= new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;

            var completions = openai.Completions.CreateCompletionAsync(completionRequest);

            string OutPutResult = null;

            foreach (var completion in completions.Result.Completions)
            {
                OutPutResult += completion.Text;
            }
            return Ok(OutPutResult);
        }
    }
}
