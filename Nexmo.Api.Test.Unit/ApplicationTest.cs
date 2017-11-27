﻿using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nexmo.Api.Test.Unit
{
    [TestClass]
    public class ApplicationTest : MockedWebTest
    {
        [TestMethod]
        public void should_create_application()
        {
            var appRequest = new ApplicationRequest
            {
                name = "csharptest",
                type = "voice",
                answer_url = "https://abcdefg.ngrok.io/api/voice",
                event_url = "https://abcdefg.ngrok.io/api/voice",
            };

            SetExpect($"{ApiUrl}/v1/applications",
"{\"id\":\"ffffffff-ffff-ffff-ffff-ffffffffffff\",\"name\":\"csharptest\",\"voice\":{\"webhooks\":[{\"endpoint_type\":\"answer_url\",\"endpoint\":\"https://abcdefg.ngrok.io/api/voice\",\"http_method\":\"GET\"},{\"endpoint_type\":\"event_url\",\"endpoint\":\"https://abcdefg.ngrok.io/api/voice\",\"http_method\":\"POST\"}]},\"keys\":{\"public_key\":\"-----BEGIN PUBLIC KEY-----\\nMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwxyBT5FqzibSYK0vB+Gr\\nP+YlyYqsx4lvAmotTwmObZEhTWNAdU0p9hrnNXWX1Gy5O0NDIue40SUhYhJT5r4x\\nugbpNA/1KJauB8VQjetKr9bu697yskz2+EuKa2D9e6N2EMY6PD1tJWmeMmddM1tW\\n2DAXuYo7/xsDWIIA6egCTzyShNvzlKo5081t41xVVsPjsWN887Xp1KYfE0IMGV2j\\n8Nwdtw/MQfP/7Qz7i9VXb7bgx0LEg84dWsnz8u3VZ3IQHlydzPX/2iw7e4pc+k27\\nOU1SkmPn/2JtfFFS2LJpcO/FmdSyNnyHezNPyzNRLVbE0sJJ1tEhxi9GZc1I+Oc4\\ndwIDAQAB\\n-----END PUBLIC KEY-----\\n\",\"private_key\":\"-----BEGIN PRIVATE KEY-----\\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDDHIFPkWrOJtJg\\nrS8H4as/5iXJiqzHiW8Cai1PCY5tkSFNY0B1TSn2Guc1dZfUbLk7Q0Mi57jRJSFi\\nElPmvjG6Buk0D/Uolq4HxVCN60qv1u7r3vKyTPb4S4prYP17o3YQxjo8PW0laZ4y\\nZ10zW1bYMBe5ijv/GwNYggDp6AJPPJKE2/OUqjnTzW3jXFVWw+OxY3zztenUph8T\\nQgwZXaPw3B23D8xB8//tDPuL1VdvtuDHQsSDzh1ayfPy7dVnchAeXJ3M9f/aLDt7\\nilz6Tbs5TVKSY+f/Ym18UVLYsmlw78WZ1LI2fId7M0/LM1EtVsTSwknW0SHGL0Zl\\nzUj45zh3AgMBAAECggEAFP06iJ7p9fkQKwKbwMXNQIes1fm7QjtDJr0vAvB8vXBe\\nPER/7n6EE+vApqwapBP5eJTGTU7PP382kFB3bScAaMo4iSIUVgRLqXNXtJoKGVDO\\nYq/DvQbxjzQVKnMEdyoBAqdIeYAu1IEAWdzBFnbDfhNCYh0q/MkLpZhVVSm2dzkq\\nl+xrEOTyuE48RQxTQqliUYXXlUd5+bjR+oREuYsjt8j9iiK1u6Gv2ztDPeyzupny\\ntCvSlykvAKn/K6xmeO4hapPKUZ7DRthg3I3uPx+mw48GvO28mzhsqXpbDcYI7q82\\nfZgZJ3JKBTRaNnEE8d5llblC5dksMttLgO2EewdXlQKBgQDscfdVVvLYDW3lsPKl\\nAhEmi3ZcWvzDMCGeGLjJEZPfMnc+7rKbCBADQzNMZI/bsWwMJdQCMy2xMaDXr4Ew\\n4TiBdQ7ogpRex9yuJ3miKs3eey6bvpNxV70lj/xvZoSu7oANSFOCMNFUvSWFTPC5\\nNiNGk35g6xklf3WAYLx4bVJcDQKBgQDTP2qL2zQbU/hmQPnq8x/wgGn8T6zQZXbt\\nojyNPTsnIbQhwQzlFM01SzNsF4hVMB8Zz6r+8XHuo3TsDdg6Orx1auIV5lXCWMj/\\n3MW/jy2JabXJyh7BViHFqQjBPHWDrX17TGGsLK/rfOqMRPPgBGTXfVhINaCo7EAh\\nSTPv2x2RkwKBgBQinGpzDhkiA6LUz8UHiQhcRgcVZIMGvUYmWs4cphgSxx7f2uvi\\n4uI0PdEamzmdQVNDgWtyikiVrlnPw1OzSkmT+2IHhLURlhRqniwWMxPoL47pysqT\\nKzNgsKGX/GKdQuBesWXb3Ge399MDO1i6aIShGNkODEUqNoppMoOa47GdAoGAWn3t\\n/F84YQSFgfgPlu/zHKlFvYm788GjQoSe/7ndHxQ2/8ac6X0RsuS18HXcNvHYQMxO\\n6cswDRQEQCJmH/uNQ5c3pj33OruhzskaBMcmsJiSAREOP6/P48ZXM7/cbz3gZPMB\\nXCoAahYmu1PGTI5VTGIrcTNX0UTy689Z6kOo1PUCgYEAjYPkvv4j286XbGHDQyt7\\ngPvbFUPwtYxwk0u/CuZ1scBkVRCMwc8Gic1hL0yB09nvp86cCjNyYcFqa8fTpjom\\n0C7wjZd6zHR4y23U/jVxhdny6lotpgpWKO7DVprjyHQ90yGu+EDq3jDCOjyhdmqP\\n766dkdpKIYoBJOTH9+3r8gc=\\n-----END PRIVATE KEY-----\\n\"},\"_links\":{\"self\":{\"href\":\"/v1/applications/ffffffff-ffff-ffff-ffff-ffffffffffff\"}}}",
$"name={appRequest.name}&type={appRequest.type}&answer_url=https%3a%2f%2fabcdefg.ngrok.io%2fapi%2fvoice&event_url=https%3a%2f%2fabcdefg.ngrok.io%2fapi%2fvoice&api_key={ApiKey}&api_secret={ApiSecret}&");

            var result = Application.Create(appRequest);

            Assert.AreEqual("ffffffff-ffff-ffff-ffff-ffffffffffff", result.id);
        }

        [TestMethod]
        public void should_get_list_of_applications()
        {
            SetExpect($"{ApiUrl}/v1/applications?page_size=10&page_index=0&api_key={ApiKey}&api_secret={ApiSecret}&",
"{\"count\":1,\"page_size\":10,\"page_index\":0,\"_embedded\":{\"applications\":[{\"id\":\"ffffffff-ffff-ffff-ffff-ffffffffffff\",\"name\":\"csharptest\",\"voice\":{\"webhooks\":[{\"endpoint_type\":\"event_url\",\"endpoint\":\"https://abcdefg.ngrok.io/api/voice\",\"http_method\":\"POST\"},{\"endpoint_type\":\"answer_url\",\"endpoint\":\"https://abcdefg.ngrok.io/api/voice\",\"http_method\":\"GET\"}]},\"keys\":{\"public_key\":\"-----BEGIN PUBLIC KEY-----\\nMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwxyBT5FqzibSYK0vB+Gr\\nP+YlyYqsx4lvAmotTwmObZEhTWNAdU0p9hrnNXWX1Gy5O0NDIue40SUhYhJT5r4x\\nugbpNA/1KJauB8VQjetKr9bu697yskz2+EuKa2D9e6N2EMY6PD1tJWmeMmddM1tW\\n2DAXuYo7/xsDWIIA6egCTzyShNvzlKo5081t41xVVsPjsWN887Xp1KYfE0IMGV2j\\n8Nwdtw/MQfP/7Qz7i9VXb7bgx0LEg84dWsnz8u3VZ3IQHlydzPX/2iw7e4pc+k27\\nOU1SkmPn/2JtfFFS2LJpcO/FmdSyNnyHezNPyzNRLVbE0sJJ1tEhxi9GZc1I+Oc4\\ndwIDAQAB\\n-----END PUBLIC KEY-----\\n\"},\"_links\":{\"self\":{\"href\":\"/v1/applications/ffffffff-ffff-ffff-ffff-ffffffffffff\"}}}]},\"_links\":{\"self\":{\"href\":\"/v1/applications?page_size=10\"},\"first\":{\"href\":\"/v1/applications?page_size=10\"},\"last\":{\"href\":\"/v1/applications?page_size=10d&page_index=1\"}}}");

            var results = Application.List();

            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void should_get_application()
        {
            var appId = "ffffffff-ffff-ffff-ffff-ffffffffffff";

            SetExpect($"{ApiUrl}/v1/applications/{appId}?api_key={ApiKey}&api_secret={ApiSecret}&",
"{\"id\":\"ffffffff-ffff-ffff-ffff-ffffffffffff\",\"name\":\"csharptest\",\"voice\":{\"webhooks\":[{\"endpoint_type\":\"answer_url\",\"endpoint\":\"https://abcdefg.ngrok.io/api/voice\",\"http_method\":\"GET\"},{\"endpoint_type\":\"event_url\",\"endpoint\":\"https://abcdefg.ngrok.io/api/voice\",\"http_method\":\"POST\"}]},\"keys\":{\"public_key\":\"-----BEGIN PUBLIC KEY-----\\nMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwxyBT5FqzibSYK0vB+Gr\\nP+YlyYqsx4lvAmotTwmObZEhTWNAdU0p9hrnNXWX1Gy5O0NDIue40SUhYhJT5r4x\\nugbpNA/1KJauB8VQjetKr9bu697yskz2+EuKa2D9e6N2EMY6PD1tJWmeMmddM1tW\\n2DAXuYo7/xsDWIIA6egCTzyShNvzlKo5081t41xVVsPjsWN887Xp1KYfE0IMGV2j\\n8Nwdtw/MQfP/7Qz7i9VXb7bgx0LEg84dWsnz8u3VZ3IQHlydzPX/2iw7e4pc+k27\\nOU1SkmPn/2JtfFFS2LJpcO/FmdSyNnyHezNPyzNRLVbE0sJJ1tEhxi9GZc1I+Oc4\\ndwIDAQAB\\n-----END PUBLIC KEY-----\\n\"},\"_links\":{\"self\":{\"href\":\"/v1/applications/ffffffff-ffff-ffff-ffff-ffffffffffff\"}}}");

            var results = Application.List(AppId: appId);

            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void should_update_application()
        {
            var appId = "ffffffff-ffff-ffff-ffff-ffffffffffff";
            var appRequest = new ApplicationRequest
            {
                id = "ffffffff-ffff-ffff-ffff-ffffffffffff",
                name = "woocsharptest",
                type = "voice",
                answer_url = "https://abcdefg.ngrok.io/api/voice",
                event_url = "https://abcdefg.ngrok.io/api/voice",
            };

            // TODO: don't want to introduce UrlEncode dependency, but URLs are hardcoded
            SetExpect($"{ApiUrl}/v1/applications/{appId}?id={appId}&name={appRequest.name}&type={appRequest.type}&answer_url=https%3a%2f%2fabcdefg.ngrok.io%2fapi%2fvoice&event_url=https%3a%2f%2fabcdefg.ngrok.io%2fapi%2fvoice&api_key={ApiKey}&api_secret={ApiSecret}&",
"{\"id\":\"ffffffff-ffff-ffff-ffff-ffffffffffff\",\"name\":\"woocsharptest\",\"voice\":{\"webhooks\":[{\"endpoint_type\":\"answer_url\",\"endpoint\":\"https://abcdefg.ngrok.io/api/voice\",\"http_method\":\"GET\"},{\"endpoint_type\":\"event_url\",\"endpoint\":\"https://abcdefg.ngrok.io/api/voice\",\"http_method\":\"POST\"}]},\"keys\":{\"public_key\":\"-----BEGIN PUBLIC KEY-----\\nMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwxyBT5FqzibSYK0vB+Gr\\nP+YlyYqsx4lvAmotTwmObZEhTWNAdU0p9hrnNXWX1Gy5O0NDIue40SUhYhJT5r4x\\nugbpNA/1KJauB8VQjetKr9bu697yskz2+EuKa2D9e6N2EMY6PD1tJWmeMmddM1tW\\n2DAXuYo7/xsDWIIA6egCTzyShNvzlKo5081t41xVVsPjsWN887Xp1KYfE0IMGV2j\\n8Nwdtw/MQfP/7Qz7i9VXb7bgx0LEg84dWsnz8u3VZ3IQHlydzPX/2iw7e4pc+k27\\nOU1SkmPn/2JtfFFS2LJpcO/FmdSyNnyHezNPyzNRLVbE0sJJ1tEhxi9GZc1I+Oc4\\ndwIDAQAB\\n-----END PUBLIC KEY-----\\n\"},\"_links\":{\"self\":{\"href\":\"/v1/applications/ffffffff-ffff-ffff-ffff-ffffffffffff\"}}}");

            var result = Application.Update(appRequest);

            Assert.AreEqual("woocsharptest", result.name);
        }

        [TestMethod]
        public void should_delete_application()
        {
            var appId = "ffffffff-ffff-ffff-ffff-ffffffffffff";

            SetExpect($"{ApiUrl}/v1/applications/{appId}?api_key={ApiKey}&api_secret={ApiSecret}&",
"");
            SetExpectStatus(HttpStatusCode.NoContent);
            var result = Application.Delete(appId);

            Assert.AreEqual(true, result);
        }
    }
}