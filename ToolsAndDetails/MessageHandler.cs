using System;

namespace ToolsAndDetailsServer
{
    internal class MessageHandler
    {

        public string Handle(ref Storage storage, string message)
        {
            var messageArray = message.Split();
            var messageSize = messageArray.Length;
            string answer = String.Empty;

            if (messageSize > 0)
            {
                switch (messageArray[0])
                {
                    case "put":
                        try
                        {
                            var item = messageArray[1];
                            var name = messageArray[2];
                            var config = messageArray[3];
                            var year = messageArray[4];
                            string description = null;
                            if (messageSize > 5)
                            {
                                description = messageArray[5];
                            }

                            if (item == "tool")
                            {
                                storage.AddTool(name, config, Int32.Parse(year), description);
                                answer = "Toll added";
                            }
                            else if (item == "detail")
                            {
                                storage.AddDetail(name, Int32.Parse(config), Int32.Parse(year), description);
                                answer = "Detail added";
                            }
                            else
                                answer = "Unknown item didn't add";
                        }
                        catch
                        {
                            answer = "Command \"put\" error";
                        }
                        break;

                    case "get":
                        try
                        {
                            var item = messageArray[1];
                            var name = messageArray[2];
                            string config = null;
                            if (messageSize > 3)
                            {
                                config = messageArray[3];
                            }

                            if (item == "tool")
                            {
                                var tool = storage.GetTool(name, config);
                                if (tool == null)
                                {
                                    answer = $"This {item} doesn't exist";
                                    break;
                                }
                                answer = $"You got {tool}";
                            }
                            else if (item == "detail")
                            {
                                var detail = config == null ? storage.GetDetail(name) : storage.GetDetail(name, Int32.Parse(config));
                                if (detail == null)
                                {
                                    answer = $"This {item} doesn't exist";
                                    break;
                                }
                                answer = $"You got {detail}";
                            }
                            else
                                answer = "Unknown item didn't get";
                        }
                        catch
                        {
                            answer = "Command \"get\" error";
                        }
                        break;

                    case "find":
                        try
                        {
                            var item = messageArray[1];
                            var name = messageArray[2];
                            string config = null;
                            if (messageSize > 3)
                            {
                                config = messageArray[3];
                            }

                            if (item == "tool")
                            {
                                var tools = storage.FindTool(name, config);

                                if (tools.Length == 0)
                                {
                                    answer = $"This {item} doesn't exist";
                                    break;
                                }

                                answer = $"You found";
                                foreach (var tool in tools)
                                {
                                    answer += $"\n{tool}";
                                }
                            }
                            else if (item == "detail")
                            {
                                var details = config == null ? storage.FindDetail(name) : storage.FindDetail(name, Int32.Parse(config));

                                if (details.Length == 0)
                                {
                                    answer = $"This {item} doesn't exist";
                                    break;
                                }

                                answer = $"You found";
                                foreach (var detail in details)
                                {
                                    answer += $"\n{detail}";
                                }
                            }
                            else
                                answer = "Unknown item didn't find";
                        }
                        catch
                        {
                            answer = "Command \"find\" error";
                        }
                        break;

                    case "exit":
                        answer = "exit";
                        break;
                    default:
                        answer = "Unknown command";
                        break;
                }
            }
            return answer;
        }
    }
}