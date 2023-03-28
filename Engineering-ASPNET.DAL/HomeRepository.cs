namespace Engineering_ASPNET.DAL
{
    public class HomeRepository
    {
        public async Task<HelloWorldDto> HelloWorld()
        {
            HttpClient httpClient = new();
            HelloWorldDto helloWorldDto = new HelloWorldDto();
            helloWorldDto.httpResponseMessage = await httpClient.GetStringAsync("http://40.113.119.8:80/HelloWorld");
            return helloWorldDto;
        }
    }
}