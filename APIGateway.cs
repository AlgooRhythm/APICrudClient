using APICrudClient.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace APICrudClient
{
    public class APIGateway
    {
        private string url = "https://localhost:7186/api/Home";
        private string urlGetUser = "https://localhost:7186/api/Home/GetUsers/";

        private HttpClient httpClient = new HttpClient();

        public List<user> ListUsers(bool IsActiveUserOnly = false)
        {
            url = urlGetUser + IsActiveUserOnly.ToString().ToLower();

            List<user> users = new List<user>();
            if(url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                
                if(response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<List<user>>(result);

                    if (datacol != null)
                        users = datacol;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the Endpoint, Error Info " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured at the Endpoint, Error Info " + ex.Message);
            }
            finally { }

            return users;
        }

        public user CreateUsers(user users)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string json = JsonConvert.SerializeObject(users);
            try
            {
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<user>(result);

                    if (data != null)
                        users = data;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the Endpoint, Error Info " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured at the Endpoint, Error Info " + ex.Message);
            }
            finally { }

            return users;
        }

        public user GetUser(int id)
        {
            user users = new user();
            url = url + "/" + id;

            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if(response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<user>(result);
                    if (data != null)
                        users = data;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the API Endpoint, Error Info " + result);
                }
            }
            catch(Exception ex) 
            {
                throw new Exception("Error Occured at the API Endpoint, Error Info " + ex.Message);
            }
            finally{ }

            return users;
        }

        public void UpdateUser(user users)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            int id = users.id;
            url = url + "/" + id;
            string json = JsonConvert.SerializeObject(users);

            try
            {
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the API Endpoint, Error Info " + result);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error Occured at the API Endpoint, Error Info " + ex.Message);
            }
            finally { }

            return;
        }

        public void DeleteUser(int id)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            url = url + "/" + id;

            try
            {
                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;
                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the API Endpoint, Error Info " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured ath the API Endpoint, Error Info" + ex.Message);
            }
            finally { };

            return;
        }
    }
}
