using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using IRepository;
using System.Collections.Generic;
using Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ServiceViber
{
    public class RestViber: IServiceViber
    {
        private RestClient _restClient;
        private ViberUsersContext _db;
        private WeebHookResult _weebHookResult;

        public RestViber()
        {
            _restClient = new RestClient("https://chatapi.viber.com/pa/");
            _db = new ViberUsersContext();
        }        

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _db.Users.ToArrayAsync();
        }

        public async Task SetWebHook()
        {
            var data = new
            {
                url = "https://1005f80041f8.ngrok.io",
                send_name = true,
                send_photo = true,
            };

            _weebHookResult = await Execute<WeebHookResult>("set_webhook", data);
        }

        public async Task RemoveWebHook()
        {
            var data = new
            {
                url = "",
            };

            _weebHookResult = await Execute<WeebHookResult>("set_webhook", data);
        }

        public bool IsRegister()
        {
            return _weebHookResult.Status == 0;
        }

        private async Task<T> Execute<T>(string uri, object data)
        {
            var request = new RestRequest(uri, Method.POST);
            request.AddHeader("X-Viber-Auth-Token", "4d1134e08ea7d15d-d9a2acaefe02186c-eb6213e5892f80a1");
            request.AddJsonBody(data);

            var result = await _restClient.ExecuteAsync(request);

            var r = JsonConvert.DeserializeObject<T>(result.Content);

            return r;
        }

        public async Task AddUser(string data)
        {
            var result = JsonConvert.DeserializeObject<WebHookResponse>(data);

            if (!await _db.Users.AnyAsync(i => i.IdViber == result.User.Id))
            {
                await _db.AddAsync(new User
                {
                    IdViber = result.User.Id,
                    Name = result.User.Name,
                    Country = result.User.Country,
                    Language = result.User.Language,
                });

                _db.SaveChanges();
            }
        }

        public async Task UpdateUser(int Id)
        {           
            var user = await GetUser(Id);
            var result = await GetUserDetails(user.IdViber);

            if (user != null && result.User != null)
            {
                user.DeviceType = result.User.DeviceType;
                _db.Users.Update(user);

                _db.SaveChanges();
            }
            
        }

        private Task<UserDetails> GetUserDetails(string viberId)
        {
            var data = new
            {
                id = viberId,
            };

            return Execute<UserDetails>("get_user_details", data);
        }

        public Task<User> GetUser(int Id)
        {
            return _db.Users.AsNoTracking().Where(i => i.Id == Id).FirstOrDefaultAsync();
        }
    }
}
