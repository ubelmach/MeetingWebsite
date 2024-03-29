﻿namespace MeetingWebsite.BLL.Infrastructure
{
    public class OperationDetails
    {
        public OperationDetails(bool succeeded, string message, string property)
        {
            Succeeded = succeeded;
            Message = message;
            Property = property;
        }
        public bool Succeeded { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }
    }
}