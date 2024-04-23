using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AICodingGame;
using AICodingGame.Helpers.Deserialization;
using AICodingGame.Infrastructure.Services.Models;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildBattleController : MonoBehaviour
{
    public List<RobotDto> RobotList = new();
    
    private void OnEnable()
    {
        using (HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost/") })
        {
            HttpResponseMessage responseMessage = client.GetAsync("api/Robot/get").Result;
            if (responseMessage.StatusCode != HttpStatusCode.OK)
            {
                Debug.LogError("Unable to take robot list. Check server");
                return;
            }

            List<RobotDto> RobotList = responseMessage.Content.ReadAsStringAsync().Result.JsonToRobotDTO();
            
            var robotContainer = GameObject.FindGameObjectWithTag(ObjectsTags.RobotContainerMenu).GetComponent<RobotList>();
            foreach (var robot in RobotList)
            {
                if (robotContainer.GetChilds()
                        .FirstOrDefault(obj => obj.GetComponentInChildren<TextMeshProUGUI>().text == robot.Name) == null)
                    robotContainer.Add(robot.Name);
            }
        }
    }

    public void OnBattleStart()
    {
        if (RobotList.Count > 1)
        {
            BattleDTO battle = new BattleDTO()
            {
                Members = RobotList,
                StartedDateTime = DateTime.Now,
                EndDateTime = null
            };
            HttpRequestMessage request = new( HttpMethod.Post, "http://localhost/api/Battle/add" );

            StringContent content = new(JObject.FromObject(battle).ToString()); 
            request.Content = content;

            HttpResponseMessage responseMessage = new HttpClient().SendAsync(request).Result;
            
            if (responseMessage.StatusCode == HttpStatusCode.OK)
                SceneManager.LoadScene("BattleScene", LoadSceneMode.Additive);
        }
    }
}