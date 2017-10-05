using Microsoft.AspNetCore.Hosting.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NexmoVoiceASPNetCoreQuickStarts.Helpers
{
    public class NCCOHelpers
    {
        public void CreateTalkNCCO(string rootpath, string callText, string callVoice)
        {
            dynamic TalkNCCO = new JObject();
            TalkNCCO.action = "talk";
            TalkNCCO.text = callText;
            TalkNCCO.voiceName = callVoice;

            SaveFile(rootpath, "TalkNCCO.json", TalkNCCO);
        }

        public void CreateStreamNCCO(string rootpath, string[] streamUrl, int level, bool bargeIn, int loopTimes)
        {
            dynamic StreamNCCO = new JObject();
            StreamNCCO.action = "stream";
            StreamNCCO.streamUrl = new JArray { streamUrl };
            StreamNCCO.level = level;
            StreamNCCO.bargeIn = bargeIn;
            StreamNCCO.loop = loopTimes;

            SaveFile(rootpath, "StreamNCCO.json", StreamNCCO);
        }

        private void SaveFile(string rootpath, string filename, dynamic StreamNCCO)
        {
            var pathToFile = Path.Combine(rootpath, filename);
            using (StreamWriter s = File.CreateText(pathToFile))
            {
                s.Write(StreamNCCO.ToString());
            }
        }
    }
}
