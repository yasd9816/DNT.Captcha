namespace DNT.Captcha
{
    public class CaptchaModel
    {
        public string Question { get; set; } 
        public int Answer { get; set; } 
        public int FirstNumber { get; set; } 
        public int SecondNumber { get; set; } 
    }
}