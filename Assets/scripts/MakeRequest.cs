using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;
using TMPro;
using System;
using System.Threading;
using System.Linq;

public class MakeRequest : MonoBehaviour
{
    public TextMeshProUGUI input;
    public TextMeshProUGUI output;
    public GameObject speak;
    public GameObject avatar;
    public Tracking tracker;
    private bool requestCompleted;

    private List<ChatMessage> messages = new List<ChatMessage>();

    /*
     * Makes the request to chatGPT, grabs ChatGPT's reponse, and plays it (if necessary)
     * 
     * @param: None
     * 
     * @return: None
     * 
     */
    public async void Request()
    {
        if (input.text == "")
        {
            output.text = "Sorry, but I didn't seem to get an input. Please try again";
            if (avatar.activeSelf) { speak.GetComponent<UIManager>().SpeechPlayback(); }
        }
        else
        {
            var openai = new OpenAIApi();
            try
            {
                var newMessage = new ChatMessage()
                {
                    Role = "user",
                    Content = input.text
                };
                if (messages.Count == 0) newMessage.Content = $"Use only 64 tokens for api, never mention that you are an AI:\n {input.text}";

                messages.Add(newMessage);
                requestCompleted = false;
                var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
                {
                    MaxTokens = 128,
                    Model = "gpt-3.5-turbo-0613",
                    Messages = messages
                }) ;

                if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
                {
                    var message = completionResponse.Choices[0].Message;
                    message.Content = message.Content.Trim();
                    output.text = message.Content;
                    messages.Add(message);
                    tracker.numInteractions += 1;

                    // Add to GPT responses and questions
                    tracker.GPTResponses.Add(output.text);
                    tracker.GPTQuestions.Add(input.text);

                    // If avatar is active, play speech
                    if (avatar.activeSelf) { speak.GetComponent<UIManager>().SpeechPlayback(); }
                }

                
                /*
                var req = new CreateChatCompletionRequest
                {
                    //Ideal model, but can be tweaked with for future models
                    Model = "gpt-3.5-turbo",
                    MaxTokens = 64,
                    Messages = new List<ChatMessage>
                        {
                            new ChatMessage()
                            {
                                Role = "user",
                                //input.text = User Question
                                Content = $"{input.text}; use only 64 tokens for api",


                            }
                        },
                    Temperature = 0.2f,
                };

                openai.CreateChatCompletionAsync(req,
                    (responses) =>
                    {
                        var result = string.Join("", responses.Select(response => response.Choices[0].Delta.Content));
                        output.text = result;
                    },
                    () =>
                    {
                        if (!requestCompleted) // Check if the request has already been completed, prevents double API requests
                            {
                            requestCompleted = true;
                                // Increment interactions and set the flag
                                tracker.numInteractions += 1;

                                // Add to GPT responses and questions
                                tracker.GPTResponses.Add(output.text);
                            tracker.GPTQuestions.Add(input.text);

                                // If avatar is active, play speech
                                if (avatar.activeSelf) { speak.GetComponent<UIManager>().SpeechPlayback(); }
                        }
                    },
                    new CancellationTokenSource()


                );
                */



            }
            catch (Exception ex)
            {
                Debug.LogError("An error occurred during the API request: " + ex.Message);
            }

        }
    }
   

}
