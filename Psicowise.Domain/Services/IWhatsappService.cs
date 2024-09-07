using Psicowise.Domain.Commands;

namespace Psicowise.Domain.Services;

public interface IWhatsappService
{
    //Instance Controller
    Task<GenericCommandResult> CriarInstanciaWhatsapp(string instanceName, string token, bool qrCode);
    Task<GenericCommandResult> GetAllInstancias(string instanceName);
    Task<GenericCommandResult> GetInstancia(string instanceName);
    Task<GenericCommandResult> RestartInstancia(string instanceName);
    Task<GenericCommandResult> GetStateInstancia(string instanceName);
    Task<GenericCommandResult> LogoutInstancia(string instanceName);
    Task<GenericCommandResult> RemoveInstancia(string instanceName);


    //Send Message Controller
    Task<GenericCommandResult> SendTextMessage(string instanceName, string number, string message);
    Task<GenericCommandResult> SendImageMessage(
        string instanceName, 
        string number, 
        string base64, 
        string filename, 
        string caption
        );

    Task<GenericCommandResult> SendAudioMessage(
        string instanceName,
        string number,
        string base64,
        string filename,
        string caption
        );

    Task<GenericCommandResult> SendLocation(
        string instanceName,
        string number,
        string lat,
        string lng,
        string name,
        string address
    );

    Task<GenericCommandResult> SendContact(
        string instanceName,
        string number,
        string contactName,
        string contactNumber
    );
}