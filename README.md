# DNT.Captcha 

**NT.Captcha** یک کتابخانه سبک و قابل‌اعتماد برای تولید و اعتبارسنجی کپچای عددی در فرم‌های ورود است. این پکیج توسط تیم **[DotNetTime](http://www.dotnettime.ir/)** طراحی شده تا امنیت فرم‌های احراز هویت را با راهکاری ساده، سریع و قابل استفاده در تمام فریم‌ورک‌های دات‌نت افزایش دهد.

ویژگی‌ها:

-   تولید سوال کپچای جمع دو عدد تصادفی
    
-   اعتبارسنجی پاسخ کاربر به صورت امن و قابل تست
    
-   سازگار با ASP.NET Core، MVC، Web Forms، Console و سایر پروژه‌های دات‌نت
    
-   پشتیبانی از نگهداری موقت پاسخ‌ها با `IMemoryCache`
    
-   طراحی فریم‌ورک-اگنستیک و قابل توسعه
    

این پکیج برای توسعه‌دهندگانی طراحی شده که به دنبال راهکاری سریع، قابل‌اعتماد و قابل‌استفاده در پروژه‌های واقعی هستند—با تمرکز بر امنیت فرم‌های ورود و تجربه کاربری ساده.


# مثال استفاده در ASP.NET Core

    // Startup.cs یا Program.cs  
    services.AddMemoryCache();
    services.AddScoped<CaptchaService>();

    // در کنترلر  
    var  captcha = _captchaService.StoreCaptcha("LoginCaptcha"); 
    ViewBag.CaptchaQuestion = captcha.Question;

    // اعتبارسنجی
    bool isValid = _captchaService.ValidateCaptcha("LoginCaptcha", userInput);

 مثال استفاده در Console App

    var  cache = new  MemoryCache(new  MemoryCacheOptions());
    var  captchaService = new  CaptchaService(cache); 
    var  captcha =captchaService.StoreCaptcha("ConsoleCaptcha"); 
    Console.WriteLine(captcha.Question); 
    int  input = int.Parse(Console.ReadLine()); 
    bool  isValid = captchaService.ValidateCaptcha("ConsoleCaptcha", input)
