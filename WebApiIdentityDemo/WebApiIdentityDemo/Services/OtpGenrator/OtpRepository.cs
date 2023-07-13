namespace WebApiIdentityDemo.Services.OtpGenrator
{
    public class OtpRepository : IOtpRepository
    {
        public int randomNumber()
        {
            Random generator = new Random();
            int r = generator.Next(100000, 1000000);
            return r;
        }
    }
}
