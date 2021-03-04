using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace TeamworkSimulation.Model
{
    public class WindowsUserMessage : IUserMessageService
    {

        public void MessageUser(string caption, string message, UserMessageType userMessageType)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageTypeToMessageImage(userMessageType));
        }

        public UserMessageResult MessageUserWithResult(string caption, string message, UserMessageType userMessageType, UserMessageOption option)
        {
            return (UserMessageResult)MessageBox.Show(message, caption, (MessageBoxButton)option, MessageTypeToMessageImage(userMessageType));
        }

        public static MessageBoxImage MessageTypeToMessageImage(UserMessageType userMessageType)
        {
            switch(userMessageType)
            {
                case UserMessageType.Information:
                    return MessageBoxImage.Information;
                case UserMessageType.Warning:
                    return MessageBoxImage.Warning;
                case UserMessageType.Error:
                    return MessageBoxImage.Error;
                case UserMessageType.Question:
                    return MessageBoxImage.Question;
                default:
                    throw new ArgumentException(nameof(userMessageType));
            }
        }

    }
}
