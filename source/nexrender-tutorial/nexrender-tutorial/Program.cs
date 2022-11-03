using System.Diagnostics;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using nexrender_tutorial;
using nexrender_tutorial.Models;

namespace nexrender
{
    public class Program
    {
        private static Random rnd = new Random();
        private static List<UserStatisticsDataModel> _userStatisticsData = new List<UserStatisticsDataModel>();
        private static List<NexrenderDataModel> _nexrenderDataModel = new List<NexrenderDataModel>();
        static void Main(string[] args)
        {
            GenerateData();
            PrepareData();
            RenderVideos();
        }

        static void PrepareData()
        {
            foreach (var user in _userStatisticsData)
            {
                _nexrenderDataModel.Add(new NexrenderDataModel
                {
                    template = new Template
                    {
                        src = @"file:///d:/nexrender_ae_rendering/AE template/main.aep",
                        composition = "Comp 1"
                    },
                    assets = new List<Assets>
                    {
                        new Assets
                        {
                            type = "data",
                            layerName = "Username", 
                            property = "Source Text",
                            value = $"{user.Username}"
                        },
                        new Assets
                        {
                            type = "data",
                            layerName = "Darkmode",
                            property = "Source Text",
                            value = $"{user.Darkmode}"
                        },
                        new Assets
                        {
                            type = "data",
                            layerName = "Headline",
                            property = "Source Text",
                            value = $"{user.Headlines}"
                        },
                        new Assets
                        {
                            type = "data",
                            layerName = "Subline",
                            property = "Source Text",
                            value = $"{user.Sublines}"
                        },                       
                        new Assets
                        {
                             src = $"{user.Images}",
                             type = "image",
                             layerName = "background.jpg"
                        }
                    },
                    actions = new Actions()
                    {
                        postrender = new List<PostRender>
                        {
                            new PostRender
                            {
                                module = "@nexrender/action-encode",
                                preset = "mp4",
                                output = $"{user.Username}.mp4"
                            },
                            new PostRender
                            {
                                module = "@nexrender/action-copy",
                                input = $"{user.Username}.mp4",
                                output = $"D:/nexrender_ae_rendering/rendered/{user.Username}.mp4"
                            }
                        }
                    }
                });
            }
        }

        static void RenderVideos()
        {
            for (int video = 0; video < _nexrenderDataModel.Count; video++)
            {
                var task = Task.Run(() => StartNexrender(video));
                task.Wait();
            }
        }
        static void StartNexrender(int video)
        {
            string binary = "--binary=@\"C:/Program Files\\Adobe\\Adobe After Effects 2023\\Support Files\\aerender.exe\"";
            System.IO.File.WriteAllText(@"D:\\nexrender_ae_rendering\nexrender\main.json", JsonConvert.SerializeObject(_nexrenderDataModel[video]));
            var proc = System.Diagnostics.Process.Start(
                @"D:\nexrender_ae_rendering\nexrender\nexrender-cli-win64.exe",
                $"--file D:/nexrender_ae_rendering/nexrender/main.json {binary}");
            proc.WaitForExit();
        }
        static void GenerateData()
        {
            var countUsers = 7;
            for (int userId = 1; userId < countUsers + 1; userId++)
            {
                int index = userId -1;
                _userStatisticsData.Add(new UserStatisticsDataModel
                {
                    Darkmode = $"{rnd.Next(1, 3)}",
                    Headlines = $"{Util._headlines[index]}",
                    Sublines = $"{Util._sublines[index]}",
                    Images = $"{Util._days[index]}",
                    Username = $"promo_{userId}"

                });
            }
        }
    }
}