
namespace MauiAppMeuCombustivel;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string marca = txt_marca.Text?.Trim() ?? "";
        string modelo = txt_modelo.Text?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(marca) ||
            string.IsNullOrWhiteSpace(modelo))
        {
            await DisplayAlert(
                "Atenção",
                "Informe a marca e o modelo do veículo.",
                "OK");
            return;
        }

        var cultura = System.Globalization.CultureInfo.GetCultureInfo("pt-BR");

        bool etanolValido = double.TryParse(
            txt_etanol.Text,
            System.Globalization.NumberStyles.Number,
            cultura,
            out double etanol);

        bool gasolinaValida = double.TryParse(
            txt_gasolina.Text,
            System.Globalization.NumberStyles.Number,
            cultura,
            out double gasolina);

        if (!etanolValido || !gasolinaValida ||
            etanol <= 0 || gasolina <= 0)
        {
            await DisplayAlert(
                "Atenção",
                "Informe preços válidos e maiores que zero.",
                "OK");
            return;
        }

        string resultado;

        if (etanol / gasolina <= 0.70)
        {
            resultado = $"O etanol está compensando para o seu {marca} {modelo}.";
        }
        else
        {
            resultado = $"A gasolina está compensando para o seu {marca} {modelo}.";
        }

        await DisplayAlert("Resultado", resultado, "OK");
    }
}
