using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using valenlog.Application.DTOs.Externals;
using valenlog.Application.Interfaces;
using valenlog.Domain.Entities;
using valenlog.Infrastructure.Data;
using valenlog.Infrastructure.GraphQL.Queries;
namespace valenlog.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ValenlogDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        public BlogRepository(ValenlogDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<PostHeaderDTO>> GetPostHeadersAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("HashNode");
            var token = "f36dfbe8-f4da-44bf-a8e5-24dbb4517fd0";
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var query = Queries.GetMyPosts;

            string username = "ValenBan";
            int page = 1;
            int pageSize = 20;
            var request = new
            {
                query,
                variables = new { username, page, pageSize }
            };

            var posts = new List<PostHeaderDTO>();

            try
            {
                var response = await httpClient.PostAsJsonAsync("https://gql.hashnode.com/", request);
                response.EnsureSuccessStatusCode();

                // 1. Guardamos el JSON crudo en una variable para que lo puedas inspeccionar
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Poné un punto de interrupción (breakpoint) en la línea de arriba para ver el contenido de 'jsonResponse'.

                // 2. Intentamos procesar el JSON de forma segura
                var jsonNode = System.Text.Json.Nodes.JsonNode.Parse(jsonResponse);
                var postNodes = jsonNode["data"]["user"]["posts"]["nodes"];

                if (postNodes != null)
                {
                    // Si todo sale bien, deserializamos y llenamos la lista
                    posts = postNodes.Deserialize<List<PostHeaderDTO>>();
                }
            }
            catch (Exception ex)
            {

            }

            return posts;
        }
      
    }
}
