using System;
using System.Collections.Generic;
using System.Linq;

namespace ToolsAndDetailsServer
{
    public class Storage
    {
        private List<Tool> tools = new List<Tool>();
        private List<Detail> details = new List<Detail>();

        #region Tool Methods
        public void AddTool(string name, string type, int year, string description = null)
        {
            tools.Add(new Tool(name, type, year, description));
        }
        public void AddTool(Tool tool)
        {
            tools.Add(tool);
        }
        public Tool GetTool(string name, string type = null)
        {
            IEnumerable<Tool> result;
            if (type == null)
                result = tools.Where(item => item.Name == name);
            else
                result = tools.Where(item => item.Name == name && item.Type == type);

            var tool = result.FirstOrDefault();
            tools.Remove(tool);

            return tool;
        }

        public Tool[] FindTool(string name, string type = null)
        {
            if (type == null)
                return tools.Where(item => item.Name == name).ToArray();
            return tools.Where(item => item.Name == name && item.Type == type).ToArray();
        }
        #endregion

        #region Detail Methods
        public void AddDetail(string name, int serialNumber, int year, string description = null)
        {
            details.Add(new Detail(name, serialNumber, year, description));
        }
        public void AddDetail(Detail detail)
        {
            details.Add(detail);
        }
        public Detail GetDetail(string name, int? serialNumber = null)
        {
            IEnumerable<Detail> result;
            if (serialNumber == null)
                result = details.Where(item => item.Name == name);
            else
                result = details.Where(item => item.Name == name && item.SerialNumber == serialNumber);

            var detail = result.FirstOrDefault();
            details.Remove(detail);

            return detail;
        }

        public Detail[] FindDetail(string name, int? serialNumber = null)
        {
            if (serialNumber == null)
                return details.Where(item => item.Name == name).ToArray();
            return details.Where(item => item.Name == name && item.SerialNumber == serialNumber).ToArray();
        }
        #endregion
    }
}
