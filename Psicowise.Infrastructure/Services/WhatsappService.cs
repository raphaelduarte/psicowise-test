using System.Net;
using Microsoft.Extensions.Configuration;
using Psicowise.Domain.Commands;
using Psicowise.Domain.Services;
using System.Net.Http;
using System.Text;
using System.Text.Json;
namespace Psicowise.Infrastructure.Services;

public class WhatsappService : IWhatsappService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public WhatsappService(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
    }

    public async Task<GenericCommandResult> CriarInstanciaWhatsapp(string instanceName, string token, bool qrCode)
    {
        try
        {
            var url = $"{_configuration["EvolutionApi:Url"]}/instance/create";
            var payload = new
            {
                instanceName,
                token,
                qrCode
            };

            var response = await _httpClient.PostAsync(url, new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();

            return new GenericCommandResult(response.IsSuccessStatusCode, "Instancia do Whatsapp criada com sucesso", result);
        }
        catch (Exception e)
        {
            return new GenericCommandResult(false, "Exceção ao criar instâncias", e.Message);
        }
    }

    public async Task<GenericCommandResult> GetAllInstancias(string instanceName)
    {
        try
        {
            var url = $"{_configuration["EvolutionApi:Url"]}/instance/fetchInstances";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return new GenericCommandResult(true, "Instâncias obtidas com sucesso", result);
            }
            else
            {
                var errorResult = await response.Content.ReadAsStringAsync();
                return new GenericCommandResult(false, "Erro ao obter instâncias", errorResult);
            }
        }
        catch (Exception ex)
        {
            return new GenericCommandResult(false, "Exceção ao obter instâncias", ex.Message);
        }
    }

    public async Task<GenericCommandResult> GetInstancia(string instanceName)
    {
        try
        {
            var url = $"{_configuration["EvolutionApi:Url"]}/instance/connect/{instanceName}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Instance-Name", instanceName);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return new GenericCommandResult(true, "Instâncias obtidas com sucesso", result);
            }
            else
            {
                var errorResult = await response.Content.ReadAsStringAsync();
                return new GenericCommandResult(false, "Erro ao obter instâncias", errorResult);
            }
        }
        catch (Exception ex)
        {
            return new GenericCommandResult(false, "Exceção ao obter instância", ex.Message);
        }
    }

    public async Task<GenericCommandResult> RestartInstancia(string instanceName)
    {
        try
        {
            var url = $"{_configuration["EvolutionApi:Url"]}/instance/restart/{instanceName}";
            var response = await _httpClient.PostAsync(url, null);
            var result = await response.Content.ReadAsStringAsync();

            return new GenericCommandResult(response.IsSuccessStatusCode, result, null);
        }
        catch (Exception e)
        {
            return new GenericCommandResult(false, "Exceção ao dar restart na instância", e.Message);
        }
    }

    public async Task<GenericCommandResult> GetStateInstancia(string instanceName)
    {
        try
        {

            var url = $"{_configuration["EvolutionApi:Url"]}/instance/connectionState/{instanceName}";
            var response = await _httpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            return new GenericCommandResult(response.IsSuccessStatusCode, result, null);
        }
        catch (Exception e)
        {
            return new GenericCommandResult(false, "Exceção ao obter estado da instância", e.Message);
        }
    }

    public async Task<GenericCommandResult> LogoutInstancia(string instanceName)
    {
        try
        {
            var url = $"{_configuration["EvolutionApi:Url"]}/instance/logout/{instanceName}";
            var response = await _httpClient.PostAsync(url, null);
            var result = await response.Content.ReadAsStringAsync();

            return new GenericCommandResult(response.IsSuccessStatusCode, result, null);
        }
        catch (Exception e)
        {
            return new GenericCommandResult(false, "Error ao fazer logout da instância", e.Message);
        }
    }

    public async Task<GenericCommandResult> RemoveInstancia(string instanceName)
    {
        try
        {
            var url = $"{_configuration["EvolutionApi:Url"]}/instance/delete/{instanceName}";
            var response = await _httpClient.DeleteAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            return new GenericCommandResult(response.IsSuccessStatusCode, result, null);
        }
        catch (Exception e)
        {
            return new GenericCommandResult(false, "Error ao remover instância", e.Message);
        }
    }

    public async Task<GenericCommandResult> SendTextMessage(string instanceName, string number, string message)
    {
        try
        {
            var url = $"{_configuration["EvolutionApi:Url"]}/message/sendText/{instanceName}";
            var payload = new
            {
                number,
                message
            };

            var response = await _httpClient.PostAsync(url, new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();

            return new GenericCommandResult(response.IsSuccessStatusCode, result, null);
        }
        catch (Exception e)
        {
            return new GenericCommandResult(false, "Error ao enviar mensagem de texto", e.Message);
        }
    }

    public async Task<GenericCommandResult> SendImageMessage(string instanceName, string number, string base64, string filename, string caption)
    {
        try
        {
            var url = $"{_configuration["EvolutionApi:Url"]}/message/sendMedia/{instanceName}";
            var payload = new
            {
                number,
                base64,
                filename,
                caption
            };

            var response = await _httpClient.PostAsync(url, new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();

            return new GenericCommandResult(response.IsSuccessStatusCode, result, null);
        }
        catch (Exception e)
        {
            return new GenericCommandResult(false, "Erro ao enviar mensagem de imagem", e.Message);
        }
    }

    public async Task<GenericCommandResult> SendAudioMessage(string instanceName, string number, string base64, string filename, string caption)
    {
        try
        {
            var url = $"{_configuration["EvolutionApi:Url"]}/message/sendWhatsAppAudio/{instanceName}/sendAudio";
            var payload = new
            {
                number,
                base64,
                filename,
                caption
            };

            var response = await _httpClient.PostAsync(url, new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();

            return new GenericCommandResult(response.IsSuccessStatusCode, result, null);
        }
        catch (Exception e)
        {
            return new GenericCommandResult(false, "Erro ao enviar mensagem de áudio", e.Message);
        }
    }

    public async Task<GenericCommandResult> SendLocation(string instanceName, string number, string lat, string lng, string name, string address)
    {
        try
        {
            var url = $"{_configuration["EvolutionApi:Url"]}/message/sendLocation/{instanceName}";
            var payload = new
            {
                number,
                lat,
                lng,
                name,
                address
            };

            var response = await _httpClient.PostAsync(url, new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();

            return new GenericCommandResult(response.IsSuccessStatusCode, result, null);
        }
        catch (Exception e)
        {
            return new GenericCommandResult(false, "Erro ao enviar localização", e.Message);
        }
    }

    public async Task<GenericCommandResult> SendContact(string instanceName, string number, string contactName, string contactNumber)
    {
        try
        {
            var url = $"{_configuration["EvolutionApi:Url"]}/message/sendContact/{instanceName}";
            var payload = new
            {
                number,
                contactName,
                contactNumber
            };

            var response = await _httpClient.PostAsync(url, new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));
            var result = await response.Content.ReadAsStringAsync();

            return new GenericCommandResult(response.IsSuccessStatusCode, result, null);
        }
        catch (Exception e)
        {
            return new GenericCommandResult(false, "Erro ao enviar contato", e.Message);
        }
    }
}