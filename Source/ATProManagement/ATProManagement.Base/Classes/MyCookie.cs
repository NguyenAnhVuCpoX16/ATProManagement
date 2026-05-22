using ATProManagement.Base;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace ATProManagement.Context
{
    public class MyCookie : IMyCookie
    {
        private readonly IJSRuntime _js;

        public MyCookie(IJSRuntime js)
        {
            _js = js;
        }

        public async Task Clear()
        {
            await _js.InvokeVoidAsync("cookieHelper.clearCookies");
        }

        public async Task<bool> Exist(string key)
        {
            var value = await Get<object>(key);
            return value != null;
        }

        public async Task<T?> Get<T>(string key)
        {
            var encrypted =
               await _js.InvokeAsync<string>(
                   "cookieHelper.getCookie",
                   key
               );

            if (string.IsNullOrEmpty(encrypted))
                return default;

            try
            {
                var decrypted =
                    AesEncryptionHelper.Decrypt(
                        encrypted
                    );

                return JsonSerializer.Deserialize<T>(
                    decrypted
                );
            }
            catch
            {
                return default;
            }
        }

        public async Task Remove(string key)
        {
            await _js.InvokeVoidAsync("cookieHelper.removeCookie",key);
        }

        public async Task Set(string key, object value, int days = 3)
        {
            var json =
                JsonSerializer.Serialize(value);

            var encrypted =
                AesEncryptionHelper.Encrypt(json);

            await _js.InvokeVoidAsync("cookieHelper.setCookie",key,encrypted,days);
        }
    }
}
