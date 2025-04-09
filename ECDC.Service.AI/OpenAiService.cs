using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ECDC.Service.AI
{
    public class OpenAiService
    {
        private readonly string _apiKey;
        private readonly string _endpoint;
        private readonly string _name;

        public OpenAiService(string apiKey, string endpoint, string name)
        {
            _apiKey = apiKey;
            _endpoint = endpoint;
            _name = name;
        }

        public async Task<string> SendToModel(string text, string systemPrompt, double temp, int maxTokens, double topP)
        {

            var payload = new
            {
                messages = new object[]
                {
                    new {
                        role = "system",
                        content = new object[] {
                            new {
                                type = "text",
                                text = systemPrompt
                            }
                        }
                    },
                    new {
                        role = "user",
                        content = new object[] {
                            new {
                                type = "text",
                                text = text
                            }
                        }
                    }
                },
                temperature = temp,
                top_p = topP,
                max_tokens = maxTokens,
                stream = false,
                model = _name,
            };
            var responseData = await SendToModelAsync(payload);
            return responseData;

        }

        public async Task<string> SendToModel(dynamic payload )
        {               
            var responseData = await SendToModelAsync(payload);                    
            return responseData.output;
        }

        private async Task<string> SendToModelAsync(dynamic payload)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("api-key", _apiKey);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);


                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                httpClient.Timeout = TimeSpan.FromMinutes(2);

                var jsonPayLoad = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayLoad, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(_endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                    return responseData?.choices[0]?.message?.content;
                }
                else
                {
                    try
                    {
                        var responseData = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                        return responseData?.error?.message;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }                
            }
        }

        // Keep track of the conversation messages (system, user, assistant)
        private List<Dictionary<string, string>> conversationMessages
            = new List<Dictionary<string, string>>()
            {
                // You can add an initial 'system' message to define the AI’s role
                new Dictionary<string, string>
                {
                    { "role", "system" },
                    { "content", "You are a helpful assistant." }
                }
            };

        public void AddContextToChat(string context)
        {
            conversationMessages.Add(new Dictionary<string, string>
            {
                { "role", "system" },
                { "content", context }
            });
        }

        public async Task<string> SendChatAsync(string userInput, double temp, int maxTokens, double topP)
        {


            userInput = userInput.Trim();
            if (string.IsNullOrEmpty(userInput)) 
                return null;

            // 2. Add the user message to the conversation
            conversationMessages.Add(new Dictionary<string, string>
            {
                { "role", "user" },
                { "content", userInput }
            });

            // 3. Build the JSON body for the request
            var requestBody = new
            {
                messages = conversationMessages,
                n = 1,
                top_p = topP,
                max_tokens = maxTokens,
                temperature = temp,
                model = _name,
            };

            var responseData = await SendToModelAsync(requestBody);

            //dynamic parsedJson = JsonConvert.DeserializeObject(responseData);
            string assistantReply = responseData;

            // Add assistant reply to conversation
            conversationMessages.Add(new Dictionary<string, string>
                {
                    { "role", "assistant" },
                    { "content", assistantReply }
                });

            return assistantReply;               

        }
    }
}
