﻿using Nexmo.Api.Request;

namespace Nexmo.Api
{
    public class Client
    {
        private Credentials _credentials;
        public Credentials Credentials
        {
            get => _credentials;
            set
            {
                _credentials = value;
                PropagateCredentials();
            }
        }

        public Client(Credentials creds)
        {
            Credentials = creds;
        }

        private void PropagateCredentials()
        {
            Account = new ClientMethods.Account(Credentials);
            Application = new ClientMethods.Application(Credentials);
            Number = new ClientMethods.Number(Credentials);
            NumberVerify = new ClientMethods.NumberVerify(Credentials);
            Search = new ClientMethods.Search(Credentials);
            ShortCode = new ClientMethods.ShortCode(Credentials);
            SMS = new ClientMethods.SMS(Credentials);
        }

        public ClientMethods.Account Account { get; private set; }
        public ClientMethods.Application Application { get; private set; }
        public ClientMethods.Number Number { get; private set; }
        public ClientMethods.NumberInsight NumberInsight { get; private set; }
        public ClientMethods.NumberVerify NumberVerify { get; private set; }
        public ClientMethods.Search Search { get; private set; }
        public ClientMethods.ShortCode ShortCode { get; private set; }
        public ClientMethods.SMS SMS { get; private set; }
    }
}
