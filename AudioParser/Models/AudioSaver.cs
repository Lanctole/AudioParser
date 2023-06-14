using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Net;
using System.Security.Policy;

namespace AudioParser.Models
{
    public class AudioSaver
    {
        public AudioSaver(string url,string saveDir) {
            
            string audioSelector = "audio";

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            using (IWebDriver driver = new ChromeDriver(options))
            {
                Directory.CreateDirectory(saveDir);
                driver.Navigate().GoToUrl(url);
                IReadOnlyCollection<IWebElement> audioElements = driver.FindElements(By.CssSelector(audioSelector));
                foreach (IWebElement audioElement in audioElements)
                {
                    string audioUrl = audioElement.GetAttribute("src");
                    WebClient webClient = new WebClient();
                    int lastSlashIndex = audioUrl.LastIndexOf('/');
                    string filename = audioUrl.Substring(lastSlashIndex + 1);
                    if(string.IsNullOrEmpty(audioUrl))
                    {
                        continue;
                    }
                    else
                    {
                       webClient.DownloadFile(audioUrl, saveDir + "/" + filename);
                    }
                    
                }
            }
        }
       
    }
} 


