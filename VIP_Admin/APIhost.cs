using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;

namespace VIP_Admin
{
    public class APIhost
    {
        private static APIhost instance;

        private APIhost()
        {
            client.BaseAddress = new Uri("http://localhost:5029/api/");
            options = new JsonSerializerOptions { ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        }
        JsonSerializerOptions options = new JsonSerializerOptions();
        HttpClient client = new HttpClient();
        public static APIhost GetInstance()
        {
            if (instance == null)
                instance = new APIhost();
            return instance;
        }
        public List<Application1> Application1s { get; set; }

        public List<Club> Clubs { get; set; }
              
        public List<Role> Roles { get; set; }
              
        public List<StatusApplication> StatusApplications { get; set; }
               
        public List<TypeOfClub> TypeOfClubs { get; set; }
               
        public List<User> Users { get; set; }
        //мне НЕ ЛЕНЬ СЕЙЧАС РАСПИСЫВАТЬ ВСЕ ЭТИ МЕТОДЫ ИЗ API
        public async Task<List<Club>> GetClubs()
        {
            Clubs= await client.GetFromJsonAsync<List<Club>>("Clubs", options);
            return Clubs;
        }
        public async Task<List<TypeOfClub>> GetTypesOfClubs()
        {
            TypeOfClubs = await client.GetFromJsonAsync<List<TypeOfClub>>("TypeOfClubs", options);
            return TypeOfClubs;
        }
        public async void AuthMe(string login, string password)
        {
            User auth = null;
            try
            {
                auth = await client.GetFromJsonAsync<User>($"Users/Authorize?login={login}&password={password}", options);
            }
            catch (Exception ex) {
                MessageBox.Show($"Пароль? не тот! {ex.Message}");
                }
            if (auth != null)
                AuthorizedUser.GetInstance().AuthUser = auth;
            
          
        }
        public async Task<List<Club>> FilterClubs(TypeOfClub selectedType)
        {
            var req = JsonSerializer.Serialize(selectedType);
            var resp = await client.PostAsync("Clubs/GetFiltredClubs", new StringContent(req, Encoding.UTF8, "application/json"));
            if(resp.StatusCode==System.Net.HttpStatusCode.OK)
            {
                Clubs = await resp.Content.ReadFromJsonAsync<List<Club>>(options);
            }
            return Clubs;
        }
        public async Task<List<Application1>> GetAppls()
        {
            List<Application1> myappls = new List<Application1>();
            try
            {
                
                var resp = await client.GetAsync("Application1/GetAppls");
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    myappls = await resp.Content.ReadFromJsonAsync<List<Application1>>(options);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return myappls;
        }
        //public async Task<List<Club>> GetClubs()
        //{
        //    List <Club> clubs = new List<Club>();    
        //    clubs = await client.GetFromJsonAsync<List<Club>>("Clubs", options);
        //    return clubs;
        //}

        public async Task CreateApples(Application1 NewApplication)
        {
            
            var req = JsonSerializer.Serialize(NewApplication, options);
            var resp = await client.PostAsync("Application1", new StringContent(req, Encoding.UTF8, "application/json"));
            //if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //   string result = await resp.Content.ReadFromJsonAsync<string>(options);
            //}
            string Result;
            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {


                Result = await resp.Content.ReadAsStringAsync();
                MessageBox.Show("Технические шоколадки.. обратитесь к админу!");
                return;
            }
            else
            {
                Result = await resp.Content.ReadAsStringAsync();
                MessageBox.Show("Вы успешно подали заявку!");
            }

        }


        public async Task ReadyAppls(Application1 application)
        {
            //NewMember
            //application.IdClubNavigation = new();
            //application.IdStatusNavigation = new();
            //application.IdTypeNavigation = new();
            Appls appls = new Appls(){Id= application.Id, IdClub = application.IdClub, IdStatus = application.IdStatus, IdType = application.IdType, Image = application.Image, Title = application.Title, Description = application.Description, DateOfFiling = application.DateOfFiling, IdApplicant = application.IdApplicant, User = application.IdApplicantNavigation };
            appls.User.Clubs = new List<Club>();    
            appls.User.Application1s = new List<Application1>();    
            var req = JsonSerializer.Serialize(appls, options);
            var resp = await client.PostAsync("Clubs/NewMember", new StringContent(req, Encoding.UTF8, "application/json"));
            string Result;
            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {


                Result = await resp.Content.ReadAsStringAsync();
                MessageBox.Show("Технические шоколадки.. обратитесь к админу!");
                return;
            }
            else
            {
                Result = await resp.Content.ReadAsStringAsync();
                MessageBox.Show("Вы успешно приняли заявку!");
            }
        }


    }
}
