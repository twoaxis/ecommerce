﻿using API.EmailSetting;

namespace Core.Interfaces.EmailSetting
{
    public interface IEmailSettings
    {
        public Task SendEmailMessage(Email email);
    }
}