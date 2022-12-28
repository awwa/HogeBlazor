using System.Globalization;
using System.Reflection;
using HogeBlazor.Client.Helpers;
using HogeBlazor.Client.Repositories;
using HogeBlazor.Client.Services;
using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Pages;
public partial class CarDetail : IDisposable
{
    [Inject]
    public HttpInterceptorService Interceptor { get; set; } = default!;

    public Car Car { get; set; } = new Car
    {
        Body = new Body(),
        Interior = new Interior(),
        Performance = new Performance(),
        Engine = new Engine(),
        MotorX = new Motor(),
        MotorY = new Motor(),
        Battery = new Battery(),
        TireFront = new Tire(),
        TireRear = new Tire(),
        Transmission = new Transmission(),
    };

    public List<KeyValuePair<string, string>> TestValues { get; set; } = new List<KeyValuePair<string, string>>
    {
        new KeyValuePair<string, string>("A", "a"),
        new KeyValuePair<string, string>("B", "b"),
        new KeyValuePair<string, string>("C", "c"),
    };

    public List<KeyValuePair<string, string>> Numbers { get; set; } = new List<KeyValuePair<string, string>>
    {
        new KeyValuePair<string, string>("全長", "4545"),
        new KeyValuePair<string, string>("全幅", "1840"),
        new KeyValuePair<string, string>("全高", "1690"),
        new KeyValuePair<string, string>("ホイールベース", "2700"),
        new KeyValuePair<string, string>("最低地上高", "210"),
    };

    [Parameter]
    public int Id { get; set; }

    [Inject]
    public ICarHttpRepository CarRepo { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {
        Interceptor.RegisterEvent();
        Car = await GetCar(this.Id);
    }

    private async Task<Car> GetCar(int id)
    {
        return await CarRepo.GetCar(id);
    }

    async void ButtonClicked()
    {
        //
        //CultureInfo ci = new CultureInfo("es-MX", false);
        //CultureInfo.CurrentCulture = ci;
        Console.WriteLine(CultureInfo.CurrentCulture.ToString());
        Car = await GetCar(this.Id);
    }

    public void Dispose() => Interceptor.DisposeEvent();
}
