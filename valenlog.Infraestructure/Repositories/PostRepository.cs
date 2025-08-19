using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
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
    public class PostRepository : IPostRepository
    {
        private readonly ValenlogDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        public PostRepository(ValenlogDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        public Task<List<Post>> GetRelevantPostHeaders()
        {
            return _context.Posts
                .OrderByDescending(p => p.totalReactions)
                .Take(5)
                .ToListAsync();
        }

        public Task<Post?> GetPostByIDAsync(string id)
        {
            return _context.Posts
                .Where(p => p.id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<PostHeaderDTO> GetPostHeaderByIDAsync(string id)
        {
            var httpClient = _httpClientFactory.CreateClient("HashNode");
            var token = "f36dfbe8-f4da-44bf-a8e5-24dbb4517fd0";
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var query = Queries.GetPostHeaderByID;

            var request = new
            {
                query,
                variables = new { id}
            };

            PostHeaderDTO? postHeader = null;

            try
            {
                var response = await httpClient.PostAsJsonAsync("https://gql.hashnode.com/", request);
                response.EnsureSuccessStatusCode();

                // 1. Guardamos el JSON crudo en una variable para que lo puedas inspeccionar
                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Poné un punto de interrupción (breakpoint) en la línea de arriba para ver el contenido de 'jsonResponse'.

                // 2. Intentamos procesar el JSON de forma segura
                var json = System.Text.Json.Nodes.JsonNode.Parse(jsonResponse);
                var selectedPost = json["data"]["post"];

                if (selectedPost != null)
                {
                    // Si todo sale bien, deserializamos y llenamos la lista
                    postHeader = selectedPost.Deserialize<PostHeaderDTO>();
                }
            }
            catch (Exception ex)
            {

            }

            return postHeader;
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

        public Task<bool> RegiserPost(Post post)
        {
            return _context.Posts.AddAsync(post)
                .AsTask() 
                .ContinueWith(t => _context.SaveChangesAsync().Result > 0); 
        }

        public async Task<bool> RegisterViewPostAsync(string id)
        {
            return await _context.Posts
                .Where(p => p.id == id)
                .ExecuteUpdateAsync(p => p.SetProperty(x => x.totalReactions, x => x.totalReactions + 1)) > 0;
        }

        public async Task<content> GetPostConentByIDAsync(string id)
        {
            var httpClient = _httpClientFactory.CreateClient("HashNode");
            var token = "f36dfbe8-f4da-44bf-a8e5-24dbb4517fd0";
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var query = Queries.GetPostContentByID;

            var request = new
            {
                query,
                variables = new { id }
            };

            content? postContent = null;

            var response = await httpClient.PostAsJsonAsync("https://gql.hashnode.com/", request);
            response.EnsureSuccessStatusCode();

            // 1. Guardamos el JSON crudo en una variable para que lo puedas inspeccionar
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // Poné un punto de interrupción (breakpoint) en la línea de arriba para ver el contenido de 'jsonResponse'.

            // 2. Intentamos procesar el JSON de forma segura
            var json = System.Text.Json.Nodes.JsonNode.Parse(jsonResponse);
            var selectedPost = json["data"]["post"]["content"];

            if (selectedPost != null)
            {
                // Si todo sale bien, deserializamos y llenamos la lista
                postContent = selectedPost.Deserialize<content>();
            }

            return postContent;
        }

        public async Task<bool> existPost(string id)
        {
            bool result = false;
            PostHeaderDTO postHeader = await GetPostHeaderByIDAsync(id);
            if (postHeader != null)
            {
                return result = true;
            }
            return result;
        }
    }
}
