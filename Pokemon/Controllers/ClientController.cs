using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Dto;
using Pokemon.Models;

namespace Pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpClientTesterController(IHttpClientFactory httpClientFactory) : ControllerBase
    {
        [HttpGet("{country}")]
        public async Task<IActionResult> GetList([FromRoute] string country)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://universities.hipolabs.com/");
            var response = await client.GetAsync($"search?country={country}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("joke")]
        public async Task<IActionResult> GetListV2()
        {
            var client = httpClientFactory.CreateClient("jokes");
            var response = await client.GetAsync($"api/Author");
            var result = await response.Content.ReadFromJsonAsync<AuthorDto>();
            Console.Write(result);
            return Ok(result);
        }
    }
}
