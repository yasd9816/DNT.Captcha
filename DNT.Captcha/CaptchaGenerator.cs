using System;
using Microsoft.Extensions.Caching.Memory;

namespace DNT.Captcha
{
    public class CaptchaService
    {
        private readonly IMemoryCache _cache;
        private static readonly Random _random = new Random();
        public CaptchaService(IMemoryCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// تولید دو عدد تصادفی و طرح سوال
        /// </summary>
        /// <returns></returns>
        public CaptchaModel GenerateSumCaptcha()
        {
            int a = _random.Next(1, 99);
            int b = _random.Next(1, 99);
            return new CaptchaModel()
            {
                FirstNumber = a,
                SecondNumber = b,
                Answer = a + b,
                Question = $"پاسخ جمع دو عدد {a} + {b} چی میشه؟"
            };
        }
        /// <summary>
        /// مقایسه جواب کاربر و عدد مورد انتظار
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expected"></param>
        /// <returns></returns>
        public bool ValidateCaptcha(int input, int expected)
        {
            return input == expected;
        }
        /// <summary>
        /// دریافت کلید برای کش کردن توسط IMemoryCache به مدت محدود و
        /// </summary>
        /// <param name="key">کلید کش پاسخ</param>
        /// <returns></returns>
        public CaptchaModel StoreCaptcha(string key)
        {
            int a = _random.Next(1, 99);
            int b = _random.Next(1, 99);

            var model = new CaptchaModel()
            {
                FirstNumber = a,
                SecondNumber = b,
                Answer = a + b,
                Question = $"پاسخ جمع دو عدد {a} + {b} چی میشه؟"
            };
            _cache.Set(key, model, TimeSpan.FromMinutes(10));
            return model;
        }

        /// <summary>
        /// مقایسه عدد ورودی و عدد تولید شده با توجه جواب کاربر از مقدار کش شده
        /// </summary>
        /// <param name="key">کلید کش</param>
        /// <param name="input">ورودی کاربر</param>
        /// <returns></returns>
        public bool ValidateCaptcha(string key, int input)
        {
            if (_cache.TryGetValue(key, out CaptchaModel model))
            {
                return input == model.Answer;
            }
            return false;
        }
    }
}