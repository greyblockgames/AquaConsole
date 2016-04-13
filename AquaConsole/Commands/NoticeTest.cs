using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTool.Commands
{
    class NoticeTest : ICommand
    {
        public string Command
        {
            get
            {
                return "noticetest";
            }
        }

        public string HelpText
        {
            get
            {
                return "Notice Test";
            }
        }

        public void CommandMethod(string p)
        {
            Utility.WriteNotice(p);
        }
    }
}
