using System;
using System.Collections.Generic;
using System.Text;

namespace TeamworkSimulation.Model
{
    public interface IUserMessageService
    {

        void MessageUser(string caption, string message, UserMessageType userMessageType);
        UserMessageResult MessageUserWithResult(string caption, string message, UserMessageType userMessageType, UserMessageOption option);

    }
}
